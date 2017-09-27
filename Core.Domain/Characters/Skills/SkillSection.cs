using System;


namespace Core.Domain.Characters.Skills
{
    internal sealed class SkillSection : ISkillSection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SkillSection"/> class.
        /// </summary>
        /// <param name="character">The character to whom these skills belong.</param>
        /// <exception cref="System.ArgumentNullException">Throw when an argument is null.</exception>
        internal SkillSection(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Arguments cannot be null.");
            this.Acrobatics     = new Skill(character, character.Dexterity, "Acrobatics");
            this.Appraise       = new Skill(character, character.Intelligence, "Appraise");
            this.Bluff          = new Skill(character, character.Charisma, "Bluff");
            this.Climb          = new Climb(character);
            this.Craft = new CraftSkillSection(character);
            this.Diplomacy      = new Skill(character, character.Charisma, "Diplomacy");
            this.DisableDevice  = new Skill(character, character.Dexterity, "Disable Device") { CanBeUsedUntrained = false };
            this.Disguise       = new Skill(character, character.Charisma, "Disguise");
            this.EscapeArtist   = new Skill(character, character.Dexterity, "Escape Artist");
            this.Fly            = new Fly(character);
            this.HandleAnimal   = new Skill(character, character.Charisma, "Handle Animal") { CanBeUsedUntrained = false };
            this.Heal           = new Skill(character, character.Wisdom, "Heal");
            this.Intimidate     = new Skill(character, character.Charisma, "Intimidate");
            this.Knowledge = new KnowledgeSkillSection(character);
            this.Linguistics    = new Skill(character, character.Intelligence, "Linguistics") { CanBeUsedUntrained = false };
            this.Perception     = new Skill(character, character.Wisdom, "Perception");
            this.Perform = new PerformSkillSection(character);
            this.Profession = new ProfessionSkillSection(character);
            this.Ride           = new Skill(character, character.Dexterity, "Ride");
            this.SenseMotive    = new Skill(character, character.Wisdom, "Sense Motive");
            this.SleightOfHand  = new Skill(character, character.Dexterity, "Sleight of Hand") { CanBeUsedUntrained = false };
            this.Spellcraft     = new Skill(character, character.Intelligence, "Spellcraft") { CanBeUsedUntrained = false };
            this.Stealth        = new Stealth(character);
            this.Survival       = new Skill(character, character.Wisdom, "Survival");
            this.Swim           = new Swim(character);
            this.UseMagicDevice = new Skill(character, character.Charisma, "Use Magic Device") { CanBeUsedUntrained = false };
        }
        #endregion

        #region Properties
        public ISkill Acrobatics { get; }

        public ISkill Appraise { get; }

        public ISkill Bluff { get; }

        public ISkill Climb { get; }

        public ICraftSkillSection Craft { get; }

        public ISkill Diplomacy { get; }

        public ISkill DisableDevice { get; }

        public ISkill Disguise { get; }

        public ISkill EscapeArtist { get; }

        public ISkill Fly { get; }

        public ISkill HandleAnimal { get; }

        public ISkill Heal { get; }

        public ISkill Intimidate { get; }

        public IKnowledgeSkillSection Knowledge { get; }

        public ISkill Linguistics { get; }

        public ISkill Perception { get; }

        public IPerformSkillSection Perform { get; }

        public IProfessionSkillSection Profession { get; }

        public ISkill Ride { get; }

        public ISkill SenseMotive { get; }

        public ISkill SleightOfHand { get; }

        public ISkill Spellcraft { get; }

        public ISkill Stealth { get; }

        public ISkill Survival { get; }

        public ISkill Swim { get; }

        public ISkill UseMagicDevice { get; }
        #endregion
    }
}