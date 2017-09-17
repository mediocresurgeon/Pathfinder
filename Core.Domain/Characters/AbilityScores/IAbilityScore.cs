namespace Core.Domain.Characters.AbilityScores
{
    /// <summary>
    /// An ability score, such as
    /// Strength,
    /// Dexterity,
    /// Constitution,
    /// Intelligence,
    /// Wisdom,
    /// or Charisma.
    /// </summary>
    public interface IAbilityScore
    {
        /// <summary>
        /// Gets or sets this ability score's base value.
        /// </summary>
        byte? BaseScore { get; set; }

        /// <summary>
        /// Returns the raw ability score.
        /// </summary>
        byte? GetTotal();

        /// <summary>
        /// Returns the modifier.
        /// </summary>
        sbyte GetModifier();
    }
}