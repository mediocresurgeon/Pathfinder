using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Equipment;
using Core.Domain.Items;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Equipment
{
    [TestFixture]
    public class EquipmentSectionTests
    {
        #region Constructor
        [Test(Description = "Ensures that EquipmentSection cannot be instanciated without a non-null ICharacter reference.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new EquipmentSection(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures that a fresh instance of EquipmentSection has sensible defaults.")]
        public void Default()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            var (ring1, ring2) = equipmentSection.Rings;

            // Assert
            Assert.IsNull(equipmentSection.Armor);
            Assert.IsNull(equipmentSection.Belt);
            Assert.IsNull(equipmentSection.Body);
            Assert.IsNull(equipmentSection.Chest);
            Assert.IsNull(equipmentSection.Eyes);
            Assert.IsNull(equipmentSection.Feet);
            Assert.IsNull(equipmentSection.Hands);
            Assert.IsNull(equipmentSection.Head);
            Assert.IsNull(equipmentSection.Headband);
            Assert.IsNull(equipmentSection.Neck);
            Assert.IsNull(ring1);
            Assert.IsNull(ring2);
            Assert.IsNull(equipmentSection.Shield);
            Assert.IsNull(equipmentSection.Shoulders);
            Assert.IsNull(equipmentSection.Spellbook);
            Assert.IsNull(equipmentSection.Wrists);
            Assert.IsEmpty(equipmentSection.GetInventory());
        }
        #endregion

        #region Armor
        [Test(Description = "Ensures that null armor cannot be equipped.")]
        public void EquipArmor_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IArmorSlot armor = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(armor);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that armor cannot be equipped if armor has already been equipped.")]
        public void EquipArmor_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IArmorSlot armor = new Mock<IArmorSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(armor);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping armor performs the correct operations.")]
        public void EquipArmor_HappyPath()
        {
            // Arrange
            bool armorAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockArmor = new Mock<IArmorSlot>();
            mockArmor.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                     .Callback(() => armorAppliedCorrectly = true);
            IArmorSlot armor = mockArmor.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(armor);

            // Assert
            Assert.AreSame(armor, equipmentSection.Armor,
                          "Equipping armor should create a reference in the equipment section's Armor slot.");
            Assert.IsTrue(armorAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Belt
        [Test(Description = "Ensures that null belt cannot be equipped.")]
        public void EquipBelt_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IBeltSlot belt = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(belt);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that belts cannot be equipped if a belt has already been equipped.")]
        public void EquipBelt_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IBeltSlot belt = new Mock<IBeltSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(belt);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping a belt performs the correct operations.")]
        public void EquipBelt_HappyPath()
        {
            // Arrange
            bool beltAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockBelt = new Mock<IBeltSlot>();
            mockBelt.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                    .Callback(() => beltAppliedCorrectly = true);
            IBeltSlot belt = mockBelt.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(belt);

            // Assert
            Assert.AreSame(belt, equipmentSection.Belt,
                          "Equipping a belt should create a reference in the equipment section's Belt slot.");
            Assert.IsTrue(beltAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Body
        [Test(Description = "Ensures that null body cannot be equipped.")]
        public void EquipBody_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IBodySlot body = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(body);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that bodies cannot be equipped if a body has already been equipped.")]
        public void EquipBody_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IBodySlot body = new Mock<IBodySlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(body);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping a body performs the correct operations.")]
        public void EquipBody_HappyPath()
        {
            // Arrange
            bool bodyAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockBody = new Mock<IBodySlot>();
            mockBody.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                    .Callback(() => bodyAppliedCorrectly = true);
            IBodySlot body = mockBody.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(body);

            // Assert
            Assert.AreSame(body, equipmentSection.Body,
                          "Equipping a body should create a reference in the equipment section's Body slot.");
            Assert.IsTrue(bodyAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Chest
        [Test(Description = "Ensures that null chest cannot be equipped.")]
        public void EquipChest_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IChestSlot chest = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(chest);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that chests cannot be equipped if a chest has already been equipped.")]
        public void EquipChest_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IChestSlot chest = new Mock<IChestSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(chest);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping a chest performs the correct operations.")]
        public void EquipChest_HappyPath()
        {
            // Arrange
            bool chestAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockChest = new Mock<IChestSlot>();
            mockChest.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                     .Callback(() => chestAppliedCorrectly = true);
            IChestSlot chest = mockChest.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(chest);

            // Assert
            Assert.AreSame(chest, equipmentSection.Chest,
                          "Equipping a chest should create a reference in the equipment section's Chest slot.");
            Assert.IsTrue(chestAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Eyes
        [Test(Description = "Ensures that null eyes cannot be equipped.")]
        public void EquipEyes_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IEyesSlot eyes = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(eyes);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that eyes cannot be equipped if an eyes has already been equipped.")]
        public void EquipEyes_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IEyesSlot eyes = new Mock<IEyesSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(eyes);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping an eyes performs the correct operations.")]
        public void EquipEyes_HappyPath()
        {
            // Arrange
            bool eyesAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockEyes = new Mock<IEyesSlot>();
            mockEyes.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                    .Callback(() => eyesAppliedCorrectly = true);
            IEyesSlot eyes = mockEyes.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(eyes);

            // Assert
            Assert.AreSame(eyes, equipmentSection.Eyes,
                          "Equipping an eyes should create a reference in the equipment section's Eyes slot.");
            Assert.IsTrue(eyesAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Feet
        [Test(Description = "Ensures that null feet cannot be equipped.")]
        public void EquipFeet_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IFeetSlot feet = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(feet);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that feet cannot be equipped if feet have already been equipped.")]
        public void EquipFeet_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IFeetSlot feet = new Mock<IFeetSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(feet);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping feet performs the correct operations.")]
        public void EquipFeet_HappyPath()
        {
            // Arrange
            bool feetAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockFeet = new Mock<IFeetSlot>();
            mockFeet.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                    .Callback(() => feetAppliedCorrectly = true);
            IFeetSlot feet = mockFeet.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(feet);

            // Assert
            Assert.AreSame(feet, equipmentSection.Feet,
                          "Equipping feet should create a reference in the equipment section's Feet slot.");
            Assert.IsTrue(feetAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Hands
        [Test(Description = "Ensures that null hands cannot be equipped.")]
        public void EquipHands_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IHandsSlot hands = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(hands);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that hands cannot be equipped if hands have already been equipped.")]
        public void EquipHands_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IHandsSlot hands = new Mock<IHandsSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(hands);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping hands performs the correct operations.")]
        public void EquipHands_HappyPath()
        {
            // Arrange
            bool handsAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockHands = new Mock<IHandsSlot>();
            mockHands.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                     .Callback(() => handsAppliedCorrectly = true);
            IHandsSlot hands = mockHands.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(hands);

            // Assert
            Assert.AreSame(hands, equipmentSection.Hands,
                          "Equipping hands should create a reference in the equipment section's Hands slot.");
            Assert.IsTrue(handsAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Head
        [Test(Description = "Ensures that null heads cannot be equipped.")]
        public void EquipHead_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IHeadSlot head = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(head);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that heads cannot be equipped if a head has already been equipped.")]
        public void EquipHead_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IHeadSlot head = new Mock<IHeadSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(head);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping a head performs the correct operations.")]
        public void EquipHead_HappyPath()
        {
            // Arrange
            bool headAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockHead = new Mock<IHeadSlot>();
            mockHead.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                    .Callback(() => headAppliedCorrectly = true);
            IHeadSlot head = mockHead.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(head);

            // Assert
            Assert.AreSame(head, equipmentSection.Head,
                          "Equipping a head should create a reference in the equipment section's Head slot.");
            Assert.IsTrue(headAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Headband
        [Test(Description = "Ensures that null headbands cannot be equipped.")]
        public void EquipHeadband_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IHeadbandSlot headband = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(headband);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that headbands cannot be equipped if a headband has already been equipped.")]
        public void EquipHeadband_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IHeadbandSlot headband = new Mock<IHeadbandSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(headband);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping a headband performs the correct operations.")]
        public void EquipHeadband_HappyPath()
        {
            // Arrange
            bool headbandAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockHeadband = new Mock<IHeadbandSlot>();
            mockHeadband.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                        .Callback(() => headbandAppliedCorrectly = true);
            IHeadbandSlot headband = mockHeadband.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(headband);

            // Assert
            Assert.AreSame(headband, equipmentSection.Headband,
                          "Equipping a headband should create a reference in the equipment section's Headband slot.");
            Assert.IsTrue(headbandAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Neck
        [Test(Description = "Ensures that null necks cannot be equipped.")]
        public void EquipNeck_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            INeckSlot neck = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(neck);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that necks cannot be equipped if a neck has already been equipped.")]
        public void EquipNeck_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            INeckSlot neck = new Mock<INeckSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(neck);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping a neck performs the correct operations.")]
        public void EquipNeck_HappyPath()
        {
            // Arrange
            bool neckAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockNeck = new Mock<INeckSlot>();
            mockNeck.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                        .Callback(() => neckAppliedCorrectly = true);
            INeckSlot neck = mockNeck.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(neck);

            // Assert
            Assert.AreSame(neck, equipmentSection.Neck,
                          "Equipping a neck should create a reference in the equipment section's Neck slot.");
            Assert.IsTrue(neckAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Shield
        [Test(Description = "Ensures that null shields cannot be equipped.")]
        public void EquipShield_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IShieldSlot shield = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(shield);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that shields cannot be equipped if a shield has already been equipped.")]
        public void EquipShield_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IShieldSlot shield = new Mock<IShieldSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(shield);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping a shield performs the correct operations.")]
        public void EquipShield_HappyPath()
        {
            // Arrange
            bool shieldAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockShield = new Mock<IShieldSlot>();
            mockShield.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                      .Callback(() => shieldAppliedCorrectly = true);
            IShieldSlot shield = mockShield.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(shield);

            // Assert
            Assert.AreSame(shield, equipmentSection.Shield,
                          "Equipping a shield should create a reference in the equipment section's Shield slot.");
            Assert.IsTrue(shieldAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Shoulders
        [Test(Description = "Ensures that null shoulders cannot be equipped.")]
        public void EquipShoulders_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IShouldersSlot shoulders = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(shoulders);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that shoulders cannot be equipped if shoulders has already been equipped.")]
        public void EquipShoulders_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IShouldersSlot shoulders = new Mock<IShouldersSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(shoulders);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping shoulders performs the correct operations.")]
        public void EquipShoulders_HappyPath()
        {
            // Arrange
            bool shouldersAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockShoulders = new Mock<IShouldersSlot>();
            mockShoulders.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                         .Callback(() => shouldersAppliedCorrectly = true);
            IShouldersSlot shoulders = mockShoulders.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(shoulders);

            // Assert
            Assert.AreSame(shoulders, equipmentSection.Shoulders,
                          "Equipping shoulders should create a reference in the equipment section's Shoulders slot.");
            Assert.IsTrue(shouldersAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Wrists
        [Test(Description = "Ensures that null wrists cannot be equipped.")]
        public void EquipWrists_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IWristsSlot wrists = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(wrists);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that wrists cannot be equipped if wrists have already been equipped.")]
        public void EquipWrists_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IWristsSlot wrists = new Mock<IWristsSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(wrists);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that equipping wrists performs the correct operations.")]
        public void EquipWrists_HappyPath()
        {
            // Arrange
            bool wristsAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockWrists = new Mock<IWristsSlot>();
            mockWrists.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                      .Callback(() => wristsAppliedCorrectly = true);
            IWristsSlot wrists = mockWrists.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(wrists);

            // Assert
            Assert.AreSame(wrists, equipmentSection.Wrists,
                          "Equipping wrists should create a reference in the equipment section's Wrists slot.");
            Assert.IsTrue(wristsAppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Rings
        [Test(Description = "Ensures that null rings cannot be equipped.")]
        public void EquipRing_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IRingSlot ring = null;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(ring);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Test(Description = "Ensures that the same ring cannot be equipped twice.")]
        public void EquipRing_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IRingSlot ring = new Mock<IRingSlot>().Object;

            // Act
            TestDelegate equip = () => equipmentSection.Equip(ring);

            // Assert
            Assert.DoesNotThrow(equip);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(equip); // Throws the second time
        }


        [Test(Description = "Ensures that three rings cannot be equipped.")]
        public void EquipingThirdRing_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IRingSlot ring1 = new Mock<IRingSlot>().Object;
            IRingSlot ring2 = new Mock<IRingSlot>().Object;
            IRingSlot ring3 = new Mock<IRingSlot>().Object;

            // Act
            TestDelegate firstEquip = () => equipmentSection.Equip(ring1);
            TestDelegate secondEquip = () => equipmentSection.Equip(ring2);
            TestDelegate thirdEquip = () => equipmentSection.Equip(ring3);

            // Assert
            Assert.DoesNotThrow(firstEquip);                      // No exception is thrown the first time
            Assert.DoesNotThrow(secondEquip);                     // ...or the second time...
            Assert.Throws<InvalidOperationException>(thirdEquip); // But the third time is forbidden.
        }


        [Test(Description = "Ensures that equipping rings performs the correct operations.")]
        public void EquipRings_HappyPath()
        {
            // Arrange
            bool ring1AppliedCorrectly = false; // We'll check on these later
            bool ring2AppliedCorrectly = false; // We'll check on these later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockRing1 = new Mock<IRingSlot>();
            mockRing1.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                     .Callback(() => ring1AppliedCorrectly = true);
            IRingSlot ring1 = mockRing1.Object;

            var mockRing2 = new Mock<IRingSlot>();
            mockRing2.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                     .Callback(() => ring2AppliedCorrectly = true);
            IRingSlot ring2 = mockRing2.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Equip(ring1);
            equipmentSection.Equip(ring2);

            // Assert
            Assert.AreSame(ring1, equipmentSection.Rings.Item1,
                          "The first equipped ring should be stored in the first ring slot.");
            Assert.IsTrue(ring1AppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
            Assert.AreSame(ring2, equipmentSection.Rings.Item2,
                          "The second equipped ring should be stored in the first ring slot.");
            Assert.IsTrue(ring2AppliedCorrectly,
                          "Equipping the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Spellbook
        [Test(Description = "Ensures that null spellbooks cannot be stowed.")]
        public void StowSpellbook_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            ISpellbook spellbook = null;

            // Act
            TestDelegate stow = () => equipmentSection.Stow(spellbook);

            // Assert
            Assert.Throws<ArgumentNullException>(stow);
        }


        [Test(Description = "Ensures that a spellbook cannot be equipped if a spellbook have already been stowed.")]
        public void StowSpellbook_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            ISpellbook spellbook = new Mock<ISpellbook>().Object;

            // Act
            TestDelegate stow = () => equipmentSection.Stow(spellbook);

            // Assert
            Assert.DoesNotThrow(stow);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(stow); // Throws the second time
        }


        [Test(Description = "Ensures that stowing a spellbook performs the correct operations.")]
        public void StowSpellbook_HappyPath()
        {
            // Arrange
            bool spellbookAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockSpellbook = new Mock<ISpellbook>();
            mockSpellbook.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                         .Callback(() => spellbookAppliedCorrectly = true);
            ISpellbook spellbook = mockSpellbook.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Stow(spellbook);

            // Assert
            Assert.AreSame(spellbook, equipmentSection.Spellbook,
                          "Stowing a spellbook should create a reference in the equipment section's Spellbook slot.");
            Assert.IsTrue(spellbookAppliedCorrectly,
                          "Stowing the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion

        #region Inventory
        [Test(Description = "Ensures that null stowables cannot be stowed.")]
        public void StowIStowable_Null_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IStowable item = null;

            // Act
            TestDelegate stow = () => equipmentSection.Stow(item);

            // Assert
            Assert.Throws<ArgumentNullException>(stow);
        }


        [Test(Description = "Ensures that stowables cannot be stowed if they have already been stowed.")]
        public void StowIStowable_Twice_Throws()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            EquipmentSection equipmentSection = new EquipmentSection(character);
            IStowable item = new Mock<IStowable>().Object;

            // Act
            TestDelegate stow = () => equipmentSection.Stow(item);

            // Assert
            Assert.DoesNotThrow(stow);                      // No exception is thrown the first time
            Assert.Throws<InvalidOperationException>(stow); // Throws the second time
        }


        [Test(Description = "Ensures that stowing stowables performs the correct operations.")]
        public void StowIStowable_HappyPath()
        {
            // Arrange
            bool itemAppliedCorrectly = false; // We'll check on this later

            ICharacter character = new Mock<ICharacter>().Object;

            var mockItem = new Mock<IStowable>();
            mockItem.Setup(i => i.ApplyTo(It.Is<ICharacter>(input => character == input)))
                    .Callback(() => itemAppliedCorrectly = true);
            IStowable item = mockItem.Object;

            EquipmentSection equipmentSection = new EquipmentSection(character);

            // Act
            equipmentSection.Stow(item);

            // Assert
            Assert.Contains(item, equipmentSection.GetInventory(),
                          "Stowing an item should create a reference in the equipment section's GetInventory collection.");
            Assert.IsTrue(itemAppliedCorrectly,
                          "Stowing the item should call the item's .ApplyTo method, passing in the character as an argument.");
        }
        #endregion
    }
}