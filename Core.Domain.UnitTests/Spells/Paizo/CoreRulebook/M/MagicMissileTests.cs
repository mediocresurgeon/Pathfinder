using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class MagicMissileTests
    {
        [Test(Description = "Ensures correct property values which are not characterclass-specific.")]
        public void MagicMissile_GenericProperties()
        {
			// Act
            var spell = MagicMissile.SorcererVersion;
			// Assert
            Assert.AreEqual("Magic Missile", spell.GetName().Text);
            Assert.IsFalse(spell.AllowsSavingThrow);
			Assert.AreEqual(School.Evocation, spell.School);
            Assert.IsEmpty(spell.GetSubschools());
            Assert.That(spell.GetDescriptors(), Has.Exactly(1).Matches<Descriptor>(d => Descriptor.Force == d));
        }


		[Test]
		public void MagicMissile_SorcererVersion()
		{
			// Act
			var spell = MagicMissile.SorcererVersion;
			// Assert
			Assert.AreEqual(1, spell.Level);
		}


		[Test]
		public void MagicMissile_WizardVersion()
		{
			// Act
            var spell = MagicMissile.WizardVersion;
			// Assert
			Assert.AreEqual(1, spell.Level);
		}
    }
}