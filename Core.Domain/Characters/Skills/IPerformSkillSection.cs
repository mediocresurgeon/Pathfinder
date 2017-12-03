namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// An ICharacter's Perform skills.
    /// </summary>
    public interface IPerformSkillSection
    {
        /// <summary>
        /// An ICharacter's aptitude for performing comedies, dramas, and pantomimes.
        /// </summary>
        ISkill Act { get; }

        /// <summary>
        /// An ICharacter's aptitude for performing buffoonery, limericks, and joke-telling.
        /// </summary>
        ISkill Comedy { get; }

        /// <summary>
        /// An ICharacter's aptitude for dancing, such as a ballet, waltz, or jig.
        /// </summary>
        ISkill Dance { get; }

        /// <summary>
        /// An ICharacter's aptitude for playing a musical instrument with a keyboard, such as a harpsichord, piano, or pipe organ.
        /// </summary>
        ISkill KeyboardInstruments { get; }

        /// <summary>
        /// An ICharacter's aptitude for performing epics, odes, and storytelling.
        /// </summary>
        ISkill Oratory { get; }

        /// <summary>
        /// An ICharacter's aptitude for playing percussion instruments, such as bells, chimes, drums, or gongs.
        /// </summary>
        ISkill PercussionInstruments { get; }

        /// <summary>
        /// An ICharacter's aptitude for playing stringed instruments, such as fiddles, harps, lutes, and mandolins.
        /// </summary>
        ISkill StringInstruments { get; }

        /// <summary>
        /// An ICharacter's aptitude for playing wind instruments, such as flutes, pan pipes, recorders, and trumpets.
        /// </summary>
        ISkill WindInstruments { get; }

        /// <summary>
        /// An ICharacter's aptitude for singing, including ballads, chants, and melodies.
        /// </summary>
        ISkill Sing { get; }
    }
}