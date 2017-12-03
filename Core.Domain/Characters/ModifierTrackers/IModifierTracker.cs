using System;


namespace Core.Domain.Characters.ModifierTrackers
{
    /// <summary>
    /// Tracks the magnitude of a particular type of modifier.
    /// </summary>
    public interface IModifierTracker
    {
        /// <summary>
        /// Adds a new calculation to this IModifierTracker.
        /// </summary>
        /// <param name="calculation">The calculation to perform.</param>
        void Add(Func<byte> calculation);

        /// <summary>
        /// Returns the total modifier.
        /// </summary>
        byte GetTotal();
    }
}