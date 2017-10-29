using System;


namespace Core.Domain.Characters.Skills
{
    internal sealed class PerformSkillSection : IPerformSkillSection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegistries.PerformSkillSection"/> class.
        /// </summary>
        /// <param name="character">The character to whom these skills belong.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal PerformSkillSection(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Arguments cannot be null.");
            this.Act                   = new Perform(character, "Act");
            this.Comedy                = new Perform(character, "Comedy");
            this.Dance                 = new Perform(character, "Dance");
            this.KeyboardInstruments   = new Perform(character, "Keyboard Instruments");
            this.Oratory               = new Perform(character, "Oratory");
            this.PercussionInstruments = new Perform(character, "Percussion Instruments");
            this.StringInstruments     = new Perform(character, "String Instruments");
            this.WindInstruments       = new Perform(character, "Wind Instruments");
            this.Sing                  = new Perform(character, "Sing");
        }
        #endregion

        #region Properties
        public ISkill Act { get; }

        public ISkill Comedy { get; }

        public ISkill Dance { get; }

        public ISkill KeyboardInstruments { get; }

        public ISkill Oratory { get; }

        public ISkill PercussionInstruments { get; }

        public ISkill StringInstruments { get; }

        public ISkill Sing { get; }

        public ISkill WindInstruments { get; }
        #endregion
    }
}