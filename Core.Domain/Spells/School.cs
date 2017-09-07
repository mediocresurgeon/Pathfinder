namespace Core.Domain.Spells
{
	/// <summary>
	/// A school of magic is a group of related spells that work in similar ways.
	/// </summary>
    /// <remarks>See this page for details: http://www.d20pfsrd.com/magic#TOC-School-Subschool-</remarks>
	public enum School
    {
        /// <summary>
        /// Abjurations are protective spells.
        /// </summary>
        Abjuration,

        /// <summary>
        /// Conjurations are spells which transport creatures,
        /// objects,
        /// or energy.
        /// </summary>
        Conjuration,

		/// <summary>
		/// Divination spells enable you to learn secrets long forgotten,
        /// predict the future,
        /// find hidden things,
        /// and foil deceptive spells.
		/// </summary>
		Divination,

		/// <summary>
		/// Enchantment spells affect the minds of others,
        /// influencing or controlling their behavior.
		/// </summary>
		Enchantment,

		/// <summary>
		/// Evocation spells manipulate magical energy
        /// or tap an unseen source of power
        /// to create something out of nothing.
		/// </summary>
		Evocation,

		/// <summary>
		/// Illusion spells deceive the senses or minds of others.
		/// </summary>
		Illusion,

		/// <summary>
		/// Necromancy spells manipulate the power of death,
        /// unlife,
        /// and the life force.
		/// </summary>
		Necromancy,

		/// <summary>
		/// Transmutation spells change the properties of some creature,
        /// thing,
        /// or condition.
		/// </summary>
		Transmutation,
    }
}