using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields
{
    public abstract class Shield : Item, IShieldSlot
    {
        #region Backing variables
        private bool _isMasterwork = false;
        private readonly ShieldBonusAggregator _armorClass;
        private readonly ShieldEnchantmentAggregator _enchantments;
        private readonly ShieldHardnessAggregator _hardness;
        private readonly ShieldHitPointAggregator _hitPoints;
        #endregion

        #region Constructor
        internal Shield(byte armorBonus, float materialInchesOfThickness, byte materialHitPointsPerInch, byte materialHardness)
        {
            _armorClass = new ShieldBonusAggregator(armorBonus);
            _enchantments = new ShieldEnchantmentAggregator(this);
            _hardness = new ShieldHardnessAggregator(materialHardness);
            _hitPoints = new ShieldHitPointAggregator(materialInchesOfThickness, materialHitPointsPerInch);
        }


        /// <summary>
        /// Scales a shield's weight based on the shield's size.
        /// </summary>
        /// <returns>The new weight.</returns>
        /// <param name="size">The shield's size.</param>
        /// <param name="mediumWeight">The medium-size weight for a shield of this type.</param>
        protected static double WeightScaledBySize(SizeCategory size, double mediumWeight)
        {
            switch(size)
            {
                case SizeCategory.Small:  return mediumWeight / 2.0;
                case SizeCategory.Medium: return mediumWeight;
                case SizeCategory.Large:  return mediumWeight * 2.0;
                default:
                    throw new NotImplementedException($"Unable to scale weight for { size }.");
            }
        }


        /// <summary>
        /// Scales a shield's thickness based on the shield's size.
        /// </summary>
        /// <returns>The new thickness (in inches).</returns>
        /// <param name="size">The shield's size.</param>
        /// <param name="mediumInchesOfThickness">The thickness of a medium-size shield of this type.</param>
        protected static float InchesOfThicknessScaledBySize(SizeCategory size, float mediumInchesOfThickness)
        {
            switch (size)
            {
                case SizeCategory.Small:  return mediumInchesOfThickness / 2f;
                case SizeCategory.Medium: return mediumInchesOfThickness;
                case SizeCategory.Large:  return mediumInchesOfThickness * 2f;
                default:
                    throw new NotImplementedException($"Unable to scale inches of thickness for { size }.");
            }
        }


        /// <summary>
        /// Markets the size of the value scaled by.
        /// </summary>
        /// <returns>The value scaled by size.</returns>
        /// <param name="size">Size.</param>
        /// <param name="mediumMarketValue">Medium market value.</param>
        protected static double MarketValueScaledBySize(SizeCategory size, double mediumMarketValue)
        {
            switch (size)
            {
                case SizeCategory.Small:  return mediumMarketValue;
                case SizeCategory.Medium: return mediumMarketValue;
                case SizeCategory.Large:  return mediumMarketValue * 2.0;
                default:
                    throw new NotImplementedException($"Unable to scale market value for { size }.");
            }
        }
        #endregion

        #region Properties
        #region Protected
        /// <summary>
        /// The armor check penalty of this. shield.
        /// </summary>
        /// <value>The armor check penalty.</value>
        protected abstract Func<byte> ArmorCheckPenalty { get; }


        /// <summary>
        /// Determines whether or not this shield's masterwork status can be legally toggled.
        /// </summary>
        /// <value><c>true</c> if masterwork is toggleable; otherwise, <c>false</c>.</value>
        protected virtual bool MasterworkIsToggleable { get; set; } = true;


        /// <summary>
        /// Gets the shield's funamental name.
        /// </summary>
        /// <value>The name.</value>
        protected abstract Func<INameFragment[]> MundaneName { get; }


        /// <summary>
        /// The market price for the item, taking into account adjustments for item materials, size, quality, and base price.
        /// Excludes costs from enchantments.
        /// </summary>
        /// <value>The mundane market price.</value>
        protected abstract Func<double> MundaneMarketPrice { get; }
        #endregion

        #region Internal
        internal virtual ShieldBonusAggregator ArmorClass { get => _armorClass; }

        internal virtual ShieldHardnessAggregator Hardness { get => _hardness; }

        internal virtual ShieldHitPointAggregator HitPoints { get => _hitPoints; }

        internal virtual ShieldEnchantmentAggregator Enchantments { get => _enchantments; }
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
        #region Protected
        /// <summary>
        /// This function contains the standard logic for determining the armor check penalty of a shield.
        /// It does not mutate the state of this shield.
        /// By default, use this logic for calculating the armor check penalty of a Shield (Shield.GetArmorCheckPenalty).
        /// </summary>
        /// <returns>The armor check penalty.</returns>
        /// <param name="baseArmorCheckPenalty">The armor check penalty of a standard, non-masterwork version of the shield.</param>
        protected byte StandardArmorCheckPenaltyCalculation(byte baseArmorCheckPenalty)
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
        protected double StandardMundaneMarketPriceCalculation(double sizedBasePrice)
        {
            return this.IsMasterwork ? sizedBasePrice + 150 : sizedBasePrice;
        }
        #endregion

        #region Public
        /// <summary>
        /// Returns the armor check penalty of this Shield, which may be applied to certain skills.
        /// </summary>
        /// <returns>The armor check penalty.</returns>
        public virtual byte GetArmorCheckPenalty() => this.ArmorCheckPenalty();


        /// <summary>
        /// Returns the caster level of this Shield.
        /// </summary>
        /// <value>The caster level.</value>
        public override byte? CasterLevel => this.Enchantments.GetCasterLevel();


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
            runningTotal += this.Enchantments.GetEnchantmentMarketValue();
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
            character.ArmorClass?.ShieldBonuses?.Add(() => this.GetShieldBonus());
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
        #endregion
    }
}