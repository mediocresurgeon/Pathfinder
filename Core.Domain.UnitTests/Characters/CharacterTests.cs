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

        [Test(Description = "Ensures that Character.Create(byte) assigns the correct types to its ability scores.")]
        public void ICharacter_StrengthIsStrength()
        {
            // Arrange
            ICharacter character = Character.Create(1);

            // Assert
            Assert.IsInstanceOf<Strength>(character.Strength,
                                          "Character.Strength should be a Strength score.");
            Assert.IsInstanceOf<Dexterity>(character.Dexterity,
                                           "Character.Dexterity should be a Dexterity score.");
            Assert.IsInstanceOf<Constitution>(character.Constitution,
                                              "Character.Constitution should be a Constitution score.");
            Assert.IsInstanceOf<Intelligence>(character.Intelligence,
                                              "Character.Intelligence should be a Intelligence score.");
            Assert.IsInstanceOf<Wisdom>(character.Wisdom,
                                        "Character.Wisdom should be a Wisdom score.");
            Assert.IsInstanceOf<Charisma>(character.Charisma,
                                          "Character.Charisma should be a Charisma score.");
        }


		[Test(Description = "Ensures characters are created at the correct level.")]
		public void ICharacter_ConstructorValueIsPropertyOutput()
		{
			// Arrange
			byte inputLevel = 17;
			ICharacter character = Character.Create(inputLevel);

			// Act
			byte outputLevel = character.Level;

			// Assert
			Assert.AreEqual(inputLevel, outputLevel,
                            "The character level from the constructor should assign the character's level.");
		}
        #endregion

        #region Constructor tests
        [Test(Description = "Ensures that the constructor rejects level arguments which are too small.")]
        public void Constructor_Level0_ArgumentOutOfRangeException()
        {
            // Arrange
            byte level = 0;

            // Act
            TestDelegate createCharacter = () => new Character(level);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(createCharacter,
                                                       "Characters cannot be level zero.");
        }


        [Test(Description = "Ensures that the constructor rejects level arguments which are too large.")]
        public void Constructor_Level21_ArgumentOutOfRangeException()
        {
            // Arrange
            byte level = 21;

            // Act
            TestDelegate createCharacter = () => new Character(level);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(createCharacter,
                                                       "Characters cannot be higher than level 20.");
        }
        #endregion
    }
}