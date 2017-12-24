using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Initiatives
{
    /// <summary>
    /// A measurement of how quick an ICharacter is to react in combat.
    /// </summary>
    public interface IInitiative
    {
        /// <summary>
        /// The IAbilityScore which powers IInitiative.
        /// </summary>
        IAbilityScore KeyAbilityScore { get; set; }

        /// <summary>
        /// Returns the competence bonuses to intiative.
        /// </summary>
        IModifierTracker CompetenceBonuses { get; }

        /// <summary>
        /// Returns the luck bonuses to intiative.
        /// </summary>
        IModifierTracker LuckBonuses { get; }

        /// <summary>
        /// Returns the untyped bonuses to IInitiative.
        /// </summary>
        IModifierTracker UntypedBonuses { get; }

        /// <summary>
        /// Returns the penalties to IInitiative.
        /// </summary>
        IModifierTracker Penalties { get; }

        /// <summary>
        /// Returns the total initiative.
        /// </summary>
        sbyte GetTotal();
    }
}