using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Shields
{
    internal interface IShieldHardnessAggregator
    {
        byte MaterialHardness { get; }

        IModifierTracker EnhancementBonuses { get; }

        byte GetTotal();
    }
}