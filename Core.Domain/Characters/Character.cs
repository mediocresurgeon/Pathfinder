using Core.Domain.Characters.AbilityScores;


namespace Core.Domain.Characters
{
    /// <summary>
    /// An avatar for a player character.
    /// Or sometimes a game element for a game master.
    /// </summary>
    public sealed class Character : ICharacter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Character"/> class.
        /// </summary>
        public Character()
        {
            // Intentionally blank.
            // (I doubt this will remain blank for long.)
        }

        #region Properties
        #region Ability scores
        internal AbilityScore Strength { get; } = new Strength { BaseScore = 10 };

        IAbilityScore ICharacter.Strength => this.Strength;

        internal AbilityScore Dexterity { get; } = new Dexterity { BaseScore = 10 };

        IAbilityScore ICharacter.Dexterity => this.Dexterity;

        internal AbilityScore Constitution { get; } = new Constitution { BaseScore = 10 };

        IAbilityScore ICharacter.Constitution => this.Constitution;

        internal AbilityScore Intelligence { get; } = new Intelligence { BaseScore = 10 };

        IAbilityScore ICharacter.Intelligence => this.Intelligence;

        internal AbilityScore Wisdom { get; } = new Wisdom { BaseScore = 10 };

        IAbilityScore ICharacter.Wisdom => this.Wisdom;

        internal AbilityScore Charisma { get; } = new Charisma { BaseScore = 10 };

        IAbilityScore ICharacter.Charisma => this.Charisma;
		#endregion
		#endregion
	}
}