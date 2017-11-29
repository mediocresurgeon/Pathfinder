using System;
using System.Linq;


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
            this.Acrobatics = new Skill(character, character?.AbilityScores?.Dexterity, "Acrobatics") { ArmorCheckPenaltyApplies = true };
            this.Appraise = new Skill(character, character?.AbilityScores?.Intelligence, "Appraise");
            this.Bluff = new Skill(character, character?.AbilityScores?.Charisma, "Bluff");
            this.Climb = new Climb(character);
            this.Craft = new CraftSkillSection(character);
            this.Diplomacy = new Skill(character, character?.AbilityScores?.Charisma, "Diplomacy");
            this.DisableDevice = new Skill(character, character?.AbilityScores?.Dexterity, "Disable Device") { ArmorCheckPenaltyApplies = true, CanBeUsedUntrained = false };
            this.Disguise = new Skill(character, character?.AbilityScores?.Charisma, "Disguise");
            this.EscapeArtist = new Skill(character, character?.AbilityScores?.Dexterity, "Escape Artist") { ArmorCheckPenaltyApplies = true };
            this.Fly = new Fly(character);
            this.HandleAnimal = new Skill(character, character?.AbilityScores?.Charisma, "Handle Animal") { CanBeUsedUntrained = false };
            this.Heal = new Skill(character, character?.AbilityScores?.Wisdom, "Heal");
            this.Intimidate = new Skill(character, character?.AbilityScores?.Charisma, "Intimidate");
            this.Knowledge = new KnowledgeSkillSection(character);
            this.Linguistics = new Skill(character, character?.AbilityScores?.Intelligence, "Linguistics") { CanBeUsedUntrained = false };
            this.Perception = new Skill(character, character?.AbilityScores?.Wisdom, "Perception");
            this.Perform = new PerformSkillSection(character);
            this.Profession = new ProfessionSkillSection(character);
            this.Ride = new Skill(character, character?.AbilityScores?.Dexterity, "Ride") { ArmorCheckPenaltyApplies = true };
            this.SenseMotive = new Skill(character, character?.AbilityScores?.Wisdom, "Sense Motive");
            this.SleightOfHand = new Skill(character, character?.AbilityScores?.Dexterity, "Sleight of Hand") { ArmorCheckPenaltyApplies = true, CanBeUsedUntrained = false };
            this.Spellcraft = new Skill(character, character?.AbilityScores?.Intelligence, "Spellcraft") { CanBeUsedUntrained = false };
            this.Stealth = new Stealth(character);
            this.Survival = new Skill(character, character?.AbilityScores?.Wisdom, "Survival");
            this.Swim = new Swim(character);
            this.UseMagicDevice = new Skill(character, character?.AbilityScores?.Charisma, "Use Magic Device") { CanBeUsedUntrained = false };
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

        #region Methods
        public ISkill[] GetAllSkills()
        {
            return this.GetType()
                       .GetProperties()
                       .Where(p => p.PropertyType == typeof(ISkill))
                       .Select(p => p.GetValue(this))
                       .Union(this.Craft.GetType()
                              .GetProperties()
                              .Where(p => p.PropertyType == typeof(ISkill))
                              .Select(p => p.GetValue(this.Craft)))
                       .Union(this.Knowledge.GetType()
                              .GetProperties()
                              .Where(p => p.PropertyType == typeof(ISkill))
                              .Select(p => p.GetValue(this.Knowledge)))
                       .Union(this.Perform.GetType()
                              .GetProperties()
                              .Where(p => p.PropertyType == typeof(ISkill))
                              .Select(p => p.GetValue(this.Perform)))
                       .Union(this.Profession.GetType()
                              .GetProperties()
                              .Where(p => p.PropertyType == typeof(ISkill))
                              .Select(p => p.GetValue(this.Profession)))
                       .Cast<ISkill>()
                       .ToArray();
        }
        #endregion
    }
}