using System;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Shields;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields
{
    [TestFixture]
    public class ShieldBonusAggregatorTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of ShieldBonusAggregator.")]
        public void Default()
        {
            // Arrange
            byte baseShieldBonus = 23;
            ShieldBonusAggregator aggregator = new ShieldBonusAggregator(baseShieldBonus);

            // Assert
            Assert.AreEqual(baseShieldBonus, aggregator.BaseBonus);
            Assert.IsInstanceOf<EnhancementBonusTracker>(aggregator.EnhancementBonuses);
        }


        [Test(Description = "Ensures that the GetTotal() method aggregates modifiers correctly.")]
        public void GetTotal_Aggregates()
        {
            // Arrange
            byte baseShieldBonus = 23;
            ShieldBonusAggregator aggregator = new ShieldBonusAggregator(baseShieldBonus);
            aggregator.EnhancementBonuses.Add(() => 5);

            // Act
            byte total = aggregator.GetTotal();

            // Assert
            Assert.AreEqual(total, 28,
                            "28 = 23 base + 5 enhancement");
        }
    }
}