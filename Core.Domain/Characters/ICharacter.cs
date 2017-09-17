using Core.Domain.Characters.AbilityScores;


namespace Core.Domain.Characters
{
    /// <summary>
    /// An avatar for a player character.
    /// Or sometimes a game element for a game master.
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// Gets the level.
        /// </summary>
        byte Level { get; }

        #region Ability scores
        /// <summary>
        /// Gets the Strength.
        /// </summary>
        IAbilityScore Strength { get; }


        /// <summary>
        /// Gets the Dexterity.
        /// </summary>
        IAbilityScore Dexterity { get; }


        /// <summary>
        /// Gets the Consitution.
        /// </summary>
        IAbilityScore Constitution { get; }


        /// <summary>
        /// Gets the Intelligence.
        /// </summary>
        IAbilityScore Intelligence { get; }


        /// <summary>
        /// Gets the Wisdom.
        /// </summary>
        IAbilityScore Wisdom { get; }


        /// <summary>
        /// Gets the Charisma.
        /// </summary>
        IAbilityScore Charisma { get; }
        #endregion
    }
}