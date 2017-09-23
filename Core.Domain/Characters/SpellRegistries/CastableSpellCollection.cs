using System;
using System.Collections.Generic;


namespace Core.Domain.Characters.SpellRegistries
{
    /// <summary>
    /// A collection of ready-to-cast spells, such as the spells prepared by a Cleric.
    /// </summary>
    internal sealed class CastableSpellCollection : ICastableSpellCollection
    {
        #region Backing variables
        private readonly List<ICastableSpell> _spells;
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="T:Core.Domain.Characters.SpellRegistries.CastableSpellCollection"/> class.
		/// </summary>
		internal CastableSpellCollection()
        {
            _spells = new List<ICastableSpell>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the spell to this collection.
        /// </summary>
        /// <param name="spell">The spell to add.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when spell argument is null.</exception>
        public void Add(ICastableSpell spell)
        {
            if (null == spell)
                throw new ArgumentNullException($"{ nameof(spell) } argument cannot be null.");
            _spells.Add(spell);
        }


        /// <summary>
        /// Returns the subset of spells which have a matching level.
        /// </summary>
        /// <returns>The spells.</returns>
        public ICastableSpell[] GetAll()
        {
            return _spells.ToArray();
        }
        #endregion
    }
}