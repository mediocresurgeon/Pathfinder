namespace Core.Domain.Characters.Skills
{
    public interface ISkillSection
    {
        ISkill Acrobatics { get; }

        ISkill Appraise { get; }

        ISkill Bluff { get; }

        ISkill Climb { get; }

        ICraftSkillSection Craft { get; }

        ISkill Diplomacy { get; }

        ISkill DisableDevice { get; }

        ISkill Disguise { get; }

        ISkill EscapeArtist { get; }

        ISkill Fly { get; }

        ISkill HandleAnimal { get; }

        ISkill Heal { get; }

        ISkill Intimidate { get; }

        IKnowledgeSkillSection Knowledge { get; }

        ISkill Linguistics { get; }

        ISkill Perception { get; }

        IPerformSkillSection Perform { get; }

        IProfessionSkillSection Profession { get; }

        ISkill Ride { get; }

        ISkill SenseMotive { get; }

        ISkill SleightOfHand { get; }

        ISkill Spellcraft { get; }

        ISkill Stealth { get; }

        ISkill Survival { get; }

        ISkill Swim { get; }

        ISkill UseMagicDevice { get; }

        ISkill[] GetAllSkills();
    }
}