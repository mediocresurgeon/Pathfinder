using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    public class KnowledgeTests
    {
		#region Constructor
		[Test(Description = "Ensures that Knowledge cannot be instanciated with a null ICharacter argument.")]
		public void Constructor_NullICharacter_Throws()
		{
			// Arrange
			ICharacter character = null;
			string knowledgeType = "Chemistry";

			// Act
			TestDelegate constructor = () => new Knowledge(character, knowledgeType);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor);
		}


		[Test(Description = "Ensures that Knowledge cannot be instanciated with a null knowledgeType argument.")]
		public void Constructor_NullCraftType_Throws()
		{
			// Arrange
			var intelligence = Mock.Of<IAbilityScore>();
            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
			string knowledgeType = null;

			// Act
			TestDelegate constructor = () => new Knowledge(mockCharacter.Object, knowledgeType);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor);
		}
		#endregion

		[Test(Description = "Ensures a Knowledge skill has sensible defaults.")]
		public void Default()
		{
			// Arrange
            var intelligence = Mock.Of<IAbilityScore>();
			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
			string knowledgeType = "Chemistry";

			// Act
			var knowledge = new Knowledge(mockCharacter.Object, knowledgeType);

			// Assert
			Assert.AreSame(intelligence, knowledge.KeyAbilityScore);
			Assert.AreEqual("Knowledge (Chemistry)", knowledge.ToString());
			Assert.IsFalse(knowledge.CanBeUsedUntrained);
		}
    }
}