namespace Core.Domain.Spells
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
		private AntimagicField(byte level)
            : base(name:        "Antimagic Field",
                   webAddress:  "http://www.d20pfsrd.com/magic/all-spells/a/antimagic-field",
                   school:      School.Abjuration,
                   level:       level)
        {
			// Intentionally blank
		}

		/// <summary>
		/// Returns a Cleric version of Antimagic Field.
		/// </summary>
		public static AntimagicField AsCleric
		{
			get { return new AntimagicField(8); }
		}

		/// <summary>
		/// Returns a Sorcerer version of Antimagic Field.
		/// </summary>
		public static AntimagicField AsSorcerer
		{
			get { return new AntimagicField(6); }
		}

		/// <summary>
		/// Returns a Wizard version of Antimagic Field.
		/// </summary>
		public static AntimagicField AsWizard
		{
			get { return new AntimagicField(6); }
		}

		/// <summary>
		/// Returns a Magic Domain version of Antimagic Field.
		/// </summary>
		public static AntimagicField AsMagicDomain
		{
			get { return new AntimagicField(6); }
		}

		/// <summary>
		/// Returns a Protection Domain version of Antimagic Field.
		/// </summary>
		public static AntimagicField AsProtectionDomain
		{
			get { return new AntimagicField(6); }
		}
    }
}