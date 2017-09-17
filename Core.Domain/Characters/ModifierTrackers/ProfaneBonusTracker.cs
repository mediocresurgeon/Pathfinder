﻿using System.Collections.Generic;


namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// A profane bonus stems from the power of evil.
	/// </summary>
	internal sealed class ProfaneBonusTracker : NonStackingModifierTracker
	{
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.ModifierTrackers.ProfaneBonusTracker"/> class.
        /// </summary>
        internal ProfaneBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}

		protected override IList<byte> Modifiers { get; } = new List<byte>();
	}
}