using System;
using System.Collections.Generic;


namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// A collection of ready-to-cast spells, such as the spells prepared by a Cleric.
    /// </summary>
    internal sealed class CastableSpellCollection : ICastableSpellCollection
    {
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="T:Core.Domain.Characters.SpellRegistries.CastableSpellCollection"/> class.
		/// </summary>
		internal CastableSpellCollection()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        private List<ICastableSpell> Spells { get; } = new List<ICastableSpell>();
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
            this.Spells.Add(spell);
        }


        /// <summary>
        /// Returns the spells in this collection.
        /// </summary>
        /// <returns>The spells.</returns>
        public ICastableSpell[] GetAllSpells()
        {
            return this.Spells.ToArray();
        }
        #endregion
    }
}