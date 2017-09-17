using System.Collections.Generic;


namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// An alchemical bonus is granted by the use of a non-magical,
    /// alchemical substance such as antitoxin.
	/// </summary>
	internal sealed class AlchemicalBonusTracker : NonStackingModifierTracker
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.ModifierTrackers.AlchemicalBonusTracker"/> class.
        /// </summary>
        internal AlchemicalBonusTracker()
        {
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}

        protected override IList<byte> Modifiers { get; } = new List<byte>();
    }
}