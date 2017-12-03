namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    /// <summary>
    /// Spells and spell-like effects are turned back upon the original caster.
    /// </summary>
    public sealed class SpellTurning : Spell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Paizo.CoreRulebook.SpellTurning"/> class.
        /// </summary>
        /// <param name="spellLevel">This spell's level.</param>
        private SpellTurning(byte spellLevel)
            : base(name:       "Spell Turning",
                   webAddress: "http://www.d20pfsrd.com/magic/all-spells/s/spell-turning",
                   spellLevel: spellLevel)
        {
            // Intentionally blank
        }


        /// <summary>
        /// Spell Turning does not allow saving throws.
        /// </summary>
        public override bool AllowsSavingThrow => false;


        /// <summary>
        /// Spell Turning is an abjuration spell.
        /// </summary>
        public override School School => School.Abjuration;


        /// <summary>
        /// Spell Turning has no descriptors.
        /// </summary>
        public override Descriptor[] GetDescriptors() => new Descriptor[0];


        /// <summary>
        /// Spell Turning has no subschools.
        /// </summary>
        public override Subschool[] GetSubschools() => new Subschool[0];


        /// <summary>
        /// Returns a Sorcerer version of Antimagic Field.
        /// </summary>
        public static SpellTurning SorcererVersion => new SpellTurning(7);


        /// <summary>
        /// Returns a Wizard version of Antimagic Field.
        /// </summary>
        public static SpellTurning WizardVersion => new SpellTurning(7);


        /// <summary>
        /// Returns a Luck Domain version of Antimagic Field.
        /// </summary>
        public static SpellTurning LuckDomainVersion => new SpellTurning(7);


        /// <summary>
        /// Returns a Magic Domain version of Antimagic Field.
        /// </summary>
        public static SpellTurning MagicDomainVersion => new SpellTurning(7);
    }
}