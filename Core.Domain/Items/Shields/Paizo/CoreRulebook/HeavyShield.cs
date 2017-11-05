using System;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    /// <summary>
    /// The material from which the Heavy Shield is made.
    /// </summary>
    public enum HeavyShieldMaterial
    {
        Darkwood,
        Dragonhide,
        Mithril,
        Wood,
        Steel,
    }

    public sealed class HeavyShield : Shield, IHeavyShield
    {
        #region Backing variables
        private readonly byte _materialHardness;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.Paizo.CoreRulebook.HeavyShield"/> class.
        /// </summary>
        /// <param name="size">The size of character the shield is sized for.</param>
        /// <param name="material">The material the shield is made from.</param>
        public HeavyShield(SizeCategory size, HeavyShieldMaterial material)
            : base(size, GetMediumThickness(material))
        {
            const double steelWeight = 15;
            const double steelPrice = 20;
            const double woodWeight = 10;
            const double woodPrice = 7;
            const byte armorCheckPenalty = 2;

            switch (material)
            {
                case HeavyShieldMaterial.Darkwood:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    _materialHardness = 5;
                    this.HitPointsPerInch = 10;
                    this.WeightCalculation = () => DarkwoodShield.GetWeight(this.WeightScaledBySize(woodWeight));
                    this.MarketPriceCalculation = () => DarkwoodShield.GetBaseMarketValue(this.MarketValueScaledBySize(woodPrice), this.Weight);
                    this.ArmorCheckPenaltyCalculation = () => DarkwoodShield.GetArmorCheckPenalty(armorCheckPenalty);
                    break;
                case HeavyShieldMaterial.Dragonhide:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    _materialHardness = 10;
                    this.HitPointsPerInch = 10;
                    this.WeightCalculation = () => this.WeightScaledBySize(woodWeight);
                    this.MarketPriceCalculation = () => DragonhideShield.GetBaseMarketValue(this.MarketValueScaledBySize(woodPrice));
                    this.ArmorCheckPenaltyCalculation = () => this.StandardArmorCheckPenaltyCalculation(armorCheckPenalty);
                    break;
                case HeavyShieldMaterial.Mithril:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    _materialHardness = 15;
                    this.HitPointsPerInch = 30;
                    this.WeightCalculation = () => MithralShield.GetWeight(this.WeightScaledBySize(steelWeight));
                    this.MarketPriceCalculation = () => MithralShield.GetBaseMarketValue(this.MarketValueScaledBySize(steelPrice));
                    this.ArmorCheckPenaltyCalculation = () => MithralShield.GetArmorCheckPenalty(armorCheckPenalty);
                    break;
                case HeavyShieldMaterial.Steel:
                    _materialHardness = 10;
                    this.HitPointsPerInch = 30;
                    this.WeightCalculation = () => this.WeightScaledBySize(steelWeight);
                    this.MarketPriceCalculation = () => this.StandardMarketPriceCalculation(this.MarketValueScaledBySize(steelPrice));
                    this.ArmorCheckPenaltyCalculation = () => this.StandardArmorCheckPenaltyCalculation(armorCheckPenalty);
                    break;
                case HeavyShieldMaterial.Wood:
                    _materialHardness = 5;
                    this.HitPointsPerInch = 10;
                    this.WeightCalculation = () => this.WeightScaledBySize(woodWeight);
                    this.MarketPriceCalculation = () => this.StandardMarketPriceCalculation(this.MarketValueScaledBySize(woodPrice));
                    this.ArmorCheckPenaltyCalculation = () => this.StandardArmorCheckPenaltyCalculation(armorCheckPenalty);
                    break;
                default:
                    throw new NotImplementedException($"Unable to create a HeavyShield from { material }.");
            }

        }

        /// <summary>
        /// Wood shields have a different thickness from steel shields.
        /// Use this function to determine the medium-sied thickness of the shield.
        /// </summary>
        /// <returns>The medium thickness.</returns>
        /// <param name="material">The shield material.</param>
        private static float GetMediumThickness(HeavyShieldMaterial material)
        {
            float woodThickness = 3f / 2f;
            float steelThickness = 2f / 3f;

            switch (material)
            {
                case HeavyShieldMaterial.Darkwood:   // wood
                    return woodThickness;
                case HeavyShieldMaterial.Dragonhide: // use wood stats, even though it isn't really wood
                    return woodThickness;
                case HeavyShieldMaterial.Wood:       // wood
                    return woodThickness;
                default:                             // assume steel
                    return steelThickness;
            }
        }
        #endregion

        #region Properties
        public override byte? CasterLevel => null;

        protected override byte HitPointsPerInch { get; }

        protected override Func<double> WeightCalculation { get; }

        protected override Func<double> MarketPriceCalculation { get; }

        protected override Func<byte> ArmorCheckPenaltyCalculation { get; }
        #endregion

        #region Methods
        public override byte GetHardness()
        {
            return _materialHardness;
        }


        public override INameFragment[] GetName()
        {
            throw new NotImplementedException();
        }


        public override School[] GetSchools()
        {
            return new School[0];
        }


        public override byte GetShieldBonus()
        {
            return 2;
        }
        #endregion
    }
}