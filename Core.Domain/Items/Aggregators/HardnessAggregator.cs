using System;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Aggregators
{
    internal sealed class HardnessAggregator : IHardnessAggregator
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Aggregators.HardnessAggregator"/> class.
        /// </summary>
        /// <param name="materialHardness">The material's base hardness.</param>
        internal HardnessAggregator(byte materialHardness)
            : this(materialHardness, new EnhancementBonusTracker())
        {
            // Intentionally blank
        }


        /// <summary>
        /// Dependency injection constructor.
        /// Intended for unit testing.
        /// </summary>
        /// <param name="materialHardness">The material's base hardness.</param>
        /// <param name="enhancementBonuses">Tracks enhancement bonuses to the base bonus.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal HardnessAggregator(byte materialHardness, IModifierTracker enhancementBonuses)
        {
            this.MaterialHardness = materialHardness;
            this.EnhancementBonuses = enhancementBonuses ?? throw new ArgumentNullException(nameof(enhancementBonuses), "Argument may not be null.");
        }
        #endregion

        #region Properties
        public byte MaterialHardness { get; }

        public IModifierTracker EnhancementBonuses { get; }
        #endregion

        #region Methods
        public byte GetTotal()
        {
            byte runningTotal = this.MaterialHardness;
            runningTotal += this.EnhancementBonuses.GetTotal();
            return runningTotal;
        }
        #endregion
    }
}