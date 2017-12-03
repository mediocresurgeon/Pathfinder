namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// An ICharacter's Profession skills.
    /// </summary>
    public interface IProfessionSkillSection
    {
        /// <summary>
        /// An ICharacter's aptitude for the art of architecture.
        /// </summary>
        ISkill Architect { get; }

        /// <summary>
        /// An ICharacter's aptitude for the art of baking food.
        /// </summary>
        ISkill Baker { get; }

        /// <summary>
        /// An ICharacter's aptitude for practicing law.
        /// </summary>
        ISkill Barrister { get; }

        /// <summary>
        /// An ICharacter's aptitude for the art of brewing alcohol.
        /// </summary>
        ISkill Brewer { get; }
		
        /// <summary>
        /// An ICharacter's aptitude for the art of butchering meat.
        /// </summary>
        ISkill Butcher { get; }

        /// <summary>
        /// An ICharacter's aptitude for business administration.
        /// </summary>
        ISkill Clerk { get; }

        /// <summary>
        /// An ICharacter's aptitude for the art of cooking.
        /// </summary>
        ISkill Cook { get; }

        /// <summary>
        /// An ICharacter's aptitude for high-class prostitution.
        /// </summary>
        ISkill Courtesan { get; }

        /// <summary>
        /// An ICharacter's aptitude for professional driving.
        /// </summary>
        ISkill Driver { get; }

        /// <summary>
        /// An ICharacter's aptitude for the art of engineering.
        /// </summary>
        ISkill Engineer { get; }

        /// <summary>
        /// An ICharacter's aptitude for the business of farming.
        /// </summary>
        ISkill Farmer { get; }

        /// <summary>
        /// An ICharacter's aptitude for professional fishing.
        /// </summary>
        ISkill Fisherman { get; }

        /// <summary>
        /// An ICharacter's aptitude for professional gambling.
        /// </summary>
        ISkill Gambler { get; }

        /// <summary>
        /// An ICharacter's aptitude for the art of gardening.
        /// </summary>
        ISkill Gardener { get; }

        /// <summary>
        /// An ICharacter's aptitude for professional herbalism.
        /// </summary>
        ISkill Herbalist { get; }

        /// <summary>
        /// An ICharacter's aptitude for running an inn.
        /// </summary>
        ISkill Innkeeper { get; }

        /// <summary>
        /// An ICharacter's aptitude for running a library.
        /// </summary>
        ISkill Librarian { get; }

        /// <summary>
        /// An ICharacter's aptitude for the business of retail.
        /// </summary>
        ISkill Merchant { get; }

        /// <summary>
        /// An ICharacter's aptitude for delivering children.
        /// </summary>
        ISkill Midwife { get; }

        /// <summary>
        /// An ICharacter's aptitude for the art of milling.
        /// </summary>
        ISkill Miller { get; }

        /// <summary>
        /// An ICharacter's aptitude for the art of mining.
        /// </summary>
        ISkill Miner { get; }

        /// <summary>
        /// An ICharacter's aptitude for the business of transporting goods.
        /// </summary>
        ISkill Porter { get; }

        /// <summary>
        /// An ICharacter's aptitude for the art of working aboard sea and air vessels.
        /// </summary>
        ISkill Sailor { get; }

        /// <summary>
        /// An ICharacter's aptitude for the business of documenting.
        /// </summary>
        ISkill Scribe { get; }

        /// <summary>
        /// An ICharacter's aptitude for the business of herding animals.
        /// </summary>
        ISkill Shepherd { get; }

        /// <summary>
        /// An ICharacter's aptitude for managing a stable.
        /// </summary>
        ISkill StableMaster { get; }

        /// <summary>
        /// An ICharacter's aptitude for the business of soldiering.
        /// </summary>
        ISkill Soldier { get; }

        /// <summary>
        /// An ICharacter's aptitude for the business of turning raw hides into leather.
        /// </summary>
        ISkill Tanner { get; }

        /// <summary>
        /// An ICharacter's aptitude for the art of trapping animals.
        /// </summary>
        ISkill Trapper { get; }

        /// <summary>
        /// An ICharacter's aptitude for the business of collecting and cutting wood.
        /// </summary>
        ISkill Woodcutter { get; }
    }
}