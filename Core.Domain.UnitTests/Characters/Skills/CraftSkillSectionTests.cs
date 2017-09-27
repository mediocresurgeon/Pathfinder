﻿using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    public class CraftSkillSectionTests
    {
        #region Constructor
        [Test(Description = "Ensures that a null ICharacter argument throws an ArgumentNullException.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new CraftSkillSection(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
		#endregion

		#region Raw skills
        [Test(Description = "Ensures Craft (Alchemy) is instantiated correctly.")]
		public void Default_Alchemy()
		{
			// Arrange
			var strength     = new Mock<IAbilityScore>().Object;
			var dexterity    = new Mock<IAbilityScore>().Object;
			var constitution = new Mock<IAbilityScore>().Object;
			var intelligence = new Mock<IAbilityScore>().Object;
			var wisdom       = new Mock<IAbilityScore>().Object;
			var charisma     = new Mock<IAbilityScore>().Object;

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Strength)
						 .Returns(strength);
			mockCharacter.Setup(c => c.Dexterity)
						 .Returns(dexterity);
			mockCharacter.Setup(c => c.Constitution)
						 .Returns(constitution);
			mockCharacter.Setup(c => c.Intelligence)
						 .Returns(intelligence);
			mockCharacter.Setup(c => c.Wisdom)
						 .Returns(wisdom);
			mockCharacter.Setup(c => c.Charisma)
						 .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

			// Act
            var skill = crafts.Alchemy;

			// Assert
			Assert.IsNotNull(skill);
			Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Alchemy)", skill.ToString());
		}


        [Test(Description = "Ensures Craft (Armor) is instantiated correctly.")]
        public void Default_Armor()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Armor;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Armor)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Baskets) is instantiated correctly.")]
        public void Default_Baskets()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Baskets;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Baskets)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Books) is instantiated correctly.")]
        public void Default_Books()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Books;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Books)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Bows) is instantiated correctly.")]
        public void Default_Bows()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Bows;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Bows)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Calligraphy) is instantiated correctly.")]
        public void Default_Calligraphy()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Calligraphy;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Calligraphy)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Carpentry) is instantiated correctly.")]
        public void Default_Carpentry()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Carpentry;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Carpentry)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Cloth) is instantiated correctly.")]
        public void Default_Cloth()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Cloth;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Cloth)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Clothing) is instantiated correctly.")]
        public void Default_Clothing()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Clothing;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Clothing)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Glass) is instantiated correctly.")]
        public void Default_Glass()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Glass;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Glass)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Jewelry) is instantiated correctly.")]
        public void Default_Jewelry()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Jewelry;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Jewelry)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Leather) is instantiated correctly.")]
        public void Default_Leather()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Leather;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Leather)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Locks) is instantiated correctly.")]
        public void Default_Locks()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Locks;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Locks)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Paintings) is instantiated correctly.")]
        public void Default_Paintings()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Paintings;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Paintings)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Pottery) is instantiated correctly.")]
        public void Default_Pottery()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Pottery;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Pottery)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Sculptures) is instantiated correctly.")]
        public void Default_Sculptures()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Sculptures;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Sculptures)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Ships) is instantiated correctly.")]
        public void Default_Ships()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Ships;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Ships)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Shoes) is instantiated correctly.")]
        public void Default_Shoes()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Shoes;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Shoes)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Stonemasonry) is instantiated correctly.")]
        public void Default_Stonemasonry()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Stonemasonry;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Stonemasonry)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Traps) is instantiated correctly.")]
        public void Default_Traps()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Traps;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Traps)", skill.ToString());
        }


        [Test(Description = "Ensures Craft (Weapons) is instantiated correctly.")]
        public void Default_Weapons()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var crafts = new CraftSkillSection(mockCharacter.Object);

            // Act
            var skill = crafts.Weapons;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Craft>(skill);
            Assert.AreEqual("Craft (Weapons)", skill.ToString());
        }
        #endregion
    }
}