using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
    internal sealed class SpellLikeAbilityRegistrar : ISpellLikeAbilityRegistrar
    {
        #region Backing variables
        private readonly ICharacter _character;
        private readonly List<ISpellLikeAbility> _registeredSpells;
		private event OnSpellLikeAbilityRegisteredEventHandler _eventHandler;
        #endregion

        #region Constructor
        public SpellLikeAbilityRegistrar(ICharacter character)
        {
            _character = character ?? throw new ArgumentNullException($"{ nameof(character) } argument cannot be null.");
            _registeredSpells = new List<ISpellLikeAbility>();
        }
		#endregion

		#region Methods
		public ISpellLikeAbility Register(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore)
		{
            return this.Register(usesPerDay, spell, keyAbilityScore, this._character.Level);
		}


		public ISpellLikeAbility Register(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore, byte casterLevel)
		{
			if (null == spell)
				throw new ArgumentNullException($"{ nameof(spell) } argument cannot be null.");
			if (null == keyAbilityScore)
				throw new ArgumentNullException($"{ nameof(keyAbilityScore) } argument cannot be null.");
            ISpellLikeAbility existingSpell = _registeredSpells.Where(rs => rs.Spell == spell)
															   .FirstOrDefault();
			if (null != existingSpell)
				return existingSpell;
            ISpellLikeAbility newSpell = new SpellLikeAbility(usesPerDay, spell, keyAbilityScore, casterLevel);
			_registeredSpells.Add(newSpell);
			_eventHandler?.Invoke(this, new SpellLikeAbilityRegisteredEventArgs(newSpell));
			return newSpell;
		}


		public void OnSpellLikeAbilityRegistered(OnSpellLikeAbilityRegisteredEventHandler handler)
		{
			_eventHandler += handler;
		}


		public ISpellLikeAbility[] GetSpellLikeAbilities()
        {
            return _registeredSpells.ToArray();
        }
        #endregion
    }
}