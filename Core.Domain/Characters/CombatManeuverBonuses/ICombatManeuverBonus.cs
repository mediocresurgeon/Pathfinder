using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.CombatManeuverBonuses
{
    /// <summary>
    /// An measurement of an ICharacter's skill at performing combat maneuvers, such as:
    /// bull rush,
    /// disarm,
    /// grapple,
    /// overrun,
    /// sunder,
    /// and trip.
    /// </summary>
    /// <remarks>Also called CMB.</remarks>
    public interface ICombatManeuverBonus
    {
        /// <summary>
        /// The ICharacter's IAbilityScore which powers CMB.
        /// </summary>
        IAbilityScore KeyAbilityScore { get; set; }

        /// <summary>
        /// Returns enhancement bonuses to CMB.
        /// </summary>
        IModifierTracker EnhancementBonuses { get; }

        /// <summary>
        /// Returns untyped bonuses to CMB.
        /// </summary>
        IModifierTracker UntypedBonuses { get; }

        /// <summary>
        /// Returns penalties bonuses to CMB (not including size adjustments).
        /// </summary>
        IModifierTracker Penalties { get; }

        /// <summary>
        /// Returns adjustments to CMB by virtue of the ICharacter's size.
        /// </summary>
        sbyte GetSizeModifier();

        /// <summary>
        /// Returns the total CMB.
        /// </summary>
        sbyte GetTotal();
    }
}