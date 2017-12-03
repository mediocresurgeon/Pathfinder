using Core.Domain.Items;


namespace Core.Domain.Characters.Equipment
{
    /// <summary>
    /// An ICharacter's equipment.
    /// </summary>
    public interface IEquipmentSection
    {
        /// <summary>
        /// Returns the armor that the ICharacter has equipped.
        /// </summary>
        IArmorSlot Armor { get; }

        /// <summary>
        /// Equips armor to the ICharacter.
        /// </summary>
        void Equip(IArmorSlot armor);

        /// <summary>
        /// Returns the belt that the ICharacter has equipped.
        /// </summary>
        IBeltSlot Belt { get; }

        /// <summary>
        /// Equips a belt to the ICharacter.
        /// </summary>
        void Equip(IBeltSlot belt);

        /// <summary>
        /// Returns the garment that the ICharacter has equipped.
        /// </summary>
        IBodySlot Body { get; }

        /// <summary>
        /// Equips a garment to the ICharacter.
        /// </summary>
        void Equip(IBodySlot garment);

        /// <summary>
        /// Returns the chestpiece that the ICharacter has equipped.
        /// </summary>
        IChestSlot Chest { get; }

        /// <summary>
        /// Equips a chestpiece to the ICharacter.
        /// </summary>
        void Equip(IChestSlot chestpiece);

        /// <summary>
        /// Returns the eyepiece that the ICharacter has equipped.
        /// </summary>
        IEyesSlot Eyes { get; }

        /// <summary>
        /// Equips an eyepiece to the ICharacter.
        /// </summary>
        void Equip(IEyesSlot eyepiece);

        /// <summary>
        /// Returns the footwear that the ICharacter has equipped.
        /// </summary>
        IFeetSlot Feet { get; }

        /// <summary>
        /// Equips footwear to the ICharacter.
        /// </summary>
        void Equip(IFeetSlot footwear);

        /// <summary>
        /// Returns the gloves that the ICharacter has equipped.
        /// </summary>
        IHandsSlot Hands { get; }

        /// <summary>
        /// Equips gloves to the ICharacter.
        /// </summary>
        void Equip(IHandsSlot gloves);

        /// <summary>
        /// Returns the headband that the ICharacter has equipped.
        /// </summary>
        IHeadbandSlot Headband { get; }

        /// <summary>
        /// Equips a headband to the ICharacter.
        /// </summary>
        void Equip(IHeadbandSlot headband);

        /// <summary>
        /// Returns the headgear that the ICharacter has equipped.
        /// </summary>
        IHeadSlot Head { get; }

        /// <summary>
        /// Equips headgear to the ICharacter.
        /// </summary>
        void Equip(IHeadSlot headgear);

        /// <summary>
        /// Returns the neckpiece that the ICharacter has equipped.
        /// </summary>
        INeckSlot Neck { get; }

        /// <summary>
        /// Equips a neckpiece to the ICharacter.
        /// </summary>
        void Equip(INeckSlot neckpiece);

        /// <summary>
        /// Returns the rings that the ICharacter has equipped.
        /// </summary>
        (IRingSlot, IRingSlot) Rings { get; }

        /// <summary>
        /// Equips a ring to the ICharacter.
        /// </summary>
        void Equip(IRingSlot ring);

        /// <summary>
        /// Returns the shield that the ICharacter has equipped.
        /// </summary>
        IShieldSlot Shield { get; }

        /// <summary>
        /// Equips a shield to the ICharacter.
        /// </summary>
        void Equip(IShieldSlot shield);

        /// <summary>
        /// Returns the shoulders accessory that the ICharacter has equipped.
        /// </summary>
        IShouldersSlot Shoulders { get; }

        /// <summary>
        /// Equips shoulders to the ICharacter.
        /// </summary>
        void Equip(IShouldersSlot shoulders);

        /// <summary>
        /// Returns the bracers that the ICharacter has equipped.
        /// </summary>
        IWristsSlot Wrists { get; }

        /// <summary>
        /// Equips bracers to the ICharacter.
        /// </summary>
        void Equip(IWristsSlot bracers);

        /// <summary>
        /// Returns the spellbook that the ICharacter has equipped.
        /// </summary>
        ISpellbook Spellbook { get; }

        /// <summary>
        /// Stows a spellbook in the ICharacter's inventory.
        /// </summary>
        void Stow(ISpellbook spellbook);

        /// <summary>
        /// Returns items which are stowed in the ICharacter's inventory.
        /// </summary>
        IItem[] GetInventory();

        /// <summary>
        /// Stows an item in the ICharacter's inventory.
        /// </summary>
        void Stow(IStowable item);
    }
}