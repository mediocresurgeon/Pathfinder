using Core.Domain.Characters.ModifierTrackers;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.ModifierTrackers
{
    [TestFixture]
    public class NonStackingModifierTrackerTests
    {
        [Test(Description = "Tests the default calculation for an empty NonStackingBonusTracker.")]
        public void Default_ZeroTotal()
        {
            // Arrange
            GreatestModifierTracker tracker = new Mock<GreatestModifierTracker> { CallBase = true}.Object;

            // Act
            byte total = tracker.GetTotal();

            // Assert
            Assert.AreEqual(0, total,
                           "An unmodified NonStackingBonusTracker should have a total of zero.");
        }


		[Test(Description = "Ensures that only the greatest value from a NonStackingBonusTracker is returned.")]
		public void ThreeValues_GreatestValueReturned()
		{
			// Arrange
			GreatestModifierTracker tracker = new Mock<GreatestModifierTracker> { CallBase = true }.Object;
            tracker.Add(2);
			tracker.Add(5);
            tracker.Add(3);

			// Act
			byte total = tracker.GetTotal();

			// Assert
			Assert.AreEqual(5, total,
                           "Only the greatest value from a NonStackingBonusTracker should be returned.");
		}
    }
}