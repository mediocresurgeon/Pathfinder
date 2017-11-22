using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;


namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    internal sealed class Reflecting : ShieldEnchantment
    {
        #region Constructor
        internal Reflecting()
            : base("Reflecting", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/reflecting/")
        {
            this.SpecialAbilityBonus = 5;
        }
        #endregion

        #region Properties
        public override byte CasterLevel => 14;
        #endregion

        #region Methods
        public override void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");

            // Once per day, the shield can cast Spell Turning.
            // Since it is not specified which version of the spell to use, here we assume it is the sorcerer version.
            ISpell spell = SpellTurning.SorcererVersion;

            // This is cast using the shield's stats.
            IAbilityScore enchantmentCastingStat = new AbilityScore { BaseScore = Convert.ToByte(10 + spell.Level) };

            character.SpellLikeAbilities?
                     .Registrar?
                     .Register(usesPerDay:      1,
                               spell:           spell,
                               keyAbilityScore: enchantmentCastingStat,
                               baseCasterLevel: () => this.CasterLevel);
        }

        public override void Enchant(Shield shield)
        {
            // Intentionally blank
        }

        public override School[] GetSchools()
        {
            return new School[] { School.Abjuration };
        }
        #endregion
    }
}