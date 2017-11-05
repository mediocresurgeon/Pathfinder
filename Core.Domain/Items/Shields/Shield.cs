using System;
using Core.Domain.Characters;


namespace Core.Domain.Items.Shields
{
    public abstract class Shield : Item, IShieldSlot
    {
        #region Backing variables
        private bool _isMasterwork = false;
        #endregion

        #region Constructor
        protected Shield(SizeCategory size, float mediumInchesOfThickness)
        {
            this.HitPointsCalculation = () => {
                float exact = this.InchesOfThickness * this.HitPointsPerInch;   // Get exact number of hp
                ushort rounded = Convert.ToUInt16(Math.Floor(exact));           // Round the total down
                return Math.Max(rounded, (ushort)1);                            // Ensures there's always at least 1 hp
            };

            switch (size)
            {
                case SizeCategory.Small:
                    this.InchesOfThickness = mediumInchesOfThickness / 2;
                    this.WeightScaledBySize = (baseWeight) => baseWeight / 2;
                    this.MarketValueScaledBySize = (baseMarketValue) => baseMarketValue;
                    break;
                case SizeCategory.Medium:
                    this.InchesOfThickness = mediumInchesOfThickness;
                    this.WeightScaledBySize = (baseWeight) => baseWeight;
                    this.MarketValueScaledBySize = (baseMarketValue) => baseMarketValue;
                    break;
                case SizeCategory.Large:
                    this.InchesOfThickness = mediumInchesOfThickness * 2;
                    this.WeightScaledBySize = (baseWeight) => baseWeight * 2;
                    this.MarketValueScaledBySize = (baseMarketValue) => baseMarketValue * 2;
                    break;
            }
        }
        #endregion

        #region Hit points
        protected float InchesOfThickness { get; }

        protected abstract byte HitPointsPerInch { get; }

        protected Func<ushort> HitPointsCalculation { get; set; }

        public override ushort GetHitPoints() => this.HitPointsCalculation();
        #endregion

        #region Masterwork
        /// <summary>
        /// Determines whether or not this shield's masterwork status can be legally toggled.
        /// </summary>
        /// <value><c>true</c> if masterwork is toggleable; otherwise, <c>false</c>.</value>
        protected virtual bool MasterworkIsToggleable { get; set; } = true;


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

        #region Weight
        /// <summary>
        /// Scales the weight of a shield by the size category of the shield.
        /// </summary>
        /// <value>The scaled weight of the shield.</value>
        protected Func<double, double> WeightScaledBySize { get; }

        protected abstract Func<double> WeightCalculation { get; }

        public override double Weight
        {
            get => this.WeightCalculation();
        }
        #endregion

        #region Market Price
        protected virtual double StandardMarketPriceCalculation(double basePrice)
        {
            return this.IsMasterwork ? basePrice + 150 : basePrice;
        }
        /// <summary>
        /// Scales the market value of a shield by the size category of the shield.
        /// </summary>
        /// <value>The scaled market value of the shield.</value>
        protected Func<double, double> MarketValueScaledBySize { get; }

        protected abstract Func<double> MarketPriceCalculation { get; }

        public override double GetMarketPrice() => this.MarketPriceCalculation();
        #endregion

        #region Armor Check Penalty
        protected virtual byte StandardArmorCheckPenaltyCalculation(byte baseArmorCheckPenalty)
        {
            if (!this.IsMasterwork)
                return baseArmorCheckPenalty;
            int masterworkArmorCheckPenalty = baseArmorCheckPenalty - 1;
            return masterworkArmorCheckPenalty > 0 ? Convert.ToByte(masterworkArmorCheckPenalty) : (byte)0;
        }

        protected abstract Func<byte> ArmorCheckPenaltyCalculation { get; }

        public virtual byte GetArmorCheckPenalty() => this.ArmorCheckPenaltyCalculation();
        #endregion

        #region Character statistics
        public abstract byte GetShieldBonus();


        public virtual void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            character.ArmorClass?.ShieldBonuses?.Add(() => this.GetShieldBonus());
        }
        #endregion
    }
}