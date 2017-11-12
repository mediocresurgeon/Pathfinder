using System;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Shields
{
    internal sealed class ShieldBonusAggregator
    {
        #region Constructor
        internal ShieldBonusAggregator(byte baseShieldBonus)
        {
            this.BaseBonus = baseShieldBonus;
        }
        #endregion

        #region Properties
        internal byte BaseBonus { get; }


        internal IModifierTracker EnhancementBonuses { get; } = new EnhancementBonusTracker();
        #endregion

        #region Methods
        internal byte GetTotal()
        {
            byte runningTotal = this.BaseBonus;
            runningTotal += this.EnhancementBonuses.GetTotal();
            return runningTotal;
        }
        #endregion
    }
}