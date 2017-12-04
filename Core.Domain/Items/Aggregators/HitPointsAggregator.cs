using System;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Aggregators
{
    internal sealed class HitPointsAggregator : IHitPointsAggregator
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Aggregators.HitPointsAggregator"/> class.
        /// </summary>
        /// <param name="baseHitPoints">The base hit points.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal HitPointsAggregator(Func<ushort> baseHitPoints)
            : this(baseHitPoints, new EnhancementBonusTracker())
        {
            // Intentionally blank
        }


        /// <summary>
        /// Dependency injection constructor.
        /// Intended for unit testing.
        /// </summary>
        /// <param name="baseHitPoints">The base hit points.</param>
        /// <param name="enhancementBonuses">Tracks enhancement bonuses to the base bonus.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal HitPointsAggregator(Func<ushort> baseHitPoints, IModifierTracker enhancementBonuses)
        {
            this.BaseHitPoints = baseHitPoints ?? throw new ArgumentNullException(nameof(baseHitPoints), "Argument may not be null.");
            this.EnhancementBonuses = enhancementBonuses ?? throw new ArgumentNullException(nameof(enhancementBonuses), "Argument may not be null.");
        }
        #endregion

        #region Properties
        public Func<ushort> BaseHitPoints { get; }

        public IModifierTracker EnhancementBonuses { get; }
        #endregion

        #region Methods
        public ushort GetTotal()
        {
            ushort runningTotal = this.BaseHitPoints();
            if (1 > runningTotal)
                runningTotal = 1;
            runningTotal += this.EnhancementBonuses.GetTotal();
            return runningTotal;
        }
        #endregion
    }
}