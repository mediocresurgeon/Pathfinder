using System;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Aggregators
{
    internal interface IHitPointsAggregator
    {
        Func<ushort> BaseHitPoints { get; }

        IModifierTracker EnhancementBonuses { get; }

        ushort GetTotal();
    }
}