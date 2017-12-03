namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    /// <summary>
    /// Provides an enhancement bonus to natural armor.
    /// </summary>
    public sealed class Barkskin : Spell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Barkskin"/> class.
        /// </summary>
        /// <param name="spellLevel">The spell level.</param>
        private Barkskin(byte spellLevel)
				: base(name:       "Barkskin",
                       webAddress: "http://www.d20pfsrd.com/magic/all-spells/b/barkskin/",
                       spellLevel: spellLevel)
        {
            // Intentionally blank
        }


        /// <summary>
        /// Barkskin does not allow saving throws.
        /// </summary>
        public override bool AllowsSavingThrow => false;


        /// <summary>
        /// Barkskin is a Transmutation spell.
        /// </summary>
        public override School School => School.Transmutation;


        /// <summary>
        /// Barkskin has no descriptors.
        /// </summary>
		public override Descriptor[] GetDescriptors() => new Descriptor[0];


        /// <summary>
        /// Barkskin has no subschools.
        /// </summary>
		public override Subschool[] GetSubschools() => new Subschool[0];


		/// <summary>
		/// Returns a Druid version of Barkskin.
		/// </summary>
        public static Barkskin DruidVersion => new Barkskin(2);


		/// <summary>
		/// Returns a Ranger version of Barkskin.
		/// </summary>
        public static Barkskin RangerVersion => new Barkskin(2);


        /// <summary>
        /// Returns a Defense Subdomain version of Barkskin.
        /// </summary>
        public static Barkskin DefenseSubdomainVersion => new Barkskin(2);


		/// <summary>
		/// Returns a Plant Domain version of Barkskin.
		/// </summary>
        public static Barkskin PlantDomainVersion => new Barkskin(2);
    }
}