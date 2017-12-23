using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// Associates spells with a character, allowing spell-related things to be calculated (such as DCs, caster levels, etc).
    /// </summary>
    internal sealed class SpellRegistrar : ISpellRegistrar
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegistrar"/> class.
        /// </summary>
        /// <param name="character">The character to register spells to.  Should not bell null.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when character argument is null.</exception>
        internal SpellRegistrar(ICharacter character)
        {
            this.Character = character ?? throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
        }
        #endregion

        #region Properties
        public event EventHandler<SpellRegisteredEventArgs> OnRegistered;


        private ICharacter Character { get; }


        private List<ICastableSpell> RegisteredSpells { get; } = new List<ICastableSpell>();
        #endregion

        #region Methods
        /// <summary>
        /// Registers a spell.  The spell's caster level is assumed to be the character's level.
        /// </summary>
        /// <returns>The registered spell.</returns>
        /// <param name="spell">The spell to register.</param>
        /// <param name="keyAbilityScore">The ability score which powers the spell.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public ICastableSpell Register(ISpell spell, IAbilityScore keyAbilityScore)
        {
            return this.Register(spell, keyAbilityScore, () => this.Character.Level);
        }


        /// <summary>
        /// Registers a spell.
        /// </summary>
        /// <returns>The registered spell.</returns>
        /// <param name="spell">The spell to register.</param>
        /// <param name="keyAbilityScore">The ability score which powers the spell.</param>
        /// <param name="baseCasterLevel">The spell's caster level.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public ICastableSpell Register(ISpell spell, IAbilityScore keyAbilityScore, Func<byte> baseCasterLevel)
        {
            if (null == spell)
                throw new ArgumentNullException(nameof(spell), "Argument cannot be null.");
            if (null == keyAbilityScore)
                throw new ArgumentNullException(nameof(keyAbilityScore), "Argument cannot be null.");
            if (null == baseCasterLevel)
                throw new ArgumentNullException(nameof(baseCasterLevel), "Argument cannot be null.");
            ICastableSpell existingSpell = this.RegisteredSpells.Where(rs => rs.Spell == spell)
                                                                .FirstOrDefault();
            if (null != existingSpell)
                return existingSpell;
            ICastableSpell newSpell = new CastableSpell(spell, keyAbilityScore, baseCasterLevel);
            this.RegisteredSpells.Add(newSpell);
            this.OnRegistered?.Invoke(this, new SpellRegisteredEventArgs(newSpell));
            return newSpell;
        }


        /// <summary>
        /// Returns a copy of the collection of registered spells.
        /// </summary>
        /// <returns>The registered spells.</returns>
        public ICastableSpell[] GetSpells()
        {
            return this.RegisteredSpells.ToArray();
        }
        #endregion
    }
}