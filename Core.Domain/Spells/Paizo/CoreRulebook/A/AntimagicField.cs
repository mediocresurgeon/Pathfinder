using System;

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
        /// <param name="level">Level.</param>
        private AntimagicField(byte spellLevel)
            : base(name:       "Antimagic Field",
                   webAddress: "http://www.d20pfsrd.com/magic/all-spells/a/antimagic-field",
                   spellLevel: spellLevel)
        {
			// Intentionally blank
		}

		public override Descriptor[] Descriptors => new Descriptor[0];

		public override School School => School.Abjuration;

		public override Subschool[] Subschools => new Subschool[0];

		public override bool AllowsSavingThrow => false;

		/// <summary>
		/// Returns a Cleric version of Antimagic Field.
		/// </summary>
		public static AntimagicField ClericVersion
		{
			get { return new AntimagicField(8); }
		}

		/// <summary>
		/// Returns a Sorcerer version of Antimagic Field.
		/// </summary>
		public static AntimagicField SorcererVersion
		{
			get { return new AntimagicField(6); }
		}

		/// <summary>
		/// Returns a Wizard version of Antimagic Field.
		/// </summary>
		public static AntimagicField WizardVersion
		{
			get { return new AntimagicField(6); }
		}

		/// <summary>
		/// Returns a Magic Domain version of Antimagic Field.
		/// </summary>
		public static AntimagicField MagicDomainVersion
		{
			get { return new AntimagicField(6); }
		}

		/// <summary>
		/// Returns a Protection Domain version of Antimagic Field.
		/// </summary>
		public static AntimagicField ProtectionDomainVersion
		{
			get { return new AntimagicField(6); }
		}
    }
}