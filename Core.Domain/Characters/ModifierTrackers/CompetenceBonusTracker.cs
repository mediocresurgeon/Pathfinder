﻿using System.Collections.Generic;


namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// A competence bonus affects a character’s performance of a particular task.
	/// </summary>
	internal sealed class CompetenceBonusTracker : NonStackingModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.CompetenceBonusTracker"/> class.
        /// </summary>
		internal CompetenceBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}

		protected override IList<byte> Modifiers { get; } = new List<byte>();
	}
}