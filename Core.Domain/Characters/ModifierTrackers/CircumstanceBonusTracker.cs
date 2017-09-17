using System.Collections.Generic;


namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// A circumstance bonus arises from specific conditional factors impacting the success of the task at hand.
	/// Circumstance bonuses always stack.
	/// </summary>
	internal sealed class CircumstanceBonusTracker : StackingModifierTracker
	{
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.ModifierTrackers.CircumstanceBonusTracker"/> class.
        /// </summary>
        internal CircumstanceBonusTracker()
        {
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}

		protected override IList<byte> Modifiers { get; } = new List<byte>();
	}
}