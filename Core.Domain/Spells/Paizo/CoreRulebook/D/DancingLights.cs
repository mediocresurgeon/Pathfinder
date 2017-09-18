namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    public sealed class DancingLights : Spell
    {
        private DancingLights(byte level)
			: base(name:              "Dancing Lights",
				   webAddress:        "http://www.d20pfsrd.com/magic/all-spells/d/dancing-lights",
				   school:            School.Evocation,
				   level:             level,
                   allowsSavingThrow: false,
                   descriptors:       new[] { Descriptor.Light })
        {
            // Intentionally blank
        }

		/// <summary>
		/// Returns a Sorcerer version of Dancing Lights.
		/// </summary>
		public static DancingLights BardVersion
		{
			get { return new DancingLights(0); }
		}

		/// <summary>
		/// Returns a Sorcerer version of Dancing Lights.
		/// </summary>
		public static DancingLights SorcererVersion
		{
			get { return new DancingLights(0); }
		}

		/// <summary>
		/// Returns a Wizard version of Dancing Lights.
		/// </summary>
		public static DancingLights WizardVersion
		{
			get { return new DancingLights(0); }
		}
    }
}