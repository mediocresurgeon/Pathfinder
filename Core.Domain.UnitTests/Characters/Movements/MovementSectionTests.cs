using Core.Domain.Characters.Movements;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Movements
{
    [TestFixture]
    [Parallelizable]
    public class MovementSectionTests
    {
        [Test(Description = "Ensures sensible defaults for MovementSection.")]
        public void Defaut()
        {
            // Arrange
            MovementSection speeds = new MovementSection();

            // Assert
            Assert.IsInstanceOf<Movement>(speeds.Burrow);
            Assert.IsFalse(speeds.Burrow.BaseSpeed.HasValue);

            Assert.IsInstanceOf<Movement>(speeds.Climb);
            Assert.IsFalse(speeds.Climb.BaseSpeed.HasValue);

            Assert.IsInstanceOf<Fly>(speeds.Fly);
            Assert.IsFalse(speeds.Fly.BaseSpeed.HasValue);

            Assert.IsInstanceOf<Movement>(speeds.Swim);
            Assert.IsFalse(speeds.Swim.BaseSpeed.HasValue);
			
            Assert.IsInstanceOf<Movement>(speeds.Land);
			Assert.IsTrue(speeds.Land.BaseSpeed.HasValue);
			Assert.AreEqual(6, speeds.Land.BaseSpeed.Value);
        }
    }
}