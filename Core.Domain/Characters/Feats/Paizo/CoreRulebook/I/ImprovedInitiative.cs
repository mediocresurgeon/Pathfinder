using System;


namespace Core.Domain.Characters.Feats.Paizo.CoreRulebook
{
    /// <summary>
    /// A trained character has rapid reflexes which allow them to react rapidly to danger.
    /// </summary>
    public sealed class ImprovedInitiative : Feat
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.Feats.Paizo.CoreRulebook.I.ImprovedInitiative"/> class.
        /// </summary>
        public ImprovedInitiative()
            : base("Improved Initiative", "http://www.d20pfsrd.com/feats/combat-feats/improved-initiative-combat-final/")
        {
            // Intentionally blank
        }

		/// <summary>
		/// Trains the specified character in this feat.
		/// </summary>
		/// <param name="character">The character to train.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
		public override void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            character.Initiative.UntypedBonuses.Add(4);
        }
    }
}