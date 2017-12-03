using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook.F
{
    [TestFixture]
    [Parallelizable]
    public class FlyTests
    {
        [Test(Description = "Ensures correct property values which are not characterclass-specific.")]
        public void Fly_GenericProperties()
        {
            // Act
            var spell = Fly.WizardVersion;
            // Assert
            Assert.AreEqual("Fly", spell.GetName().Text);
            Assert.IsTrue(spell.AllowsSavingThrow);
            Assert.AreEqual(School.Transmutation, spell.School);
            Assert.IsEmpty(spell.GetSubschools());
            Assert.IsEmpty(spell.GetDescriptors());
        }


        [Test]
        public void Fly_SorcererVersion()
        {
            // Act
            var spell = Fly.SorcererVersion;
            // Assert
            Assert.AreEqual(3, spell.Level);
        }


        [Test]
        public void Fly_WizardVersion()
        {
            // Act
            var spell = Fly.WizardVersion;
            // Assert
            Assert.AreEqual(3, spell.Level);
        }


        [Test]
        public void Fly_TravelSubdomainVersion()
        {
            // Act
            var spell = Fly.TravelDomainVersion;
            // Assert
            Assert.AreEqual(3, spell.Level);
        }


        [Test]
        public void Fly_VoidDomainVersion()
        {
            // Act
            var spell = Fly.VoidDomainVersion;
            // Assert
            Assert.AreEqual(3, spell.Level);
        }
    }
}