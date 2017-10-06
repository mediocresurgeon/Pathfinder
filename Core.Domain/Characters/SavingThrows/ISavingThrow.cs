using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.SavingThrows
{
    public interface ISavingThrow
    {
        IAbilityScore KeyAbilityScore { get; set; }

        bool IsGood { get; set; }

		IModifierTracker LuckBonuses { get; }

		IModifierTracker ResistanceBonuses { get; }

		IModifierTracker UntypedBonuses { get; }

		IModifierTracker Penalties { get; }

        byte GetLevelBonus();

        sbyte GetTotal();
    }
}