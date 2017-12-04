using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook.C
{
    [TestFixture]
    [Parallelizable]
    public class CureLightWoundsTests
    {
		[Test(Description = "Ensures correct property values which are not characterclass-specific.")]
		public void GenericProperties()
		{
			// Act
            var spell = CureLightWounds.BardVersion;
			
            // Assert
            Assert.AreEqual("Cure Light Wounds", spell.GetName().Text);
            Assert.IsTrue(spell.AllowsSavingThrow);
			Assert.AreEqual(School.Conjuration, spell.School);
            Assert.That(spell.GetSubschools(), Has.Exactly(1).Matches<Subschool>(s => Subschool.Healing == s));
            Assert.IsEmpty(spell.GetDescriptors());
		}


        [Test]
		public void BardVersion()
		{
			// Act
			var spell = CureLightWounds.BardVersion;
			
            // Assert
			Assert.AreEqual(1, spell.Level);
		}


        [Test]
        public void ClericVersion()
        {
            // Act
            var spell = CureLightWounds.ClericVersion;

            // Assert
            Assert.AreEqual(1, spell.Level);
        }


        [Test]
		public void DruidVersion()
		{
			// Act
            var spell = CureLightWounds.DruidVersion;
			
            // Assert
			Assert.AreEqual(1, spell.Level);
		}


        [Test]
		public void PaladinVersion()
		{
			// Act
            var spell = CureLightWounds.PaladinVersion;
			
            // Assert
			Assert.AreEqual(1, spell.Level);
		}


        [Test]
		public void RangerVersion()
		{
			// Act
            var spell = CureLightWounds.RangerVersion;
			
            // Assert
			Assert.AreEqual(2, spell.Level);
		}


        [Test]
		public void HealingDomainVersion()
		{
			// Act
            var spell = CureLightWounds.HealingDomainVersion;
			
            // Assert
			Assert.AreEqual(1, spell.Level);
		}
    }
}