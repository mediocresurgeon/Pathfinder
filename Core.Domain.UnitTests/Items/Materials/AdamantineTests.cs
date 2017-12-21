using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Materials
{
    [TestFixture]
    [Parallelizable]
    public class AdamantineTests
    {
        [Test(Description = "Ensures that Adamantine has the correct hardness.")]
        public void Hardness()
        {
            Assert.AreEqual(20, Adamantine.Hardness);
        }


        [Test(Description = "Ensures that Adamantine has the correct hit points per inch of thickness.")]
        public void HitPointsPerInch()
        {
            Assert.AreEqual(40, Adamantine.HitPointsPerInch);
        }


        #region ArmorBaseMarketPrice
        [Test(Description = "Ensures that Adamantine increases the price of light armor by the correct amount.")]
        public void GetLightArmorBaseMarketPrice()
        {
            // Assert
            double baseMarketPrice = 0;

            // Act
            var adamantinePrice = Adamantine.GetLightArmorBaseMarketPrice(baseMarketPrice);

            // Assert
            Assert.AreEqual(5000, adamantinePrice,
                            "Adamantine should increase the price of light armor by +5000gp.");
        }


        [Test(Description = "Ensures that Adamantine increases the price of medium armor by the correct amount.")]
        public void GetMediumArmorBaseMarketPrice()
        {
            // Assert
            double baseMarketPrice = 0;

            // Act
            var adamantinePrice = Adamantine.GetMediumArmorBaseMarketPrice(baseMarketPrice);

            // Assert
            Assert.AreEqual(10_000, adamantinePrice,
                            "Adamantine should increase the price of light armor by +10000gp.");
        }


        [Test(Description = "Ensures that Adamantine increases the price of heavy armor by the correct amount.")]
        public void GetHeavyArmorBaseMarketPrice()
        {
            // Assert
            double baseMarketPrice = 0;

            // Act
            var adamantinePrice = Adamantine.GetHeavyArmorBaseMarketPrice(baseMarketPrice);

            // Assert
            Assert.AreEqual(15_000, adamantinePrice,
                            "Adamantine should increase the price of light armor by +15000gp.");
        }
        #endregion

        #region ArmorDamageReduction
        [Test(Description = "Ensures that Admanatine light armor has the correct type of damage reduction associated with it.")]
        public void GetLightArmorDamageReduction()
        {
            // Act
            var dr = Adamantine.GetLightArmorDamageReduction();

            // Assert
            Assert.AreEqual(1, dr.Magnitude());
            Assert.AreEqual("—", dr.BypassedBy);
        }


        [Test(Description = "Ensures that Admanatine medium armor has the correct type of damage reduction associated with it.")]
        public void GetMediumArmorDamageReduction()
        {
            // Act
            var dr = Adamantine.GetMediumArmorDamageReduction();

            // Assert
            Assert.AreEqual(2, dr.Magnitude());
            Assert.AreEqual("—", dr.BypassedBy);
        }


        [Test(Description = "Ensures that Admanatine heavy armor has the correct type of damage reduction associated with it.")]
        public void GetHeavyArmorDamageReduction()
        {
            // Act
            var dr = Adamantine.GetHeavyArmorDamageReduction();

            // Assert
            Assert.AreEqual(3, dr.Magnitude());
            Assert.AreEqual("—", dr.BypassedBy);
        }
        #endregion
    }
}