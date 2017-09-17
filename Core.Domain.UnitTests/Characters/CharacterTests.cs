using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using NUnit.Framework;

namespace Core.Domain.UnitTests.Characters
{
    [TestFixture]
    public class CharacterTests
    {
        #region ICharacter tests
        // These tests make sure that Character passes through its properties correctly to its interface.

        [Test]
        public void ICharacter_StrengthIsStrength()
        {
            // Arrange
            ICharacter character = Character.Create(1);

            // Assert
            Assert.IsInstanceOf<Strength>(character.Strength);
        }


        [Test]
        public void ICharacter_DexterityIsDexterity()
        {
            // Arrange
            ICharacter character = Character.Create(1);

            // Assert
            Assert.IsInstanceOf<Dexterity>(character.Dexterity);
        }


        [Test]
        public void ICharacter_ConstitutionIsConstitution()
        {
            // Arrange
            ICharacter character = Character.Create(1);

            // Assert
            Assert.IsInstanceOf<Constitution>(character.Constitution);
        }


        [Test]
        public void ICharacter_IntelligenceIsIntelligence()
        {
            // Arrange
            ICharacter character = Character.Create(1);

            // Assert
            Assert.IsInstanceOf<Intelligence>(character.Intelligence);
        }


        [Test]
        public void ICharacter_WisdomIsWisdom()
        {
            // Arrange
            ICharacter character = Character.Create(1);

            // Assert
            Assert.IsInstanceOf<Wisdom>(character.Wisdom);
        }


        [Test]
        public void ICharacter_CharismaIsCharisma()
        {
            // Arrange
            ICharacter character = Character.Create(1);

            // Assert
            Assert.IsInstanceOf<Charisma>(character.Charisma);
        }


		[Test]
		public void ICharacter_ConstructorValueIsPropertyOutput()
		{
			// Arrange
			byte inputLevel = 17;
			ICharacter character = Character.Create(inputLevel);

			// Act
			byte outputLevel = character.Level;

			// Assert
			Assert.AreEqual(inputLevel, outputLevel);
		}
        #endregion

        #region Constructor tests
        [Test]
        public void Constructor_Level0_ArgumentOutOfRangeException()
        {
            // Arrange
            byte level = 0;
            TestDelegate characterCreator = () => new Character(level);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(characterCreator);
        }


        [Test]
        public void Constructor_Level21_ArgumentOutOfRangeException()
        {
            // Arrange
            byte level = 21;
            TestDelegate characterCreator = () => new Character(level);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(characterCreator);
        }
        #endregion
    }
}