using System;
using System.Collections.Generic;
using System.Linq;


namespace Core.Domain.Characters.SpellRegistries
{
    /// <summary>
    /// A collection of registered spells, such as the spells prepared by a Cleric.
    /// </summary>
    internal sealed class RegisteredSpellCollection : IRegisteredSpellCollection
    {
        #region Backing variables
        private readonly List<IRegisteredSpell> _spells;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.SpellRegistries.RegisteredSpellsCollection"/> class.
        /// </summary>
        internal RegisteredSpellCollection()
        {
            _spells = new List<IRegisteredSpell>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the registered spell to this collection.
        /// </summary>
        /// <param name="spell">The registered spell to add.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when spell argument is null.</exception>
        public void Add(IRegisteredSpell spell)
        {
            if (null == spell)
                throw new ArgumentNullException($"{ nameof(spell) } argument cannot be null.");
            _spells.Add(spell);
        }


        /// <summary>
        /// Returns the subset of spells which have a matching level.
        /// </summary>
        /// <returns>The registered spells.</returns>
        /// <param name="level">The spell level to filter by.</param>
        public IRegisteredSpell[] GetSpellsByLevel(byte level)
        {
            return _spells.Where(s => level == s.Spell.Level)
                          .ToArray();
        }
        #endregion
    }
}