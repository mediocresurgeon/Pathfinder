namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// A size bonus is a boon granted by virtue of the amount of space a character occupies.
    /// (Note that penalties due to character size are possible as well.)
	/// </summary>
	internal sealed class SizeBonusTracker : NonStackingModifierTracker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.SizeBonusTracker"/> class.
        /// </summary>
        internal SizeBonusTracker()
        {
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
    }
}