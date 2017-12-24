using System;
using Core.Domain.Characters;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;


namespace Core.Domain.Items.Armor.Paizo.CoreRulebook
{
    /// <summary>
    /// Armor made from heavy, quilted cloth.
    /// </summary>
    public sealed class PaddedArmor : Armor, IPaddedArmor, ILightArmor
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.PaddedArmor"/> class.
        /// </summary>
        /// <param name="size">Size.</param>
        public PaddedArmor(SizeCategory size)
            : base(1, Cloth.Hardness)
        {
            this.ArmorCheckPenalty = () => StandardArmorCheckPenaltyCalculation(1);
            this.MaximumDexterityBonus = () => 8;
            this.MundaneName = () => new INameFragment[] {
                new NameFragment("Padded Armor", "http://www.d20pfsrd.com/equipment/Armor/padded")
            };
            this.MundaneMarketPrice = () => base.StandardMundaneMarketPriceCalculation(MarketValueScaledBySize(size, 5));
            this.Weight = () => WeightScaledBySize(size, 10);
        }
        #endregion

        #region Properties
        /// <summary>
        /// The logic for calculating this armor's armor check penalty.
        /// </summary>
        protected internal override Func<byte> ArmorCheckPenalty { get; }


        /// <summary>
        /// The logic for calculating this armor's max dex bonus to AC.
        /// </summary>
        protected internal override Func<byte> MaximumDexterityBonus { get; }


        /// <summary>
        /// The logic for calculating this armor's fundamental name.
        /// </summary>
        protected internal override Func<INameFragment[]> MundaneName { get; }


        /// <summary>
        /// The logic for calculating this armor's market price (not including enchantments).
        /// </summary>
        protected internal override Func<double> MundaneMarketPrice { get; }


        /// <summary>
        /// The logic for calculating this armor's weight.
        /// </summary>
        protected internal override Func<double> Weight { get; }


        /// <summary>
        /// The magnitude of the speed penalty applied by this armor.
        /// Should be between 0 (no penalty) and 1 (movement is completely impossible).
        /// </summary>
        protected internal override float SpeedPenalty { get; } = 0;
        #endregion

        #region Enchantments
        /// <summary>
        /// Adds a magical enhancement bonus to this armor.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when bonus is zero, or greater than five.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when attempting to apply an enchantment twice.</exception>
        new public PaddedArmor EnchantWithEnhancementBonus(byte bonus)
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
        new public PaddedArmor EnchantWithAcidResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public PaddedArmor EnchantWithColdResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public PaddedArmor EnchantWithElectricityResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public PaddedArmor EnchantWithFireResistance(EnergyResistanceMagnitude protectionLevel)
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
        new public PaddedArmor EnchantWithSonicResistance(EnergyResistanceMagnitude protectionLevel)
        {
            base.EnchantWithSonicResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Etherealness.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public PaddedArmor EnchantWithEtherealness()
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
        new public PaddedArmor EnchantWithFortification(FortificationType protectionLevel)
        {
            base.EnchantWithFortification(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Ghost Touch.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public PaddedArmor EnchantWithGhostTouch()
        {
            base.EnchantWithGhostTouch();
            return this;
        }


        /// <summary>
        /// Enchants this armor with Glamered.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public PaddedArmor EnchantWithGlamered()
        {
            base.EnchantWithGlamered();
            return this;
        }


        /// <summary>
        /// Enchants this armor with Invulnerability.
        /// </summary>
        /// <param name="miracleWasUsed">Indicates whether the Miracle spell was used to create the enchantment.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public PaddedArmor EnchantWithInvulnerability(bool miracleWasUsed)
        {
            base.EnchantWithInvulnerability(miracleWasUsed);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Shadow.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        new public PaddedArmor EnchantWithShadow(ShadowStrength strength)
        {
            base.EnchantWithShadow(strength);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Slick.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        new public PaddedArmor EnchantWithSlick(SlickStrength slickness)
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
        new public PaddedArmor EnchantWithSpellResistance(SpellResistanceMagnitude protectionLevel)
        {
            base.EnchantWithSpellResistance(protectionLevel);
            return this;
        }


        /// <summary>
        /// Enchants this armor with Undead Controlling.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public PaddedArmor EnchantWithUndeadControlling()
        {
            base.EnchantWithUndeadControlling();
            return this;
        }


        /// <summary>
        /// Enchants this armor with Wild.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when this armor does not already have a magical enhancement bonus, or when this enchantment has already been applied.</exception>
        new public PaddedArmor EnchantWithWild()
        {
            base.EnchantWithWild();
            return this;
        }
        #endregion
    }
}