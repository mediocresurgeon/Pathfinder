using System;
using Core.Domain.Characters;
using Core.Domain.Items.Shields;
using Core.Domain.Spells;


namespace Core.Domain.Items.Enchantments.Paizo.CoreRulebook
{
    /// <summary>
    /// An enhancement bonus to a shield or armor.
    /// </summary>
    internal sealed class EnhancementBonus : IArmorEnchantment, IShieldEnchantment
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Armor.Enchantments.Paizo.CoreRulebook.EnhancementBonus"/> class.
        /// </summary>
        /// <param name="bonus">The enhancement bonus. Should be at least 1 and not greater than 5.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when bonus is zero, or greater than five.</exception>
        internal EnhancementBonus(byte bonus)
        {
            if (1 > bonus || 5 < bonus)
                throw new ArgumentOutOfRangeException(nameof(bonus), bonus, "Argument must be at least 1 and no greater than 5.");
            this.SpecialAbilityBonus = bonus;
            this.CasterLevel = Convert.ToByte(bonus * 3);
            this.Name = new NameFragment($"+{ bonus }", "http://www.d20pfsrd.com/basics-ability-scores/glossary#TOC-Enhancement-Bonus");
        }
        #endregion

        #region Properties
        public byte CasterLevel { get; }


        public INameFragment Name { get; }


        public byte SpecialAbilityBonus { get; }


        public double Cost => 0;
        #endregion

        #region Methods
        public School[] GetSchools() => new School[] { School.Abjuration };


        public void ApplyTo(ICharacter character)
        {
            // Intentionally blank
        }


        public void Enchant(Armor.Armor armor)
        {
            if (null == armor)
                throw new ArgumentNullException(nameof(armor), "Argument cannot be null.");
            armor.ArmorClass?.EnhancementBonuses?.Add(() => this.SpecialAbilityBonus);
            armor.Hardness?.EnhancementBonuses?.Add(() => Convert.ToByte(2 * this.SpecialAbilityBonus));
            armor.HitPoints?.EnhancementBonuses?.Add(() => Convert.ToByte(10 * this.SpecialAbilityBonus));
        }


        public void Enchant(Shield shield)
        {
            if (null == shield)
                throw new ArgumentNullException(nameof(shield), "Argument cannot be null.");
            shield.ArmorClass?.EnhancementBonuses?.Add(() => this.SpecialAbilityBonus);
            shield.Hardness?.EnhancementBonuses?.Add(() => Convert.ToByte(2 * this.SpecialAbilityBonus));
            shield.HitPoints?.EnhancementBonuses?.Add(() => Convert.ToByte(10 * this.SpecialAbilityBonus));
        }
        #endregion
    }
}