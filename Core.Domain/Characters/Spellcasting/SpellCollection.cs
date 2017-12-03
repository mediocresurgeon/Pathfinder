using System;
using System.Collections.Generic;
using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
	/// <summary>
	/// A collection of spells, such as the spells in a spellbook or a witch's familiar.
	/// </summary>
	internal sealed class SpellCollection : ISpellCollection
    {
		#region Constructor
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegistries.SpellCollection"/> class.
        /// </summary>
		internal SpellCollection()
		{
			// Intentionally blank
		}
        #endregion

        #region Properties
        private List<ISpell> Spells { get; } = new List<ISpell>();
        #endregion

        #region Methods
        /// <summary>
        /// Adds the spell to this collection.
        /// </summary>
        /// <param name="spell">The spell to add.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when spell argument is null.</exception>
        public void Add(ISpell spell)
		{
			if (null == spell)
				throw new ArgumentNullException($"{ nameof(spell) } argument cannot be null.");
			this.Spells.Add(spell);
		}


		/// <summary>
		/// Returns all spells in this collection.
		/// </summary>
		public ISpell[] GetAllSpells()
		{
			return this.Spells.ToArray();
		}
		#endregion
	}
}