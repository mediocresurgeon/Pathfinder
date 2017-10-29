using Core.Domain.Items;


namespace Core.Domain.Characters.Equipment
{
    public interface IEquipmentSection
    {
        IArmorSlot Armor { get; }

        void Equip(IArmorSlot armor);

        IBeltSlot Belt { get; }

        void Equip(IBeltSlot belt);

        IBodySlot Body { get; }

        void Equip(IBodySlot garment);

        IChestSlot Chest { get; }

        void Equip(IChestSlot chestpiece);

        IEyesSlot Eyes { get; }

        void Equip(IEyesSlot eyepiece);

        IFeetSlot Feet { get; }

        void Equip(IFeetSlot footwear);

        IHandsSlot Hands { get; }

        void Equip(IHandsSlot gloves);

        IHeadbandSlot Headband { get; }

        void Equip(IHeadbandSlot headband);

        IHeadSlot Head { get; }

        void Equip(IHeadSlot headgear);

        INeckSlot Neck { get; }

        void Equip(INeckSlot neckpiece);

        (IRingSlot, IRingSlot) Rings { get; }

        void Equip(IRingSlot ring);

        IShieldSlot Shield { get; }

        void Equip(IShieldSlot shield);

        IShouldersSlot Shoulders { get; }

        void Equip(IShouldersSlot shoulders);

        IWristsSlot Wrists { get; }

        void Equip(IWristsSlot bracers);

        ISpellbook Spellbook { get; }

        void Stow(ISpellbook spellbook);

        IItem[] GetInventory();

        void Stow(IStowable item);
    }
}