using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ArmorClasses;
using Core.Domain.Characters.AttackBonuses;
using Core.Domain.Characters.CombatManeuverBonuses;
using Core.Domain.Characters.CombatManeuverDefenses;
using Core.Domain.Characters.DamageReduction;
using Core.Domain.Characters.EnergyResistances;
using Core.Domain.Characters.Equipment;
using Core.Domain.Characters.Feats;
using Core.Domain.Characters.Initiatives;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.Movements;
using Core.Domain.Characters.SavingThrows;
using Core.Domain.Characters.Skills;
using Core.Domain.Characters.Spellcasting;


namespace Core.Domain.Characters
{
    /// <summary>
    /// An avatar for a player character.
    /// Or sometimes a game element for a game master.
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// Returns this ICharacter's level.
        /// </summary>
        byte Level { get; }

        /// <summary>
        /// Gets or sets this ICharacter's size category.
        /// </summary>
        SizeCategory Size { get; set; }

        /// <summary>
        /// Returns this ICharacter's movement data.
        /// </summary>
        IMovementSection MovementModes { get; }

        /// <summary>
        /// Returns this ICharacter's ability scores.
        /// </summary>
        IAbilityScoreSection AbilityScores { get; }

        /// <summary>
        /// Returns this ICharacter's initiative.
        /// </summary>
        IInitiative Initiative { get; }

        /// <summary>
        /// Returns this ICharacter's saving throws.
        /// </summary>
        ISavingThrowSection SavingThrows { get; }

        /// <summary>
        /// Returns this ICharacter's skills.
        /// </summary>
        ISkillSection Skills { get; }

        /// <summary>
        /// Returns this ICharacter's spells.
        /// </summary>
        ISpellSection Spells { get; }

        /// <summary>
        /// Returns this ICharacter's spell-like abilities.
        /// </summary>
        ISpellLikeAbilitySection SpellLikeAbilities { get; }

        /// <summary>
        /// Returns this ICharacter's armor class.
        /// </summary>
        IArmorClass ArmorClass { get; }

        /// <summary>
        /// Returns this ICharacter's spell resistance.
        /// </summary>
        IModifierTracker SpellResistance { get; }

        /// <summary>
        /// Returns this ICharacter's damage reductions.
        /// </summary>
        IDamageReductionTracker DamageReduction { get; }

        /// <summary>
        /// Returns this ICharacter's energy resistances.
        /// </summary>
        IEnergyResistanceSection EnergyResistances { get; }

        /// <summary>
        /// Returns this ICharacter's global attack bonuses.
        /// </summary>
        IAttackBonusSection AttackBonuses { get; }

        /// <summary>
        /// Returns this ICharacter's CMB.
        /// </summary>
        ICombatManeuverBonus CombatManeuverBonus { get; }

        /// <summary>
        /// Returns this ICharacter's CMD.
        /// </summary>
        ICombatManeuverDefense CombatManeuverDefense { get; }

        /// <summary>
        /// Returns this Character's equipment.
        /// </summary>
        IEquipmentSection Equipment { get; }

        #region Feats
        /// <summary>
        /// Trains this ICharacter in the use of an IFeat.
        /// </summary>
        /// <param name="feat">The IFeat to train this ICharacter in.</param>
        void Train(IFeat feat);
        #endregion
    }
}