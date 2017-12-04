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
    public class SlickTests
    {
        #region Slick
        [Test(Description = "Ensures that a fresh instance of Slick has sensible defaults.")]
        public void Regular_Default()
        {
            // Arrange
            var enchantment = new Slick(SlickStrength.Regular);

            // Assert
            Assert.AreEqual("Slick", enchantment.Name.Text);
            Assert.AreEqual(0, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(3750, enchantment.Cost);
            Assert.AreEqual(4, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Conjuration == s));
            Assert.Throws<ArgumentNullException>(() => enchantment.ApplyTo(null));
        }


        [Test(Description = "Ensures that Slick affects a character's Escape Artist skill properly.")]
        public void Regular_ApplyTo()
        {
            // Arrange
            var competenceBonusTracker = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Skills.EscapeArtist.CompetenceBonuses)
                         .Returns(competenceBonusTracker);
            var enchantment = new Slick(SlickStrength.Regular);

            // Act
            enchantment.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(competenceBonusTracker)
                .Verify(er => er.Add(It.Is<Func<byte>>(calc => 5 == calc())),
                        "Slick should give a +5 competence bonus to a character's Escape Artist skill.");
        }
        #endregion

        #region Improved Slick
        [Test(Description = "Ensures that a fresh instance of Improved Slick has sensible defaults.")]
        public void Improved_Default()
        {
            // Arrange
            var enchantment = new Slick(SlickStrength.Improved);

            // Assert
            Assert.AreEqual("Improved Slick", enchantment.Name.Text);
            Assert.AreEqual(0, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(15_000, enchantment.Cost);
            Assert.AreEqual(10, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Conjuration == s));
            Assert.Throws<ArgumentNullException>(() => enchantment.ApplyTo(null));
        }


        [Test(Description = "Ensures that Improved Slick affects a character's Escape Artist skill properly.")]
        public void Improved_ApplyTo()
        {
            // Arrange
            var competenceBonusTracker = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Skills.EscapeArtist.CompetenceBonuses)
                         .Returns(competenceBonusTracker);
            var enchantment = new Slick(SlickStrength.Improved);

            // Act
            enchantment.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(competenceBonusTracker)
                .Verify(er => er.Add(It.Is<Func<byte>>(calc => 10 == calc())),
                        "Improved Slick should give a +10 competence bonus to a character's Escape Artist skill.");
        }
        #endregion

        #region Greater Slick
        [Test(Description = "Ensures that a fresh instance of Greater Slick has sensible defaults.")]
        public void Greater_Default()
        {
            // Arrange
            var enchantment = new Slick(SlickStrength.Greater);

            // Assert
            Assert.AreEqual("Greater Slick", enchantment.Name.Text);
            Assert.AreEqual(0, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(33750, enchantment.Cost);
            Assert.AreEqual(15, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Conjuration == s));
            Assert.Throws<ArgumentNullException>(() => enchantment.ApplyTo(null));
        }


        [Test(Description = "Ensures that Greater Slick affects a character's Escape Artist skill properly.")]
        public void Greater_ApplyTo()
        {
            // Arrange
            var competenceBonusTracker = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Skills.EscapeArtist.CompetenceBonuses)
                         .Returns(competenceBonusTracker);
            var enchantment = new Slick(SlickStrength.Greater);

            // Act
            enchantment.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(competenceBonusTracker)
                .Verify(er => er.Add(It.Is<Func<byte>>(calc => 15 == calc())),
                        "Greater Slick should give a +15 competence bonus to a character's Escape Artist skill.");
        }
        #endregion
    }
}