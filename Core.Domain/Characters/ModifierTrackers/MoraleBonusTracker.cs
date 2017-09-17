namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// A morale bonus represents the effects of greater hope,
    /// courage,
    /// and determination.
	/// </summary>
	internal sealed class MoraleBonusTracker : NonStackingModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.MoraleBonusTracker"/> class.
        /// </summary>
		internal MoraleBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
	}
}