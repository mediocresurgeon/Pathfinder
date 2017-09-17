namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// An enhancement bonus represents an increase in the sturdiness
    /// and/or effectiveness of armor or natural armor,
    /// or the effectiveness of a weapon,
    /// or a general bonus to an ability score.
	/// </summary>
	internal sealed class EnhancementBonusTracker : NonStackingModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.EnhancementBonusTracker"/> class.
        /// </summary>
		internal EnhancementBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
	}
}