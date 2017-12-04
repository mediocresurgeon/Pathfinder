using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Aggregators;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Aggregators
{
    [TestFixture]
    [Parallelizable]
    public class ArmorClassAggregatorTests
    {
        [Test(Description = "Ensures that a fresh instance of ArmorClassAggregator has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var aggregator = new ArmorClassAggregator(17);

            // Act & Assert
            Assert.AreEqual(17, aggregator.BaseBonus);
            Assert.IsInstanceOf<EnhancementBonusTracker>(aggregator.EnhancementBonuses);
        }


        [Test(Description = "Ensures that GetTotal() aggregates bonuses correctly.")]
        public void GetTotal()
        {
            // Arrange
            var mockEnhancementBonuses = new Mock<IModifierTracker>();
            mockEnhancementBonuses.Setup(bt => bt.GetTotal())
                                  .Returns(5);
            var aggregator = new ArmorClassAggregator(3, mockEnhancementBonuses.Object);

            // Act
            var total = aggregator.GetTotal();

            // Assert
            mockEnhancementBonuses.Verify(eb => eb.GetTotal(), Times.Once,
                                          "ArmorClassAggregator.GetTotal() should use the total enhancement bonus exactly once.");
            Assert.AreEqual(8, total,
                            "8 = (3 base) + (5 enhancement bonus)");
        }
    }
}