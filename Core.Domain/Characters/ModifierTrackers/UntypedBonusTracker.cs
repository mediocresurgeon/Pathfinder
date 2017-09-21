namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// Untyped bonuses always stack.
	/// </summary>
	internal sealed class UntypedBonusTracker : StackingModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.UntypedBonusTracker"/> class.
        /// </summary>
		internal UntypedBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
	}
}