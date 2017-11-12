using System;
using Core.Domain.Characters;
using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;

namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    public enum HeavyShieldMaterial
    {
        Darkwood,
        Dragonhide,
        Mithral,
        Wood,
        Steel,
    }


    public sealed class HeavyShield : Shield
    {
        #region Constructor
        public HeavyShield(SizeCategory size, HeavyShieldMaterial material)
            : base(armorBonus: 2,
                   materialInchesOfThickness: InchesOfThicknessScaledBySize(size, GetMediumInchesOfThicknessForMaterial(material)),
                   materialHitPointsPerInch:  GetHitPointsPerInchOfThicknessForMaterial(material),
                   materialHardness:          GetHardnessForMaterial(material))
        {
            const byte baseArmorCheckPenalty = 2;
            const double steelWeight = 15;
            const double steelPrice = 20;
            const double woodWeight = 10;
            const double woodPrice = 7;

            INameFragment standardShieldName = new NameFragment("Heavy Shield", "http://www.d20pfsrd.com/equipment/Armor/shield-heavy-wooden-or-steel");

            switch (material)
            {
                case HeavyShieldMaterial.Darkwood:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    this.ArmorCheckPenalty = () => DarkwoodShield.GetArmorCheckPenalty(baseArmorCheckPenalty);
                    this.MundaneMarketPrice = () => DarkwoodShield.GetBaseMarketValue(MarketValueScaledBySize(size, woodPrice), this.Weight);
                    this.Weight = DarkwoodShield.GetWeight(WeightScaledBySize(size, woodWeight));
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Darkwood", DarkwoodShield.WebAddress),
                        standardShieldName
                    };
                    break;
                case HeavyShieldMaterial.Dragonhide:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    this.ArmorCheckPenalty = () => this.StandardArmorCheckPenaltyCalculation(baseArmorCheckPenalty);
                    this.MundaneMarketPrice = () => DragonhideShield.GetBaseMarketValue(MarketValueScaledBySize(size, woodPrice));
                    this.Weight = WeightScaledBySize(size, woodWeight);
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Dragonhide", DragonhideShield.WebAddress),
                        standardShieldName
                    };
                    break;
                case HeavyShieldMaterial.Mithral:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    this.ArmorCheckPenalty = () => MithralShield.GetArmorCheckPenalty(baseArmorCheckPenalty);
                    this.MundaneMarketPrice = () => MithralShield.GetBaseMarketValue(MarketValueScaledBySize(size, steelPrice));
                    this.Weight = MithralShield.GetWeight(WeightScaledBySize(size, steelWeight));
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Mithral", MithralShield.WebAddress),
                        standardShieldName
                    };
                    break;
                case HeavyShieldMaterial.Steel:
                    this.ArmorCheckPenalty = () => this.StandardArmorCheckPenaltyCalculation(baseArmorCheckPenalty);
                    this.MundaneMarketPrice = () => StandardMundaneMarketPriceCalculation(MarketValueScaledBySize(size, steelPrice));
                    this.Weight = WeightScaledBySize(size, steelWeight);
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Heavy Steel Shield", standardShieldName.WebAddress),
                    };
                    break;
                case HeavyShieldMaterial.Wood:
                    this.ArmorCheckPenalty = () => this.StandardArmorCheckPenaltyCalculation(baseArmorCheckPenalty);
                    this.MundaneMarketPrice = () => StandardMundaneMarketPriceCalculation(MarketValueScaledBySize(size, woodPrice));
                    this.Weight = WeightScaledBySize(size, woodWeight);
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Heavy Wooden Shield", standardShieldName.WebAddress),
                    };
                    break;
            }
        }


        private static byte GetHitPointsPerInchOfThicknessForMaterial(HeavyShieldMaterial material)
        {
            switch (material)
            {
                case HeavyShieldMaterial.Darkwood:   return DarkwoodShield.HitPointsPerInch;
                case HeavyShieldMaterial.Dragonhide: return DragonhideShield.HitPointsPerInch;
                case HeavyShieldMaterial.Mithral:    return MithralShield.HitPointsPerInch;
                case HeavyShieldMaterial.Wood:       return 10;
                case HeavyShieldMaterial.Steel:      return 30;
                default:
                    throw new NotImplementedException($"Unable to determine hardness of Heavy Shield made of { material }.");
            }
        }


        private static byte GetHardnessForMaterial(HeavyShieldMaterial material)
        {
            switch (material)
            {
                case HeavyShieldMaterial.Darkwood:   return DarkwoodShield.Hardness;
                case HeavyShieldMaterial.Dragonhide: return DragonhideShield.Hardness;
                case HeavyShieldMaterial.Mithral:    return MithralShield.Hardness;
                case HeavyShieldMaterial.Wood:       return 5;
                case HeavyShieldMaterial.Steel:      return 10;
                default:
                    throw new NotImplementedException($"Unable to determine hardness of Heavy Shield made of { material }.");
            }
        }


        private static float GetMediumInchesOfThicknessForMaterial(HeavyShieldMaterial material)
        {
            const float woodThickness = 3f / 2f;
            const float metalThickness = 2f / 3f;

            switch (material)
            {
                case HeavyShieldMaterial.Darkwood:   return woodThickness;
                case HeavyShieldMaterial.Dragonhide: return woodThickness;
                case HeavyShieldMaterial.Wood:       return woodThickness;
                case HeavyShieldMaterial.Mithral:    return metalThickness;
                case HeavyShieldMaterial.Steel:      return metalThickness;
                default:
                    throw new NotImplementedException($"Unable to determine medium-size thickness of Heavy Shield made of { material }.");
            }
        }
        #endregion

        #region Properties
        #region Protected
        protected override Func<byte> ArmorCheckPenalty { get; }

        protected override Func<double> MundaneMarketPrice { get; }

        protected override Func<INameFragment[]> MundaneName { get; }
        #endregion

        #region Public
        public override double Weight { get; }
        #endregion
        #endregion

        #region Enchantments
        /// <summary>
        /// Adds a magical enhancement bonus to this shield.
        /// </summary>
        /// <exception cref = "System.ArgumentOutOfRangeException" > Thrown when bonus is zero, or greater than five.</exception>
        /// <exception cref = "System.InvalidOperationException" > Thrown when attempting to apply an enchantment twice.</exception>
        public HeavyShield EnchantWithEnhancementBonus(byte bonus)
        {
            if (!this.IsMasterwork)
                throw new InvalidOperationException("Only masterwork items can be enchanted.");
            this.MasterworkIsToggleable = false;
            this.Enchantments.EnchantWith(new EnhancementBonus(bonus));
            return this;
        }
        #endregion
    }
}