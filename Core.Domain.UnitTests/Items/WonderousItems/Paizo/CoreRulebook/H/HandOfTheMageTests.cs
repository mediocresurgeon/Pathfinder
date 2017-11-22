using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Items.WonderousItems.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.WonderousItems.Paizo.CoreRulebook.H
{
    [TestFixture]
    public class HandOfTheMageTests
    {
        #region Properties
        [Test(Description = "Ensures sensible defaults for a fresh instance of Hand of the Mage.")]
        public void Default()
        {
            // Arrange
            HandOfTheMage item = new HandOfTheMage();

            // Assert
            Assert.AreEqual(2, item.Weight);
            Assert.AreEqual(2, item.CasterLevel);
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
            // Arrange
            bool appliedCorrectly = false; // We'll check on this later

            var charisma = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(ab => ab.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.SpellLikeAbilities.Registrar.Register(
                            It.Is<byte>(input => 0 == input),                  // 0 time per day means it is at-will
                            It.Is<MageHand>(input => true),                    // spell should be of type MageHand
                            It.Is<IAbilityScore>(input => charisma == input))) // Spell should be tied to charisma ability score
                         .Callback(() => appliedCorrectly = true);

            HandOfTheMage item = new HandOfTheMage();

            // Act
            item.ApplyTo(mockCharacter.Object);

            // Assert
            Assert.IsTrue(appliedCorrectly);
        }
        #endregion
    }
}