namespace Core.Domain.Characters.Skills
{
    public interface IPerformSkillSection
    {
        ISkill Act { get; }

        ISkill Comedy { get; }

        ISkill Dance { get; }

        ISkill KeyboardInstruments { get; }

        ISkill Oratory { get; }

        ISkill PercussionInstruments { get; }

        ISkill StringInstruments { get; }

        ISkill WindInstruments { get; }

        ISkill Sing { get; }
    }
}