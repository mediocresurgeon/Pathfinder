using Core.Domain.Characters.Movements;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Movements
{
    [TestFixture]
    public class FlyTests
    {
        [Test(Description = "Ensures sensible default values for Movements.Fly.")]
        public void DefaultValues()
        {
            // Arrange
            var flySpeed = new Fly();

            // Assert
            Assert.IsFalse(flySpeed.BaseSpeed.HasValue);
            Assert.AreEqual(Maneuverability.Average, flySpeed.Maneuverability,
                           "By default, Fly should have an average maneuverability.");
        }
    }
}