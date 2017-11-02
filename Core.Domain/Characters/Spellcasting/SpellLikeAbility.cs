using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// An innate ability to produce an effect similar to a spell.
    /// </summary>
    internal class SpellLikeAbility : CastableSpell, ISpellLikeAbility
    {
        #region Backing variables
        private readonly byte _usesPerDay;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegistries.SpellLikeAbility"/> class.
		/// </summary>
		/// <param name="usesPerDay">The number of times per day this spell-like ability can be used.</param>
		/// <param name="spell">The spell this spell-like ability imitates.</param>
		/// <param name="keyAbilityScore">The ability score associated with casting this spell-like ability.</param>
		/// <param name="baseCasterLevel">The caster level of this spell-like ability.</param>
		public SpellLikeAbility(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore, Func<byte> baseCasterLevel)
            : base(spell, keyAbilityScore, baseCasterLevel)
        {
            _usesPerDay = usesPerDay;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the number of times per day this spell-like ability can be used.
        /// </summary>
        public virtual byte UsesPerDay => _usesPerDay;
        #endregion
    }
}