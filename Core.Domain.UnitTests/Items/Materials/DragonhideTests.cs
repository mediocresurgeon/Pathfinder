using System;
using Core.Domain.Items.Aggregators;
using Core.Domain.Items.Enchantments;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Materials
{
    [TestFixture]
    [Parallelizable]
    public class DragonhideTests
    {
        [Test(Description = "Ensures Dragonhide has the correct hardness.")]
        public void Hardness()
        {
            Assert.AreEqual(10, Dragonhide.Hardness);
        }


        [Test(Description = "Ensures Dragonhide has the correct hit points per inch of thickness.")]
        public void HitPointsPerInch()
        {
            Assert.AreEqual(10, Dragonhide.HitPointsPerInch);
        }

        #region GetArmorBaseMarketPrice()
        [Test(Description = "Ensures that .GetArmorBaseMarketPrice() throws an exception if it has a null argument.")]
        public void GetArmorBaseMarketPrice_NullEnchantments_Throws()
        {
            // Arrange
            double baseCost = 200;
            IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor> enchantments = null;
            var color = DragonhideColor.Black;

            // Act
            TestDelegate getPrice = () => Dragonhide.GetArmorBaseMarketPrice(baseCost, enchantments, color);

            // Assert
            Assert.Throws<ArgumentNullException>(getPrice);
        }


        [Test(Description = "Ensures that the value of dragonhide armor without any enchantments is calculated correctly.")]
        public void GetArmorBaseMarketPrice_NoEnchantments()
        {
            // Arrange
            double baseCost = 200;
            var enchantments = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var color = DragonhideColor.Black;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, enchantments, color);

            // Assert
            Assert.AreEqual(700, dragonhidePrice,
                            "700 = (200 base + 150 masterwork) * (2 dragonhide)");
        }

        #region Black
        [Test(Description = "Ensures that the value of dragonhide armor with regular acid resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BlackAcidResistanceRegular()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new AcidResistance(EnergyResistanceMagnitude.Regular) });

            var color = DragonhideColor.Black;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-3800, dragonhidePrice,
                            "-3800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (18000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with improved acid resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BlackAcidResistanceImproved()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new AcidResistance(EnergyResistanceMagnitude.Improved) });

            var color = DragonhideColor.Black;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-9800, dragonhidePrice,
                            "-9800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (42000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with greater acid resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BlackAcidResistanceGreater()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new AcidResistance(EnergyResistanceMagnitude.Greater) });

            var color = DragonhideColor.Black;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-15800, dragonhidePrice,
                            "-15800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (66000 energy resistance * 25% discount)");
        }
        #endregion

        #region Copper
        [Test(Description = "Ensures that the value of dragonhide armor with regular acid resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_CopperAcidResistanceRegular()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new AcidResistance(EnergyResistanceMagnitude.Regular) });

            var color = DragonhideColor.Copper;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-3800, dragonhidePrice,
                            "-3800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (18000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with improved acid resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_CopperAcidResistanceImproved()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new AcidResistance(EnergyResistanceMagnitude.Improved) });

            var color = DragonhideColor.Copper;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-9800, dragonhidePrice,
                            "-9800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (42000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with greater acid resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_CopperAcidResistanceGreater()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new AcidResistance(EnergyResistanceMagnitude.Greater) });

            var color = DragonhideColor.Copper;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-15800, dragonhidePrice,
                            "-15800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (66000 energy resistance * 25% discount)");
        }
        #endregion

        #region Green
        [Test(Description = "Ensures that the value of dragonhide armor with regular acid resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_GreenAcidResistanceRegular()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new AcidResistance(EnergyResistanceMagnitude.Regular) });

            var color = DragonhideColor.Green;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-3800, dragonhidePrice,
                            "-3800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (18000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with improved acid resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_GreenAcidResistanceImproved()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new AcidResistance(EnergyResistanceMagnitude.Improved) });

            var color = DragonhideColor.Green;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-9800, dragonhidePrice,
                            "-9800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (42000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with greater acid resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_GreenAcidResistanceGreater()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new AcidResistance(EnergyResistanceMagnitude.Greater) });

            var color = DragonhideColor.Green;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-15800, dragonhidePrice,
                            "-15800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (66000 energy resistance * 25% discount)");
        }
        #endregion

        #region Silver
        [Test(Description = "Ensures that the value of dragonhide armor with regular cold resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_SilverColdResistanceRegular()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ColdResistance(EnergyResistanceMagnitude.Regular) });

            var color = DragonhideColor.Silver;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-3800, dragonhidePrice,
                            "-3800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (18000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with improved cold resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_SilverColdResistanceImproved()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ColdResistance(EnergyResistanceMagnitude.Improved) });

            var color = DragonhideColor.Silver;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-9800, dragonhidePrice,
                            "-9800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (42000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with greater cold resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_SilverColdResistanceGreater()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ColdResistance(EnergyResistanceMagnitude.Greater) });

            var color = DragonhideColor.Silver;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-15800, dragonhidePrice,
                            "-15800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (66000 energy resistance * 25% discount)");
        }
        #endregion

        #region White
        [Test(Description = "Ensures that the value of dragonhide armor with regular cold resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_WhiteColdResistanceRegular()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ColdResistance(EnergyResistanceMagnitude.Regular) });

            var color = DragonhideColor.White;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-3800, dragonhidePrice,
                            "-3800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (18000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with improved cold resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_WhiteColdResistanceImproved()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ColdResistance(EnergyResistanceMagnitude.Improved) });

            var color = DragonhideColor.White;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-9800, dragonhidePrice,
                            "-9800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (42000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with greater cold resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_WhiteColdResistanceGreater()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ColdResistance(EnergyResistanceMagnitude.Greater) });

            var color = DragonhideColor.White;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-15800, dragonhidePrice,
                            "-15800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (66000 energy resistance * 25% discount)");
        }
        #endregion

        #region Blue
        [Test(Description = "Ensures that the value of dragonhide armor with regular electricity resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BlueElectricityResistanceRegular()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ElectricityResistance(EnergyResistanceMagnitude.Regular) });

            var color = DragonhideColor.Blue;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-3800, dragonhidePrice,
                            "-3800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (18000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with improved electricity resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BlueElectricityResistanceImproved()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ElectricityResistance(EnergyResistanceMagnitude.Improved) });

            var color = DragonhideColor.Blue;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-9800, dragonhidePrice,
                            "-9800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (42000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with greater electricity resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BlueElectricityResistanceGreater()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ElectricityResistance(EnergyResistanceMagnitude.Greater) });

            var color = DragonhideColor.Blue;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-15800, dragonhidePrice,
                            "-15800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (66000 energy resistance * 25% discount)");
        }
        #endregion

        #region Bronze
        [Test(Description = "Ensures that the value of dragonhide armor with regular electricity resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BronzeElectricityResistanceRegular()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ElectricityResistance(EnergyResistanceMagnitude.Regular) });

            var color = DragonhideColor.Bronze;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-3800, dragonhidePrice,
                            "-3800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (18000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with improved electricity resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BronzeElectricityResistanceImproved()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ElectricityResistance(EnergyResistanceMagnitude.Improved) });

            var color = DragonhideColor.Bronze;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-9800, dragonhidePrice,
                            "-9800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (42000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with greater electricity resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BronzeElectricityResistanceGreater()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new ElectricityResistance(EnergyResistanceMagnitude.Greater) });

            var color = DragonhideColor.Bronze;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-15800, dragonhidePrice,
                            "-15800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (66000 energy resistance * 25% discount)");
        }
        #endregion

        #region Brass
        [Test(Description = "Ensures that the value of dragonhide armor with regular fire resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BrassFireResistanceRegular()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new FireResistance(EnergyResistanceMagnitude.Regular) });

            var color = DragonhideColor.Brass;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-3800, dragonhidePrice,
                            "-3800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (18000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with improved fire resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BrassFireResistanceImproved()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new FireResistance(EnergyResistanceMagnitude.Improved) });

            var color = DragonhideColor.Brass;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-9800, dragonhidePrice,
                            "-9800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (42000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with greater fire resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_BrassFireResistanceGreater()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new FireResistance(EnergyResistanceMagnitude.Greater) });

            var color = DragonhideColor.Brass;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-15800, dragonhidePrice,
                            "-15800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (66000 energy resistance * 25% discount)");
        }
        #endregion

        #region Gold
        [Test(Description = "Ensures that the value of dragonhide armor with regular fire resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_GoldFireResistanceRegular()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new FireResistance(EnergyResistanceMagnitude.Regular) });

            var color = DragonhideColor.Gold;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-3800, dragonhidePrice,
                            "-3800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (18000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with improved fire resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_GoldFireResistanceImproved()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new FireResistance(EnergyResistanceMagnitude.Improved) });

            var color = DragonhideColor.Gold;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-9800, dragonhidePrice,
                            "-9800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (42000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with greater fire resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_GoldFireResistanceGreater()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new FireResistance(EnergyResistanceMagnitude.Greater) });

            var color = DragonhideColor.Gold;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-15800, dragonhidePrice,
                            "-15800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (66000 energy resistance * 25% discount)");
        }
        #endregion

        #region Red
        [Test(Description = "Ensures that the value of dragonhide armor with regular fire resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_RedFireResistanceRegular()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new FireResistance(EnergyResistanceMagnitude.Regular) });

            var color = DragonhideColor.Red;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-3800, dragonhidePrice,
                            "-3800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (18000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with improved fire resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_RedFireResistanceImproved()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new FireResistance(EnergyResistanceMagnitude.Improved) });

            var color = DragonhideColor.Red;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-9800, dragonhidePrice,
                            "-9800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (42000 energy resistance * 25% discount)");
        }


        [Test(Description = "Ensures that the value of dragonhide armor with greater fire resistance is calculated correctly.")]
        public void GetArmorBaseMarketPrice_RedFireResistanceGreater()
        {
            // Arrange
            double baseCost = 200;
            var mockEnchantments = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IArmorEnchantment[] { new FireResistance(EnergyResistanceMagnitude.Greater) });

            var color = DragonhideColor.Red;

            // Act
            var dragonhidePrice = Dragonhide.GetArmorBaseMarketPrice(baseCost, mockEnchantments.Object, color);

            // Assert
            Assert.AreEqual(-15800, dragonhidePrice,
                            "-15800 = [(200 base + 150 masterwork) * (2 dragonhide)] - (66000 energy resistance * 25% discount)");
        }
        #endregion

        #endregion
    }
}