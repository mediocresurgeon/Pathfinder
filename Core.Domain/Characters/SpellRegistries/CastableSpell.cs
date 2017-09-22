using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
    /// <summary>
    /// A spell which is ready for a character to cast.
    /// </summary>
    public class CastableSpell : ICastableSpell
    {
        #region Backing variables
        private readonly ISpell _spell;
        private readonly IAbilityScore _keyAbilityScore;
        private readonly ICharacter _character;
        private readonly byte? _casterLevel;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegistries.CastableSpell"/> class.
		/// </summary>
		/// <param name="spell">The spell.</param>
		/// <param name="keyAbilityScore">The ability score which powers the spell.</param>
		/// <param name="casterLevel">The spell's caster level.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		internal CastableSpell(ISpell spell, IAbilityScore keyAbilityScore, byte casterLevel)
            :this(spell, keyAbilityScore, null, casterLevel)
        {
            // Intentionally blank
        }


		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegistries.CastableSpell"/> class.
		/// </summary>
		/// <param name="spell">The spell.</param>
		/// <param name="keyAbilityScore">The ability score which powers this spell.</param>
        /// <param name="character">The character associated with this spell.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		internal CastableSpell(ISpell spell, IAbilityScore keyAbilityScore, ICharacter character)
			: this(spell, keyAbilityScore, character, null)
		{
            if (null == character)
                throw new ArgumentNullException($"{ nameof(character) } argument cannot be null.");
		}


        private CastableSpell(ISpell spell, IAbilityScore keyAbilityScore, ICharacter character, byte? casterLevel)
        {
			_spell = spell ?? throw new ArgumentNullException($"{ nameof(spell) } argument cannot be null.");
			_keyAbilityScore = keyAbilityScore ?? throw new ArgumentNullException($"{ nameof(keyAbilityScore) } argument cannot be null.");
            _character = character;
			_casterLevel = casterLevel;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns data about the spell which is independent of the caster.
        /// </summary>
        public virtual ISpell Spell => _spell;

        protected virtual IModifierTracker DcBonusesTracker { get; } = new UntypedBonusTracker();

        protected virtual IAbilityScore KeyAbilityScore => _keyAbilityScore;

        protected ICharacter Character => _character;

        protected byte? CasterLevelOverride => _casterLevel;
		#endregion

		#region Methods
        /// <summary>
        /// Adds an untyped bonus to this spell's difficulty class (DC).
        /// </summary>
        /// <param name="bonus">The bonus to add.</param>
		public void AddDifficultyClassBonus(byte bonus)
		{
			this.DcBonusesTracker.Add(bonus);
		}


        /// <summary>
        /// Returns the difficulty class of the spell, factoring in the character's stats and abilities.
        /// </summary>
        public byte? GetDifficultyClass()
        {
            if (!Spell.AllowsSavingThrow)
                return null;
            byte runningTotal = 10;
            runningTotal += this.Spell.Level;
            runningTotal += this.KeyAbilityScore.GetBonus();
            runningTotal += this.DcBonusesTracker.GetTotal();
            return runningTotal;
        }


        /// <summary>
        /// Returns the effective caster level of the spell, factoring in the character's stats and abilities.
        /// </summary>
        public virtual byte GetEffectiveCasterLevel()
        {
            if (this.CasterLevelOverride.HasValue)
                return this.CasterLevelOverride.Value;
            return this.Character.Level;
        }
        #endregion
    }
}