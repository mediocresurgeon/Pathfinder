namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    /// <summary>
    /// Summons ghostly lights which move up to 100ft per round.
    /// </summary>
    public sealed class DancingLights : Spell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Paizo.CoreRulebook.DancingLights"/> class.
        /// </summary>
        /// <param name="spellLevel">This spell's level.</param>
        private DancingLights(byte spellLevel)
			: base(name:       "Dancing Lights",
				   webAddress: "http://www.d20pfsrd.com/magic/all-spells/d/dancing-lights",
				   spellLevel: spellLevel)
        {
            // Intentionally blank
        }


        /// <summary>
        /// Dancing Lights does not allow a saving throw.
        /// </summary>
        public override bool AllowsSavingThrow => false;


        /// <summary>
        /// Dancing Lights is an Evocation spell.
        /// </summary>
        public override School School => School.Evocation;


        /// <summary>
        /// Dancing Lights has a Light descriptor.
        /// </summary>
		public override Descriptor[] GetDescriptors() => new[] { Descriptor.Light };


        /// <summary>
        /// Dancing Lights does not have a subschool.
        /// </summary>
		public override Subschool[] GetSubschools() => new Subschool[0];


		/// <summary>
		/// Returns a Bard version of Dancing Lights.
		/// </summary>
        public static DancingLights BardVersion => new DancingLights(0);


		/// <summary>
		/// Returns a Sorcerer version of Dancing Lights.
		/// </summary>
        public static DancingLights SorcererVersion => new DancingLights(0);


		/// <summary>
		/// Returns a Wizard version of Dancing Lights.
		/// </summary>
        public static DancingLights WizardVersion => new DancingLights(0);
    }
}