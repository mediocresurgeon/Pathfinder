﻿using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Movements
{
    /// <summary>
    /// A mode of movement, such as burrowing, climbing, flying, swimming, or walking.
    /// </summary>
    internal class Movement : IMovement
    {
        // This class is intended to support inheritance.

        #region Properties
        /// <summary>
        /// The base speed.
        /// A null value indicates that this movement mode does not apply
        /// or cannot be used.
        /// </summary>
        /// <value>The base speed (in squares).</value>
        public virtual byte? BaseSpeed { get; set; }


        public virtual IModifierTracker EnhancementBonuses { get; } = new EnhancementBonusTracker();


        public virtual IModifierTracker Penalties { get; } = new PenaltyTracker();
        #endregion

        #region Methods
        /// <summary>
        /// Calculates the total distance of movement allowed (in squares).
        /// A null value indicates that this movement mode does not apply
        /// or cannot be used.
        /// </summary>
        public virtual byte? GetTotal()
        {
            if (!this.BaseSpeed.HasValue)
                return null;
            byte runningTotal = this.BaseSpeed.Value;
            runningTotal += this.EnhancementBonuses.GetTotal();
            runningTotal -= this.Penalties.GetTotal();
            return runningTotal;
        }
        #endregion
    }
}