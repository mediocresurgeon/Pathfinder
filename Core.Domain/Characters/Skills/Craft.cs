using System;

namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// A measurement of the skill a character has in crafting a mundane items.
    /// </summary>
    internal sealed class Craft : Skill
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Skills.Craft"/> class.
		/// </summary>
		/// <param name="character">The character to whom this skill belongs.</param>
        /// <param name="craftType">The type of craft represented by the instance of this skill.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
		internal Craft(ICharacter character, string craftType)
            : base(
                character:       character,
                keyAbilityScore: character?.AbilityScores?.Intelligence,
                name:            $"Craft ({ craftType ?? throw new ArgumentNullException(nameof(craftType), "Argument cannot be null.") })")
        {
            // Intentionally blank
        }
    }
}