using System;
using System.Collections.Generic;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Feats;
using Core.Domain.Characters.Movements;
using Core.Domain.Characters.Skills;
using Core.Domain.Characters.SpellRegistries;
using Core.Domain.Items;


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
                throw new ArgumentOutOfRangeException($"Invalid character level ({ level }): Character levels must be between 1 and 20 (inclusive).");
            this.Level = level;
            this.SpellRegistrar = new SpellRegistrar(this);
            this.SpellLikeAbilityRegistrar = new SpellLikeAbilityRegistrar(this);
            _feats = new List<IFeat>();
            this.Skills = new SkillSection(this);
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

        #region Movements
        /// <summary>
        /// Returns this character's burrow speed.
        /// It has a null default base speed.
        /// </summary>
        internal Movement BurrowSpeed { get; } = new Movement();

        IMovement ICharacter.BurrowSpeed => this.BurrowSpeed;


		/// <summary>
		/// Returns this character's climb speed.
		/// It has a null default base speed.
		/// </summary>
		internal Movement ClimbSpeed { get; } = new Movement();

        IMovement ICharacter.ClimbSpeed => this.ClimbSpeed;


		/// <summary>
		/// Returns this character's fly speed.
		/// It has a null default base speed.
		/// </summary>
		internal Movements.Fly FlySpeed { get; } = new Movements.Fly();

        IFly ICharacter.FlySpeed => this.FlySpeed;


        /// <summary>
        /// Returns this character's land speed.
        /// It has a default base speed of 6 squares.
        /// </summary>
        internal Movement LandSpeed { get; } = new Movement { BaseSpeed = 6 };

        IMovement ICharacter.LandSpeed => this.LandSpeed;


		/// <summary>
		/// Returns this character's swim speed.
		/// It has a null default base speed.
		/// </summary>
		internal Movement SwimSpeed { get; } = new Movement();

        IMovement ICharacter.SwimSpeed => this.SwimSpeed;
        #endregion

        #region Ability scores
        /// <summary>
        /// Returns this character's Strength score.
        /// It has a default base score of 10.
        /// </summary>
        internal AbilityScore Strength { get; } = new Strength { BaseScore = 10 };

        IAbilityScore ICharacter.Strength => this.Strength;


        /// <summary>
        /// Returns this character's Dexterity score.
        /// It has a default base score of 10.
        /// </summary>
        internal AbilityScore Dexterity { get; } = new Dexterity { BaseScore = 10 };

        IAbilityScore ICharacter.Dexterity => this.Dexterity;


        /// <summary>
        /// Returns this character's Constitution score.
        /// It has a default base score of 10.
        /// </summary>
        internal AbilityScore Constitution { get; } = new Constitution { BaseScore = 10 };

        IAbilityScore ICharacter.Constitution => this.Constitution;


        /// <summary>
        /// Returns this character's Intelligence score.
        /// It has a default base score of 10.
        /// </summary>
        internal AbilityScore Intelligence { get; } = new Intelligence { BaseScore = 10 };

        IAbilityScore ICharacter.Intelligence => this.Intelligence;


        /// <summary>
        /// Returns this character's Wisdom score.
        /// It has a default base score of 10.
        /// </summary>
        internal AbilityScore Wisdom { get; } = new Wisdom { BaseScore = 10 };

        IAbilityScore ICharacter.Wisdom => this.Wisdom;


        /// <summary>
        /// Returns this character's Charisma score.
        /// It has a default base score of 10.
        /// </summary>
        internal AbilityScore Charisma { get; } = new Charisma { BaseScore = 10 };

        IAbilityScore ICharacter.Charisma => this.Charisma;
        #endregion

        public ISkillSection Skills { get; }

        #region Spells
        /// <summary>
        /// Returns this character's spell register.
        /// </summary>
        /// <value>The spell register.</value>
        public ISpellRegistrar SpellRegistrar { get; }


        /// <summary>
        /// Returns or assigns the spellbook this character uses to prepare spells.
        /// Can be null.
        /// </summary>
        public ISpellbook Spellbook { get; set; }


        /// <summary>
        /// Returns the collection of spells prepared by this character.
        /// </summary>
        public ICastableSpellCollection SpellsPrepared { get; } = new CastableSpellCollection();


        /// <summary>
        /// Returns the collection of spells known by this character.
        /// </summary>
        public ICastableSpellCollection SpellsKnown { get; } = new CastableSpellCollection();


		/// <summary>
		/// Returns this character's spell-like ability register.
		/// </summary>
        public ISpellLikeAbilityRegistrar SpellLikeAbilityRegistrar { get; }


        /// <summary>
        /// Returns the collection of spell-like abilities known by this character.
        /// </summary>
        public ISpellLikeAbilityCollection SpellLikeAbilities { get; } = new SpellLikeAbilityCollection();
        #endregion
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