using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Initiatives
{
    public interface IInitiative
    {
        IAbilityScore KeyAbilityScore { get; set; }

        IModifierTracker UntypedBonuses { get; }

        IModifierTracker Penalties { get; }

        sbyte GetTotal();
    }
}