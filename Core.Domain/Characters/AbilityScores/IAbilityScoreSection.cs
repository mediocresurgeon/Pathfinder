namespace Core.Domain.Characters.AbilityScores
{
    /// <summary>
    /// A section of an ICharacter which contains the ICharacter's IAbilityScores.
    /// </summary>
    public interface IAbilityScoreSection
    {
        /// <summary>
        /// Returns the strength ability score.
        /// </summary>
        IAbilityScore Strength { get; }

        /// <summary>
        /// Returns the dexterity ability score.
        /// </summary>
        IAbilityScore Dexterity { get; }

        /// <summary>
        /// Returns the constitution ability score.
        /// </summary>
        IAbilityScore Constitution { get; }

        /// <summary>
        /// Returns the intelligence ability score.
        /// </summary>
        IAbilityScore Intelligence { get; }

        /// <summary>
        /// Returns the wisdom ability score.
        /// </summary>
        IAbilityScore Wisdom { get; }

        /// <summary>
        /// Returns the charisma ability score.
        /// </summary>
        IAbilityScore Charisma { get; }
    }
}