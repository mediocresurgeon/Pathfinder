using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;


namespace Core.Domain.Items.Enchantments.Paizo.CoreRulebook
{
    internal sealed class Etherealness : IArmorEnchantment
    {
        #region Constructor
        internal Etherealness()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        public INameFragment Name { get; } = new NameFragment("Etherealness", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/etherealness/");


        public byte CasterLevel => 13;


        public byte SpecialAbilityBonus => 0;


        public double Cost => 49_000;
        #endregion

        #region Methods
        public School[] GetSchools() => new School[] { School.Transmutation };


        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument may not be null.");
            var spell = EtherealJaunt.SorcererVersion;
            var castingStat = new AbilityScore() { BaseScore = Convert.ToByte(10 + spell.Level) };
            var sla = new SpellLikeAbility(usesPerDay: 1,
                                           spell: spell,
                                           keyAbilityScore: castingStat,
                                           baseCasterLevel: () => this.CasterLevel);
            character.SpellLikeAbilities?.Known?.Add(sla);
        }


        public void Enchant(Armor.Armor armor)
        {
            // Intentionally blank
        }
        #endregion
    }
}