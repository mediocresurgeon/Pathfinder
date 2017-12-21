using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.Movements;
using Core.Domain.Characters.Skills;
using Core.Domain.Items.Aggregators;
using Core.Domain.Items.Enchantments;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;


namespace Core.Domain.Items.Armor
{
    /// <summary>
    /// A protective covering used to prevent combat damage inflicted by weapons.
    /// Typically, equipped Armor grants an Armor bonus to armor class.
    /// </summary>
    public abstract class Armor : Item, IArmorSlot
    {
        #region Backing variables
        private bool _isMasterwork = false;
        private readonly IArmorClassAggregator _armorClass;
        private readonly IHardnessAggregator _hardness;
        private readonly IHitPointsAggregator _hitPoints;
        private readonly IEnchantmentAggregator<IArmorEnchantment, Armor> _enchantments;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.Armor"/> class.
        /// </summary>
        /// <param name="baseArmorBonus">The base armor bonus.</param>
        /// <param name="materialHardness">The hardness of the dominant material.</param>
        protected internal Armor(byte baseArmorBonus, byte materialHardness)
            : this(armorClass:   new ArmorClassAggregator(baseArmorBonus),
                   hardness:     new HardnessAggregator(materialHardness),
                   hitPoints:    new HitPointsAggregator(() => Convert.ToUInt16(baseArmorBonus * 5)),
                   enchantments: null)
        {
            // Intentionally blank
        }


        /// <summary>
        /// Dependency injection constructor (used for testing).
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.Armor"/> class.
        /// </summary>
        /// <param name="armorClass">Tied to the ArmorClass property; cannot be null.</param>
        /// <param name="hardness">Tied to the Hardness property; cannot be null.</param>
        /// <param name="hitPoints">Tied to the HitPoints property; cannot be null.</param>
        /// <param name="enchantments">If this is null, this will assign a new instance of ArmorEnchantmentAggregator to the Enchantments property.</param>
        internal Armor(IArmorClassAggregator                            armorClass,
                       IHardnessAggregator                              hardness,
                       IHitPointsAggregator                             hitPoints,
                       IEnchantmentAggregator<IArmorEnchantment, Armor> enchantments)
        {
            _armorClass = armorClass ?? throw new ArgumentNullException(nameof(armorClass), "Argument may not be null.");
            _hardness = hardness ?? throw new ArgumentNullException(nameof(hardness), "Argument may not be null.");
            _hitPoints = hitPoints ?? throw new ArgumentNullException(nameof(hitPoints), "Argument may not be null.");
            _enchantments = enchantments ?? new ArmorEnchantmentAggregator(this);
        }


        /// <summary>
        /// Scales an armor's weight based on the armor's size.
        /// </summary>
        /// <returns>The new weight.</returns>
        /// <param name="size">The armor's size.</param>
        /// <param name="mediumWeight">The medium-size weight for armor of this type.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        protected static double WeightScaledBySize(SizeCategory size, double mediumWeight)
        {
            switch (size)
            {
                case SizeCategory.Small:  return mediumWeight / 2.0;
                case SizeCategory.Medium: return mediumWeight;
                case SizeCategory.Large:  return mediumWeight * 2.0;
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
        #endregion

        #region Properties
        #region Protected
        /// <summary>
        /// The armor check penalty of this Armor.
        /// </summary>
        /// <value>The armor check penalty.</value>
        protected internal abstract Func<byte> ArmorCheckPenalty { get; }


        /// <summary>
        /// Determines whether or not this armor's masterwork status can be legally toggled.
        /// </summary>
        /// <value><c>true</c> if masterwork is toggleable; otherwise, <c>false</c>.</value>
        protected internal virtual bool MasterworkIsToggleable { get; set; } = true;


        /// <summary>
        /// Gets the armor's funamental name.
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


        /// <summary>
        /// The magnitude of the speed penalty applied by this armor.
        /// Should be between 0 (no penalty) and 1 (movement is completely impossible).
        /// </summary>
        protected internal abstract float SpeedPenalty { get; }


        /// <summary>
        /// The maximum dexterity bonus allowed by this armor.
        /// If there is no maximum dexterity bonus, this should be Byte.MaxValue.
        /// </summary>
        protected internal abstract Func<byte> MaximumDexterityBonus { get; }
        #endregion

        #region Internal
        internal virtual IArmorClassAggregator ArmorClass { get => _armorClass; }

        internal virtual IHardnessAggregator Hardness { get => _hardness; }

        internal virtual IHitPointsAggregator HitPoints { get => _hitPoints; }

        internal virtual IEnchantmentAggregator<IArmorEnchantment, Armor> Enchantments { get => _enchantments; }
        #endregion

        #region Public
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Core.Domain.Items.Armor.Armor"/> is masterwork.
        /// </summary>
        /// <value><c>true</c> if is masterwork; otherwise, <c>false</c>.</value>
        /// <exception cref="System.InvalidOperationException">Thrown when attempting to change whether or not this shield is masterwork and that would place this object in an invalid state.</exception>
        public bool IsMasterwork
        {
            get => _isMasterwork;
            set
            {
                if (value != this.IsMasterwork && !this.MasterworkIsToggleable)
                    throw new InvalidOperationException("This armor's masterwork status cannot be set.");
                _isMasterwork = value;
            }
        }
        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// This function contains the standard logic for determining the armor check penalty of armor.
        /// It does not mutate the state of this armor.
        /// By default, use this logic for calculating the armor check penalty of an armor (Armor.GetArmorCheckPenalty).
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
        /// A standard function for calculating the mundane market price of armor.
        /// Adds 150 to the sized price of the armor if the armor is masterwork.
        /// </summary>
        /// <returns>The market price calculation.</returns>
        /// <param name="sizedBasePrice">The base price of the item (taking adjustments for size into account).</param>
        protected internal double StandardMundaneMarketPriceCalculation(double sizedBasePrice)
        {
            return this.IsMasterwork ? sizedBasePrice + 150 : sizedBasePrice;
        }


        /// <summary>
        /// Returns the magnitude of the Armor bonus applied to a character when this armor is equipped.
        /// </summary>
        public virtual byte GetArmorBonus() => this.ArmorClass.GetTotal();


        /// <summary>
        /// Returns the hardness of this Armor.
        /// </summary>
        /// <returns>The hardness.</returns>
        public override byte GetHardness() => this.Hardness.GetTotal();


        /// <summary>
        /// Returns the hit points of this Armor.
        /// </summary>
        /// <returns>The hit points.</returns>
        public override ushort GetHitPoints() => this.HitPoints.GetTotal();


        /// <summary>
        /// Returns the caster level of this Shield.
        /// </summary>
        /// <returns>The caster level.</returns>
        public override byte? GetCasterLevel() => this.Enchantments.GetCasterLevel();


        /// <summary>
        /// Returns the schools of magic associated with this Armor.
        /// </summary>
        /// <returns>This armor's schools of magic.</returns>
        public override School[] GetSchools() => this.Enchantments.GetSchools();


        /// <summary>
        /// Returns the armor check penalty of this Armor, which may be applied to certain skills.
        /// </summary>
        /// <returns>The armor check penalty.</returns>
        public virtual byte GetArmorCheckPenalty() => this.ArmorCheckPenalty();


        /// <summary>
        /// Returns the maximum dexterity bonus of this Armor,
        /// which may impose an upper limit to a character's armor class from Dexterity.
        /// </summary>
        public virtual byte GetMaximumDexterityBonus() => this.MaximumDexterityBonus();


        /// <summary>
        /// Returns the weight of this Armor (in pounds).
        /// </summary>
        /// <returns>The weight (in pounds).</returns>
        public override double GetWeight() => this.Weight();


        /// <summary>
        /// Calculates the final market price for this Armor.
        /// </summary>
        /// <returns>The market price (in gp).</returns>
        public override double GetMarketPrice()
        {
            double runningTotal = this.MundaneMarketPrice();
            runningTotal += this.Enchantments.GetMarketPrice();
            return runningTotal;
        }


        /// <summary>
        /// Applies this armor's effects to a character.
        /// </summary>
        /// <param name="character">The character which is receiving the effects of the armor.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public virtual void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            character.ArmorClass?.ArmorBonuses?.Add(() => this.GetArmorBonus());
            character.ArmorClass?.MaxKeyAbilityScore?.Add(() => this.GetMaximumDexterityBonus());
            foreach (var skill in character.Skills?.GetAllSkills() ?? Enumerable.Empty<ISkill>())
            {
                skill.Penalties?.Add(() => skill.ArmorCheckPenaltyApplies ? this.GetArmorCheckPenalty() : (byte)0);
            }
            this.Enchantments.ApplyTo(character);
            foreach (IMovement movement in character.MovementModes?.GetAll() ?? Enumerable.Empty<IMovement>())
            {
                movement.Penalties.Add(() => {
                    if (!movement.BaseSpeed.HasValue)
                        return 0;
                    var finalSpeed = Math.Floor((1f - this.SpeedPenalty) * movement.BaseSpeed.Value);
                    return Convert.ToByte(movement.BaseSpeed.Value - finalSpeed);
                });
            }
        }


        /// <summary>
        /// Returns the name of this Armor.
        /// </summary>
        public override INameFragment[] GetName()
        {
            var (enhancementBonusName, otherEnchantmentNames) = this.Enchantments.GetNames();

            if (null != enhancementBonusName)
            {
                List<INameFragment> name = new List<INameFragment>();
                // Armor has an enhancement bonus. Mention this first.
                name.Add(enhancementBonusName);
                // Armor may have additional enchantments. Mention these second.
                name.AddRange(otherEnchantmentNames);
                // Finally, indicate the material and item type.
                name.AddRange(this.MundaneName());
                return name.ToArray();
            }
            else if (this.MasterworkIsToggleable && this.IsMasterwork)
            {
                List<INameFragment> name = new List<INameFragment>();
                // Armor is masterwork, but not by the nature of its material.
                // Indicate that it is masterwork.
                var firstNameFragment = this.MundaneName()[0];
                INameFragment newNameFragment = new NameFragment($"Masterwork { firstNameFragment.Text }", firstNameFragment.WebAddress);
                name.Add(newNameFragment);
                name.AddRange(this.MundaneName().Skip(1));
                return name.ToArray();
            }
            // Armor is not enchanted, and is masterwork by virtue of its material
            return this.MundaneName();
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Core.Domain.Items.Armor.Armor"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Core.Domain.Items.Armor.Armor"/>.</returns>
        public override string ToString()
        {
            return String.Join(" ", this.GetName().Select(nf => nf.Text));
        }
        #endregion

        #region Enchantments
        /// <summary>
        /// Adds a magical enhancement bonus to this armor.
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
        /// Enchants this armor with Acid Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithAcidResistance(EnergyResistanceMagnitude protectionLevel)
        {
            this.Enchantments.EnchantWith(new AcidResistance(protectionLevel));
        }


        /// <summary>
        /// Enchants this armor with Cold Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithColdResistance(EnergyResistanceMagnitude protectionLevel)
        {
            this.Enchantments.EnchantWith(new ColdResistance(protectionLevel));
        }


        /// <summary>
        /// Enchants this armor with Electricity Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithElectricityResistance(EnergyResistanceMagnitude protectionLevel)
        {
            this.Enchantments.EnchantWith(new ElectricityResistance(protectionLevel));
        }


        /// <summary>
        /// Enchants this armor with Fire Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithFireResistance(EnergyResistanceMagnitude protectionLevel)
        {
            this.Enchantments.EnchantWith(new FireResistance(protectionLevel));
        }


        /// <summary>
        /// Enchants this armor with Sonic Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithSonicResistance(EnergyResistanceMagnitude protectionLevel)
        {
            this.Enchantments.EnchantWith(new SonicResistance(protectionLevel));
        }


        /// <summary>
        /// Enchants this armor with Etherealness.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithEtherealness()
        {
            this.Enchantments.EnchantWith(new Etherealness());
        }


        /// <summary>
        /// Enchants this armor with Fortification.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithFortification(FortificationType protectionLevel)
        {
            this.Enchantments.EnchantWith(new Fortification(protectionLevel));
        }


        /// <summary>
        /// Enchants this armor with Ghost Touch.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithGhostTouch()
        {
            this.Enchantments.EnchantWith(new GhostTouch());
        }


        /// <summary>
        /// Enchants this armor with Glamered.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithGlamered()
        {
            this.Enchantments.EnchantWith(new Glamered());
        }


        /// <summary>
        /// Enchants this armor with Invulnerability.
        /// </summary>
        /// <param name="miracleWasUsed">Indicates whether the Miracle spell was used to create the enchantment.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithInvulnerability(bool miracleWasUsed)
        {
            this.Enchantments.EnchantWith(new Invulnerability(miracleWasUsed));
        }


        /// <summary>
        /// Enchants this armor with Shadow.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        protected internal virtual void EnchantWithShadow(ShadowStrength strength)
        {
            this.Enchantments.EnchantWith(new Shadow(strength));
        }


        /// <summary>
        /// Enchants this armor with Slick.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        protected internal virtual void EnchantWithSlick(SlickStrength slickness)
        {
            this.Enchantments.EnchantWith(new Slick(slickness));
        }


        /// <summary>
        /// Enchants this armor with Spell Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithSpellResistance(SpellResistanceMagnitude protectionLevel)
        {
            this.Enchantments.EnchantWith(new SpellResistance(protectionLevel));
        }


        /// <summary>
        /// Enchants this armor with Undead Controlling.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithUndeadControlling()
        {
            this.Enchantments.EnchantWith(new UndeadControlling());
        }


        /// <summary>
        /// Enchants this armor with Wild.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        protected internal virtual void EnchantWithWild()
        {
            this.Enchantments.EnchantWith(new Wild());
        }
        #endregion
    }
}