namespace Core.Domain.Characters.ModifierTrackers
{
    /// <summary>
    /// Represents a set of penalties.
    /// Penalties always stack.
    /// </summary>
    internal sealed class PenaltyTracker : StackingModifierTracker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.PenaltyTracker"/> class.
        /// </summary>
        internal PenaltyTracker()
        {
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
    }
}