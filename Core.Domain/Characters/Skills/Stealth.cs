namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// A character's ability to avoid detection by hiding or moving silently.
    /// </summary>
    internal sealed class Stealth : Skill
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Skills.Stealth"/> class.
		/// </summary>
		/// <param name="character">The character to whom this skill belongs.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
		internal Stealth(ICharacter character)
            : base(character, character?.AbilityScores?.Dexterity, "Stealth")
        {
            this.ArmorCheckPenaltyApplies = true;
			#region Size bonus
			this.SizeBonuses.Add(() =>
			{
				switch (this.Character.Size)
				{
					case SizeCategory.Small: return 4;
					// Add more sizes here
					default:                 return 0;
                }
			});
			#endregion
			#region Size penalty
			this.Penalties.Add(() =>
			{
				switch (this.Character.Size)
				{
					case SizeCategory.Large: return 4;
                        // Add more sizes here
                    default:                 return 0;
				}
			});
			#endregion
		}
    }
}