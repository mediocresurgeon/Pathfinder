using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
	/// <summary>
	/// A collection of spells, such as the spells in a spellbook or a witch's familiar.
	/// </summary>
	internal sealed class SpellCollection : ISpellCollection
    {
		#region Backing variables
		private readonly List<ISpell> _spells;
		#endregion

		#region Constructor
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegistries.SpellCollection"/> class.
        /// </summary>
		internal SpellCollection()
		{
			_spells = new List<ISpell>();
		}
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
			_spells.Add(spell);
		}


		/// <summary>
		/// Returns the subset of spells which have a matching level.
		/// </summary>
		/// <returns>The spells.</returns>
		/// <param name="level">The spell level to filter by.</param>
		public ISpell[] GetSpellsByLevel(byte level)
		{
			return _spells.Where(s => level == s.Level)
						  .ToArray();
		}
		#endregion
	}
}