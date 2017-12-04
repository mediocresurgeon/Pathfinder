using System;
using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook.E
{
    [TestFixture]
    [Parallelizable]
    public class EtherealJauntTests
    {
        [Test(Description = "Ensures correct property values which are not characterclass-specific.")]
        public void GenericProperties()
        {
            // Act
            var spell = EtherealJaunt.ClericVersion;

            // Assert
            Assert.AreEqual("Ethereal Jaunt", spell.GetName().Text);
            Assert.IsFalse(spell.AllowsSavingThrow);
            Assert.AreEqual(School.Transmutation, spell.School);
            Assert.IsEmpty(spell.GetSubschools());
            Assert.IsEmpty(spell.GetDescriptors());
        }


        [Test]
        public void ClericVersion()
        {
            // Act
            var spell = EtherealJaunt.ClericVersion;

            // Assert
            Assert.AreEqual(7, spell.Level);
        }


        [Test]
        public void SorcererVersion()
        {
            // Act
            var spell = EtherealJaunt.SorcererVersion;

            // Assert
            Assert.AreEqual(7, spell.Level);
        }


        [Test]
        public void WizardVersion()
        {
            // Act
            var spell = EtherealJaunt.WizardVersion;

            // Assert
            Assert.AreEqual(7, spell.Level);
        }
    }
}