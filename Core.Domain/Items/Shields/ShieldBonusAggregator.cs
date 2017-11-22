using System;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Shields
{
    internal sealed class ShieldBonusAggregator : IShieldBonusAggregator
    {
        #region Constructor
        internal ShieldBonusAggregator(byte baseShieldBonus)
        {
            this.BaseBonus = baseShieldBonus;
        }
        #endregion

        #region Properties
        public byte BaseBonus { get; }


        public IModifierTracker EnhancementBonuses { get; } = new EnhancementBonusTracker();
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