using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    [Parallelizable]
    public class PerformTests
    {
		#region Constructor
		[Test(Description = "Ensures that Perform cannot be instanciated with a null ICharacter argument.")]
		public void Constructor_NullICharacter_Throws()
		{
			// Arrange
			ICharacter character = null;
			string performType = "Trash Talk";

			// Act
			TestDelegate constructor = () => new Perform(character, performType);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor);
		}


		[Test(Description = "Ensures that Perform cannot be instanciated with a null performType argument.")]
		public void Constructor_NullCraftType_Throws()
		{
			// Arrange
            var charisma = Mock.Of<IAbilityScore>();
            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Charisma).Returns(charisma);
			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores).Returns(mockAbilityScores.Object);
			string performType = null;

			// Act
			TestDelegate constructor = () => new Perform(mockCharacter.Object, performType);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor);
		}
		#endregion

		[Test(Description = "Ensures a Perform skill has sensible defaults.")]
		public void Default()
		{
			// Arrange
            var charisma = Mock.Of<IAbilityScore>();
			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Charisma).Returns(charisma);
			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores).Returns(mockAbilityScores.Object);
			string performType = "Trash Talk";

			// Act
			var perform = new Perform(mockCharacter.Object, performType);

			// Assert
			Assert.AreSame(charisma, perform.KeyAbilityScore);
			Assert.AreEqual("Perform (Trash Talk)", perform.ToString());
            Assert.IsFalse(perform.ArmorCheckPenaltyApplies);
			Assert.IsTrue(perform.CanBeUsedUntrained);
		}
    }
}