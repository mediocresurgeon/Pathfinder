namespace Core.Domain.Characters.Skills
{
    public interface IKnowledgeSkillSection
    {
        ISkill Arcana { get; }

        ISkill Dungeoneering { get; }

        ISkill Engineering { get; }

        ISkill Geography { get; }

        ISkill History { get; }

        ISkill Local { get; }

        ISkill Nature { get; }

        ISkill Nobility { get; }

        ISkill Planes { get; }

        ISkill Religion { get; }
    }
}