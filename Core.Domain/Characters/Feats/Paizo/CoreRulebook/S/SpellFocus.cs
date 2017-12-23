using System;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Spells;


namespace Core.Domain.Characters.Feats.Paizo.CoreRulebook
{
    /// <summary>
    /// Spells of the chosen school are more difficult to resist.
    /// </summary>
    public sealed class SpellFocus : Feat
    {
        // This class must either expose classes which are currently non-public or remain sealed.

        #region Backing variables
        private readonly School _school;
		#endregion

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

        #region Override methods
        /// <summary>
        /// Trains the specified character in this feat.
        /// </summary>
        /// <param name="character">The character to train.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the character argument is null.</exception>
        public override void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");

            // First, look through already registered spells and update them as necessary
            foreach(var spell in character.Spells.Registrar.GetSpells())
            {
                this.ApplyToSpell(spell);
            }
			// Do the same things for spell-like abilities
            foreach (var spell in character.SpellLikeAbilities.Registrar.GetSpellLikeAbilities())
			{
				this.ApplyToSpell(spell);
			}

            // Second, listen for the event that triggers when a spell is registered so they can be updated
            character.Spells.Registrar.OnRegistered += (sender, e) => {
                this.ApplyToSpell(e.Spell);
            };
			// Do the same thing for spell-like abilities
            character.SpellLikeAbilities.Registrar.OnRegistered += (sender, e) => {
                this.ApplyToSpell(e.SpellLikeAbility);
            };
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
                throw new ArgumentNullException(nameof(spell), "Argument cannot be null.");
            if (_school == spell.Spell.School)
                spell.AddDifficultyClassBonus(1);
        }
        #endregion
    }
}