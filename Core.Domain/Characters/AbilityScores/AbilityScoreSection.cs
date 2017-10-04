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
        public IAbilityScore Strength { get; } = new Strength();

        public IAbilityScore Dexterity { get; } = new Dexterity();

        public IAbilityScore Constitution { get; } = new Constitution();

        public IAbilityScore Intelligence { get; } = new Intelligence();

        public IAbilityScore Wisdom { get; } = new Wisdom();

        public IAbilityScore Charisma { get; } = new Charisma();
        #endregion
    }
}