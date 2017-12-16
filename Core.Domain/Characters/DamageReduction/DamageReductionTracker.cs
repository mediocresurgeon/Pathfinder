using System;
using System.Collections.Generic;
using System.Linq;


namespace Core.Domain.Characters.DamageReduction
{
    /// <summary>
    /// Tracks a Character's damage reductions.
    /// </summary>
    internal sealed class DamageReductionTracker : IDamageReductionTracker
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.DamageReduction.DamageReductionTracker"/> class.
        /// </summary>
        internal DamageReductionTracker()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        private List<(Func<byte> Magnitude, string BypassedBy)> DamageReductions { get; } = new List<(Func<byte>, string)>();
        #endregion

        #region Methods
        /// <summary>
        /// Adds a new damage reduction.
        /// </summary>
        /// <param name="magnitude">The magnitude of the damage reduction.</param>
        /// <param name="bypassedBy">
        /// What the damage reduction is bypassed by.
        /// If the damage reduction cannot be bypassed, this value is "—".
        /// </param>
        /// <exception cref="System.ArgumentException">Thrown when bypassedBy argument is empty or white space.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void Add(Func<byte> magnitude, string bypassedBy)
        {
            if (null == magnitude)
                throw new ArgumentNullException(nameof(magnitude), "Argument may not be null.");
            if (null == bypassedBy)
                throw new ArgumentNullException(nameof(bypassedBy), "Argument my not be null.");
            if (String.IsNullOrWhiteSpace(bypassedBy))
                throw new ArgumentException("Argument may not be empty of white space.", nameof(bypassedBy));
            this.DamageReductions.Add((magnitude, bypassedBy));
        }


        /// <summary>
        /// Returns the damage reduction of each type with the highest magnitude.
        /// </summary>
        public (Func<byte> Magnitude, string BypassedBy)[] GetAll()
        {
            return this.DamageReductions.Where(dr => 0 < dr.Magnitude())                  // DR of zero does not need to be reported
                                        .GroupBy(dr => dr.BypassedBy.ToLowerInvariant())
                                        .Select(drg => drg.Aggregate((agg, next) => next.Magnitude() > agg.Magnitude() ? next : agg)) // Finds the DR from the DRgroup with the largest magnitude
                                        .ToArray();
        }
        #endregion
    }
}