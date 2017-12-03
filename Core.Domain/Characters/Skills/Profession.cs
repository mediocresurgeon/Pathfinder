using System;


namespace Core.Domain.Characters.Skills
{
    internal sealed class Profession : Skill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Skills.Profession"/> class.
        /// </summary>
        /// <param name="character">The character to whom this skill belongs.</param>
        /// <param name="professionType">The kind of profession represented by this skill.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal Profession(ICharacter character, string professionType)
            : base(
                character:       character,
                keyAbilityScore: character?.AbilityScores?.Wisdom,
                name:            $"Profession ({ professionType ?? throw new ArgumentNullException(nameof(professionType), "Argument may not be null.") })")
        {
            this.CanBeUsedUntrained = false;
        }
    }
}