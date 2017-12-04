using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook.M
{
    [TestFixture]
    [Parallelizable]
    public class MageHandTests
    {
        [Test(Description = "Ensures correct property values which are not characterclass-specific.")]
        public void GenericProperties()
        {
            // Act
            var spell = MageHand.BardVersion;

            // Assert
            Assert.AreEqual("Mage Hand", spell.GetName().Text);
            Assert.IsFalse(spell.AllowsSavingThrow);
            Assert.AreEqual(School.Transmutation, spell.School);
            Assert.IsEmpty(spell.GetSubschools());
            Assert.IsEmpty(spell.GetDescriptors());
        }


        [Test]
        public void BardVersion()
        {
            // Act
            var spell = MageHand.BardVersion;

            // Assert
            Assert.AreEqual(0, spell.Level);
        }


        [Test]
        public void SorcererVersion()
        {
            // Act
            var spell = MageHand.SorcererVersion;

            // Assert
            Assert.AreEqual(0, spell.Level);
        }


        [Test]
        public void WizardVersion()
        {
            // Act
            var spell = MageHand.WizardVersion;

            // Assert
            Assert.AreEqual(0, spell.Level);
        }
    }
}