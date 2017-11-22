using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Shields
{
    internal interface IShieldHitPointAggregator
    {
        float InchesOfThickness { get; }

        byte HitPointsPerInchOfThickness { get; }

        IModifierTracker EnhancementBonuses { get; }

        ushort GetTotal();
    }
}