using Core.Domain.Characters.Movements;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Movements
{
    [TestFixture]
    public class MovementTests
    {
        [Test(Description = "Ensures that by default, movements do not have base values or totals.")]
        public void DefaultValues()
        {
            // Arrange
            var movement = new Mock<Movement> { CallBase = true }.Object;

            // Assert
            Assert.IsFalse(movement.BaseSpeed.HasValue,
                          "By default, a movement should not have a base speed.");

            Assert.IsFalse(movement.GetTotal().HasValue,
						  "By default, a movement with null BaseSpeed should not have a total.");
        }


		[Test(Description = "Ensures that setting a BaseScore allows speeds to be calculated.")]
		public void BaseValue_Aggregates()
		{
			// Arrange
			var movement = new Mock<Movement> { CallBase = true }.Object;
            movement.BaseSpeed = 6;

            // Act
            var total = movement.GetTotal();

			// Assert
			Assert.IsTrue(movement.BaseSpeed.HasValue);
            Assert.AreEqual(6, movement.BaseSpeed.Value);
            Assert.IsTrue(total.HasValue);
            Assert.AreEqual(6, total.Value);
		}


		[Test(Description = "Ensures that enhancement bonuses are aggregated correctly.")]
		public void EnhancementBonus_Aggregates()
		{
			// Arrange
			var movement = new Mock<Movement> { CallBase = true }.Object;
			movement.BaseSpeed = 6;
            movement.AddEnhancementBonus(2);

			// Act
			var total = movement.GetTotal();

			// Assert
			Assert.IsTrue(movement.BaseSpeed.HasValue);
			Assert.AreEqual(6, movement.BaseSpeed.Value);
			Assert.IsTrue(total.HasValue);
			Assert.AreEqual(8, total.Value);
		}
    }
}