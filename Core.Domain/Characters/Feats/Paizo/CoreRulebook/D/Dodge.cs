using System;


namespace Core.Domain.Characters.Feats.Paizo.CoreRulebook
{
    /// <summary>
    /// A trained character can react swiftly to avoid an opponent's attacks.
    /// </summary>
    public sealed class Dodge : Feat
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Feats.Paizo.CoreRulebook.D.Dodge"/> class.
        /// </summary>
        public Dodge()
            : base("Dodge", "http://www.d20pfsrd.com/feats/combat-feats/dodge-combat-final/")
        {
            // Intentionally blank
        }
        #endregion

        #region Methods
        /// <summary>
        /// Trains the specified character in this feat.
        /// </summary>
        /// <param name="character">The character to train.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public override void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            character.ArmorClass.DodgeBonuses.Add(() => 1);
        }
        #endregion
    }
}