using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook.B
{
    [TestFixture]
    [Parallelizable]
    public class BarkskinTests
    {
        [Test(Description = "Ensures correct property values which are not characterclass-specific.")]
        public void GenericProperties()
        {
            // Act
            var spell = Barkskin.DruidVersion;
			
            // Assert
            Assert.AreEqual("Barkskin", spell.GetName().Text);
            Assert.IsFalse(spell.AllowsSavingThrow);
            Assert.AreEqual(School.Transmutation, spell.School);
            Assert.IsEmpty(spell.GetSubschools());
            Assert.IsEmpty(spell.GetDescriptors());
        }


        [Test]
		public void DruidVersion()
		{
			// Act
			var spell = Barkskin.DruidVersion;
			
            // Assert
			Assert.AreEqual(2, spell.Level);
		}


		[Test]
		public void RangerVersion()
		{
			// Act
            var spell = Barkskin.RangerVersion;
			
            // Assert
			Assert.AreEqual(2, spell.Level);
		}


		[Test]
		public void DefenseSubdomainVersion()
		{
			// Act
            var spell = Barkskin.DefenseSubdomainVersion;
			
            // Assert
			Assert.AreEqual(2, spell.Level);
		}


		[Test]
		public void PlantDomainVersion()
		{
			// Act
            var spell = Barkskin.PlantDomainVersion;
			
            // Assert
			Assert.AreEqual(2, spell.Level);
		}
    }
}