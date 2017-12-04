using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Aggregators
{
    internal interface IArmorClassAggregator
    {
        byte BaseBonus { get; }

        IModifierTracker EnhancementBonuses { get; }

        byte GetTotal();
    }
}