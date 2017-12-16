using System;
using System.Collections.Generic;
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
using Core.Domain.Characters.SpellResistances;


namespace Core.Domain.Characters
{
    /// <summary>
    /// An avatar for a player character.
    /// Or sometimes a game element for a game master.
    /// </summary>
    public sealed class Character : ICharacter
    {
        #region Backing variables
        private readonly List<IFeat> _feats;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Character"/> class.
        /// </summary>
        /// <param name="level">The character's level (1-20).</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when level is 0 or 21+.</exception>
        internal Character(byte level)
        {
            if (1 > level || 20 < level)
                throw new ArgumentOutOfRangeException(nameof(level), $"Invalid character level ({ level }): Character levels must be between 1 and 20 (inclusive).");
            this.Level = level;
            _feats = new List<IFeat>();
            this.Initiative = new Initiative(this.AbilityScores.Dexterity);
            this.SavingThrows = new SavingThrowSection(this);
            this.Skills = new SkillSection(this);
            this.Spells = new SpellSection(this);
            this.ArmorClass = new ArmorClass(this);
            this.AttackBonuses = new AttackBonusSection(this);
            this.CombatManeuverBonus = new CombatManeuverBonus(this);
            this.CombatManeuverDefense = new CombatManeuverDefense(this);
            this.Equipment = new EquipmentSection(this);
        }

        /// <summary>
        /// Returns an instance of ICharacter.
        /// </summary>
        /// <returns>The character.</returns>
        /// <param name="level">The character's level (1-20).</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when level is 0 or 21+.</exception>
        public static ICharacter Create(byte level)
        {
            return new Character(level);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns this character's level.
        /// </summary>
        public byte Level { get; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public SizeCategory Size { get; set; } = SizeCategory.Medium;

        /// <summary>
        /// Returns this Character's movement data.
        /// </summary>
        public IMovementSection MovementModes { get; } = new MovementSection(); 

        /// <summary>
        /// Returns this Character's ability scores.
        /// </summary>
        public IAbilityScoreSection AbilityScores { get; } = new AbilityScoreSection();

        /// <summary>
        /// Returns this Character's initiative.
        /// </summary>
        public IInitiative Initiative { get; }

        /// <summary>
        /// Returns this Character's saving throws.
        /// </summary>
        public ISavingThrowSection SavingThrows { get; }

        /// <summary>
        /// Returns this Character's skills.
        /// </summary>
        public ISkillSection Skills { get; }

        /// <summary>
        /// Returns this Character's spells.
        /// </summary>
        public ISpellSection Spells { get; }

        /// <summary>
        /// Returns this Character's spell-like abilities.
        /// </summary>
        public ISpellLikeAbilitySection SpellLikeAbilities { get; }

        /// <summary>
        /// Returns this Character's armor class.
        /// </summary>
        public IArmorClass ArmorClass { get; }

        /// <summary>
        /// Returns this Character's spell resistance.
        /// </summary>
        public IModifierTracker SpellResistance { get; } = new SpellResistanceTracker();

        /// <summary>
        /// Returns this Character's damage reductions.
        /// </summary>
        public IDamageReductionTracker DamageReduction { get; } = new DamageReductionTracker();

        /// <summary>
        /// Returns this Character's energy resistances.
        /// </summary>
        public IEnergyResistanceSection EnergyResistances { get; } = new EnergyResistanceSection();

        /// <summary>
        /// Returns this Character's global attack bonuses.
        /// </summary>
        public IAttackBonusSection AttackBonuses { get; }

        /// <summary>
        /// Returns this Character's CMB.
        /// </summary>
        public ICombatManeuverBonus CombatManeuverBonus { get; }

        /// <summary>
        /// Returns this Character's CMD.
        /// </summary>
        public ICombatManeuverDefense CombatManeuverDefense { get; }

        /// <summary>
        /// Returns this Character's equipment.
        /// </summary>
        public IEquipmentSection Equipment { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Trains this character in a feat.
        /// </summary>
        public void Train(IFeat feat)
        {
            if (_feats.Contains(feat)) return; // Ignore attempts to train a feat that has already been trained.
            _feats.Add(feat);
			feat.ApplyTo(this);
        }
        #endregion
    }
}