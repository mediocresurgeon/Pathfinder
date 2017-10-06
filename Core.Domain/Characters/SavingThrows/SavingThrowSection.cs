using System;


namespace Core.Domain.Characters.SavingThrows
{
    internal sealed class SavingThrowSection : ISavingThrowSection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SavingThrows.SavingThrowSection"/> class.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal SavingThrowSection(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            this.Fortitude = new SavingThrow(character, character?.AbilityScores?.Constitution);
            this.Reflex    = new SavingThrow(character, character?.AbilityScores?.Dexterity);
            this.Will      = new SavingThrow(character, character?.AbilityScores?.Wisdom);
        }
        #endregion

        #region Properties
        public ISavingThrow Fortitude { get; }

        public ISavingThrow Reflex { get; }

        public ISavingThrow Will { get; }
        #endregion
    }
}