using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class ReflectingTests
    {
        [Test(Description = "Ensures that a fresh instance of Reflecting has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var enchantment = new Reflecting();

            // Assert
            Assert.AreEqual("Reflecting", enchantment.Name.Text);
            Assert.AreEqual(5, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(14, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Abjuration == s));
        }

        #region ApplyTo
        [Test(Description = "Ensures that Reflecting cannot be applied to a null character.")]
        public void ApplyTo_NullICharacter()
        {
            // Arrange
            var enchantment = new Reflecting();

            // Act
            TestDelegate applyTo = () => enchantment.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures that a character with the Reflecting enchantment can cast Spell Turning as a spell-like ability.")]
        public void ApplyTo_Character_SpellLikeAbility()
        {
            // Arrange
            var slaKnown = Mock.Of<ISpellLikeAbilityCollection>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SpellLikeAbilities.Known)
                         .Returns(slaKnown);
            var enchantment = new Reflecting();

            // Act
            enchantment.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(slaKnown)
                .Verify(r => r.Add(It.Is<ISpellLikeAbility>(sla => sla.Spell is SpellTurning
                                                            && 1  == sla.UsesPerDay
                                                            && 14 == sla.CasterLevel.GetTotal()
                                                            && 7  == sla.Spell.Level)),
                        "Applying a Reflecting shield enchantment to a character should let the character cast Spell Turnng once per day at caster level 14 using an ability score of 17.");
        }
        #endregion
    }
}