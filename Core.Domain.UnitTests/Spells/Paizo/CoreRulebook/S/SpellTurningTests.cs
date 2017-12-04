using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook.S
{
    [TestFixture]
    [Parallelizable]
    public class SpellTurningTests
    {
        [Test(Description = "Ensures correct property values which are not characterclass-specific.")]
        public void GenericProperties()
        {
            // Act
            var spell = SpellTurning.SorcererVersion;

            // Assert
            Assert.AreEqual("Spell Turning", spell.GetName().Text);
            Assert.IsFalse(spell.AllowsSavingThrow);
            Assert.AreEqual(School.Abjuration, spell.School);
            Assert.IsEmpty(spell.GetSubschools());
            Assert.IsEmpty(spell.GetDescriptors());
        }


        [Test]
        public void LuckDomainVersion()
        {
            // Act
            var spell = SpellTurning.LuckDomainVersion;

            // Assert
            Assert.AreEqual(7, spell.Level);
        }


        [Test]
        public void MagicDomainVersion()
        {
            // Act
            var spell = SpellTurning.MagicDomainVersion;

            // Assert
            Assert.AreEqual(7, spell.Level);
        }


        [Test]
        public void SorcererVersion()
        {
            // Act
            var spell = SpellTurning.SorcererVersion;

            // Assert
            Assert.AreEqual(7, spell.Level);
        }


        [Test]
        public void WizardVersion()
        {
            // Act
            var spell = SpellTurning.WizardVersion;

            // Assert
            Assert.AreEqual(7, spell.Level);
        }
    }
}