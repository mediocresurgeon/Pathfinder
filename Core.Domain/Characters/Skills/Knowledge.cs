using System;

namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// A measurement of a character's expertise an an academic field.
    /// </summary>
    internal sealed class Knowledge : Skill
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Skills.Knowledge"/> class.
		/// </summary>
		/// <param name="character">The character to whom this skill belongs.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
		internal Knowledge(ICharacter character, string knowledgeType)
            : base(
                character:       character,
                keyAbilityScore: character?.Intelligence,
                name:            $"Knowledge ({ knowledgeType ?? throw new ArgumentNullException(nameof(knowledgeType), $"Argument cannot be null.") })")
        {
            this.CanBeUsedUntrained = false;
        }
    }
}