using System;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Shields;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields
{
    [TestFixture]
    [Parallelizable]
    public class ShieldHardnessAggregatorTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of ShieldHardnessAggregator.")]
        public void Default()
        {
            // Arrange
            byte baseHardness = 20;
            ShieldHardnessAggregator aggregator = new ShieldHardnessAggregator(baseHardness);

            // Assert
            Assert.AreEqual(baseHardness, aggregator.MaterialHardness);
            Assert.IsInstanceOf<EnhancementBonusTracker>(aggregator.EnhancementBonuses);
        }


        [Test(Description = "Ensures that the GetTotal() method aggregates modifiers correctly.")]
        public void GetTotal_Aggregates()
        {
            // Arrange
            byte baseHardness = 20;
            ShieldHardnessAggregator aggregator = new ShieldHardnessAggregator(baseHardness);
            aggregator.EnhancementBonuses.Add(() => 10);

            // Act
            byte total = aggregator.GetTotal();

            // Assert
            Assert.AreEqual(total, 30,
                            "30 = 2 base + 10 enhancement");
        }
    }
}