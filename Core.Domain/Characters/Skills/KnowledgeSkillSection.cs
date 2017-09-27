using System;


namespace Core.Domain.Characters.Skills
{
    internal sealed class KnowledgeSkillSection : IKnowledgeSkillSection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.KnowledgeSkillSection"/> class.
        /// </summary>
        /// <param name="character">The character to whom these skills belong.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal KnowledgeSkillSection(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Arguments cannot be null.");
            this.Arcana        = new Knowledge(character, "Arcana");
            this.Dungeoneering = new Knowledge(character, "Dungeoneering");
            this.Engineering   = new Knowledge(character, "Engineering");
            this.Geography     = new Knowledge(character, "Geography");
            this.History       = new Knowledge(character, "History");
            this.Local         = new Knowledge(character, "Local");
            this.Nature        = new Knowledge(character, "Nature");
            this.Nobility      = new Knowledge(character, "Nobility");
            this.Planes        = new Knowledge(character, "Planes");
            this.Religion      = new Knowledge(character, "Religion");
        }
        #endregion

        #region Properties
        public ISkill Arcana { get; }

        public ISkill Dungeoneering { get; }

        public ISkill Engineering { get; }

        public ISkill Geography { get; }

        public ISkill History { get; }

        public ISkill Local { get; }

        public ISkill Nature { get; }

        public ISkill Nobility { get; }

        public ISkill Planes { get; }

        public ISkill Religion { get; }
        #endregion
    }
}