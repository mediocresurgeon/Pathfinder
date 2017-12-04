using System;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class ShadowTests
    {
        #region Shadow
        [Test(Description = "Ensures that a fresh instance of Shadow has sensible defaults.")]
        public void Regular_Default()
        {
            // Arrange
            var enchantment = new Shadow(ShadowStrength.Regular);

            // Assert
            Assert.AreEqual("Shadow", enchantment.Name.Text);
            Assert.AreEqual(0, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(3750, enchantment.Cost);
            Assert.AreEqual(5, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Illusion == s));
            Assert.Throws<ArgumentNullException>(() => enchantment.ApplyTo(null));
        }


        [Test(Description = "Ensures that Shadow affects a character's Stealth skill properly.")]
        public void Regular_ApplyTo()
        {
            // Arrange
            var competenceBonusTracker = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Skills.Stealth.CompetenceBonuses)
                         .Returns(competenceBonusTracker);
            var enchantment = new Shadow(ShadowStrength.Regular);

            // Act
            enchantment.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(competenceBonusTracker)
                .Verify(er => er.Add(It.Is<Func<byte>>(calc => 5 == calc())),
                        "Shadow should give a +5 competence bonus to a character's Stealth skill.");
        }
        #endregion

        #region Improved Shadow
        [Test(Description = "Ensures that a fresh instance of Improved Shadow has sensible defaults.")]
        public void Improved_Default()
        {
            // Arrange
            var enchantment = new Shadow(ShadowStrength.Improved);

            // Assert
            Assert.AreEqual("Improved Shadow", enchantment.Name.Text);
            Assert.AreEqual(0, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(15_000, enchantment.Cost);
            Assert.AreEqual(10, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Illusion == s));
            Assert.Throws<ArgumentNullException>(() => enchantment.ApplyTo(null));
        }


        [Test(Description = "Ensures that Improved Shadow affects a character's Stealth skill properly.")]
        public void Improved_ApplyTo()
        {
            // Arrange
            var competenceBonusTracker = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Skills.Stealth.CompetenceBonuses)
                         .Returns(competenceBonusTracker);
            var enchantment = new Shadow(ShadowStrength.Improved);

            // Act
            enchantment.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(competenceBonusTracker)
                .Verify(er => er.Add(It.Is<Func<byte>>(calc => 10 == calc())),
                        "Improved Shadow should give a +10 competence bonus to a character's Stealth skill.");
        }
        #endregion

        #region Greater Shadow
        [Test(Description = "Ensures that a fresh instance of Greater Shadow has sensible defaults.")]
        public void Greater_Default()
        {
            // Arrange
            var enchantment = new Shadow(ShadowStrength.Greater);

            // Assert
            Assert.AreEqual("Greater Shadow", enchantment.Name.Text);
            Assert.AreEqual(0, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(33750, enchantment.Cost);
            Assert.AreEqual(15, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Illusion == s));
            Assert.Throws<ArgumentNullException>(() => enchantment.ApplyTo(null));
        }


        [Test(Description = "Ensures that Greater Shadow affects a character's Stealth skill properly.")]
        public void Greater_ApplyTo()
        {
            // Arrange
            var competenceBonusTracker = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Skills.Stealth.CompetenceBonuses)
                         .Returns(competenceBonusTracker);
            var enchantment = new Shadow(ShadowStrength.Greater);

            // Act
            enchantment.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(competenceBonusTracker)
                .Verify(er => er.Add(It.Is<Func<byte>>(calc => 15 == calc())),
                        "Greater Shadow should give a +15 competence bonus to a character's Stealth skill.");
        }
        #endregion
    }
}