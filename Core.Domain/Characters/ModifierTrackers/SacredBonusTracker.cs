using System.Collections.Generic;


namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// A sacred bonus stems from the power of good.
	/// </summary>
	internal sealed class SacredBonusTracker : NonStackingModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.SacredBonusTracker"/> class.
        /// </summary>
		internal SacredBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}

		protected override IList<byte> Modifiers { get; } = new List<byte>();
	}
}