namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    /// <summary>
    /// An invisibile barrier which prevents the function of magic within its confines.
    /// </summary>
    public sealed class AntimagicField : Spell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.AntimagicField"/> class.
        /// </summary>
        /// <param name="spellLevel">The level of this spell.</param>
        private AntimagicField(byte spellLevel)
            : base(name:       "Antimagic Field",
                   webAddress: "http://www.d20pfsrd.com/magic/all-spells/a/antimagic-field",
                   spellLevel: spellLevel)
        {
			// Intentionally blank
		}


        /// <summary>
        /// Antimagic Field does not allow saving throws.
        /// </summary>
        public override bool AllowsSavingThrow => false;


        /// <summary>
        /// Antimagic Field is an Abjuration spell.
        /// </summary>
        public override School School => School.Abjuration;


        /// <summary>
        /// Antimagic Field has no descriptors.
        /// </summary>
		public override Descriptor[] GetDescriptors() => new Descriptor[0];


        /// <summary>
        /// Antimagic Field has no subschools.
        /// </summary>
		public override Subschool[] GetSubschools() => new Subschool[0];


		/// <summary>
		/// Returns a Cleric version of Antimagic Field.
		/// </summary>
        public static AntimagicField ClericVersion => new AntimagicField(8);


		/// <summary>
		/// Returns a Sorcerer version of Antimagic Field.
		/// </summary>
        public static AntimagicField SorcererVersion => new AntimagicField(6);


		/// <summary>
		/// Returns a Wizard version of Antimagic Field.
		/// </summary>
        public static AntimagicField WizardVersion => new AntimagicField(6);


		/// <summary>
		/// Returns a Magic Domain version of Antimagic Field.
		/// </summary>
        public static AntimagicField MagicDomainVersion => new AntimagicField(6);


		/// <summary>
		/// Returns a Protection Domain version of Antimagic Field.
		/// </summary>
        public static AntimagicField ProtectionDomainVersion => new AntimagicField(6);
    }
}