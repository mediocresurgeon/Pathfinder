using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    public class CraftTests
    {
        #region Constructor
        [Test(Description = "Ensures that Craft cannot be instanciated with a null ICharacter argument.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;
            string craftType = "Robot";

            // Act
            TestDelegate constructor = () => new Craft(character, craftType);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures that Craft cannot be instanciated with a null craftType argument.")]
        public void Constructor_NullCraftType_Throws()
		{
            // Arrange
            IAbilityScore intelligence = new Mock<IAbilityScore>().Object;

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Intelligence).Returns(intelligence);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores).Returns(mockAbilityScores.Object);
			
            string craftType = null;

			// Act
			TestDelegate constructor = () => new Craft(mockCharacter.Object, craftType);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor);
		}
        #endregion

        [Test(Description = "Ensures a Craft skill has sensible defaults.")]
        public void Default()
        {
			// Arrange
			IAbilityScore intelligence = new Mock<IAbilityScore>().Object;

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Intelligence).Returns(intelligence);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores).Returns(mockAbilityScores.Object);
			
            string craftType = "Robot";

			// Act
            var craft = new Craft(mockCharacter.Object, craftType);

            // Assert
            Assert.AreSame(intelligence, craft.KeyAbilityScore);
            Assert.AreEqual("Craft (Robot)", craft.ToString());
            Assert.IsTrue(craft.CanBeUsedUntrained);
        }
    }
}