using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.CombatManeuverDefenses
{
    public interface ICombatManeuverDefense
    {
		IModifierTracker CircumstanceBonuses { get; }

		IModifierTracker DeflectionBonuses { get; }

		IModifierTracker DodgeBonuses { get; }

		IModifierTracker InsightBonuses { get; }

		IModifierTracker LuckBonuses { get; }

		IModifierTracker MoraleBonuses { get; }

		IModifierTracker ProfaneBonuses { get; }

	    IModifierTracker SacredBonuses { get; }

		IModifierTracker UntypedBonuses { get; }

		IModifierTracker Penalties { get; }

        sbyte GetSizeModifier();

        sbyte GetTotal();
    }
}