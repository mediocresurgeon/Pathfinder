using System;
using System.ComponentModel;
using Core.Domain.Characters;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;


namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    /// <summary>
    /// The materials a tower shield can be made from.
    /// </summary>
    public enum TowerShieldMaterial
    {
        /// <summary>
        /// A default material.
        /// </summary>
        Wood,

        /// <summary>
        /// A lightweight wood.
        /// Always masterwork.
        /// Reduces armor check penalty by 2.
        /// </summary>
        Darkwood,
    }


    /// <summary>
    /// A massive shield tall enough to grant full cover.
    /// </summary>
    public sealed class TowerShield : Shield, ITowerShield
    {
        #region Constructor
        private const byte ARMOR_BONUS = 4;
        private const byte BASE_ARMOR_CHECK_PENALTY = 10;
        private const byte INCHES_OF_THICKNESS = 2;
        private const double WOOD_WEIGHT = 45;
        private const double WOOD_PRICE = 30;
        private static INameFragment StandardShieldName { get; } = new NameFragment("Tower Shield", "http://www.d20pfsrd.com/equipment/armor/shield-tower/");


        /// <summary>
        /// Use this constructor when the shield is to be made from Dragonhide.
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.Paizo.CoreRulebook.TowerShield"/> class.
        /// </summary>
        /// <param name="size">The size of character this shield is intended to be used by.</param>
        /// <param name="color">The dominant material the shield is crafted from.</param>
        public TowerShield(SizeCategory size, DragonhideColor color)
            : base(armorClassBonus:           ARMOR_BONUS,
                   materialInchesOfThickness: InchesOfThicknessScaledBySize(size, INCHES_OF_THICKNESS),
                   materialHitPointsPerInch:  Dragonhide.HitPointsPerInch,
                   materialHardness:          Dragonhide.Hardness)
        {
            this.IsMasterwork = true;
            this.MasterworkIsToggleable = false;
            this.ArmorCheckPenalty = () => this.StandardArmorCheckPenaltyCalculation(BASE_ARMOR_CHECK_PENALTY);
            this.MundaneMarketPrice = () => Dragonhide.GetShieldBaseMarketPrice(MarketValueScaledBySize(size, WOOD_PRICE), this.Enchantments, color);
            this.Weight = () => WeightScaledBySize(size, WOOD_WEIGHT);
            this.MundaneName = () => new INameFragment[] {
                new NameFragment($"{ color } Dragonhide", Dragonhide.WebAddress),
                StandardShieldName
            };
            // Tower shields apply a maximum dexterity bonus to AC
            this.OnApplied += (sender, e) => {
                e.Character?.ArmorClass?.MaxKeyAbilityScore?.Add(this.GetMaximumDexterityBonus);
            };
            // Tower shields inflict a -2 penalty to melee attack rolls
            this.OnApplied += (sender, e) => {
                e.Character?.AttackBonuses?.GenericMeleeAttackBonus?.Penalties?.Add(() => 2);
            };
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.Paizo.CoreRulebook.TowerShield"/> class.
        /// </summary>
        /// <param name="size">The size of character this shield is intended to be used by.</param>
        /// <param name="material">The dominant material the shield is crafted from.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        public TowerShield(SizeCategory size, TowerShieldMaterial material)
            : base(armorClassBonus:           ARMOR_BONUS,
                   materialInchesOfThickness: InchesOfThicknessScaledBySize(size, INCHES_OF_THICKNESS),
                   materialHitPointsPerInch:  GetHitPointsPerInchOfThicknessForMaterial(material),
                   materialHardness:          GetHardnessForMaterial(material))
        {
            switch (material)
            {
                case TowerShieldMaterial.Darkwood:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    this.ArmorCheckPenalty = () => Darkwood.GetShieldArmorCheckPenalty(BASE_ARMOR_CHECK_PENALTY);
                    this.MundaneMarketPrice = () => Darkwood.GetShieldBaseMarketValue(MarketValueScaledBySize(size, WOOD_PRICE), this.GetWeight());
                    this.Weight = () => Darkwood.GetWeight(WeightScaledBySize(size, WOOD_WEIGHT));
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Darkwood", Darkwood.WebAddress),
                        StandardShieldName
                    };
                    break;
                case TowerShieldMaterial.Wood:
                    this.ArmorCheckPenalty = () => this.StandardArmorCheckPenaltyCalculation(BASE_ARMOR_CHECK_PENALTY);
                    this.MundaneMarketPrice = () => StandardMundaneMarketPriceCalculation(MarketValueScaledBySize(size, WOOD_PRICE));
                    this.Weight = () => WeightScaledBySize(size, WOOD_WEIGHT);
                    this.MundaneName = () => new INameFragment[] {
                        StandardShieldName
                    };
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
            }
            // Tower shields apply a maximum dexterity bonus to AC
            this.OnApplied += (sender, e) => {
                e.Character?.ArmorClass?.MaxKeyAbilityScore?.Add(this.GetMaximumDexterityBonus);
            };
            // Tower shields inflict a -2 penalty to melee attack rolls
            this.OnApplied += (sender, e) => {
                e.Character?.AttackBonuses?.GenericMeleeAttackBonus?.Penalties?.Add(() => 2);
            };
        }


        private static byte GetHardnessForMaterial(TowerShieldMaterial material)
        {
            switch (material)
            {
                case TowerShieldMaterial.Darkwood: return Darkwood.Hardness;
                case TowerShieldMaterial.Wood:     return     Wood.Hardness;
                default:
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
            }
        }


        private static byte GetHitPointsPerInchOfThicknessForMaterial(TowerShieldMaterial material)
        {
            switch (material)
            {
                case TowerShieldMaterial.Darkwood: return Darkwood.HitPointsPerInch;
                case TowerShieldMaterial.Wood:     return     Wood.HitPointsPerInch;
                default:
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
            }
        }
        #endregion

        #region Properties

        #region Protected
        /// <summary>
        /// The logic which determines the magnitude of the shield's armor check penalty.
        /// </summary>
        protected internal override Func<byte> ArmorCheckPenalty { get; }


        /// <summary>
        /// The logic which determines name of the shield, not including modifications of the shield's name due to enchantments.
        /// </summary>
        protected internal override Func<INameFragment[]> MundaneName { get; }


        /// <summary>
        /// The logic which determines the market price of the shield's physical cost,
        /// including such factors as material, size, and whether or not the shield is masterwork.
        /// </summary>
        protected internal override Func<double> MundaneMarketPrice { get; }


        /// <summary>
        /// The logic which determines the weight of the shield.
        /// </summary>
        protected internal override Func<double> Weight { get; }
        #endregion

        #endregion

        #region Public
        /// <summary>
        /// Returns the mx dex bonus of this tower shield.
        /// </summary>
        public byte GetMaximumDexterityBonus() => 2;


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