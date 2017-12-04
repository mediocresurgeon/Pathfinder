using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Materials
{
    [TestFixture]
    [Parallelizable]
    public class LeatherTests
    {
        [Test(Description = "Ensures Leather has the correct hardness.")]
        public void Hardness()
        {
            Assert.AreEqual(2, Leather.Hardness);
        }


        [Test(Description = "Ensures Leather has the correct hit points per inch of thickness.")]
        public void HitPointsPerInch()
        {
            Assert.AreEqual(5, Leather.HitPointsPerInch);
        }
    }
}
