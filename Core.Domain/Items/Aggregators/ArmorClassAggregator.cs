using System;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Aggregators
{
    internal sealed class ArmorClassAggregator : IArmorClassAggregator
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Aggregators.ArmorClassAggregator"/> class.
        /// </summary>
        /// <param name="baseBonus">The base armor class bonus.</param>
        internal ArmorClassAggregator(byte baseBonus)
            : this(baseBonus, new EnhancementBonusTracker())
        {
            // Intentionally blank
        }


        /// <summary>
        /// Dependency injection constructor.
        /// Intended for unit testing.
        /// </summary>
        /// <param name="baseBonus">The base armor class bonus.</param>
        /// <param name="enhancementBonuses">Tracks enhancement bonuses to the base bonus.</param>
        /// <exception cref="System.ArgumentNullException">Throw when an argument is null.</exception>
        internal ArmorClassAggregator(byte baseBonus, IModifierTracker enhancementBonuses)
        {
            this.BaseBonus = baseBonus;
            this.EnhancementBonuses = enhancementBonuses ?? throw new ArgumentNullException(nameof(enhancementBonuses), "Argument may not be null.");
        }
        #endregion

        #region Properties
        public byte BaseBonus { get; }

        public IModifierTracker EnhancementBonuses { get; }
        #endregion

        #region Methods
        public byte GetTotal()
        {
            byte runningTotal = this.BaseBonus;
            runningTotal += this.EnhancementBonuses.GetTotal();
            return runningTotal;
        }
        #endregion
    }
}