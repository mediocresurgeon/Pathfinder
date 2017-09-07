namespace Core.Domain.Spells
{
    /// <summary>
    /// Positive energy heals the living and damages undead.
    /// </summary>
    public sealed class CureLightWounds : Spell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.CureLightWounds"/> class.
        /// </summary>
        /// <param name="level">The spell's level.</param>
		private CureLightWounds(byte level)
            : base(name:       "Cure Light Wounds",
                   webAddress: "http://www.d20pfsrd.com/magic/all-spells/c/cure-light-wounds",
                   school:     School.Conjuration,
                   level:      level,
                   subschools: new[] { Subschool.Healing })
        {
			// Intentionally blank
		}

        /// <summary>
        /// Returns a Bard version of Cure Light Wounds.
        /// </summary>
		public static CureLightWounds AsBard
		{
			get { return new CureLightWounds(1); }
		}

		/// <summary>
		/// Returns a Cleric version of Cure Light Wounds.
		/// </summary>
		public static CureLightWounds AsCleric
        {
            get { return new CureLightWounds(1); }
        }

		/// <summary>
		/// Returns a Druid version of Cure Light Wounds.
		/// </summary>
		public static CureLightWounds AsDruid
		{
			get { return new CureLightWounds(1); }
		}

		/// <summary>
		/// Returns a Paladin version of Cure Light Wounds.
		/// </summary>
		public static CureLightWounds AsPaladin
		{
			get { return new CureLightWounds(1); }
		}

		/// <summary>
		/// Returns a Ranger version of Cure Light Wounds.
		/// </summary>
		public static CureLightWounds AsRanger
		{
			get { return new CureLightWounds(2); }
		}

		/// <summary>
		/// Returns a Healing Domain version of Cure Light Wounds.
		/// </summary>
		public static CureLightWounds AsHealingDomain
		{
			get { return new CureLightWounds(1); }
		}
    }
}