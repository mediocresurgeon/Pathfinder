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
        public void MageHand_GenericProperties()
        {
            // Act
            var spell = MageHand.BardVersion;
            // Assert
            Assert.AreEqual("Mage Hand", spell.Name);
            Assert.IsFalse(spell.AllowsSavingThrow);
            Assert.AreEqual(School.Transmutation, spell.School);
            Assert.IsEmpty(spell.Subschools);
            Assert.IsEmpty(spell.Descriptors);
        }


        [Test]
        public void MageHand_BardVersion()
        {
            // Act
            var spell = MageHand.BardVersion;
            // Assert
            Assert.AreEqual(0, spell.Level);
        }


        [Test]
        public void MageHand_SorcererVersion()
        {
            // Act
            var spell = MageHand.SorcererVersion;
            // Assert
            Assert.AreEqual(0, spell.Level);
        }


        [Test]
        public void MageHand_WizardVersion()
        {
            // Act
            var spell = MageHand.WizardVersion;
            // Assert
            Assert.AreEqual(0, spell.Level);
        }
    }
}