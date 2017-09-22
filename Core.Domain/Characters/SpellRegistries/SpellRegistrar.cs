using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
    /// <summary>
    /// Associates spells with a character, allowing spell-related things to be calculated (such as DCs, caster levels, etc).
    /// </summary>
    internal sealed class SpellRegistrar : ISpellRegistrar
    {
        private readonly ICharacter _character;
        private readonly List<ICastableSpell> _registeredSpells;
        private event OnSpellRegisteredEventHandler _eventHandler;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegistrar"/> class.
		/// </summary>
		/// <param name="character">The character to register spells to.  Should not bell null.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when character argument is null.</exception>
		internal SpellRegistrar(ICharacter character)
        {
            _character = character ?? throw new ArgumentNullException($"Failed to construct SpellRegistrar: { nameof(character) } argument annot be null.");
            _registeredSpells = new List<ICastableSpell>();
        }


		/// <summary>
		/// Registers a spell.  The spell's caster level is assumed to be the character's level.
		/// </summary>
		/// <returns>The registered spell.</returns>
		/// <param name="spell">The spell to register.</param>
		/// <param name="keyAbilityScore">The ability score which powers the spell.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		public ICastableSpell Register(ISpell spell, IAbilityScore keyAbilityScore)
        {
            return this.Register(spell, keyAbilityScore, _character.Level);
        }


		/// <summary>
		/// Registers a spell.
		/// </summary>
		/// <returns>The registered spell.</returns>
		/// <param name="spell">The spell to register.</param>
        /// <param name="keyAbilityScore">The ability score which powers the spell.</param>
        /// <param name="casterLevel">The spell's caster level.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		public ICastableSpell Register(ISpell spell, IAbilityScore keyAbilityScore, byte casterLevel)
        {
            if (null == spell)
                throw new ArgumentNullException($"{ nameof(spell) } argument cannot be null.");
            if (null == keyAbilityScore)
                throw new ArgumentNullException($"{ nameof(keyAbilityScore) } argument cannot be null.");
            ICastableSpell existingSpell = _registeredSpells.Where(rs => rs.Spell == spell)
                                                             .FirstOrDefault();
            if (null != existingSpell)
                return existingSpell;
            ICastableSpell newSpell = new CastableSpell(spell, keyAbilityScore, casterLevel);
            _registeredSpells.Add(newSpell);
            _eventHandler?.Invoke(this, new SpellRegisteredEventArgs(newSpell));
            return newSpell;
        }


        /// <summary>
        /// Allows an event handler to be called whenever a new spell is registered.
        /// </summary>
        /// <param name="handler">Handler.</param>
        public void OnSpellRegistered(OnSpellRegisteredEventHandler handler)
        {
            _eventHandler += handler;
        }


        /// <summary>
        /// Returns a copy of the collection of registered spells.
        /// </summary>
        /// <returns>The registered spells.</returns>
        public ICastableSpell[] GetSpells()
        {
            return _registeredSpells.ToArray();
        }
    }
}