using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Feats;
using Core.Domain.Characters.Skills;
using Moq;
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

            // Act
            var abilityScores = character.AbilityScores;

            // Assert
            Assert.IsInstanceOf<AbilityScoreSection>(abilityScores);
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

        #region Properties
        [Test(Description = "Ensures that a default character has sensible default values for LandSpeed.")]
        public void LandSpeed_DefaultValues()
        {
            // Arrange
            var character = new Character(1);

            // Assert
            Assert.IsTrue(character.MovementModes.Land.BaseSpeed.HasValue,
                         "By default, a character should have a land speed.");
            Assert.AreEqual(6, character.MovementModes.Land.BaseSpeed.Value,
                           "By default, a character should have a land speed of 6 squares.");
        }


        [Test(Description = "Ensures that a default character has a sensible value for .Size")]
        public void Size_DefaultValue()
        {
			// Arrange
			var character = new Character(1);

            // Act
            var size = character.Size;

            // Assert
            Assert.AreEqual(SizeCategory.Medium, size);
        }
        #endregion

        #region Skills
        [Test(Description = "Ensures Character.Skills is an instance of the correct type.")]
        public void Skills()
        {
            // Arrange
            var character = new Character(1);

            // Act
            var skills = character.Skills;

            // Act & Assert
            Assert.IsNotNull(skills);
            Assert.IsInstanceOf<SkillSection>(skills);
        }
        #endregion

        #region Methods
        [Test(Description = "Ensures that attempts to train a feat more than once are ignored.")]
        public void TrainIFeat_Duplicates_Ignored()
        {
            // Arrange
            var character = new Character(1);
            int trainedCount = 0;
            var mockFeat = new Mock<IFeat>();
            mockFeat.Setup(f => f.ApplyTo(It.IsAny<ICharacter>()))
                    .Callback(() => trainedCount++); // Calling Feat.ApplyTo() should increment the trainedCount variable
            var feat = mockFeat.Object;

            // Act
            character.Train(feat); // Should increment trainedCount from 0 to 1
			character.Train(feat); // Should NOT increment trainedCount from 1 to 2

			// Assert
			Assert.AreEqual(1, trainedCount);
		}
        #endregion
    }
}