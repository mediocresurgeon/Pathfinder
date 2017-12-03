namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    /// <summary>
    /// Weak telekinesis which provides up to 5lbs of force.
    /// </summary>
    public sealed class MageHand : Spell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Paizo.CoreRulebook.MageHand"/> class.
        /// </summary>
        /// <param name="spellLevel">This spell's level.</param>
        private MageHand(byte spellLevel)
            : base(name:       "Mage Hand",
                   webAddress: "http://www.d20pfsrd.com/magic/all-spells/m/mage-hand/",
                   spellLevel: spellLevel)
        {
            // Intentionally blank
        }


        /// <summary>
        /// Mage Hand does not allow saving throws.
        /// </summary>
        public override bool AllowsSavingThrow => false;


        /// <summary>
        /// Mage Hand is a Transmutation spell.
        /// </summary>
        public override School School => School.Transmutation;


        /// <summary>
        /// Mage Hand has no descriptors.
        /// </summary>
        public override Descriptor[] GetDescriptors() => new Descriptor[0];


        /// <summary>
        /// Mage Hand has no subschools.
        /// </summary>
        public override Subschool[] GetSubschools() => new Subschool[0];


        /// <summary>
        /// Returns a Bard version of Mage Hand.
        /// </summary>
        public static MageHand BardVersion => new MageHand(0);


        /// <summary>
        /// Returns a Sorcerer version of Mage Hand.
        /// </summary>
        public static MageHand SorcererVersion => new MageHand(0);


        /// <summary>
        /// Returns a Wizard version of Mage Hand.
        /// </summary>
        public static MageHand WizardVersion => new MageHand(0);
    }
}