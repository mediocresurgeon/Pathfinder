namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    public sealed class MageHand : Spell
    {
        private MageHand(byte spellLevel)
            : base(name:       "Mage Hand",
                   webAddress: "http://www.d20pfsrd.com/magic/all-spells/m/mage-hand/",
                   spellLevel: spellLevel)
        {
            // Intentionally blank
        }

        public override Descriptor[] Descriptors => new Descriptor[0];

        public override School School => School.Transmutation;

        public override Subschool[] Subschools => new Subschool[0];

        public override bool AllowsSavingThrow => false;

        /// <summary>
        /// Returns a Bard version of Mage Hand.
        /// </summary>
        public static MageHand BardVersion
        {
            get { return new MageHand(0); }
        }

        /// <summary>
        /// Returns a Sorcerer version of Mage Hand.
        /// </summary>
        public static MageHand SorcererVersion
        {
            get { return new MageHand(0); }
        }

        /// <summary>
        /// Returns a Wizard version of Mage Hand.
        /// </summary>
        public static MageHand WizardVersion
        {
            get { return new MageHand(0); }
        }
    }
}