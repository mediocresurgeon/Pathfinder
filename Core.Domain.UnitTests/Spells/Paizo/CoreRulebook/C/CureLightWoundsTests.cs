using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook
{
    [TestFixture]
    public class CureLightWoundsTests
    {
		[Test]
		public void CureLightWounds_BardVersion()
		{
			// Act
            var spell = CureLightWounds.BardVersion;
			// Assert
			Assert.AreEqual("Cure Light Wounds", spell.Name);
			Assert.AreEqual(1, spell.Level);
			Assert.AreEqual(School.Conjuration, spell.School);
            Assert.That(spell.Subschools, Has.Exactly(1).Matches<Subschool>(s => Subschool.Healing == s));
            Assert.IsEmpty(spell.Descriptors);
		}


        [Test]
        public void CureLightWounds_ClericVersion()
        {
            // Act
            var spell = CureLightWounds.ClericVersion;
            // Assert
            Assert.AreEqual(1, spell.Level);
        }


        [Test]
		public void CureLightWounds_DruidVersion()
		{
			// Act
            var spell = CureLightWounds.DruidVersion;
			// Assert
			Assert.AreEqual(1, spell.Level);
		}


        [Test]
		public void CureLightWounds_PaladinVersion()
		{
			// Act
            var spell = CureLightWounds.PaladinVersion;
			// Assert
			Assert.AreEqual(1, spell.Level);
		}


        [Test]
		public void CureLightWounds_RangerVersion()
		{
			// Act
            var spell = CureLightWounds.RangerVersion;
			// Assert
			Assert.AreEqual(2, spell.Level);
		}


        [Test]
		public void CureLightWounds_HealingDomainVersion()
		{
			// Act
            var spell = CureLightWounds.HealingDomainVersion;
			// Assert
			Assert.AreEqual(1, spell.Level);
		}
    }
}