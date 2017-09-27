namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// A character's skill at scaling vertical surfaces.
    /// </summary>
    internal sealed class Climb : Skill
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Skills.Climb"/> class.
		/// </summary>
		/// <param name="character">The character to whom this skill belongs.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
		internal Climb(ICharacter character)
            : base(character, character?.Strength, "Climb")
        {
            // If the character has a climb speed, it gets a +8 racial bonus to climb.
            this.RacialBonuses.Add(() => this.Character.ClimbSpeed.BaseSpeed.HasValue ? (byte)8 : (byte)0);
        }
    }
}