using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.Skills;
using Core.Domain.Items.Aggregators;
using Core.Domain.Items.Enchantments;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields
{
    /// <summary>
    /// A piece of personal armor held in the hand or mounted on the wrist or forearm.
    /// Typically, equipping a shield grants a shield bonus to armor class.
    /// </summary>
    public abstract class Shield : Item, IShieldSlot
    {
        #region Backing variables
        private bool _isMasterwork = false;
        private readonly IArmorClassAggregator _armorClass;
        private readonly IHardnessAggregator _hardness;
        private readonly IHitPointsAggregator _hitPoints;
        private readonly IEnchantmentAggregator<IShieldEnchantment, Shield> _enchantments;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.Shield"/> class.
        /// </summary>
        /// <param name="armorClassBonus">The bonus to armor class that the shield provides.</param>
        /// <param name="materialInchesOfThickness">The thickness of the shield (in inches).  This should account for sizing differences.</param>
        /// <param name="materialHitPointsPerInch">The hitpoints-per-inch of the material this shield is made from.</param>
        /// <param name="materialHardness">The hardness of the material this shield is made from.</param>
        internal Shield(byte armorClassBonus, float materialInchesOfThickness, byte materialHitPointsPerInch, byte materialHardness)
            : this(shieldBonus:  new ArmorClassAggregator(armorClassBonus),
                   hardness:     new HardnessAggregator(materialHardness),
                   hitPoints:    new HitPointsAggregator(() => Convert.ToUInt16(Math.Floor(materialInchesOfThickness * materialHitPointsPerInch))),
                   enchantments: null)
        {
            // Intentionally blank
        }

        /// <summary>
        /// Dependency injection constructor (used for testing).
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.Shield"/> class.
        /// </summary>
        /// <param name="shieldBonus">Tied to the ArmorClass property; cannot be null.</param>
        /// <param name="hardness">Tied to the Hardness property; cannot be null.</param>
        /// <param name="hitPoints">Tied to the HitPoints property; cannot be null.</param>
        /// <param name="enchantments">If this is null, this will assign a new instance of ShieldEnchantmentAggregator to the Enchantments property.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal Shield(IArmorClassAggregator                              shieldBonus,
                        IHardnessAggregator                                hardness,
                        IHitPointsAggregator                               hitPoints,
                        IEnchantmentAggregator<IShieldEnchantment, Shield> enchantments)
        {
            _armorClass = shieldBonus ?? throw new ArgumentNullException(nameof(shieldBonus), "Argument may not be null.");
            _hardness = hardness ?? throw new ArgumentNullException(nameof(hardness), "Argument cannot be null.");
            _hitPoints = hitPoints ?? throw new ArgumentNullException(nameof(hitPoints), "Argument cannot be null.");
            _enchantments = enchantments ?? new ShieldEnchantmentAggregator(this);
            // Adds shields bonus to character's armor class.
            this.OnApplied += (sender, e) => {
                e.Character?.ArmorClass?.ShieldBonuses?.Add(this.GetShieldBonus);
            };
            // Adds armor check penalty to skills
            this.OnApplied += (sender, e) => {
                foreach (var skill in e.Character?.Skills?.GetAllSkills() ?? Enumerable.Empty<ISkill>()) {
                    skill.Penalties?.Add(() => skill.ArmorCheckPenaltyApplies ? this.GetArmorCheckPenalty() : (byte)0);
                }
            };
        }


        /// <summary>
        /// Scales a shield's weight based on the shield's size.
        /// </summary>
        /// <returns>The new weight.</returns>
        /// <param name="size">The shield's size.</param>
        /// <param name="mediumWeight">The medium-size weight for a shield of this type.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        protected static double WeightScaledBySize(SizeCategory size, double mediumWeight)
        {
            switch(size)
            {
                case SizeCategory.Small:  return mediumWeight / 2.0;
                case SizeCategory.Medium: return mediumWeight;
                case SizeCategory.Large:  return mediumWeight * 2.0;
                default:
                    throw new InvalidEnumArgumentException(nameof(size), (int)size, size.GetType());
            }
        }


        /// <summary>
        /// Scales a shield's thickness based on the shield's size.
        /// </summary>
        /// <returns>The new thickness (in inches).</returns>
        /// <param name="size">The shield's size.</param>
        /// <param name="mediumInchesOfThickness">The thickness of a medium-size shield of this type.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        protected static float InchesOfThicknessScaledBySize(SizeCategory size, float mediumInchesOfThickness)
        {
            switch (size)
            {
                case SizeCategory.Small:  return mediumInchesOfThickness / 2f;
                case SizeCategory.Medium: return mediumInchesOfThickness;
                case SizeCategory.Large:  return mediumInchesOfThickness * 2f;
                default:
                    throw new InvalidEnumArgumentException(nameof(size), (int)size, size.GetType());
            }
        }


        /// <summary>
        /// Scales the market value of the shield by size.
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="size">Size.</param>
        /// <param name="mediumMarketValue">Medium market value.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        protected static double MarketValueScaledBySize(SizeCategory size, double mediumMarketValue)
        {
            switch (size)
            {
                case SizeCategory.Small:  return mediumMarketValue;
                case SizeCategory.Medium: return mediumMarketValue;
                case SizeCategory.Large:  return mediumMarketValue * 2.0;
                default:
                    throw new InvalidEnumArgumentException(nameof(size), (int)size, size.GetType());
            }
        }


        /// <summary>
        /// This function contains the standard logic for determining the armor check penalty of a shield.
        /// It does not mutate the state of this shield.
        /// By default, use this logic for calculating the armor check penalty of a Shield (Shield.GetArmorCheckPenalty).
        /// </summary>
        /// <returns>The armor check penalty.</returns>
        /// <param name="baseArmorCheckPenalty">The armor check penalty of a standard, non-masterwork version of the shield.</param>
        protected internal byte StandardArmorCheckPenaltyCalculation(byte baseArmorCheckPenalty)
        {
            if (!this.IsMasterwork)
                return baseArmorCheckPenalty;
            int masterworkArmorCheckPenalty = baseArmorCheckPenalty - 1;
            return masterworkArmorCheckPenalty > 0 ? Convert.ToByte(masterworkArmorCheckPenalty) : (byte)0;
        }


        /// <summary>
        /// A standard function for calculating the mundane market price of a shield.
        /// Adds 150 to the sized price of the shield if the shield is masterwork.
        /// </summary>
        /// <returns>The market price calculation.</returns>
        /// <param name="sizedBasePrice">The base price of the item (taking adjustments for size into account).</param>
        protected internal double StandardMundaneMarketPriceCalculation(double sizedBasePrice)
        {
            return this.IsMasterwork ? sizedBasePrice + 150 : sizedBasePrice;
        }
        #endregion

        #region Properties
        #region Protected
        /// <summary>
        /// The armor check penalty of this Shield.
        /// </summary>
        /// <value>The armor check penalty.</value>
        protected internal abstract Func<byte> ArmorCheckPenalty { get; }


        /// <summary>
        /// Determines whether or not this shield's masterwork status can be legally toggled.
        /// </summary>
        /// <value><c>true</c> if masterwork is toggleable; otherwise, <c>false</c>.</value>
        protected internal virtual bool MasterworkIsToggleable { get; set; } = true;


        /// <summary>
        /// Gets the shield's funamental name.
        /// </summary>
        /// <value>The name.</value>
        protected internal abstract Func<INameFragment[]> MundaneName { get; }


        /// <summary>
        /// The market price for the item, taking into account adjustments for item materials, size, quality, and base price.
        /// Excludes costs from enchantments.
        /// </summary>
        /// <value>The mundane market price.</value>
        protected internal abstract Func<double> MundaneMarketPrice { get; }


        /// <summary>
        /// The weight of the item (in pounds), taking into account adjustments for item materials and size.
        /// </summary>
        /// <value>The weight.</value>
        protected internal abstract Func<double> Weight { get; }
        #endregion

        #region Internal
        /// <summary>
        /// A hook for allowing additional effects to be placed on a character when the effects of this shield are applied.
        /// </summary>
        internal event EventHandler<ApplyToCharacterEventArgs> OnApplied;

        internal virtual IArmorClassAggregator ArmorClass { get => _armorClass; }

        internal virtual IHardnessAggregator Hardness { get => _hardness; }

        internal virtual IHitPointsAggregator HitPoints { get => _hitPoints; }

        internal virtual IEnchantmentAggregator<IShieldEnchantment, Shield> Enchantments { get => _enchantments; }
        #endregion

        #region Public
        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="T:Core.Domain.Items.Shields.Shield"/> is masterwork.
        /// </summary>
        /// <value><c>true</c> if is masterwork; otherwise, <c>false</c>.</value>
        /// <exception cref="System.InvalidOperationException">Thrown when attempting to change whether or not this shield is masterwork and that would place this object in an invalid state.</exception>
        public virtual bool IsMasterwork
        {
            get => _isMasterwork;
            set
            {
                if (value != this.IsMasterwork && !this.MasterworkIsToggleable)
                    throw new InvalidOperationException("This shield's masterwork status cannot be set.");
                _isMasterwork = value;
            }
        }
        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// Returns the weight of this shield (in pounds).
        /// </summary>
        /// <returns>The weight (in pounds).</returns>
        public override double GetWeight() => this.Weight();

        /// <summary>
        /// Returns the armor check penalty of this Shield, which may be applied to certain skills.
        /// </summary>
        /// <returns>The armor check penalty.</returns>
        public virtual byte GetArmorCheckPenalty() => this.ArmorCheckPenalty();


        /// <summary>
        /// Returns the caster level of this Shield.
        /// </summary>
        /// <value>The caster level.</value>
        public override byte? GetCasterLevel() => this.Enchantments.GetCasterLevel();


        /// <summary>
        /// Returns the schools of magic associated with this Shield.
        /// </summary>
        /// <returns>This shield's schools of magic.</returns>
        public override School[] GetSchools() => this.Enchantments.GetSchools();


        /// <summary>
        /// Returns the hardness of this Shield.
        /// </summary>
        /// <returns>The hardness.</returns>
        public override byte GetHardness() => this.Hardness.GetTotal();


        /// <summary>
        /// Returns the hit points of this Shield
        /// </summary>
        /// <returns>The hit points.</returns>
        public override ushort GetHitPoints() => this.HitPoints.GetTotal();


        /// <summary>
        /// Calculates the final market price for this shield.
        /// </summary>
        /// <returns>The market price.</returns>
        public override double GetMarketPrice()
        {
            double runningTotal = this.MundaneMarketPrice();
            runningTotal += this.Enchantments.GetMarketPrice();
            return runningTotal;
        }


        /// <summary>
        /// Returns the magnitude of the Shield bonus applied to a character when this shield is equipped.
        /// </summary>
        /// <returns>The shield bonus.</returns>
        public virtual byte GetShieldBonus() => this.ArmorClass.GetTotal();


        /// <summary>
        /// Applies this shield's effects to a character.
        /// </summary>
        /// <param name="character">The character which is receiving the effects of the shield.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public virtual void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            this.OnApplied?.Invoke(this, new ApplyToCharacterEventArgs(character));
            this.Enchantments.ApplyTo(character);
        }


        /// <summary>
        /// Returns the full name of this Shield.
        /// </summary>
        /// <returns>The name.</returns>
        public override INameFragment[] GetName()
        {
            var (enhancementBonusName, otherEnchantmentNames) = this.Enchantments.GetNames();

            if (null != enhancementBonusName)
            {
                List<INameFragment> name = new List<INameFragment>();
                // Shield has an enhancement bonus. Mention this first.
                name.Add(enhancementBonusName);
                // Shield may have additional enchantments. Mention these second.
                name.AddRange(otherEnchantmentNames);
                // Finally, indicate the material and item type.
                name.AddRange(this.MundaneName());
                return name.ToArray();
            }
            else if (this.MasterworkIsToggleable && this.IsMasterwork)
            {
                List<INameFragment> name = new List<INameFragment>();
                // Shield is masterwork, but not by the nature of its material.
                // Indicate that it is masterwork.
                var firstNameFragment = this.MundaneName()[0];
                INameFragment newNameFragment = new NameFragment($"Masterwork { firstNameFragment.Text }", firstNameFragment.WebAddress);
                name.Add(newNameFragment);
                name.AddRange(this.MundaneName().Skip(1));
                return name.ToArray();
            }
            // Shield is not enchanted, and is masterwork by virtue of its material
            return this.MundaneName();
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Core.Domain.Items.Shields.Shield"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Core.Domain.Items.Shields.Shield"/>.</returns>
        public override string ToString()
        {
            return String.Join(" ", this.GetName().Select(nf => nf.Text));
        }
        #endregion

        #region Enchantments
        /// <summary>
        /// Adds a magical enhancement bonus to this shield.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when bonus is zero, or greater than five.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when attempting to apply an enchantment twice.</exception>
        protected internal virtual void EnchantWithEnhancementBonus(byte bonus)
        {
            if (!this.IsMasterwork)
                throw new InvalidOperationException("Only masterwork items can be enchanted.");
            this.MasterworkIsToggleable = false;
            this.Enchantments.EnchantWith(new EnhancementBonus(bonus));
        }


        /// <summary>
        /// Enchants this shield with Acid Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this shield's enchantment.</param>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithAcidResistance(EnergyResistanceMagnitude protectionLevel)
        {
            this.Enchantments.EnchantWith(new AcidResistance(protectionLevel));
        }


        /// <summary>
        /// Enchants this shield with Cold Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this shield's enchantment.</param>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithColdResistance(EnergyResistanceMagnitude protectionLevel)
        {
            this.Enchantments.EnchantWith(new ColdResistance(protectionLevel));
        }


        /// <summary>
        /// Enchants this shield with Electricity Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this shield's enchantment.</param>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithElectricityResistance(EnergyResistanceMagnitude protectionLevel)
        {
            this.Enchantments.EnchantWith(new ElectricityResistance(protectionLevel));
        }


        /// <summary>
        /// Enchants this shield with Fire Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this shield's enchantment.</param>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithFireResistance(EnergyResistanceMagnitude protectionLevel)
        {
            this.Enchantments.EnchantWith(new FireResistance(protectionLevel));
        }


        /// <summary>
        /// Enchants this shield with Sonic Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this shield's enchantment.</param>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithSonicResistance(EnergyResistanceMagnitude protectionLevel)
        {
            this.Enchantments.EnchantWith(new SonicResistance(protectionLevel));
        }


        /// <summary>
        /// Enchants this shield with Animated.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithAnimated()
        {
            this.Enchantments.EnchantWith(new Animated());
        }


        /// <summary>
        /// Enchants this shield with Arrow Catching.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithArrowCatching()
        {
            this.Enchantments.EnchantWith(new ArrowCatching());
        }


        /// <summary>
        /// Enchants this shield with Arrow Deflection.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithArrowDeflection()
        {
            this.Enchantments.EnchantWith(new ArrowDeflection());
        }


        /// <summary>
        /// Enchants this shield with Blinding.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithBlinding()
        {
            this.Enchantments.EnchantWith(new Blinding());
        }


        /// <summary>
        /// Enchants this shield with Fortification.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithFortification(FortificationType protectionLevel)
        {
            this.Enchantments.EnchantWith(new Fortification(protectionLevel));
        }


        /// <summary>
        /// Enchants this shield with Ghost Touch.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithGhostTouch()
        {
            this.Enchantments.EnchantWith(new GhostTouch());
        }


        /// <summary>
        /// Enchants this shield with Spell Resistance.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the spellResistance argument is a nonstandard value of SpellResistanceMagnitude.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithSpellResistance(SpellResistanceMagnitude spellResistance)
        {
            this.Enchantments.EnchantWith(new SpellResistance(spellResistance));
        }


        /// <summary>
        /// Enchants this shield with Reflecting.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithReflecting()
        {
            this.Enchantments.EnchantWith(new Reflecting());
        }


        /// <summary>
        /// Enchants this shield with Undead Controlling.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithUndeadControlling()
        {
            this.Enchantments.EnchantWith(new UndeadControlling());
        }


        /// <summary>
        /// Enchants this shield with Wild.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithWild()
        {
            this.Enchantments.EnchantWith(new Wild());
        }
        #endregion
    }
}