using System;


namespace Core.Domain.Characters.Feats.Paizo.CoreRulebook
{
	/// <summary>
	/// A trained character is more resistant to poisons, diseases, and other maladies.
	/// </summary>
	public sealed class GreatFortitude : Feat
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.Feats.Paizo.CoreRulebook.G.GreatFortitude"/> class.
        /// </summary>
        public GreatFortitude()
            : base("Great Fortitude", "http://www.d20pfsrd.com/feats/general-feats/great-fortitude/")
        {
            // Intentionally blank
        }
        #endregion

        /// <summary>
        /// Trains the specified character in this feat.
        /// </summary>
        /// <param name="character">The character to train.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public override void ApplyTo(ICharacter character)
		{
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            character.SavingThrows.Fortitude.UntypedBonuses.Add(() => 2);
		}
	}
}