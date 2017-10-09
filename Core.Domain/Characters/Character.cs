using System;
using System.Collections.Generic;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ArmorClasses;
using Core.Domain.Characters.BaseAttackBonuses;
using Core.Domain.Characters.CombatManeuverDefenses;
using Core.Domain.Characters.Feats;
using Core.Domain.Characters.Initiatives;
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
            this.BaseAttackBonus = new BaseAttackBonus(this);
            this.CombatManeuverDefense = new CombatManeuverDefense(this);
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

        public IMovementSection MovementModes { get; } = new MovementSection(); 

        public IAbilityScoreSection AbilityScores { get; } = new AbilityScoreSection();

        public IInitiative Initiative { get; }

        public ISavingThrowSection SavingThrows { get; }

        public ISkillSection Skills { get; }

        public ISpellSection Spells { get; }

        public ISpellLikeAbilitySection SpellLikeAbilities { get; }

        public IArmorClass ArmorClass { get; }

        public IBaseAttackBonus BaseAttackBonus { get; }

        public ICombatManeuverDefense CombatManeuverDefense { get; }
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