using System;
using System.ComponentModel;
using Core.Domain.Characters;
using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;


namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    public enum TowerShieldMaterial
    {
        Darkwood,
        Dragonhide,
        Wood,
    }


    /// <summary>
    /// A massive shield tall enough to grant full cover.
    /// </summary>
    public sealed class TowerShield : Shield, ITowerShield
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.Paizo.CoreRulebook.TowerShield"/> class.
        /// </summary>
        /// <param name="size">The size of character this shield is intended to be used by.</param>
        /// <param name="material">The dominant material the shield is crafted from.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        public TowerShield(SizeCategory size, TowerShieldMaterial material)
            : base(armorClassBonus:           4,
                   materialInchesOfThickness: InchesOfThicknessScaledBySize(size, 2),
                   materialHitPointsPerInch:  GetHitPointsPerInchOfThicknessForMaterial(material),
                   materialHardness:          GetHardnessForMaterial(material))
        {
            const byte BASE_ARMOR_CHECK_PENALTY = 10;
            const double WOOD_WEIGHT = 45;
            const double WOOD_PRICE = 30;

            INameFragment standardShieldName = new NameFragment("Tower Shield", "http://www.d20pfsrd.com/equipment/armor/shield-tower/");

            switch (material)
            {
                case TowerShieldMaterial.Darkwood:
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
                case TowerShieldMaterial.Dragonhide:
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
                case TowerShieldMaterial.Wood:
                    this.ArmorCheckPenalty = () => this.StandardArmorCheckPenaltyCalculation(BASE_ARMOR_CHECK_PENALTY);
                    this.MundaneMarketPrice = () => StandardMundaneMarketPriceCalculation(MarketValueScaledBySize(size, WOOD_PRICE));
                    this.Weight = () => WeightScaledBySize(size, WOOD_WEIGHT);
                    this.MundaneName = () => new INameFragment[] {
                        standardShieldName
                    };
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
            }
        }


        private static byte GetHardnessForMaterial(TowerShieldMaterial material)
        {
            switch (material)
            {
                case TowerShieldMaterial.Darkwood:   return DarkwoodShield.Hardness;
                case TowerShieldMaterial.Dragonhide: return DragonhideShield.Hardness;
                case TowerShieldMaterial.Wood:       return 5;
                default:
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
            }
        }


        private static byte GetHitPointsPerInchOfThicknessForMaterial(TowerShieldMaterial material)
        {
            switch (material)
            {
                case TowerShieldMaterial.Darkwood:   return DarkwoodShield.HitPointsPerInch;
                case TowerShieldMaterial.Dragonhide: return DragonhideShield.HitPointsPerInch;
                case TowerShieldMaterial.Wood:       return 10;
                default:
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
            }
        }
        #endregion

        #region Properties

        #region Protected
        protected internal override Func<byte> ArmorCheckPenalty { get; }

        protected internal override Func<INameFragment[]> MundaneName { get; }

        protected internal override Func<double> MundaneMarketPrice { get; }

        protected internal override Func<double> Weight { get; }
        #endregion

        #region Public
        public byte MaximumDexterityBonus { get; } = 2;
        #endregion

        #endregion

        #region Public
        /// <summary>
        /// Applies this shield's effects to a character.
        /// </summary>
        /// <param name="character">The character which is receiving the effects of the shield.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public override void ApplyTo(ICharacter character)
        {
            base.ApplyTo(character);
            character.ArmorClass?.MaxKeyAbilityScore?.Add(() => this.MaximumDexterityBonus);
            // TODO: Penalize melee attacks by -2.
        }

        #region Enchantments
        /// <summary>
        /// Adds a magical enhancement bonus to this shield.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when bonus is zero, or greater than five.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when attempting to apply an enchantment twice.</exception>
        new public TowerShield EnchantWithEnhancementBonus(byte bonus)
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
        new public TowerShield EnchantWithAcidResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithAcidResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this shield with Animated.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public TowerShield EnchantWithAnimated()
        {
            base.EnchantWithAnimated();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Arrow Catching.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public TowerShield EnchantWithArrowCatching()
        {
            base.EnchantWithArrowCatching();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Arrow Deflection.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public TowerShield EnchantWithArrowDeflection()
        {
            base.EnchantWithArrowDeflection();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Blinding.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public TowerShield EnchantWithBlinding()
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
        new public TowerShield EnchantWithColdResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public TowerShield EnchantWithElectricityResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public TowerShield EnchantWithFireResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public TowerShield EnchantWithFortification(FortificationType protectionLevel)
        {
            base.EnchantWithFortification(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this shield with Ghost Touch.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public TowerShield EnchantWithGhostTouch()
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
        new public TowerShield EnchantWithSonicResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public TowerShield EnchantWithSpellResistance(SpellResistanceMagnitude spellResistance)
        {
            base.EnchantWithSpellResistance(spellResistance);
            return this;
        }


        /// <summary>
        /// Enchants this shield with Reflecting.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public TowerShield EnchantWithReflecting()
        {
            base.EnchantWithReflecting();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Undead Controlling.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public TowerShield EnchantWithUndeadControlling()
        {
            base.EnchantWithUndeadControlling();
            return this;
        }


        /// <summary>
        /// Enchants this shield with Wild.
        /// </summary>
        /// <returns>This shield.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when this shield does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public TowerShield EnchantWithWild()
        {
            base.EnchantWithWild();
            return this;
        }
        #endregion
        #endregion
    }
}