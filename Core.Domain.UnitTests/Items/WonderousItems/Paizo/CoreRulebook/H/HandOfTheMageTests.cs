using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Items.WonderousItems.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.WonderousItems.Paizo.CoreRulebook.H
{
    [TestFixture]
    [Parallelizable]
    public class HandOfTheMageTests
    {
        #region Properties
        [Test(Description = "Ensures sensible defaults for a fresh instance of Hand of the Mage.")]
        public void Default()
        {
            // Arrange
            HandOfTheMage item = new HandOfTheMage();

            // Assert
            Assert.AreEqual(2, item.GetWeight());
            Assert.AreEqual(2, item.GetCasterLevel());
            Assert.AreEqual(2, item.GetHardness());
            Assert.AreEqual(5, item.GetHitPoints());
            Assert.AreEqual(900, item.GetMarketPrice());
            Assert.AreEqual("Hand of the Mage", item.GetName()[0].Text);
            Assert.Contains(School.Transmutation, item.GetSchools());
        }
        #endregion

        #region ApplyTo()
        [Test(Description = "Ensures that HandOfTheMage cannot be applied to a null character.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;
            HandOfTheMage item = new HandOfTheMage();

            // Act
            TestDelegate apply = () => item.ApplyTo(character);

            // Assert
            Assert.Throws<ArgumentNullException>(apply);
        }


        [Test(Description = "Ensures that HandOfTheMage cannot be applied to a null character.")]
        public void ApplyTo()
        {
            // Assert
            var slaReg = Mock.Of<ISpellLikeAbilityRegistrar>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SpellLikeAbilities.Registrar)
                         .Returns(slaReg);

            HandOfTheMage item = new HandOfTheMage();

            // Act
            item.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(slaReg)
                .Verify(r => r.Register(It.Is<byte>(usesPerDay => 0 == usesPerDay),
                                        It.Is<ISpell>(spell => spell is MageHand && 0 == spell.Level),
                                        It.Is<IAbilityScore>(abs => 10 == abs.BaseScore)),
                        "Mage Hand should register a level 0 Mage Hand as a spell-like ability allowing unlimited uses per day with a casting stat of 10.");
        }
        #endregion
    }
}