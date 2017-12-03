namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// An ICharacter's Craft skills.
    /// </summary>
    public interface ICraftSkillSection
    {
        /// <summary>
        /// The aptitude of an ICharacter for crafting alchemical items.
        /// </summary>
        ISkill Alchemy { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting armor.
        /// </summary>
        ISkill Armor { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting baskets.
        /// </summary>
        ISkill Baskets { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting (not writing in) books.
        /// </summary>
        ISkill Books { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting bows.
        /// </summary>
        ISkill Bows { get; }

        /// <summary>
        /// The aptitude of an ICharacter for creating calligraphy.
        /// </summary>
        ISkill Calligraphy { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting common objects made of wood.
        /// </summary>
        ISkill Carpentry { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting cloth.
        /// </summary>
        ISkill Cloth { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting clothing.
        /// </summary>
        ISkill Clothing { get; }

        /// <summary>
        /// The aptitude of an ICharacter for glassblowing.
        /// </summary>
        ISkill Glass { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting jewelry.
        /// </summary>
        ISkill Jewelry { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting common objects made of leather.
        /// </summary>
        ISkill Leather { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting locks.
        /// </summary>
        ISkill Locks { get; }

        /// <summary>
        /// The aptitude of an ICharacter for painting paintings.
        /// </summary>
        ISkill Paintings { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting pottery.
        /// </summary>
        ISkill Pottery { get; }

        /// <summary>
        /// The aptitude of an ICharacter for sculpting sculptures.
        /// </summary>
        ISkill Sculptures { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting waterfaring vessels.
        /// </summary>
        ISkill Ships { get; }

        /// <summary>
        /// The aptitude of an ICharacter for cobbling.
        /// </summary>
        ISkill Shoes { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting common objects made of stone.
        /// </summary>
        ISkill Stonemasonry { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting traps.
        /// </summary>
        ISkill Traps { get; }

        /// <summary>
        /// The aptitude of an ICharacter for crafting non-bow weapons.
        /// </summary>
        ISkill Weapons { get; }
    }
}