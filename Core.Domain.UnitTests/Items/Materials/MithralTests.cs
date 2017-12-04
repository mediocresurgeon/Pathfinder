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
    }
}
