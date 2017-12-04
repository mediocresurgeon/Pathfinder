using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class EtherealnessTests
    {
        [Test(Description = "Ensures that a fresh instance of Etherealness has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var enchantment = new Etherealness();

            // Assert
            Assert.AreEqual("Etherealness", enchantment.Name.Text);
            Assert.AreEqual(0, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(49_000, enchantment.Cost);
            Assert.AreEqual(13, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Transmutation == s));
        }

        #region ApplyTo
        [Test(Description = "Ensures that Etherealness cannot be applied to a null character.")]
        public void ApplyTo_NullICharacter()
        {
            // Arrange
            var enchantment = new Etherealness();

            // Act
            TestDelegate applyTo = () => enchantment.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures that Reflecting cannot be applied to a null character.")]
        public void ApplyTo_Character_SpellLikeAbility()
        {
            // Arrange
            var slaKnown = Mock.Of<ISpellLikeAbilityCollection>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SpellLikeAbilities.Known)
                         .Returns(slaKnown);
            var enchantment = new Etherealness();

            // Act
            enchantment.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(slaKnown)
                .Verify(r => r.Add(It.Is<ISpellLikeAbility>(sla => sla.Spell is EtherealJaunt
                                                            && 1 == sla.UsesPerDay
                                                            && 13 == sla.CasterLevel.GetTotal()
                                                            && 7 == sla.Spell.Level)),
                        "Applying a Etherealness armor enchantment to a character should let the character cast Ethereal Jaunt once per day at caster level 13 using an ability score of 17.");
        }
        #endregion
    }
}