using System;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    /// <summary>
    /// An enhancement bonus to a shield.
    /// </summary>
    internal sealed class EnhancementBonus : ShieldEnchantment
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook.EnhancementBonus"/> class.
        /// </summary>
        /// <param name="bonus">The enhancement bonus. Should be at least 1 and not greater than 5.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when bonus is zero, or greater than five.</exception>
        internal EnhancementBonus(byte bonus)
            : base($"+{ bonus }", "http://www.d20pfsrd.com/basics-ability-scores/glossary#TOC-Enhancement-Bonus")
        {
            if (1 > bonus || 5 < bonus)
                throw new ArgumentOutOfRangeException(nameof(bonus), bonus, "Argument must be at least 1 and no greater than 5.");
            this.SpecialAbilityBonus = bonus;
            this.CasterLevel = Convert.ToByte(bonus * 3);
        }
        #endregion

        #region Properties
        public override byte CasterLevel { get; }
        #endregion

        #region Methods
        public override void ApplyTo(ICharacter character)
        {
            // Intentionally blank
        }


        public override void Enchant(Shield shield)
        {
            shield = shield ?? throw new ArgumentNullException(nameof(shield), "Argument cannot be null.");
            shield.ArmorClass?.EnhancementBonuses?.Add(() => this.SpecialAbilityBonus);
            shield.Hardness?.EnhancementBonuses?.Add(() => Convert.ToByte(2 * this.SpecialAbilityBonus));
            shield.HitPoints?.EnhancementBonuses?.Add(() => Convert.ToByte(10 * this.SpecialAbilityBonus));
        }


        public override School[] GetSchools()
        {
            return new School[] { School.Abjuration };
        }
        #endregion
    }
}