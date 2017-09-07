using Core.Domain.Spells;
using NUnit.Framework;
using System.Linq;

namespace Core.Domain.UnitTests.Spells
{
    [TestFixture]
    public class CureLightWoundsTests
    {
		[Test]
		public void CureLightWounds_AsBard()
		{
			// Act
			var spell = CureLightWounds.AsBard;
			// Assert
			Assert.AreEqual("Cure Light Wounds", spell.Name);
			Assert.AreEqual(1, spell.Level);
			Assert.AreEqual(School.Conjuration, spell.School);
            Assert.That(spell.Subschools, Has.Exactly(1).Matches<Subschool>(s => Subschool.Healing == s));
            Assert.IsEmpty(spell.Descriptors);
		}

        [Test]
        public void CureLightWounds_AsCleric()
        {
            // Act
            var spell = CureLightWounds.AsCleric;
            // Assert
            Assert.AreEqual(1, spell.Level);
        }


        [Test]
		public void CureLightWounds_AsDruid()
		{
			// Act
			var spell = CureLightWounds.AsDruid;
			// Assert
			Assert.AreEqual(1, spell.Level);
		}


        [Test]
		public void CureLightWounds_AsPaladin()
		{
			// Act
			var spell = CureLightWounds.AsPaladin;
			// Assert
			Assert.AreEqual(1, spell.Level);
		}


        [Test]
		public void CureLightWounds_AsRanger()
		{
			// Act
			var spell = CureLightWounds.AsRanger;
			// Assert
			Assert.AreEqual(2, spell.Level);
		}


        [Test]
		public void CureLightWounds_AsHealingDomain()
		{
			// Act
			var spell = CureLightWounds.AsHealingDomain;
			// Assert
			Assert.AreEqual(1, spell.Level);
		}
    }
}