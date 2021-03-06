﻿namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// A deflection bonus affects armor class
    /// and is granted by a spell
    /// or magic effect
    /// that makes attacks veer off harmlessly.
	/// </summary>
	internal sealed class DeflectionBonusTracker : GreatestModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.DeflectionBonusTracker"/> class.
        /// </summary>
		internal DeflectionBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
	}
}