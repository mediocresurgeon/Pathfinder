using System;


namespace Core.Domain.Characters.DamageReduction
{
    /// <summary>
    /// Tracks an ICharacter's damage reductions.
    /// </summary>
    public interface IDamageReductionTracker
    {
        /// <summary>
        /// Adds a new damage reduction.
        /// </summary>
        /// <param name="magnitude">The magnitude of the damage reduction.</param>
        /// <param name="bypassedBy">
        /// What the damage reduction is bypassed by.
        /// If the damage reduction cannot be bypassed, this value is "—".
        /// </param>
        void Add(Func<byte> magnitude, string bypassedBy);

        /// <summary>
        /// Returns the damage reduction of each type with the highest magnitude.
        /// </summary>
        (Func<byte> Magnitude, string BypassedBy)[] GetAll();
    }
}