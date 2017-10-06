using System;
namespace Core.Domain.Characters.Feats.Paizo.CoreRulebook
{
	/// <summary>
	/// A trained character is more resistant to harmful mental effects.
	/// </summary>
	public sealed class IronWill : Feat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Feats.Paizo.CoreRulebook.I.IronWill"/> class.
        /// </summary>
        public IronWill()
            : base("Iron Will", "http://www.d20pfsrd.com/feats/general-feats/iron-will-final/")
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
            character.SavingThrows.Will.UntypedBonuses.Add(2);
        }
    }
}