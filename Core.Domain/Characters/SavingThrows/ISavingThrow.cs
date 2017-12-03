using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.SavingThrows
{
    /// <summary>
    /// A measurement of an ICharacter's ability to resist hostile effects, such as spells or poison.
    /// </summary>
    public interface ISavingThrow
    {
        /// <summary>
        /// The ICharacter's IAbilityScore which is associated with this ISavingThrow.
        /// </summary>
        IAbilityScore KeyAbilityScore { get; set; }

        /// <summary>
        /// Indicates whether or not the ICharacter treats this saving throw as a "good" saving throw.
        /// </summary>
        bool IsGood { get; set; }

        /// <summary>
        /// Returns the luck bonuses to this saving throw.
        /// </summary>
		IModifierTracker LuckBonuses { get; }

        /// <summary>
        /// Returns the resistance bonuses to this saving throw.
        /// </summary>
		IModifierTracker ResistanceBonuses { get; }

        /// <summary>
        /// Returns the untyped bonuses to this saving throw.
        /// </summary>
		IModifierTracker UntypedBonuses { get; }

        /// <summary>
        /// Returns the penalties to this saving throw.
        /// </summary>
		IModifierTracker Penalties { get; }

        /// <summary>
        /// Returns the bonuses to this saving throw derrived from the ICharacter's level.
        /// </summary>
        byte GetLevelBonus();

        /// <summary>
        /// Returns the total of this saving throw.
        /// </summary>
        sbyte GetTotal();
    }
}