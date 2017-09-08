using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook
{
    [TestFixture]
    public class BarkskinTests
    {
        [Test]
        public void Barkskin_DruidVersion()
        {
            // Act
            var spell = Barkskin.DruidVersion;
			// Assert
			Assert.AreEqual("Barkskin", spell.Name);
			Assert.AreEqual(2, spell.Level);
            Assert.AreEqual(School.Transmutation, spell.School);
            Assert.IsEmpty(spell.Subschools);
            Assert.IsEmpty(spell.Descriptors);
        }


		[Test]
		public void Barkskin_RangerVersion()
		{
			// Act
            var spell = Barkskin.RangerVersion;
			// Assert
			Assert.AreEqual(2, spell.Level);
		}


		[Test]
		public void Barkskin_DefenseSubdomainVersion()
		{
			// Act
            var spell = Barkskin.DefenseSubdomainVersion;
			// Assert
			Assert.AreEqual(2, spell.Level);
		}


		[Test]
		public void Barkskin_PlantDomainVersion()
		{
			// Act
            var spell = Barkskin.PlantDomainVersion;
			// Assert
			Assert.AreEqual(2, spell.Level);
		}
    }
}