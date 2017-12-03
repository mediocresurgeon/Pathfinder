namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    /// <summary>
    /// Touched subject can fly with Good maneuverability
    /// and an untyped bonus on Fly skill checks
    /// for 1 min/level.
    /// </summary>
    public sealed class Fly : Spell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Paizo.CoreRulebook.Fly"/> class.
        /// </summary>
        /// <param name="spellLevel">The level of this spell.</param>
        private Fly(byte spellLevel)
            : base(name:       "Fly",
                   webAddress: "http://www.d20pfsrd.com/magic/all-spells/f/fly",
                   spellLevel: spellLevel)
        {
            // Intentionally blank
        }


        /// <summary>
        /// Fly allows a saving throw.
        /// </summary>
        public override bool AllowsSavingThrow => true;


        /// <summary>
        /// Fly is a Transmutation spell.
        /// </summary>
        public override School School => School.Transmutation;


        /// <summary>
        /// Fly has no descriptors.
        /// </summary>
        public override Descriptor[] GetDescriptors() => new Descriptor[0];


        /// <summary>
        /// Fly has no subschools.
        /// </summary>
        public override Subschool[] GetSubschools() => new Subschool[0];


        /// <summary>
        /// Returns a Sorcerer version of Fly.
        /// </summary>
        public static Fly SorcererVersion => new Fly(3);


        /// <summary>
        /// Returns a Wizard version of Fly.
        /// </summary>
        public static Fly WizardVersion => new Fly(3);


        /// <summary>
        /// Returns a Travel Domain version of Fly.
        /// </summary>
        public static Fly TravelDomainVersion => new Fly(3);


        /// <summary>
        /// Returns a Void Domain version of Fly.
        /// </summary>
        public static Fly VoidDomainVersion => new Fly(3);
    }
}
