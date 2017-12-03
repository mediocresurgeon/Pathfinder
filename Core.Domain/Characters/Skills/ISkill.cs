using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// A measurement of an ICharacter's aptitude for accomplishing a specific task.
    /// </summary>
    public interface ISkill
    {
        /// <summary>
        /// The IAbilityScore which is associated with this <see cref="T:Core.Domain.Characters.Skills.ISkill"/>.
        /// </summary>
        /// <value>The key ability score.</value>
        IAbilityScore KeyAbilityScore { get; set; }

        /// <summary>
        /// Indicates whether or not an armor check penalty applies to this <see cref="T:Core.Domain.Characters.Skills.ISkill"/>.
        /// </summary>
        bool ArmorCheckPenaltyApplies { get; set; }

        /// <summary>
        /// Indicates whether or not this <see cref="T:Core.Domain.Characters.Skills.ISkill"/> can be used without any training.
        /// </summary>
        bool CanBeUsedUntrained { get; set; }

        /// <summary>
        /// Indicates whether or not an ICharacter treats this <see cref="T:Core.Domain.Characters.Skills.ISkill"/> as a class skill.
        /// </summary>
        bool IsClassSkill { get; set; }

        /// <summary>
        /// Indicates how much training and practice an ICharacter has had with this <see cref="T:Core.Domain.Characters.Skills.ISkill"/>.
        /// </summary>
        byte Ranks { get; set; }

        /// <summary>
        /// Returns competence bonuses to this <see cref="T:Core.Domain.Characters.Skills.ISkill"/>.
        /// </summary>
        IModifierTracker CompetenceBonuses { get; }

        /// <summary>
        /// Returns luck bonuses to this <see cref="T:Core.Domain.Characters.Skills.ISkill"/>.
        /// </summary>
        IModifierTracker LuckBonuses { get; }

        /// <summary>
        /// Returns racial bonuses to this <see cref="T:Core.Domain.Characters.Skills.ISkill"/>.
        /// </summary>
        IModifierTracker RacialBonuses { get; }

        /// <summary>
        /// Returns size bonuses to this <see cref="T:Core.Domain.Characters.Skills.ISkill"/>.
        /// </summary>
        IModifierTracker SizeBonuses { get; }

        /// <summary>
        /// Returns untyped bonuses to this <see cref="T:Core.Domain.Characters.Skills.ISkill"/>.
        /// </summary>
        IModifierTracker UntypedBonuses { get; }

        /// <summary>
        /// Returns penalties to this <see cref="T:Core.Domain.Characters.Skills.ISkill"/>.
        /// </summary>
        IModifierTracker Penalties { get; }

        /// <summary>
        /// Returns the total.
        /// </summary>
        sbyte? GetTotal();
    }
}