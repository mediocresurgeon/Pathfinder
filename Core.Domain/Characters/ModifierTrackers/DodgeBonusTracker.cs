namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// A dodge bonus improves armor class (and sometimes Reflex saves)
    /// resulting from physical skill at avoiding blows and other ill effects.
	/// Dodge bonuses always stack.
	/// </summary>
	internal sealed class DodgeBonusTracker : StackingModifierTracker
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.DodgeBonusTracker"/> class.
        /// </summary>
        internal DodgeBonusTracker()
        {
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
	}
}