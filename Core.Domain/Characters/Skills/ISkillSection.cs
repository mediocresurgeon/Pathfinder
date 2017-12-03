namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// An ICharacter's skills.
    /// </summary>
    public interface ISkillSection
    {
        /// <summary>
        /// An ICharacter's ability to keep balance while traversing narrow or treacherous surfaces.
        /// Also, diving, flipping, jumping, and rolling, avoiding attacks, and confusing opponents.
        /// </summary>
        ISkill Acrobatics { get; }

        /// <summary>
        /// An ICharacter's aptitude for evaluating the monetary value of objects.
        /// </summary>
        ISkill Appraise { get; }

        /// <summary>
        /// An ICharacter's aptitude for deceiving adversaries.
        /// </summary>
        ISkill Bluff { get; }

        /// <summary>
        /// An ICharacter's ability to scale vertical or near-vertical surfaces.
        /// </summary>
        ISkill Climb { get; }

        /// <summary>
        /// Returns the ICharacter's skills which represent its ability to create new things.
        /// </summary>
        ICraftSkillSection Craft { get; }

        /// <summary>
        /// An ICharacter's aptitude for persuading others to agree with its arguments, resolve differences, and gather valuable information or rumors from people.
        /// This skill is also used to negotiate conflicts by using the proper etiquette and manners suitable to the problem.
        /// </summary>
        ISkill Diplomacy { get; }

        /// <summary>
        /// An ICharacter's aptitude for disarming traps, opening locks,
        /// and sabotaging simple mechanical devices (such as catapults, wagon wheels, and doors).
        /// </summary>
        ISkill DisableDevice { get; }

        /// <summary>
        /// An ICharacter's aptitude for changing its appearance.
        /// </summary>
        ISkill Disguise { get; }

        /// <summary>
        /// An ICharacter's aptitude for slipping bonds and escaping from grapples.
        /// </summary>
        ISkill EscapeArtist { get; }

        /// <summary>
        /// An ICharacter's aptitude for performing daring or complex maneuvers while airborne.
        /// </summary>
        ISkill Fly { get; }

        /// <summary>
        /// An ICharacter's aptitude for working with animals.
        /// This includes teaching them tricks, getting them to follow simple commands, or even domesticating them.
        /// </summary>
        ISkill HandleAnimal { get; }

        /// <summary>
        /// An ICharacter's aptitude for tending to the ailments of others.
        /// </summary>
        ISkill Heal { get; }

        /// <summary>
        /// An ICharacter's ability to frighten opponents or getting them to act in a way that .
        /// </summary>
        ISkill Intimidate { get; }

        /// <summary>
        /// Returns the ICharacter's skills which represent its knowledge of specific subjects.
        /// </summary>
        IKnowledgeSkillSection Knowledge { get; }

        /// <summary>
        /// An ICharacter's aptitude for working with spoken and written language.
        /// </summary>
        ISkill Linguistics { get; }

        /// <summary>
        /// An ICharacter's ability to notice fine details using a variety of senses.
        /// </summary>
        ISkill Perception { get; }

        /// <summary>
        /// An ICharacter's skills which repesent how well it can perform to an audience.
        /// </summary>
        IPerformSkillSection Perform { get; }

        /// <summary>
        /// An ICharacter's skills which represent how skilled it is at a particular job.
        /// </summary>
        IProfessionSkillSection Profession { get; }

        /// <summary>
        /// An ICharacter's aptitude for riding mounts, such as a horse or griffon.
        /// </summary>
        ISkill Ride { get; }

        /// <summary>
        /// An ICharacter's aptitude for detecting falsehoods and true intentions.
        /// </summary>
        ISkill SenseMotive { get; }

        /// <summary>
        /// An ICharacter's aptitude for picking pockets, drawing hidden weapons, and taking a variety of actions without being noticed.
        /// </summary>
        ISkill SleightOfHand { get; }

        /// <summary>
        /// An ICharacter's aptitude in the art of casting spells,
        /// identifying magic items,
        /// crafting magic items,
        /// and identifying spells as they are being cast.
        /// </summary>
        ISkill Spellcraft { get; }

        /// <summary>
        /// An ICharacter's aptitude for avoiding detecting by hiding and moving silently.
        /// </summary>
        ISkill Stealth { get; }

        /// <summary>
        /// An ICharacter's aptitude for surviving and navigating in the wilderness.
        /// </summary>
        ISkill Survival { get; }

        /// <summary>
        /// An ICharacter's strength at swimming, including swimming in stormy water.
        /// </summary>
        ISkill Swim { get; }

        /// <summary>
        /// An ICharacter's aptitude for activating magical items, even if not otherwise trained in their use.
        /// </summary>
        ISkill UseMagicDevice { get; }

        /// <summary>
        /// Returns all skills, including craft, knowledge, perform, and profession skills.
        /// </summary>
        ISkill[] GetAllSkills();
    }
}