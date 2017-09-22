using System;
using Core.Domain.Characters.SpellRegistries;
using Core.Domain.Spells;


namespace Core.Domain.Characters.Feats
{
    /// <summary>
    /// Spells of the chosen school are more difficult to resist.
    /// </summary>
    public sealed class SpellFocus : Feat
    {
        // This class must either expose classes which are currently non-public or remain sealed.

        #region Backing variables
        private readonly School _school;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Feats.SpellFocus"/> class.
        /// </summary>
        /// <param name="school">The school which is the focus.</param>
        public SpellFocus(School school)
            : base(name: $"Spell Focus ({ school })",
                   webAddress: "http://www.d20pfsrd.com/feats/general-feats/spell-focus-final")
        {
            _school = school;
        }
        #endregion

        #region Override methods
        /// <summary>
        /// Trains the specified character in this feat.
        /// </summary>
        /// <param name="character">The character to train.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the character argument is null.</exception>
        public override void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException($"{nameof(character) } argument cannot be null.");
            // First, look through already registered spells and update them as necessary
            foreach(var spell in character.SpellRegistrar.GetSpells())
            {
                ApplyToSpell(spell);
            }
            // Second, listen for the event that triggers when a spell is registered so they can be updated
            character.SpellRegistrar.OnSpellRegistered((sender, e) => {
                this.ApplyToSpell(e.Spell);
            });
        }
		#endregion

		#region Private methods
		/// <summary>
		/// Applies this feat to a spell.
		/// </summary>
		/// <param name="spell">The spell to apply this feat to.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when the spell argument is null.</exception>
		private void ApplyToSpell(ICastableSpell spell)
        {
            if (null == spell)
                throw new ArgumentNullException($"{nameof(spell) } argument cannot be null.");
            if (_school == spell.Spell.School)
                spell.AddDifficultyClassBonus(1);
        }
        #endregion
    }
}