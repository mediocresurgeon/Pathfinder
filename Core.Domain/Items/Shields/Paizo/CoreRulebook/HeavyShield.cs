using System;
using System.ComponentModel;
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


    /// <summary>
    /// A large shield which is strapped to the forearm and gripped in the hand.
    /// </summary>
    public sealed class HeavyShield : Shield
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.Paizo.CoreRulebook.HeavyShield"/> class.
        /// </summary>
        /// <param name="size">The size of character this shield is intended to be used by.</param>
        /// <param name="material">The dominant material the shield is crafted from.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        public HeavyShield(SizeCategory size, HeavyShieldMaterial material)
            : base(armorClassBonus:           2,
                   materialInchesOfThickness: InchesOfThicknessScaledBySize(size, GetMediumInchesOfThicknessForMaterial(material)),
                   materialHitPointsPerInch:  GetHitPointsPerInchOfThicknessForMaterial(material),
                   materialHardness:          GetHardnessForMaterial(material))
        {
            const byte BASE_ARMOR_CHECK_PENALTY = 2;
            const double STEEL_WEIGHT = 15;
            const double STEEL_PRICE = 20;
            const double WOOD_WEIGHT = 10;
            const double WOOD_PRICE = 7;

            INameFragment standardShieldName = new NameFragment("Heavy Shield", "http://www.d20pfsrd.com/equipment/Armor/shield-heavy-wooden-or-steel");

            switch (material)
            {
                case HeavyShieldMaterial.Darkwood:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    this.ArmorCheckPenalty = () => DarkwoodShield.GetArmorCheckPenalty(BASE_ARMOR_CHECK_PENALTY);
                    this.MundaneMarketPrice = () => DarkwoodShield.GetBaseMarketValue(MarketValueScaledBySize(size, WOOD_PRICE), this.GetWeight());
                    this.Weight = () => DarkwoodShield.GetWeight(WeightScaledBySize(size, WOOD_WEIGHT));
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Darkwood", DarkwoodShield.WebAddress),
                        standardShieldName
                    };
                    break;
                case HeavyShieldMaterial.Dragonhide:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    this.ArmorCheckPenalty = () => this.StandardArmorCheckPenaltyCalculation(BASE_ARMOR_CHECK_PENALTY);
                    this.MundaneMarketPrice = () => DragonhideShield.GetBaseMarketValue(MarketValueScaledBySize(size, WOOD_PRICE), this.Enchantments);
                    this.Weight = () => WeightScaledBySize(size, WOOD_WEIGHT);
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Dragonhide", DragonhideShield.WebAddress),
                        standardShieldName
                    };
                    break;
                case HeavyShieldMaterial.Mithral:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    this.ArmorCheckPenalty = () => MithralShield.GetArmorCheckPenalty(BASE_ARMOR_CHECK_PENALTY);
                    this.MundaneMarketPrice = () => MithralShield.GetBaseMarketValue(MarketValueScaledBySize(size, STEEL_PRICE));
                    this.Weight = () => MithralShield.GetWeight(WeightScaledBySize(size, STEEL_WEIGHT));
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Mithral", MithralShield.WebAddress),
                        standardShieldName
                    };
                    break;
                case HeavyShieldMaterial.Steel:
                    this.ArmorCheckPenalty = () => this.StandardArmorCheckPenaltyCalculation(BASE_ARMOR_CHECK_PENALTY);
                    this.MundaneMarketPrice = () => StandardMundaneMarketPriceCalculation(MarketValueScaledBySize(size, STEEL_PRICE));
                    this.Weight = () => WeightScaledBySize(size, STEEL_WEIGHT);
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Heavy Steel Shield", standardShieldName.WebAddress),
                    };
                    break;
                case HeavyShieldMaterial.Wood:
                    this.ArmorCheckPenalty = () => this.StandardArmorCheckPenaltyCalculation(BASE_ARMOR_CHECK_PENALTY);
                    this.MundaneMarketPrice = () => StandardMundaneMarketPriceCalculation(MarketValueScaledBySize(size, WOOD_PRICE));
                    this.Weight = () => WeightScaledBySize(size, WOOD_WEIGHT);
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Heavy Wooden Shield", standardShieldName.WebAddress),
                    };
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
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
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
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
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
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
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
            }
        }
        #endregion

        #region Properties
        protected internal override Func<byte> ArmorCheckPenalty { get; }

        protected internal override Func<double> MundaneMarketPrice { get; }

        protected internal override Func<INameFragment[]> MundaneName { get; }

        protected internal override Func<double> Weight { get; }
        #endregion

        #region Enchantments
        /// <summary>
        /// Adds a magical enhancement bonus to this shield.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when bonus is zero, or greater than five.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when attempting to apply an enchantment twice.</exception>
        new public HeavyShield EnchantWithEnhancementBonus(byte bonus)
        {
            base.EnchantWithEnhancementBonus(bonus);
            return this;
        }


        /// <summary>
        /// Enchants this shield with Acid Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this shield's enchantment.</param>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithAcidResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithAcidResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this shield with Animated.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithAnimated()
        {
            base.EnchantWithAnimated();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Arrow Catching.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithArrowCatching()
        {
            base.EnchantWithArrowCatching();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Arrow Deflection.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithArrowDeflection()
        {
            base.EnchantWithArrowDeflection();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Blinding.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithBlinding()
        {
            base.EnchantWithBlinding();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Cold Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this shield's enchantment.</param>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithColdResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithColdResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this shield with Electricity Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this shield's enchantment.</param>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithElectricityResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithElectricityResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this shield with Fire Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this shield's enchantment.</param>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithFireResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithFireResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this shield with Fortification.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithFortification(FortificationType protectionLevel)
        {
            base.EnchantWithFortification(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this shield with Ghost Touch.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithGhostTouch()
        {
            base.EnchantWithGhostTouch();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Sonic Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this shield's enchantment.</param>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithSonicResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithSonicResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this shield with Spell Resistance.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the spellResistance argument is a nonstandard value of SpellResistanceMagnitude.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithSpellResistance(SpellResistanceMagnitude spellResistance)
        {
            base.EnchantWithSpellResistance(spellResistance);
            return this;
        }


        /// <summary>
        /// Enchants this shield with Reflecting.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithReflecting()
        {
            base.EnchantWithReflecting();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Undead Controlling.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithUndeadControlling()
        {
            base.EnchantWithUndeadControlling();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Wild.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public HeavyShield EnchantWithWild()
        {
            base.EnchantWithWild();
            return this;
        }
        #endregion
    }
}