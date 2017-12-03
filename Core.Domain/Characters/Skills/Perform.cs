using System;


namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// A measurement of a character's aptitude for entertaining.
    /// </summary>
    internal sealed class Perform : Skill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Skills.Perform"/> class.
        /// </summary>
        /// <param name="character">The character to whom this skill belongs.</param>
        /// <param name="performType">The type of performance represented by the instance of this class.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal Perform(ICharacter character, string performType)
            : base(
                character:       character,
                keyAbilityScore: character?.AbilityScores?.Charisma,
                name:            $"Perform ({ performType ?? throw new ArgumentNullException(nameof(performType), "Argument cannot be null.") })")
        {
            // Intentionally blank
        }
    }
}