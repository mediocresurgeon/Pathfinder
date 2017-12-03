using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class AntimagicFieldTests
    {
        [Test(Description = "Ensures correct property values which are not characterclass-specific.")]
		public void AntimagicField_GenericProperties()
		{
			// Act
			var spell = AntimagicField.ClericVersion;
			// Assert
            Assert.AreEqual("Antimagic Field", spell.GetName().Text);
            Assert.IsFalse(spell.AllowsSavingThrow);
			Assert.AreEqual(School.Abjuration, spell.School);
            Assert.IsEmpty(spell.GetSubschools());
            Assert.IsEmpty(spell.GetDescriptors());
		}


        [Test]
        public void AntimagicField_ClericVersion()
        {
			// Act
			var spell = AntimagicField.ClericVersion;
			// Assert
			Assert.AreEqual(8, spell.Level);
        }


		[Test]
		public void AntimagicField_SorcererVersion()
		{
			// Act
            var spell = AntimagicField.SorcererVersion;
			// Assert
			Assert.AreEqual(6, spell.Level);
		}


		[Test]
		public void AntimagicField_WizardVersion()
		{
			// Act
            var spell = AntimagicField.WizardVersion;
			// Assert
			Assert.AreEqual(6, spell.Level);
		}


		[Test]
		public void AntimagicField_MagicDomainVersion()
		{
			// Act
            var spell = AntimagicField.MagicDomainVersion;
			// Assert
			Assert.AreEqual(6, spell.Level);
		}


		[Test]
		public void AntimagicField_ProtectionDomainVersion()
		{
			// Act
            var spell = AntimagicField.ProtectionDomainVersion;
			// Assert
			Assert.AreEqual(6, spell.Level);
		}
    }
}