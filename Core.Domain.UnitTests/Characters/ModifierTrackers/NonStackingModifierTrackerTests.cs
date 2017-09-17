using Core.Domain.Characters.ModifierTrackers;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.ModifierTrackers
{
    [TestFixture]
    public class NonStackingModifierTrackerTests
    {
        [Test]
        public void Default_ZeroTotal()
        {
            // Arrange
            NonStackingModifierTracker tracker = new AlchemicalBonusTracker();

            // Act
            byte total = tracker.GetTotal();

            // Assert
            Assert.AreEqual(0, total);
        }


		[Test]
		public void ThreeValues_GreatestValueReturned()
		{
			// Arrange
			NonStackingModifierTracker tracker = new AlchemicalBonusTracker();
            tracker.Add(2);
			tracker.Add(5);
            tracker.Add(3);

			// Act
			byte total = tracker.GetTotal();

			// Assert
			Assert.AreEqual(5, total);
		}
    }
}
