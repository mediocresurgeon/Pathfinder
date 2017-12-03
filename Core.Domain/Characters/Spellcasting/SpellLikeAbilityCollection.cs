using System;
using System.Collections.Generic;


namespace Core.Domain.Characters.Spellcasting
{
    internal sealed class SpellLikeAbilityCollection : ISpellLikeAbilityCollection
    {
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="T:Core.Domain.Characters.SpellRegistries.CastableSpellsCollection"/> class.
		/// </summary>
		internal SpellLikeAbilityCollection()
		{
			// Intentionally blank
		}
        #endregion

        #region Properties
        private List<ISpellLikeAbility> Spells { get; } = new List<ISpellLikeAbility>();
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
			this.Spells.Add(spell);
		}


		/// <summary>
		/// Returns all spell-like abilities in this collection.
		/// </summary>
		/// <returns>The spell-like abilities.</returns>
		public ISpellLikeAbility[] GetAllSpells()
		{
			return this.Spells.ToArray();
		}
		#endregion
	}
}