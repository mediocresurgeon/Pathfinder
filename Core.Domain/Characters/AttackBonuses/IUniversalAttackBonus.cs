using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.AttackBonuses
{
    public interface IUniversalAttackBonus
    {
        IModifierTracker EnhancementBonuses { get; }

        IModifierTracker UntypedBonuses { get; }

        IModifierTracker Penalties { get; }
    }
}