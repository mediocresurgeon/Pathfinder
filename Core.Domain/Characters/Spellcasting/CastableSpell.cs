using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// A spell which is ready for a character to cast.
    /// </summary>
    internal class CastableSpell : ICastableSpell
    {
        #region Backing variables
        private readonly ISpell _spell;
        private readonly IAbilityScore _keyAbilityScore;
        private readonly ICasterLevel _casterLevel;
		#endregion

		#region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Spellcasting.CastableSpell"/> class.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="keyAbilityScore">The ability scored which is tied to the DC of this spell.</param>
        /// <param name="baseCasterLevel">The base caster level of this spell.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal CastableSpell(ISpell spell, IAbilityScore keyAbilityScore, Func<byte> baseCasterLevel)
        {
            if (null == baseCasterLevel)
                throw new ArgumentNullException(nameof(baseCasterLevel), "Argument cannot be null.");
            _spell = spell ?? throw new ArgumentNullException($"{ nameof(spell) } argument cannot be null.");
			_keyAbilityScore = keyAbilityScore ?? throw new ArgumentNullException($"{ nameof(keyAbilityScore) } argument cannot be null.");
            _casterLevel = new CasterLevel(baseCasterLevel);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns data about the spell which is independent of the caster.
        /// </summary>
        public virtual ISpell Spell => _spell;

        public virtual ICasterLevel CasterLevel => _casterLevel;

        protected virtual IModifierTracker DcBonusesTracker { get; } = new UntypedBonusTracker();

        protected virtual IAbilityScore KeyAbilityScore => _keyAbilityScore;
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
        #endregion
    }
}