using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Materials
{
    [TestFixture]
    [Parallelizable]
    public class ClothTests
    {
        [Test(Description = "Ensures Cloth has the correct hardness.")]
        public void Hardness()
        {
            Assert.AreEqual(0, Cloth.Hardness);
        }


        [Test(Description = "Ensures Cloth has the correct hit points per inch of thickness.")]
        public void HitPointsPerInch()
        {
            Assert.AreEqual(2, Cloth.HitPointsPerInch);
        }
    }
}