using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Materials
{
    [TestFixture]
    [Parallelizable]
    public class DarkwoodTests
    {
        [Test(Description = "Ensures Darkwood has the correct hardness.")]
        public void Hardness()
        {
            Assert.AreEqual(5, Darkwood.Hardness);
        }


        [Test(Description = "Ensures Darkwood has the correct hit points per inch of thickness.")]
        public void HitPointsPerInch()
        {
            Assert.AreEqual(10, Darkwood.HitPointsPerInch);
        }


        [Test(Description = "Ensures Darkwood cuts the weight of an item in half.")]
        public void GetWeight()
        {
            // Arrange
            double baseWeight = 12;

            // Act
            var darkwoodWeight = Darkwood.GetWeight(baseWeight);

            // Assert

            Assert.AreEqual(6, darkwoodWeight);
        }


        [Test(Description = "Ensures Darkwood reduces the armor check penalty of shields by 2.")]
        public void GetShieldArmorCheckPenalty_WasTwo_NowZero()
        {
            // Arrange
            byte baseArmorCheckPenalty = 2;

            // Act
            var darkwoodArmorCheckPenalty = Darkwood.GetShieldArmorCheckPenalty(baseArmorCheckPenalty);

            // Assert

            Assert.AreEqual(0, darkwoodArmorCheckPenalty);
        }


        [Test(Description = "Ensures Darkwood reduces the armor check penalty of shields by 2 (to a minimum of zero).")]
        public void GetShieldArmorCheckPenalty_WasOne_NowZero()
        {
            // Arrange
            byte baseArmorCheckPenalty = 1;

            // Act
            var darkwoodArmorCheckPenalty = Darkwood.GetShieldArmorCheckPenalty(baseArmorCheckPenalty);

            // Assert

            Assert.AreEqual(0, darkwoodArmorCheckPenalty);
        }


        [Test(Description = "Ensures Darkwood reduces the armor check penalty of shields by 2 (to a minimum of zero).")]
        public void GetShieldBaseMarketValue()
        {
            // Arrange
            double basePrice = 1000;
            double darkwoodWeight = 10; // normal weight 20 (darkwood cuts it in half)

            // Act
            var darkwoodValue = Darkwood.GetShieldBaseMarketValue(basePrice, darkwoodWeight);

            // Assert

            Assert.AreEqual(1350, darkwoodValue,
                            "1350 = (1000 base) + (150 masterwork) + (20gp * 10 weight)");
        }
    }
}