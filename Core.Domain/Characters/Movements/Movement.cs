using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Movements
{
    /// <summary>
    /// A mode of movement, such as burrowing, climbing, flying, swimming, or walking.
    /// </summary>
    internal abstract class Movement : IMovement
    {
        #region Properties
        /// <summary>
        /// The base speed.
        /// A null value indicates that this movement mode does not apply
        /// or cannot be used.
        /// </summary>
        /// <value>The base speed (in squares).</value>
        public virtual byte? BaseSpeed { get; set; }

        /// <summary>
        /// Provides protected access to the EnhancementBonusTracker object.
        /// </summary>
        /// <value>The enhancement bonus tracker.</value>
        protected virtual IModifierTracker EnhancementBonusTracker { get; } = new EnhancementBonusTracker();
        #endregion

        #region Methods
        /// <summary>
        /// Adds an enhancement bonus (in squares) to this movement speed.
        /// </summary>
        /// <param name="squares">The magnitude of the bonus (in squares).</param>
        public virtual void AddEnhancementBonus(byte squares)
        {
            this.EnhancementBonusTracker.Add(squares);
        }

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
            runningTotal += this.EnhancementBonusTracker.GetTotal();
            return runningTotal;
        }
        #endregion
    }
}