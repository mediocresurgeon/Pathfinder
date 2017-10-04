namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// A measurement of a character's ability to swim under adverse conditions, such as in stormy weather.
    /// </summary>
    internal sealed class Swim : Skill
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Skills.Swim"/> class.
		/// </summary>
		/// <param name="character">The character to whom this skill belongs.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
		internal Swim(ICharacter character)
            : base(character, character?.AbilityScores?.Strength, "Swim")
        {
			// If the character has a swim speed, it gets a +8 racial bonus to swim.
            this.RacialBonuses.Add(() => this.Character.MovementModes.Swim.BaseSpeed.HasValue ? (byte)8 : (byte)0);
        }
    }
}