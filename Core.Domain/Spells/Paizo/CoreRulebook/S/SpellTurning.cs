namespace Core.Domain.Spells.Paizo.CoreRulebook
{
    public sealed class SpellTurning : Spell
    {
        private SpellTurning(byte spellLevel)
            : base(name:       "Spell Turning",
                   webAddress: "http://www.d20pfsrd.com/magic/all-spells/s/spell-turning",
                   spellLevel: spellLevel)
        {
            // Intentionally blank
        }

        public override Descriptor[] Descriptors => new Descriptor[0];

        public override School School => School.Abjuration;

        public override Subschool[] Subschools => new Subschool[0];

        public override bool AllowsSavingThrow => false;

        public static SpellTurning LuckDomainVersion => new SpellTurning(7);

        public static SpellTurning MagicDomainVersion => new SpellTurning(7);

        public static SpellTurning SorcererVersion => new SpellTurning(7);

        public static SpellTurning WizardVersion => new SpellTurning(7);
    }
}