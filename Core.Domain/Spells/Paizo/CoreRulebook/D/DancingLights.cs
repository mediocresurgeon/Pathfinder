using System;

namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    public sealed class DancingLights : Spell
    {
        private DancingLights(byte spellLevel)
			: base(name:       "Dancing Lights",
				   webAddress: "http://www.d20pfsrd.com/magic/all-spells/d/dancing-lights",
				   spellLevel: spellLevel)
        {
            // Intentionally blank
        }

		public override Descriptor[] Descriptors => new[] { Descriptor.Light };

		public override School School => School.Evocation;

		public override Subschool[] Subschools => new Subschool[0];

		public override bool AllowsSavingThrow => false;

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