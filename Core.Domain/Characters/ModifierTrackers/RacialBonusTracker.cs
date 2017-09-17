using System.Collections.Generic;


namespace Core.Domain.Characters.ModifierTrackers
{
    /// <summary>
    /// A racial bonus comes from the culture a particular creature
    /// was brought up in or because of innate characteristics of that type of creature.
    /// Racial bonuses always stack.
    /// </summary>
    internal sealed class RacialBonusTracker : StackingModifierTracker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.RacialBonusTracker"/> class.
        /// </summary>
        internal RacialBonusTracker()
        {
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}

		protected override IList<byte> Modifiers { get; } = new List<byte>();
	}
}