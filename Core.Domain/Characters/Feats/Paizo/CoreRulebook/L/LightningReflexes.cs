using System;


namespace Core.Domain.Characters.Feats.Paizo.CoreRulebook
{
	/// <summary>
	/// A trained character has faster-than-normal reflexes.
	/// </summary>
	public sealed class LightningReflexes : Feat
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.Feats.Paizo.CoreRulebook.L.LightningReflexes"/> class.
        /// </summary>
        public LightningReflexes()
            : base("Lightning Reflexes", "http://www.d20pfsrd.com/feats/general-feats/lightning-reflexes-final/")
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
            character.SavingThrows.Reflex.UntypedBonuses.Add(() => 2);
        }
    }
}