using System;
using System.Collections.Generic;
using Core.Domain.Items;


namespace Core.Domain.Characters.Equipment
{
    internal sealed class EquipmentSection : IEquipmentSection
    {
        #region Constructor
        internal EquipmentSection(ICharacter character)
        {
            this.Character = character ?? throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
        }
        #endregion

        #region Properties
        private ICharacter Character { get; }

        private List<IItem> Inventory { get; } = new List<IItem>();

        public IArmorSlot Armor { get; private set; }

        public IBeltSlot Belt { get; private set; }

        public IBodySlot Body { get; private set; }

        public IChestSlot Chest { get; private set; }

        public IEyesSlot Eyes { get; private set; }

        public IFeetSlot Feet { get; private set; }

        public IHandsSlot Hands { get; private set; }

        public IHeadbandSlot Headband { get; private set; }

        public IHeadSlot Head { get; private set; }

        public INeckSlot Neck { get; private set; }

        public (IRingSlot, IRingSlot) Rings { get; private set; }

        public IShieldSlot Shield { get; private set; }

        public IShouldersSlot Shoulders { get; private set; }

        public IWristsSlot Wrists { get; private set; }

        public ISpellbook Spellbook { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Equips armor.
        /// </summary>
        /// <param name="armor">The armor to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IArmorSlot armor)
        {
            if (null == armor)
                throw new ArgumentNullException(nameof(armor), "Argument cannot be null.");
            if (null != this.Armor)
                throw new InvalidOperationException($"Cannot equip { armor }: { this.Armor } is already equipped.");
            this.Armor = armor;
            this.Armor.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips a belt.
        /// </summary>
        /// <param name="belt">The belt to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IBeltSlot belt)
        {
            if (null == belt)
                throw new ArgumentNullException(nameof(belt), "Argument cannot be null.");
            if (null != this.Belt)
                throw new InvalidOperationException($"Cannot equip { belt }: { this.Belt } is already equipped.");
            this.Belt = belt;
            this.Belt.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips a garment.
        /// </summary>
        /// <param name="garment">The garment to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IBodySlot garment)
        {
            if (null == garment)
                throw new ArgumentNullException(nameof(garment), "Argument cannot be null.");
            if (null != this.Body)
                throw new InvalidOperationException($"Cannot equip { garment }: { this.Body } is already equipped.");
            this.Body = garment;
            this.Body.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips a chestpiece.
        /// </summary>
        /// <param name="chestpiece">The chestpiece to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IChestSlot chestpiece)
        {
            if (null == chestpiece)
                throw new ArgumentNullException(nameof(chestpiece), "Argument cannot be null.");
            if (null != this.Chest)
                throw new InvalidOperationException($"Cannot equip { chestpiece }: { this.Chest } is already equipped.");
            this.Chest = chestpiece;
            this.Chest.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips an eyepiece.
        /// </summary>
        /// <param name="eyepiece">The eyepiece to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IEyesSlot eyepiece)
        {
            if (null == eyepiece)
                throw new ArgumentNullException(nameof(eyepiece), "Argument cannot be null.");
            if (null != this.Eyes)
                throw new InvalidOperationException($"Cannot equip { eyepiece }: { this.Eyes } is already equipped.");
            this.Eyes = eyepiece;
            this.Eyes.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips footwear.
        /// </summary>
        /// <param name="footwear">The footwear to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IFeetSlot footwear)
        {
            if (null == footwear)
                throw new ArgumentNullException(nameof(footwear), "Argument cannot be null.");
            if (null != this.Feet)
                throw new InvalidOperationException($"Cannot equip { footwear }: { this.Feet } is already equipped.");
            this.Feet = footwear;
            this.Feet.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips gloves.
        /// </summary>
        /// <param name="gloves">The gloves to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IHandsSlot gloves)
        {
            if (null == gloves)
                throw new ArgumentNullException(nameof(gloves), "Argument cannot be null.");
            if (null != this.Hands)
                throw new InvalidOperationException($"Cannot equip { gloves }: { this.Hands } is already equipped.");
            this.Hands = gloves;
            this.Hands.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips headband.
        /// </summary>
        /// <param name="headband">The headband to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IHeadbandSlot headband)
        {
            if (null == headband)
                throw new ArgumentNullException(nameof(headband), "Argument cannot be null.");
            if (null != this.Headband)
                throw new InvalidOperationException($"Cannot equip { headband }: { this.Headband } is already equipped.");
            this.Headband = headband;
            this.Headband.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips headgear.
        /// </summary>
        /// <param name="headgear">The headgear to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IHeadSlot headgear)
        {
            if (null == headgear)
                throw new ArgumentNullException(nameof(headgear), "Argument cannot be null.");
            if (null != this.Head)
                throw new InvalidOperationException($"Cannot equip { headgear }: { this.Head } is already equipped.");
            this.Head = headgear;
            this.Head.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips neckpiece.
        /// </summary>
        /// <param name="neckpiece">The neckpiece to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(INeckSlot neckpiece)
        {
            if (null == neckpiece)
                throw new ArgumentNullException(nameof(neckpiece), "Argument cannot be null.");
            if (null != this.Neck)
                throw new InvalidOperationException($"Cannot equip { neckpiece }: { this.Neck } is already equipped.");
            this.Neck = neckpiece;
            this.Neck.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips a ring.
        /// </summary>
        /// <param name="ring">The ring to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when both ring slots are already occupied.</exception>
        public void Equip(IRingSlot ring)
        {
            if (null == ring)
                throw new ArgumentNullException(nameof(ring), "Argument cannot be null.");
            var (leftRing, rightRing) = this.Rings;
            if (leftRing == ring || rightRing == ring)
                throw new InvalidOperationException($"{ ring } has already been equipped and may not be equipped a second time.");
            if (null != leftRing && null != rightRing)
                throw new InvalidOperationException($"Cannot equip { ring }: { leftRing } and { rightRing } are already equipped.");
            if (null != leftRing)
                this.Rings = (leftRing, ring);
            else
                this.Rings = (ring, null);
            ring.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips a shield.
        /// </summary>
        /// <param name="shield">The shield to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IShieldSlot shield)
        {
            if (null == shield)
                throw new ArgumentNullException(nameof(shield), "Argument cannot be null.");
            if (null != this.Shield)
                throw new InvalidOperationException($"Cannot equip { shield }: { this.Shield } is already equipped.");
            this.Shield = shield;
            this.Shield.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips a cape, cloak, pauldrons, spaulders, or similar item.
        /// </summary>
        /// <param name="shoulders">The item to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IShouldersSlot shoulders)
        {
            if (null == shoulders)
                throw new ArgumentNullException(nameof(shoulders), "Argument cannot be null.");
            if (null != this.Shoulders)
                throw new InvalidOperationException($"Cannot equip { shoulders }: { this.Shoulders } is already equipped.");
            this.Shoulders = shoulders;
            this.Shoulders.ApplyTo(this.Character);
        }


        /// <summary>
        /// Equips bracers or braclets.
        /// </summary>
        /// <param name="bracers">The bracers to equip.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the item slot is already occupied.</exception>
        public void Equip(IWristsSlot bracers)
        {
            if (null == bracers)
                throw new ArgumentNullException(nameof(bracers), "Argument cannot be null.");
            if (null != this.Wrists)
                throw new InvalidOperationException($"Cannot equip { bracers }: { this.Wrists } is already equipped.");
            this.Wrists = bracers;
            this.Wrists.ApplyTo(this.Character);
        }


        /// <summary>
        /// Returns a copy of the character's non-equipped items.
        /// </summary>
        /// <returns>The inventory.</returns>
        public IItem[] GetInventory()
        {
            return this.Inventory.ToArray();
        }


        /// <summary>
        /// Registers a spellbook.
        /// </summary>
        /// <param name="spellbook">The character's spellbook.</param>
        public void Stow(ISpellbook spellbook)
        {
            if (null == spellbook)
                throw new ArgumentNullException(nameof(spellbook), "Argument cannot be null.");
            if (null != this.Spellbook)
                throw new InvalidOperationException($"Cannot register { spellbook }: Character has already registered { this.Spellbook }.");
            this.Spellbook = spellbook;
            this.Spellbook.ApplyTo(this.Character);
        }


        /// <summary>
        /// Adds a non-equipable item to the inventory.
        /// </summary>
        /// <param name="item">The item to stow.</param>
        public void Stow(IStowable item)
        {
            if (null == item)
                throw new ArgumentNullException(nameof(item), "Argument cannot be null.");
            if (this.Inventory.Contains(item))
                throw new InvalidOperationException($"Inventory already contains { item }.");
            this.Inventory.Add(item);
            item.ApplyTo(this.Character);
        }
        #endregion
    }
}