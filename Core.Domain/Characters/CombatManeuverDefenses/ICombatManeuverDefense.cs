using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.CombatManeuverDefenses
{
    /// <summary>
    /// A measurement of an ICharacter's ability to resist combat maneuvers.
    /// </summary>
    public interface ICombatManeuverDefense
    {
        /// <summary>
        /// Returns circumstance bonuses to CMD.
        /// </summary>
		IModifierTracker CircumstanceBonuses { get; }

        /// <summary>
        /// Returns deflection bonuses to CMD.
        /// </summary>
		IModifierTracker DeflectionBonuses { get; }

        /// <summary>
        /// Returns dodge bonuses to CMD.
        /// </summary>
		IModifierTracker DodgeBonuses { get; }

        /// <summary>
        /// Returns insight bonuses to CMD.
        /// </summary>
		IModifierTracker InsightBonuses { get; }

        /// <summary>
        /// Returns luck bonuses to CMD.
        /// </summary>
		IModifierTracker LuckBonuses { get; }

        /// <summary>
        /// Returns morale bonuses to CMD.
        /// </summary>
		IModifierTracker MoraleBonuses { get; }

        /// <summary>
        /// Returns profane bonuses to CMD.
        /// </summary>
		IModifierTracker ProfaneBonuses { get; }

        /// <summary>
        /// Returns sacred bonuses to CMD.
        /// </summary>
	    IModifierTracker SacredBonuses { get; }

        /// <summary>
        /// Returns untyped bonuses to CMD.
        /// </summary>
		IModifierTracker UntypedBonuses { get; }

        /// <summary>
        /// Returns penalties to CMD (not including size adjustments).
        /// </summary>
		IModifierTracker Penalties { get; }

        /// <summary>
        /// Returns adjustments to CMD by virtue of the ICharacter's size.
        /// </summary>
        sbyte GetSizeModifier();

        /// <summary>
        /// Returns the total CMD.
        /// </summary>
        sbyte GetTotal();
    }
}