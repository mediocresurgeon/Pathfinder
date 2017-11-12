using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Shields
{
    public sealed class ShieldHardnessAggregator
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.ShieldHardnessAggregator"/> class.
        /// </summary>
        /// <param name="materialHardness">The hardness of the material.</param>
        internal ShieldHardnessAggregator(byte materialHardness)
        {
            this.MaterialHardness = materialHardness;
        }
        #endregion

        #region Properties
        internal byte MaterialHardness { get; }

        internal IModifierTracker EnhancementBonuses { get; } = new EnhancementBonusTracker();
        #endregion

        #region Methods
        internal byte GetTotal()
        {
            byte runningTotal = this.MaterialHardness;
            runningTotal += this.EnhancementBonuses.GetTotal();
            return runningTotal;
        }
        #endregion
    }
}