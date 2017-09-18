using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
    /// <summary>
    /// A spell which has been registered to a character.
    /// </summary>
    public sealed class RegisteredSpell : IRegisteredSpell
    {
        #region Backing variables
        private readonly ISpell _spell;
        private readonly IAbilityScore _keyAbilityScore;
        private readonly byte _casterLevel;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegistries.RegisteredSpell"/> class.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="keyAbilityScore">The ability score which powers the spell.</param>
        /// <param name="casterLevel">The spell's caster level.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        internal RegisteredSpell(ISpell spell, IAbilityScore keyAbilityScore, byte casterLevel)
        {
            _spell = spell ?? throw new ArgumentNullException($"{ nameof(spell) } argument cannot be null.");
            _keyAbilityScore = keyAbilityScore ?? throw new ArgumentNullException($"{ nameof(keyAbilityScore) } argument cannot be null.");
            _casterLevel = casterLevel;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns data about the spell which is independent of the caster.
        /// </summary>
        public ISpell Spell => _spell;
        #endregion

        #region Methods
        /// <summary>
        /// Returns the difficulty class of the spell, factoring in the character's stats and abilities.
        /// </summary>
        public byte? GetDifficultyClass()
        {
            if (!Spell.AllowsSavingThrow)
                return null;
            byte runningTotal = 10;
            runningTotal += Spell.Level;
            runningTotal += _keyAbilityScore.GetBonus();
            return runningTotal;
        }


        /// <summary>
        /// Returns the effective caster level of the spell, factoring in the character's stats and abilities.
        /// </summary>
        public byte GetEffectiveCasterLevel()
        {
            return _casterLevel;
        }
        #endregion
    }
}