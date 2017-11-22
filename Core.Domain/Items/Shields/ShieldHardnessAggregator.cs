using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Shields
{
    internal sealed class ShieldHardnessAggregator : IShieldHardnessAggregator
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
        public byte MaterialHardness { get; }

        public IModifierTracker EnhancementBonuses { get; } = new EnhancementBonusTracker();
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