using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.CombatManeuverBonuses
{
    public interface ICombatManeuverBonus
    {
        IAbilityScore KeyAbilityScore { get; set; }

        IModifierTracker EnhancementBonuses { get; }

        IModifierTracker UntypedBonuses { get; }

        IModifierTracker Penalties { get; }

        sbyte GetSizeModifier();

        sbyte GetTotal();
    }
}