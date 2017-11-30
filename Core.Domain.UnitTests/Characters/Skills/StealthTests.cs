using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    [Parallelizable]
    public class StealthTests
    {
        [Test(Description = "Ensures that small characters recieve a size bonus and no penalty to Stealth.")]
        public void Small_SizeBonus_NoPenalty()
        {
			// Arrange
			var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);

			Stealth stealthSkill = new Stealth(mockCharacter.Object);

			// Assert
            Assert.IsTrue(stealthSkill.ArmorCheckPenaltyApplies);
			Assert.AreEqual(4, stealthSkill.SizeBonuses.GetTotal(),
                           "Small characters have a +4 size bonus on Stealth checks.");
			Assert.AreEqual(0, stealthSkill.Penalties.GetTotal());
        }


		[Test(Description = "Ensures that medium characters recieve niether a size bonus nor a penalty to Stealth.")]
		public void Medium_NoSizeBonus_NoPenalty()
		{
			// Arrange
			var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);

			Stealth stealthSkill = new Stealth(mockCharacter.Object);

			// Assert
            Assert.IsTrue(stealthSkill.ArmorCheckPenaltyApplies);
			Assert.AreEqual(0, stealthSkill.SizeBonuses.GetTotal());
			Assert.AreEqual(0, stealthSkill.Penalties.GetTotal());
		}


		[Test(Description = "Ensures that large characters recieve no size bonus and a penalty to Stealth.")]
		public void Large_NoSizeBonus_NoPenalty()
		{
			// Arrange
			var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);

			Stealth stealthSkill = new Stealth(mockCharacter.Object);

			// Assert
            Assert.IsTrue(stealthSkill.ArmorCheckPenaltyApplies);
			Assert.AreEqual(0, stealthSkill.SizeBonuses.GetTotal());
			Assert.AreEqual(4, stealthSkill.Penalties.GetTotal(),
                           "Large characters have a -4 penalty on Stealth checks.");
		}
    }
}