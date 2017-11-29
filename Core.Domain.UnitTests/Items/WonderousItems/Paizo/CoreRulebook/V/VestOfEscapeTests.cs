using System;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.Skills;
using Core.Domain.Items.WonderousItems.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.WonderousItems.Paizo.CoreRulebook.V
{
    [TestFixture]
    public class VestOfEscapeTests
    {
        [Test(Description = "Ensures a fresh instance of Vest of Escape has sensible defaults.")]
        public void Default()
        {
            // Arrange
            VestOfEscape item = new VestOfEscape();

            // Assert
            Assert.AreEqual(0, item.Weight);
            Assert.AreEqual(4, item.CasterLevel);
            Assert.AreEqual(0, item.GetHardness());
            Assert.AreEqual(1, item.GetHitPoints());
            Assert.AreEqual(5200, item.GetMarketPrice());
            Assert.AreEqual("Vest of Escape", item.GetName()[0].Text);
            Assert.Contains(School.Conjuration, item.GetSchools());
            Assert.Contains(School.Transmutation, item.GetSchools());
        }


        #region ApplyTo()
        [Test(Description = "Ensures Vest of Escape cannot be applied to a null character.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;
            VestOfEscape item = new VestOfEscape();

            // Act
            TestDelegate applyTo = () => item.ApplyTo(character);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures Vest of Escape applies its bonus to Disable Device correctly.")]
        public void ApplyTo_DisableDevice()
        {
            // Arrange
            var bonusTracker = Mock.Of<IModifierTracker>();
 
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Skills.DisableDevice.CompetenceBonuses)
                         .Returns(bonusTracker);

            VestOfEscape item = new VestOfEscape();

            // Act
            item.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(bonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 4 == calc())),
                        "Vest of Escape did not apply its bonus to Disable Device correctly.");
        }


        [Test(Description = "Ensures Vest of Escape applies its bonus to Escape Artist correctly.")]
        public void ApplyTo_EscapeArtist()
        {
            // Arrange
            var bonusTracker = Mock.Of<IModifierTracker>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Skills.EscapeArtist.CompetenceBonuses)
                         .Returns(bonusTracker);

            VestOfEscape item = new VestOfEscape();

            // Act
            item.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(bonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 6 == calc())),
                        "Vest of Escape did not apply its bonus to Escape Artist correctly.");
        }
        #endregion
    }
}