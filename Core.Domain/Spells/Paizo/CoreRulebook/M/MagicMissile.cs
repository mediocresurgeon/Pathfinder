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
        /// <param name="level">The spell's level.</param>
        private MagicMissile(byte level)
            : base(name:              "Magic Missile",
                   webAddress:        "http://www.d20pfsrd.com/magic/all-spells/m/magic-missile",
                   school:            School.Evocation,
                   level:             level,
                   allowsSavingThrow: false,
                   descriptors:       new[] { Descriptor.Force })
        {
            // Intentionally blank
        }

        /// <summary>
        /// Returns a Sorcerer version of Magic Missile.
        /// </summary>
		public static MagicMissile SorcererVersion
		{
			get { return new MagicMissile(1); }
		}

		/// <summary>
		/// Returns a Wizard version of Magic Missile.
		/// </summary>
		public static MagicMissile WizardVersion
        {
            get { return new MagicMissile(1); }
        }
    }
}