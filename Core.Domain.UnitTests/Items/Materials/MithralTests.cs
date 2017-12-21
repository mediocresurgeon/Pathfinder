using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Materials
{
    [TestFixture]
    [Parallelizable]
    public class MithralTests
    {
        [Test(Description = "Ensures Mithral has the correct hardness.")]
        public void Hardness()
        {
            Assert.AreEqual(15, Mithral.Hardness);
        }


        [Test(Description = "Ensures Mithral has the correct hit points per inch of thickness.")]
        public void HitPointsPerInch()
        {
            Assert.AreEqual(30, Mithral.HitPointsPerInch);
        }


        [Test(Description = "Ensures Mithral cuts the weight of an item in half.")]
        public void GetWeight()
        {
            // Arrange
            double baseWeight = 12;

            // Act
            var mithralWeight = Mithral.GetWeight(baseWeight);

            // Assert

            Assert.AreEqual(6, mithralWeight);
        }


        [Test(Description = "Ensures Mithral reduces the armor check penalty by 3.")]
        public void GetArmorCheckPenalty_WasThree_NowZero()
        {
            // Arrange
            byte baseArmorCheckPenalty = 3;

            // Act
            var mithralArmorCheckPenalty = Mithral.GetArmorCheckPenalty(baseArmorCheckPenalty);

            // Assert

            Assert.AreEqual(0, mithralArmorCheckPenalty);
        }


        [Test(Description = "Ensures Mithral reduces the armor check penalty by 3 (to a minimum of zero).")]
        public void GetArmorCheckPenalty_WasTwo_NowZero()
        {
            // Arrange
            byte baseArmorCheckPenalty = 2;

            // Act
            var mithralArmorCheckPenalty = Mithral.GetArmorCheckPenalty(baseArmorCheckPenalty);

            // Assert

            Assert.AreEqual(0, mithralArmorCheckPenalty);
        }


        #region GetArmorMaximumDexterityBonus()
        [Test(Description = "Ensures that Mithral increases the maximum dexterity bonus of armor (typical case).")]
        public void GetArmorMaximumDexterityBonus_Zero()
        {
            // Arrange
            byte baseMaxDexBonus = 0;

            // Act
            var mithralValue = Mithral.GetArmorMaximumDexterityBonus(baseMaxDexBonus);

            // Assert

            Assert.AreEqual(2, mithralValue,
                            "2 = (0 base) + (2 mithral)");
        }


        [Test(Description = "Ensures that Mithral.GetArmorMaximumDexterityBonus() does not overflow when the argument is very large ")]
        public void GetArmorMaximumDexterityBonus_255()
        {
            // Arrange
            byte baseMaxDexBonus = byte.MaxValue;

            // Act
            var mithralValue = Mithral.GetArmorMaximumDexterityBonus(baseMaxDexBonus);

            // Assert

            Assert.AreEqual(255, mithralValue,
                            "255 <= (255 base) + (2 mithral)");
        }
        #endregion

        #region Market Price
        [Test(Description = "Ensures Darkwood reduces the armor check penalty of shields by 2 (to a minimum of zero).")]
        public void GetShieldBaseMarketValue()
        {
            // Arrange
            double basePrice = 1000;

            // Act
            var mithralValue = Mithral.GetShieldBaseMarketValue(basePrice);

            // Assert

            Assert.AreEqual(2000, mithralValue,
                            "2000 = (1000 base) + (1000 material; includes cost of masterwork)");
        }


        [Test(Description = "Ensures that Mithral increases the market value of light armor correctly.")]
        public void GetLightArmorBaseMarketPrice()
        {
            // Arrange
            double basePrice = 0;

            // Act
            var mithralPrice = Mithral.GetLightArmorBaseMarketPrice(basePrice);

            // Assert
            Assert.AreEqual(1000, mithralPrice,
                            "Mithral should increase the price of light armor by +1000gp.");
        }


        [Test(Description = "Ensures that Mithral increases the market value of medium armor correctly.")]
        public void GetMediumArmorBaseMarketPrice()
        {
            // Arrange
            double basePrice = 0;

            // Act
            var mithralPrice = Mithral.GetMediumArmorBaseMarketPrice(basePrice);

            // Assert
            Assert.AreEqual(4000, mithralPrice,
                            "Mithral should increase the price of medium armor by +4000gp.");
        }


        [Test(Description = "Ensures that Mithral increases the market value of medium armor correctly.")]
        public void GetHeavyArmorBaseMarketPrice()
        {
            // Arrange
            double basePrice = 0;

            // Act
            var mithralPrice = Mithral.GetHeavyArmorBaseMarketPrice(basePrice);

            // Assert
            Assert.AreEqual(9000, mithralPrice,
                            "Mithral should increase the price of heavy armor by +9000gp.");
        }
        #endregion
    }
}
