using System;
using System.Collections.Generic;


namespace Core.Domain.Characters.SpellRegistries
{
    internal sealed class SpellLikeAbilityCollection : ISpellLikeAbilityCollection
    {
		#region Backing variables
        private readonly List<ISpellLikeAbility> _spells;
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="T:Core.Domain.Characters.SpellRegistries.CastableSpellsCollection"/> class.
		/// </summary>
		internal SpellLikeAbilityCollection()
		{
			_spells = new List<ISpellLikeAbility>();
		}
		#endregion

		#region Methods
		/// <summary>
		/// Adds the spell-like ability to this collection.
		/// </summary>
		/// <param name="spell">The spell-like ability to add.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when spell argument is null.</exception>
        public void Add(ISpellLikeAbility spell)
		{
			if (null == spell)
				throw new ArgumentNullException($"{ nameof(spell) } argument cannot be null.");
			_spells.Add(spell);
		}


		/// <summary>
		/// Returns the subset of spell-like abilities which have a matching level.
		/// </summary>
		/// <returns>The spell-like abilities.</returns>
		public ISpellLikeAbility[] GetAll()
		{
			return _spells.ToArray();
		}
		#endregion
	}
}