using System;
using System.Collections.Generic;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Feats;
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
        private readonly byte _level;
        private readonly SpellRegistrar _spellRegistrar;
        private readonly SpellLikeAbilityRegistrar _spellLikeAbilityRegistrar;
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
            _level = level;
            _spellRegistrar = new SpellRegistrar(this);
            _spellLikeAbilityRegistrar = new SpellLikeAbilityRegistrar(this);
            _feats = new List<IFeat>();
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
        public byte Level => _level;

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

        #region Spells
        /// <summary>
        /// Returns this character's spell register.
        /// </summary>
        /// <value>The spell register.</value>
        public ISpellRegistrar SpellRegistrar => _spellRegistrar;


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
		public ISpellLikeAbilityRegistrar SpellLikeAbilityRegistrar => _spellLikeAbilityRegistrar;


        /// <summary>
        /// Returns the collection of spell-like abilities known by this character.
        /// </summary>
        public ISpellLikeAbilityCollection SpellLikeAbilities { get; } = new SpellLikeAbilityCollection();
        #endregion

        #region Feats
        public 
        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// Trains this character in a feat.
        /// </summary>
        void Train(IFeat feat)
        {
            if (_feats.Contains(feat)) return; // Ignore attempts to train a feat that has already been trained.
            _feats.Add(feat);
			feat.ApplyTo(this);
        }
        #endregion
    }
}