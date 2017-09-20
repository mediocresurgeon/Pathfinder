using Core.Domain.Characters.ModifierTrackers;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.ModifierTrackers
{
    [TestFixture]
    public class StackingModifierTrackerTests
    {
        [Test(Description = "Tests the default calculation for an empty StackingBonusTracker.")]
        public void Default_ZeroTotal()
        {
            // Arrange
            StackingModifierTracker tracker = new PenaltyTracker();

            // Act
            byte total = tracker.GetTotal();

            // Assert
            Assert.AreEqual(0, total,
                           "An unmodified NonStackingBonusTracker should have a total of zero.");
        }


		[Test(Description = "Ensures that the sum of all values from a StackingBonusTracker is returned.")]
		public void ThreeValues_ReturnSum()
		{
			// Arrange
			StackingModifierTracker tracker = new PenaltyTracker();
            tracker.Add(1);
            tracker.Add(2);
            tracker.Add(3);

			// Act
			byte total = tracker.GetTotal();

			// Assert
			Assert.AreEqual(6, total,
                           "The sum of all values inside a StackingBonusTracker should be returned.");
		}
    }
}