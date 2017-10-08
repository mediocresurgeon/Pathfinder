namespace Core.Domain.Characters.AbilityScores
{
    internal sealed class AbilityScoreSection : IAbilityScoreSection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.AbilityScores.AbilityScoreSection"/> class.
        /// </summary>
        internal AbilityScoreSection()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        public IAbilityScore Strength { get; } = new AbilityScore();

        public IAbilityScore Dexterity { get; } = new AbilityScore();

        public IAbilityScore Constitution { get; } = new AbilityScore();

        public IAbilityScore Intelligence { get; } = new AbilityScore();

        public IAbilityScore Wisdom { get; } = new AbilityScore();

        public IAbilityScore Charisma { get; } = new AbilityScore();
        #endregion
    }
}