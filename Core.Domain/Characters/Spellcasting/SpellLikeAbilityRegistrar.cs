using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
	/// <summary>
	/// Associates spells-like abilities with a character, allowing spell-like ability aggregates to be calculated (such as DCs, caster levels, etc).
	/// </summary>
	internal sealed class SpellLikeAbilityRegistrar : ISpellLikeAbilityRegistrar
    {
        #region Backing variables
		private event OnSpellLikeAbilityRegisteredEventHandler _eventHandler;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.SpellRegistries.SpellLikeAbilityRegistrar"/> class.
        /// </summary>
        /// <param name="character">The character who owns the registered spell-like abilities.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public SpellLikeAbilityRegistrar(ICharacter character)
        {
            this.Character = character ?? throw new ArgumentNullException($"{ nameof(character) } argument cannot be null.");
        }
        #endregion

        #region Properties
        private ICharacter Character { get; }

        private List<ISpellLikeAbility> RegisteredSpells { get; } = new List<ISpellLikeAbility>();
        #endregion

        #region Methods
        /// <summary>
        /// Registers a spell-like ability.  The caster level is assumed to be equal to the character's level.
        /// </summary>
        /// <param name="usesPerDay">The number of times per day the spell-like ability can be used.</param>
        /// <param name="spell">The spell this spell-like ability imitates.</param>
        /// <param name="keyAbilityScore">The ability score associated with the spell-like ability.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public ISpellLikeAbility Register(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore)
		{
            return this.Register(usesPerDay, spell, keyAbilityScore, () => this.Character.Level);
		}


        /// <summary>
        /// Registers a spell-like ability.
        /// </summary>
        /// <param name="usesPerDay">The number of times per day the spell-like ability can be used.</param>
        /// <param name="spell">The spell this spell-like ability imitates.</param>
        /// <param name="keyAbilityScore">The ability score associated with the spell-like ability.</param>
        /// <param name="baseCasterLevel">The caster level of the spell-like ability.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
		public ISpellLikeAbility Register(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore, Func<byte> baseCasterLevel)
		{
			if (null == spell)
				throw new ArgumentNullException(nameof(spell), "Argument cannot be null.");
			if (null == keyAbilityScore)
                throw new ArgumentNullException(nameof(keyAbilityScore), "Argument cannot be null.");
            if (null == baseCasterLevel)
                throw new ArgumentNullException(nameof(baseCasterLevel), "Argument cannot be null.");
            ISpellLikeAbility existingSpell = this.RegisteredSpells.Where(rs => rs.Spell == spell)
															       .FirstOrDefault();
			if (null != existingSpell)
				return existingSpell;
            ISpellLikeAbility newSpell = new SpellLikeAbility(usesPerDay, spell, keyAbilityScore, baseCasterLevel);
			this.RegisteredSpells.Add(newSpell);
			_eventHandler?.Invoke(this, new SpellLikeAbilityRegisteredEventArgs(newSpell));
			return newSpell;
		}


        /// <summary>
        /// Allows an event handler to be called when a new spell-like ability is registered.
        /// </summary>
        /// <param name="handler">The callback function.</param>
		public void OnRegistered(OnSpellLikeAbilityRegisteredEventHandler handler)
		{
            if (null == handler)
                throw new ArgumentNullException(nameof(handler), "Argument cannot be null.");
			_eventHandler += handler;
		}


        /// <summary>
        /// Retuens a copy of the collection of registered spell-like abilities.
        /// </summary>
		public ISpellLikeAbility[] GetSpellLikeAbilities()
        {
            return this.RegisteredSpells.ToArray();
        }
        #endregion
    }
}