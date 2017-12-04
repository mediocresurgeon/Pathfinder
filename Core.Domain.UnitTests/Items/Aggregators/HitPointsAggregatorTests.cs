using System;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Aggregators;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Aggregators
{
    [TestFixture]
    [Parallelizable]
    public class HitPointsAggregatorTests
    {
        #region Constructor
        [Test(Description = "Ensures that an instance of HitPointsAggregator cannot be created with a null baseHitPoints calculation.")]
        public void Constructor_NullFunc_Throws()
        {
            // Arrange
            Func<ushort> baseHitPoints = null;

            // Act
            TestDelegate constructor = () => new HitPointsAggregator(baseHitPoints);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures that a fresh instance of HitPointsAggregator has sensible defaults.")]
        public void Default()
        {
            // Arrange
            Func<ushort> baseHitPoints = () => 199;
            var aggregator = new HitPointsAggregator(baseHitPoints);

            // Act & Assert
            Assert.AreSame(baseHitPoints, aggregator.BaseHitPoints);
            Assert.IsInstanceOf<EnhancementBonusTracker>(aggregator.EnhancementBonuses);
        }
        #endregion

        #region GetTotal()
        [Test(Description = "Ensures that hit points are aggregated correctly.")]
        public void GetTotal()
        {
            Func<ushort> baseHitPoints = () => 3;
            var mockEnhancementBonuses = new Mock<IModifierTracker>();
            mockEnhancementBonuses.Setup(bt => bt.GetTotal())
                                  .Returns(5);
            var aggregator = new HitPointsAggregator(baseHitPoints, mockEnhancementBonuses.Object);

            // Act
            var result = aggregator.GetTotal();

            // Assert
            mockEnhancementBonuses.Verify(eb => eb.GetTotal(), Times.Once,
                                          "HitPointsAggregator.GetTotal() should use the total enhancement bonus exactly once.");
            Assert.AreEqual(8, result,
                            "8 = (3 base) + (5 enhancement bonus)");
        }


        [Test(Description = "Ensures that if the base hit points function is zero, exactly 1 hit point is returned.")]
        public void GetTotal_BaseZero_Returns1()
        {
            // Arrange
            Func<ushort> baseHitPoints = () => 0;
            var aggregator = new HitPointsAggregator(baseHitPoints);

            // Act
            var result = aggregator.GetTotal();

            // Assert
            Assert.AreEqual(1, result,
                            "Items always have at least 1 hit point.");
        }
        #endregion
    }
}