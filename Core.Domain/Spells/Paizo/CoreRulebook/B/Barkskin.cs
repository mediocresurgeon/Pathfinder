using System;

namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    /// <summary>
    /// Toughens a creature's skin, providing an enchancement bonus to natural armor.
    /// </summary>
    public sealed class Barkskin : Spell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Barkskin"/> class.
        /// </summary>
        /// <param name="level">Level.</param>
        private Barkskin(byte level)
				: base(name:              "Barkskin",
                       webAddress:        "http://www.d20pfsrd.com/magic/all-spells/b/barkskin/",
                       level:             level)
        {
            // Intentionally blank
        }

		public override Descriptor[] Descriptors => new Descriptor[0];

		public override School School => School.Transmutation;

		public override Subschool[] Subschools => new Subschool[0];

		public override bool AllowsSavingThrow => false;

		/// <summary>
		/// Returns a Druid version of Barkskin.
		/// </summary>
		public static Barkskin DruidVersion
        {
            get { return new Barkskin(2); }
        }

		/// <summary>
		/// Returns a Ranger version of Barkskin.
		/// </summary>
		public static Barkskin RangerVersion
		{
			get { return new Barkskin(2); }
		}

        /// <summary>
        /// Returns a Defense Subdomain version of Barkskin.
        /// </summary>
        public static Barkskin DefenseSubdomainVersion
		{
			get { return new Barkskin(2); }
		}

		/// <summary>
		/// Returns a Plant Domain version of Barkskin.
		/// </summary>
		public static Barkskin PlantDomainVersion
		{
			get { return new Barkskin(2); }
		}
    }
}