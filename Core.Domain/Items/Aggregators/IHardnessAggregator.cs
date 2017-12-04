using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Aggregators
{
    internal interface IHardnessAggregator
    {
        byte MaterialHardness { get; }

        IModifierTracker EnhancementBonuses { get; }

        byte GetTotal();
    }
}