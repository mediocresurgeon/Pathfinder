using Core.Domain.Characters.ModifierTrackers;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.ModifierTrackers
{
    [TestFixture]
    public class StackingModifierTrackerTests
    {
        [Test]
        public void Default_ZeroTotal()
        {
            // Arrange
            StackingModifierTracker tracker = new PenaltyTracker();

            // Act
            byte total = tracker.GetTotal();

            // Assert
            Assert.AreEqual(0, total);
        }


		[Test]
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
			Assert.AreEqual(6, total);
		}
    }
}