using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.SpellRegistries;


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
		internal SpellRegistrar SpellRegistrar => _spellRegistrar;

		ISpellRegistrar ICharacter.SpellRegistrar => this.SpellRegistrar;
		#endregion
		#endregion
	}
}