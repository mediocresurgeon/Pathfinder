using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.AttackBonuses
{
    /// <summary>
    /// An attack bonus which is not associated with a particular weapon.
    /// </summary>
    public interface IUniversalAttackBonus
    {
        /// <summary>
        /// Returns enhancement bonuses to attack.
        /// </summary>
        IModifierTracker EnhancementBonuses { get; }

        /// <summary>
        /// Returns untyped bonuses to attack.
        /// </summary>
        IModifierTracker UntypedBonuses { get; }

        /// <summary>
        /// Returns penalties to attack.
        /// </summary>
        IModifierTracker Penalties { get; }
    }
}