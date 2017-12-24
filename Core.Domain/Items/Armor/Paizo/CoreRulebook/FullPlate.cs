using System;
using System.ComponentModel;
using Core.Domain.Characters;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;


namespace Core.Domain.Items.Armor.Paizo.CoreRulebook
{
    /// <summary>
    /// The materials full plate can be made from.
    /// </summary>
    public enum FullPlateMaterial
    {
        /// <summary>
        /// A default material.
        /// </summary>
        Steel,

        /// <summary>
        /// A rare and extremely hard material.
        /// Always masterwork.
        /// Armor made of Adamantine confers damage reduction upon those wearing it.
        /// </summary>
        Adamantine,

        /// <summary>
        /// A lightweight metal which is harder than steel.
        /// Always masterwork.
        /// Reduces armor check penalty by 3.
        /// </summary>
        Mithral,
    }


    /// <summary>
    /// Heavy armor with a +9 AC bonus, a -6 armor check penalty, and a +1 max dex bonus.
    /// </summary>
    public sealed class FullPlate : Armor, IFullPlate, IHeavyArmor
    {
        #region Constructor
        private const byte BASE_ARMOR_BONUS = 9;
        private const byte ARMOR_CHECK_PENALTY = 6;
        private const byte MAX_DEX_BONUS = 1;
        private const double WEIGHT = 50;
        private const double PRICE = 1500;
        private NameFragment StandardName = new NameFragment("Full Plate", "http://www.d20pfsrd.com/equipment/Armor/full-plate");


        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.FullPlate"/> class.
        /// </summary>
        /// <param name="size">The size of the character intended to wear the armor.</param>
        /// <param name="material">The material the full plate is made from.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        public FullPlate(SizeCategory size, FullPlateMaterial material)
            : base(BASE_ARMOR_BONUS, GetHardnessForMaterial(material))
        {
            switch (material) {
                case FullPlateMaterial.Adamantine:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    this.ArmorCheckPenalty = () => StandardArmorCheckPenaltyCalculation(ARMOR_CHECK_PENALTY);
                    this.MaximumDexterityBonus = () => MAX_DEX_BONUS;
                    this.MundaneMarketPrice = () => Adamantine.GetHeavyArmorBaseMarketPrice(MarketValueScaledBySize(size, PRICE));
                    this.Weight = () => WeightScaledBySize(size, WEIGHT);
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Adamantine", Adamantine.WebAddress),
                        StandardName
                    };
                    var (drMag, drBypass) = Adamantine.GetHeavyArmorDamageReduction();
                    this.OnApplied += (sender, e) => {
                        e.Character?.DamageReduction?.Add(drMag, drBypass);
                    };
                    break;
                case FullPlateMaterial.Mithral:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    this.ArmorCheckPenalty = () => Mithral.GetArmorCheckPenalty(ARMOR_CHECK_PENALTY);
                    this.MaximumDexterityBonus = () => Mithral.GetArmorMaximumDexterityBonus(MAX_DEX_BONUS);
                    this.MundaneMarketPrice = () => Mithral.GetHeavyArmorBaseMarketPrice(MarketValueScaledBySize(size, PRICE));
                    this.Weight = () => Mithral.GetWeight(WeightScaledBySize(size, WEIGHT));
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Mithral", Mithral.WebAddress),
                        StandardName
                    };
                    break;
                case FullPlateMaterial.Steel:
                    this.ArmorCheckPenalty = () => StandardArmorCheckPenaltyCalculation(ARMOR_CHECK_PENALTY);
                    this.MaximumDexterityBonus = () => MAX_DEX_BONUS;
                    this.MundaneMarketPrice = () => StandardMundaneMarketPriceCalculation(MarketValueScaledBySize(size, PRICE));
                    this.Weight = () => WeightScaledBySize(size, WEIGHT);
                    this.MundaneName = () => new INameFragment[] { StandardName };
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
            }
        }


        /// <summary>
        /// Use this constructor for full plate made of dragonhide.
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.FullPlate"/> class.
        /// </summary>
        /// <param name="size">The size of character this armor is designed for.</param>
        /// <param name="color">The color of the dragonhide.</param>
        public FullPlate(SizeCategory size, DragonhideColor color)
            : base(baseArmorBonus:   BASE_ARMOR_BONUS,
                   materialHardness: Dragonhide.Hardness)
        {
            this.IsMasterwork = true;
            this.MasterworkIsToggleable = false;
            this.ArmorCheckPenalty = () => StandardArmorCheckPenaltyCalculation(ARMOR_CHECK_PENALTY);
            this.MaximumDexterityBonus = () => MAX_DEX_BONUS;
            this.MundaneName = () => new INameFragment[] {
                new NameFragment($"{ color } Dragonhide", Dragonhide.WebAddress),
                StandardName
            };
            this.MundaneMarketPrice = () => Dragonhide.GetArmorBaseMarketPrice(MarketValueScaledBySize(size, PRICE), this.Enchantments, color);
            this.Weight = () => WeightScaledBySize(size, WEIGHT);
        }


        private static byte GetHardnessForMaterial(FullPlateMaterial material)
        {
            switch (material) {
                case FullPlateMaterial.Adamantine: return Adamantine.Hardness;
                case FullPlateMaterial.Mithral:       return Mithral.Hardness;
                case FullPlateMaterial.Steel:           return Steel.Hardness;
                default:
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// The armor check penalty of this Armor.
        /// </summary>
        protected internal override Func<byte> ArmorCheckPenalty { get; }


        /// <summary>
        /// The maximum dexterity bonus allowed by this armor.
        /// If there is no maximum dexterity bonus, this should be Byte.MaxValue.
        /// </summary>
        protected internal override Func<byte> MaximumDexterityBonus { get; }


        /// <summary>
        /// Gets the armor's funamental name.
        /// </summary>
        protected internal override Func<INameFragment[]> MundaneName { get; }


        /// <summary>
        /// The market price for the item, taking into account adjustments for item materials, size, quality, and base price.
        /// Excludes costs from enchantments.
        /// </summary>
        protected internal override Func<double> MundaneMarketPrice { get; }


        /// <summary>
        /// The weight of the item (in pounds), taking into account adjustments for item materials and size.
        /// </summary>
        protected internal override Func<double> Weight { get; }


        /// <summary>
        /// The magnitude of the speed penalty applied by this armor.
        /// Should be between 0 (no penalty) and 1 (movement is completely impossible).
        /// </summary>
        protected internal override float SpeedPenalty { get; } = 0.25f;
        #endregion

        #region Enchantments
        /// <summary>
        /// Adds a magical enhancement bonus to this armor.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when bonus is zero, or greater than five.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when attempting to apply an enchantment twice.</exception>
        new public FullPlate EnchantWithEnhancementBonus(byte bonus)
        {
            base.EnchantWithEnhancementBonus(bonus);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Acid Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithAcidResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithAcidResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Cold Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithColdResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithColdResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Electricity Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithElectricityResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithElectricityResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Fire Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithFireResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithFireResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Sonic Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithSonicResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithSonicResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Etherealness.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithEtherealness()
        {
            base.EnchantWithEtherealness();
            return this;
        }


        /// <summary>
        /// Enchants this armor with Fortification.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithFortification(FortificationType protectionLevel)
        {
            base.EnchantWithFortification(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Ghost Touch.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithGhostTouch()
        {
            base.EnchantWithGhostTouch();
            return this;
        }


        /// <summary>
        /// Enchants this armor with Glamered.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithGlamered()
        {
            base.EnchantWithGlamered();
            return this;
        }


        /// <summary>
        /// Enchants this armor with Invulnerability.
        /// </summary>
        /// <param name="miracleWasUsed">Indicates whether the Miracle spell was used to create the enchantment.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithInvulnerability(bool miracleWasUsed)
        {
            base.EnchantWithInvulnerability(miracleWasUsed);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Shadow.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        new public FullPlate EnchantWithShadow(ShadowStrength strength)
        {
            base.EnchantWithShadow(strength);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Slick.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        new public FullPlate EnchantWithSlick(SlickStrength slickness)
        {
            base.EnchantWithSlick(slickness);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Spell Resistance.
        /// </summary>
        /// <param name="protectionLevel">The level of protection bestowed by this armor's enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the protectionLevel argument is a nonstandard enum.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithSpellResistance(SpellResistanceMagnitude protectionLevel)
        {
            base.EnchantWithSpellResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Undead Controlling.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithUndeadControlling()
        {
            base.EnchantWithUndeadControlling();
            return this;
        }


        /// <summary>
        /// Enchants this armor with Wild.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public FullPlate EnchantWithWild()
        {
            base.EnchantWithWild();
            return this;
        }
        #endregion
    }
}