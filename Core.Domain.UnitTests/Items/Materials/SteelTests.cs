using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Materials
{
    [TestFixture]
    [Parallelizable]
    public class SteelTests
    {
        [Test(Description = "Ensures Steel has the correct hardness.")]
        public void Hardness()
        {
            Assert.AreEqual(10, Steel.Hardness);
        }


        [Test(Description = "Ensures Steel has the correct hit points per inch of thickness.")]
        public void HitPointsPerInch()
        {
            Assert.AreEqual(30, Steel.HitPointsPerInch);
        }
    }
}