using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Movements;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    public class SwimTests
    {
		[Test(Description = "Ensures that characters without a swim speed do not recieve a +8 racial bonus to swim.")]
		public void NoClimbSpeed_NoRacialBonus()
		{
			// Arrange
			var mockSwim = new Mock<IMovement>();
			//mockSwim.Setup(c => c.BaseSpeed).Returns(null);  // Redundant - the default behavior is to return null

			var strength = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);

            var mockSpeeds = new Mock<IMovementSection>();
            mockSpeeds.Setup(ms => ms.Swim)
                      .Returns(mockSwim.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);

			Swim swim = new Swim(mockCharacter.Object);

			// Act
			var total = swim.RacialBonuses.GetTotal();

			// Assert
            Assert.IsTrue(swim.ArmorCheckPenaltyApplies);
			Assert.AreEqual(0, total);
		}


		[Test(Description = "Ensures that characters with a swim speed recieve a +8 racial bonus to swim.")]
		public void ClimbSpeed_EightRacialBonus()
		{
			// Arrange
			var mockSwim = new Mock<IMovement>();
			mockSwim.Setup(c => c.BaseSpeed)
                    .Returns(6);

			var strength = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Swim)
                      .Returns(mockSwim.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);

			Swim swim = new Swim(mockCharacter.Object);

			// Act
			var total = swim.RacialBonuses.GetTotal();

			// Assert
            Assert.IsTrue(swim.ArmorCheckPenaltyApplies);
			Assert.AreEqual(8, total);
		}
    }
}