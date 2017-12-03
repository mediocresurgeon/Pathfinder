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
        /// <param name="spellLevel">The spell's level.</param>
		private CureLightWounds(byte spellLevel)
            : base(name:       "Cure Light Wounds",
                   webAddress: "http://www.d20pfsrd.com/magic/all-spells/c/cure-light-wounds",
                   spellLevel: spellLevel)
        {
			// Intentionally blank
		}


        /// <summary>
        /// Cure Light Wounds allows a saving throw.
        /// </summary>
        public override bool AllowsSavingThrow => true;


        /// <summary>
        /// Cure Light Wounds is a conjuration spell.
        /// </summary>
        public override School School => School.Conjuration;


        /// <summary>
        /// Cure Light Wounds does not have descriptors.
        /// </summary>
		public override Descriptor[] GetDescriptors() => new Descriptor[0];


        /// <summary>
        /// Cure Light Wounds belongs to the Healing subschool.
        /// </summary>
		public override Subschool[] GetSubschools() => new[] { Subschool.Healing };


        /// <summary>
        /// Returns a Bard version of Cure Light Wounds.
        /// </summary>
        public static CureLightWounds BardVersion => new CureLightWounds(1);


		/// <summary>
		/// Returns a Cleric version of Cure Light Wounds.
		/// </summary>
        public static CureLightWounds ClericVersion => new CureLightWounds(1);


		/// <summary>
		/// Returns a Druid version of Cure Light Wounds.
		/// </summary>
        public static CureLightWounds DruidVersion => new CureLightWounds(1);


		/// <summary>
		/// Returns a Paladin version of Cure Light Wounds.
		/// </summary>
        public static CureLightWounds PaladinVersion => new CureLightWounds(1);


		/// <summary>
		/// Returns a Ranger version of Cure Light Wounds.
		/// </summary>
        public static CureLightWounds RangerVersion => new CureLightWounds(2);


		/// <summary>
		/// Returns a Healing Domain version of Cure Light Wounds.
		/// </summary>
        public static CureLightWounds HealingDomainVersion => new CureLightWounds(1);
    }
}