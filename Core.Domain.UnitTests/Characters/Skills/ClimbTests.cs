using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Movements;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    public class ClimbTests
    {
        [Test(Description = "Ensures that characters without a climb speed do not recieve a +8 racial bonus to climb.")]
        public void NoClimbSpeed_NoRacialBonus()
        {
            // Arrange
            var mockClimb = new Mock<IMovement>();
            //mockClimb.Setup(c => c.BaseSpeed).Returns(null);  // Redundant - the default behavior is to return null

            var strength = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);

            var mockSpeeds = new Mock<IMovementSection>();
            mockSpeeds.Setup(ms => ms.Climb)
                      .Returns(mockClimb.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);

            Climb climb = new Climb(mockCharacter.Object);

            // Act
            var total = climb.RacialBonuses.GetTotal();

            // Assert
            Assert.AreEqual(0, total);
        }


		[Test(Description = "Ensures that characters with a climb speed recieve a +8 racial bonus to climb.")]
		public void ClimbSpeed_EightRacialBonus()
		{
			// Arrange
			var mockClimb = new Mock<IMovement>();
			mockClimb.Setup(c => c.BaseSpeed)
                     .Returns(6);

            var strength = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);

			var mockSpeeds = new Mock<IMovementSection>();
            mockSpeeds.Setup(ms => ms.Climb)
                      .Returns(mockClimb.Object);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
			mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);

			Climb climb = new Climb(mockCharacter.Object);

			// Act
			var total = climb.RacialBonuses.GetTotal();

			// Assert
			Assert.AreEqual(8, total);
		}
    }
}