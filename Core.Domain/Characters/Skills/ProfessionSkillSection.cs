using System;


namespace Core.Domain.Characters.Skills
{
    internal sealed class ProfessionSkillSection : IProfessionSkillSection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ProfessionSkillSection"/> class.
        /// </summary>
        /// <param name="character">The character to whom these skills belong.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal ProfessionSkillSection(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Arguments cannot be null.");
            this.Architect    = new Profession(character, "Architect");
            this.Baker        = new Profession(character, "Baker");
            this.Barrister    = new Profession(character, "Barrister");
            this.Brewer       = new Profession(character, "Brewer");
            this.Butcher      = new Profession(character, "Butcher");
            this.Clerk        = new Profession(character, "Clerk");
            this.Cook         = new Profession(character, "Cook");
            this.Courtesan    = new Profession(character, "Courtesan");
            this.Driver       = new Profession(character, "Driver");
            this.Engineer     = new Profession(character, "Engineer");
            this.Farmer       = new Profession(character, "Farmer");
            this.Fisherman    = new Profession(character, "Fisherman");
            this.Gambler      = new Profession(character, "Gambler");
            this.Gardener     = new Profession(character, "Gardener");
            this.Herbalist    = new Profession(character, "Herbalist");
            this.Innkeeper    = new Profession(character, "Innkeeper");
            this.Librarian    = new Profession(character, "Librarian");
            this.Merchant     = new Profession(character, "Merchant");
            this.Midwife      = new Profession(character, "Midwife");
            this.Miller       = new Profession(character, "Miller");
            this.Miner        = new Profession(character, "Miner");
            this.Porter       = new Profession(character, "Porter");
            this.Sailor       = new Profession(character, "Sailor");
            this.Scribe       = new Profession(character, "Scribe");
            this.Shepherd     = new Profession(character, "Shepherd");
            this.StableMaster = new Profession(character, "Stable Master");
            this.Soldier      = new Profession(character, "Soldier");
            this.Tanner       = new Profession(character, "Tanner");
            this.Trapper      = new Profession(character, "Trapper");
            this.Woodcutter   = new Profession(character, "Woodcutter");
        }
        #endregion

        #region Properties
        public ISkill Architect { get; }

        public ISkill Baker { get; }

        public ISkill Barrister { get; }

        public ISkill Brewer { get; }

        public ISkill Butcher { get; }

        public ISkill Clerk { get; }

        public ISkill Cook { get; }

        public ISkill Courtesan { get; }

        public ISkill Driver { get; }

        public ISkill Engineer { get; }

        public ISkill Farmer { get; }

        public ISkill Fisherman { get; }

        public ISkill Gambler { get; }

        public ISkill Gardener { get; }

        public ISkill Herbalist { get; }

        public ISkill Innkeeper { get; }

        public ISkill Librarian { get; }

        public ISkill Merchant { get; }

        public ISkill Midwife { get; }

        public ISkill Miller { get; }

        public ISkill Miner { get; }

        public ISkill Porter { get; }

        public ISkill Sailor { get; }

        public ISkill Scribe { get; }

        public ISkill Shepherd { get; }

        public ISkill StableMaster { get; }

        public ISkill Soldier { get; }

        public ISkill Tanner { get; }

        public ISkill Trapper { get; }

        public ISkill Woodcutter { get; }
        #endregion
    }
}