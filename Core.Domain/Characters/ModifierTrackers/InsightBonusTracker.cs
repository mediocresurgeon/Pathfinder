namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// An insight bonus improves performance of a given activity
    /// by granting the character an almost precognitive knowledge of what might occur.
	/// </summary>
	internal sealed class InsightBonusTracker : NonStackingModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.InsightBonusTracker"/> class.
        /// </summary>
		internal InsightBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
	}
}