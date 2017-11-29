using System;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Shields;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields
{
    [TestFixture]
    public class ShieldHitPointAggregatorTests
    {
        [Test(Description = "Ensures that ShieldHitPointAggregator will reject negative thicknesses.")]
        public void Constructor_NegativeThickness_Throws()
        {
            // Arrange
            float thickness = -1f; // bad value
            byte hpPerInch = 3;

            // Act
            TestDelegate constructor = () => new ShieldHitPointAggregator(thickness, hpPerInch);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(constructor);
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of ShieldHitPointAggregator.")]
        public void Default()
        {
            // Arrange
            float thickness = 2f;
            byte hpPerInch = 3;
            ShieldHitPointAggregator aggregator = new ShieldHitPointAggregator(thickness, hpPerInch);

            // Assert
            Assert.AreEqual(thickness, aggregator.InchesOfThickness);
            Assert.AreEqual(hpPerInch, aggregator.HitPointsPerInchOfThickness);
            Assert.IsInstanceOf<EnhancementBonusTracker>(aggregator.EnhancementBonuses);
        }


        [Test(Description = "Ensures that if an items hit points would be less than 1, the total is 1 instead.")]
        public void GetTotal_Minimum_1()
        {
            // Arrange
            float thickness = 0;
            byte hpPerInch = 0;
            ShieldHitPointAggregator aggregator = new ShieldHitPointAggregator(thickness, hpPerInch);

            // Act
            ushort hp = aggregator.GetTotal();

            // Assert
            Assert.AreEqual(1, hp,
                            "0 thickness * 0 hp per inch = 0hp. Return 1hp instead of zero.");
        }


        [Test(Description = "Ensures that if an items hit points would be less than 1, the total is 1 before other bonuses are added.")]
        public void GetTotal_Minimum_PlusEnhancement()
        {
            // Arrange
            float thickness = 0;
            byte hpPerInch = 0;
            ShieldHitPointAggregator aggregator = new ShieldHitPointAggregator(thickness, hpPerInch);
            aggregator.EnhancementBonuses.Add(() => 10);

            // Act
            ushort hp = aggregator.GetTotal();

            // Assert
            Assert.AreEqual(11, hp,
                            "11 = 0 thickness * 0 hp per inch = 0hp. Return 1hp instead of zero, then add enhancement bonus of 10.");
        }


        [Test(Description = "Ensures that GetTotal() aggregates item hit points correctly for the most common case.")]
        public void GetTotal_TypicalCase()
        {
            // Arrange
            float thickness = 2f;
            byte hpPerInch = 3;
            ShieldHitPointAggregator aggregator = new ShieldHitPointAggregator(thickness, hpPerInch);
            aggregator.EnhancementBonuses.Add(() => 10);

            // Act
            ushort hp = aggregator.GetTotal();

            // Assert
            Assert.AreEqual(16, hp,
                            "16 = (2 inches * 3 hpper inch) + (10 enhancement)");
        }
    }
}