using Core.Domain.Spells;
using NUnit.Framework;
using System.Linq;

namespace Core.Domain.UnitTests.Spells
{
    [TestFixture]
    public class AntimagicFieldTests
    {
        [Test]
		public void AntimagicField_AsCleric()
		{
			// Act
			var spell = AntimagicField.AsCleric;
			// Assert
			Assert.AreEqual("Antimagic Field", spell.Name);
			Assert.AreEqual(8, spell.Level);
			Assert.AreEqual(School.Abjuration, spell.School);
            Assert.IsFalse(spell.Subschools.Any());
            Assert.IsFalse(spell.Descriptors.Any());
		}


		[Test]
		public void AntimagicField_AsSorcerer()
		{
			// Act
            var spell = AntimagicField.AsSorcerer;
			// Assert
			Assert.AreEqual(6, spell.Level);
		}


		[Test]
		public void AntimagicField_AsWizard()
		{
			// Act
            var spell = AntimagicField.AsWizard;
			// Assert
			Assert.AreEqual(6, spell.Level);
		}


		[Test]
		public void AntimagicField_AsMagicDomain()
		{
			// Act
            var spell = AntimagicField.AsMagicDomain;
			// Assert
			Assert.AreEqual(6, spell.Level);
		}


		[Test]
		public void AntimagicField_AsProtectionDomain()
		{
			// Act
            var spell = AntimagicField.AsProtectionDomain;
			// Assert
			Assert.AreEqual(6, spell.Level);
		}
    }
}