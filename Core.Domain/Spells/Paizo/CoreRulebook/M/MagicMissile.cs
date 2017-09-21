using System;

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
                   level:             level)
        {
            // Intentionally blank
        }

		public override Descriptor[] Descriptors => new[] { Descriptor.Force };

		public override School School => School.Evocation;

		public override Subschool[] Subschools => new Subschool[0];

		public override bool AllowsSavingThrow => false;

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