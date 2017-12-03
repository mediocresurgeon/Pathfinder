namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    /// <summary>
    /// Missiles of force strike targets.
    /// </summary>
    public sealed class MagicMissile : Spell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.MagicMissile"/> class.
        /// </summary>
        /// <param name="spellLevel">The spell's level.</param>
        private MagicMissile(byte spellLevel)
            : base(name:       "Magic Missile",
                   webAddress: "http://www.d20pfsrd.com/magic/all-spells/m/magic-missile",
                   spellLevel: spellLevel)
        {
            // Intentionally blank
        }


        /// <summary>
        /// Magic Missile does not allow saving throws.
        /// </summary>
        public override bool AllowsSavingThrow => false;


        /// <summary>
        /// Magic Missile is an Evocation spell.
        /// </summary>
        public override School School => School.Evocation;


        /// <summary>
        /// Magic Missile has a Force descriptor.
        /// </summary>
		public override Descriptor[] GetDescriptors() => new[] { Descriptor.Force };


        /// <summary>
        /// Magic Missile has no subschools.
        /// </summary>
		public override Subschool[] GetSubschools() => new Subschool[0];


        /// <summary>
        /// Returns a Sorcerer version of Magic Missile.
        /// </summary>
        public static MagicMissile SorcererVersion => new MagicMissile(1);


		/// <summary>
		/// Returns a Wizard version of Magic Missile.
		/// </summary>
        public static MagicMissile WizardVersion => new MagicMissile(1);
    }
}