namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// A shield bonus improves armor class and is granted by
    /// a shield
    /// or by a spell
    /// or magic effect that mimics a shield.
	/// </summary>
	internal sealed class ShieldBonusTracker : NonStackingModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.ShieldBonusTracker"/> class.
        /// </summary>
		internal ShieldBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
	}
}