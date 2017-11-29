using Core.Domain.Characters.EnergyResistances;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.EnergyResistances
{
    [TestFixture]
    public class EnergyResistanceSectionTests
    {
        [Test(Description = "Ensures that a fresh instance of EnergyResistanceSection has correct defaults.")]
        public void Default()
        {
            // Assert
            var enResSec = new EnergyResistanceSection();

            // Assert
            Assert.IsInstanceOf<EnergyResistance>(enResSec.AcidResistance);
            Assert.IsInstanceOf<EnergyResistance>(enResSec.ColdResistance);
            Assert.IsInstanceOf<EnergyResistance>(enResSec.ElectricityResistance);
            Assert.IsInstanceOf<EnergyResistance>(enResSec.FireResistance);
            Assert.IsInstanceOf<EnergyResistance>(enResSec.SonicResistance);
        }
    }
}