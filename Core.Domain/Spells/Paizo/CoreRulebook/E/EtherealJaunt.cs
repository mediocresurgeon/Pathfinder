namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    /// <summary>
    /// The caster becomes ethereal, along with their equipment.
    /// </summary>
    public sealed class EtherealJaunt : Spell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Paizo.CoreRulebook.E.EtherealJaunt"/> class.
        /// </summary>
        /// <param name="spellLevel">This spell's level.</param>
        private EtherealJaunt(byte spellLevel)
            : base(name:       "Ethereal Jaunt",
                   webAddress: "http://www.d20pfsrd.com/magic/all-spells/e/ethereal-jaunt",
                   spellLevel: spellLevel)
        {
            // Intentionally blank
        }

        /// <summary>
        /// Ethereal Jaunt does not allow a saving throw.
        /// </summary>
        public override bool AllowsSavingThrow => false;


        /// <summary>
        /// Ethereal Jaunt is a Transmutation spell.
        /// </summary>
        public override School School => School.Transmutation;


        /// <summary>
        /// Ethereal Jaunt does not have descriptors.
        /// </summary>
        public override Descriptor[] GetDescriptors() => new Descriptor[0];


        /// <summary>
        /// Ethereal Jaunt does not have subschools.
        /// </summary>
        public override Subschool[] GetSubschools() => new Subschool[0];


        /// <summary>
        /// Returns a Cleric version of Ethereal Jaunt.
        /// </summary>
        public static EtherealJaunt ClericVersion => new EtherealJaunt(7);


        /// <summary>
        /// Returns a Sorcerer version of Ethereal Jaunt.
        /// </summary>
        public static EtherealJaunt SorcererVersion => new EtherealJaunt(7);


        /// <summary>
        /// Returns a Wizard version of Ethereal Jaunt.
        /// </summary>
        public static EtherealJaunt WizardVersion => new EtherealJaunt(7);
    }
}