using System;
using System.ComponentModel;
using Core.Domain.Characters;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;


namespace Core.Domain.Items.Armor.Paizo.CoreRulebook
{
    /// <summary>
    /// The materials a breastplate can be made from.
    /// </summary>
    public enum BreastplateMaterial
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
    /// Medium armor with a +6 AC bonus, a -4 armor check penalty, and a +3 max dex bonus.
    /// </summary>
    public sealed class Breastplate : Armor, IBreastplate
    {
        #region Constructor
        private const byte BASE_ARMOR_BONUS = 6;
        private const byte ARMOR_CHECK_PENALTY = 4;
        private const byte MAX_DEX_BONUS = 3;
        private const double WEIGHT = 30;
        private const double PRICE = 200;
        private const float SPEED_PENALTY = 0.25f;
        private NameFragment StandardName = new NameFragment("Breastplate", "http://www.d20pfsrd.com/equipment/Armor/breastplate");


        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.Breastplate"/> class.
        /// </summary>
        /// <param name="size">The size of the character intended to wear the armor.</param>
        /// <param name="material">The material the breastplate is made from.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        public Breastplate(SizeCategory size, BreastplateMaterial material)
            : base(BASE_ARMOR_BONUS, GetHardnessForMaterial(material))
        {
            switch (material) {
                case BreastplateMaterial.Adamantine:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    this.ArmorCheckPenalty = () => StandardArmorCheckPenaltyCalculation(ARMOR_CHECK_PENALTY);
                    this.MaximumDexterityBonus = () => MAX_DEX_BONUS;
                    this.MundaneMarketPrice = () => Adamantine.GetMediumArmorBaseMarketPrice(MarketValueScaledBySize(size, PRICE));
                    this.Weight = () => WeightScaledBySize(size, WEIGHT);
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Adamantine", Adamantine.WebAddress),
                        StandardName
                    };
                    this.SpeedPenalty = SPEED_PENALTY;
                    var (drMag, drBypass) = Adamantine.GetMediumArmorDamageReduction();
                    this.ApplyDamageReduction = (character) => character.DamageReduction?.Add(drMag, drBypass);
                    break;
                case BreastplateMaterial.Mithral:
                    this.IsMasterwork = true;
                    this.MasterworkIsToggleable = false;
                    this.ArmorCheckPenalty = () => Mithral.GetArmorCheckPenalty(ARMOR_CHECK_PENALTY);
                    this.MaximumDexterityBonus = () => Mithral.GetArmorMaximumDexterityBonus(MAX_DEX_BONUS);
                    this.MundaneMarketPrice = () => Mithral.GetMediumArmorBaseMarketPrice(MarketValueScaledBySize(size, PRICE));
                    this.Weight = () => Mithral.GetWeight(WeightScaledBySize(size, WEIGHT));
                    this.MundaneName = () => new INameFragment[] {
                        new NameFragment("Mithral", Mithral.WebAddress),
                        StandardName
                    };
                    this.SpeedPenalty = 0;
                    this.ApplyDamageReduction = (character) => { };
                    break;
                case BreastplateMaterial.Steel:
                    this.ArmorCheckPenalty = () => StandardArmorCheckPenaltyCalculation(ARMOR_CHECK_PENALTY);
                    this.MaximumDexterityBonus = () => MAX_DEX_BONUS;
                    this.MundaneMarketPrice = () => StandardMundaneMarketPriceCalculation(MarketValueScaledBySize(size, PRICE));
                    this.Weight = () => WeightScaledBySize(size, WEIGHT);
                    this.MundaneName = () => new INameFragment[] { StandardName };
                    this.SpeedPenalty = SPEED_PENALTY;
                    this.ApplyDamageReduction = (character) => { };
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
            }
        }


        /// <summary>
        /// Use this constructor for breastplate made of dragonhide.
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.Breastplate"/> class.
        /// </summary>
        /// <param name="size">The size of character this armor is designed for.</param>
        /// <param name="color">The color of the dragonhide.</param>
        public Breastplate(SizeCategory size, DragonhideColor color)
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
            this.SpeedPenalty = SPEED_PENALTY;
            this.ApplyDamageReduction = (character) => { };
            this.MundaneMarketPrice = () => Dragonhide.GetArmorBaseMarketPrice(MarketValueScaledBySize(size, PRICE), this.Enchantments, color);
            this.Weight = () => WeightScaledBySize(size, WEIGHT);
        }


        private static byte GetHardnessForMaterial(BreastplateMaterial material)
        {
            switch (material) {
                case BreastplateMaterial.Adamantine: return Adamantine.Hardness;
                case BreastplateMaterial.Mithral:       return Mithral.Hardness;
                case BreastplateMaterial.Steel:           return Steel.Hardness;
                default:
                    throw new InvalidEnumArgumentException(nameof(material), (int)material, material.GetType());
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Applies the effects of damage reduction to the character wearing this armor (if applicable).
        /// </summary>
        private Action<ICharacter> ApplyDamageReduction { get; }


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
        protected internal override float SpeedPenalty { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Applies this armor's effects to a character.
        /// </summary>
        /// <param name="character">The character which is receiving the effects of the armor.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public override void ApplyTo(ICharacter character)
        {
            base.ApplyTo(character);
            this.ApplyDamageReduction(character);
        }
        #endregion
    
        #region Enchantments
        /// <summary>
        /// Adds a magical enhancement bonus to this armor.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when bonus is zero, or greater than five.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when attempting to apply an enchantment twice.</exception>
        new public Breastplate EnchantWithEnhancementBonus(byte bonus)
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
        new public Breastplate EnchantWithAcidResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public Breastplate EnchantWithColdResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public Breastplate EnchantWithElectricityResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public Breastplate EnchantWithFireResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public Breastplate EnchantWithSonicResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithSonicResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Etherealness.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public Breastplate EnchantWithEtherealness()
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
        new public Breastplate EnchantWithFortification(FortificationType protectionLevel)
        {
            base.EnchantWithFortification(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Ghost Touch.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public Breastplate EnchantWithGhostTouch()
        {
            base.EnchantWithGhostTouch();
            return this;
        }


        /// <summary>
        /// Enchants this armor with Glamered.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public Breastplate EnchantWithGlamered()
        {
            base.EnchantWithGlamered();
            return this;
        }


        /// <summary>
        /// Enchants this armor with Invulnerability.
        /// </summary>
        /// <param name="miracleWasUsed">Indicates whether the Miracle spell was used to create the enchantment.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public Breastplate EnchantWithInvulnerability(bool miracleWasUsed)
        {
            base.EnchantWithInvulnerability(miracleWasUsed);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Shadow.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        new public Breastplate EnchantWithShadow(ShadowStrength strength)
        {
            base.EnchantWithShadow(strength);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Slick.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        new public Breastplate EnchantWithSlick(SlickStrength slickness)
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
        new public Breastplate EnchantWithSpellResistance(SpellResistanceMagnitude protectionLevel)
        {
            base.EnchantWithSpellResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Undead Controlling.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public Breastplate EnchantWithUndeadControlling()
        {
            base.EnchantWithUndeadControlling();
            return this;
        }


        /// <summary>
        /// Enchants this armor with Wild.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public Breastplate EnchantWithWild()
        {
            base.EnchantWithWild();
            return this;
        }
        #endregion
    }
}