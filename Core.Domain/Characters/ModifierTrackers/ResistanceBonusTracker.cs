namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// A resistance bonus affects saving throws, providing extra protection against harm.
	/// </summary>
	internal sealed class ResistanceBonusTracker : GreatestModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.ResistanceBonusTracker"/> class.
        /// </summary>
		internal ResistanceBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
	}
}