using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Materials
{
    [TestFixture]
    [Parallelizable]
    public class WoodTests
    {
        [Test(Description = "Ensures Wood has the correct hardness.")]
        public void Hardness()
        {
            Assert.AreEqual(5, Wood.Hardness);
        }


        [Test(Description = "Ensures Wood has the correct hit points per inch of thickness.")]
        public void HitPointsPerInch()
        {
            Assert.AreEqual(10, Wood.HitPointsPerInch);
        }
    }
}