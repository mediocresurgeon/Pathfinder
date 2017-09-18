namespace Core.Domain.Spells.Paizo.CoreRulebook
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
            : base(name:              "Cure Light Wounds",
                   webAddress:        "http://www.d20pfsrd.com/magic/all-spells/c/cure-light-wounds",
                   school:            School.Conjuration,
                   level:             level,
                   allowsSavingThrow: true,
                   subschools:        new[] { Subschool.Healing })
        {
			// Intentionally blank
		}

        /// <summary>
        /// Returns a Bard version of Cure Light Wounds.
        /// </summary>
		public static CureLightWounds BardVersion
		{
			get { return new CureLightWounds(1); }
		}

		/// <summary>
		/// Returns a Cleric version of Cure Light Wounds.
		/// </summary>
		public static CureLightWounds ClericVersion
        {
            get { return new CureLightWounds(1); }
        }

		/// <summary>
		/// Returns a Druid version of Cure Light Wounds.
		/// </summary>
		public static CureLightWounds DruidVersion
		{
			get { return new CureLightWounds(1); }
		}

		/// <summary>
		/// Returns a Paladin version of Cure Light Wounds.
		/// </summary>
		public static CureLightWounds PaladinVersion
		{
			get { return new CureLightWounds(1); }
		}

		/// <summary>
		/// Returns a Ranger version of Cure Light Wounds.
		/// </summary>
		public static CureLightWounds RangerVersion
		{
			get { return new CureLightWounds(2); }
		}

		/// <summary>
		/// Returns a Healing Domain version of Cure Light Wounds.
		/// </summary>
		public static CureLightWounds HealingDomainVersion
		{
			get { return new CureLightWounds(1); }
		}
    }
}