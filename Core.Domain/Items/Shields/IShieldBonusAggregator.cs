using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Shields
{
    internal interface IShieldBonusAggregator
    {
        byte BaseBonus { get; }

        IModifierTracker EnhancementBonuses { get; }

        byte GetTotal();
    }
}