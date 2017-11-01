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
            bool appliedToSkillCorrectly = false; // we'll check on this later

            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.Add(It.Is<byte>(input => 4 == input)))
                            .Callback(() => appliedToSkillCorrectly = true);

            var mockSkill = new Mock<ISkill>();
            mockSkill.Setup(s => s.CompetenceBonuses)
                     .Returns(mockBonusTracker.Object);

            var mockSkillSection = new Mock<ISkillSection>();
            mockSkillSection.Setup(ss => ss.DisableDevice)
                            .Returns(mockSkill.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Skills)
                         .Returns(mockSkillSection.Object);

            VestOfEscape item = new VestOfEscape();

            // Act
            item.ApplyTo(mockCharacter.Object);

            // Assert
            Assert.IsTrue(appliedToSkillCorrectly,
                         "Vest of Escape did not apply its bonus to Disable Device correctly.");
        }


        [Test(Description = "Ensures Vest of Escape applies its bonus to Escape Artist correctly.")]
        public void ApplyTo_EscapeArtist()
        {
            // Arrange
            bool appliedToSkillCorrectly = false; // we'll check on this later

            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.Add(It.Is<byte>(input => 6 == input)))
                            .Callback(() => appliedToSkillCorrectly = true);

            var mockSkill = new Mock<ISkill>();
            mockSkill.Setup(s => s.CompetenceBonuses)
                     .Returns(mockBonusTracker.Object);

            var mockSkillSection = new Mock<ISkillSection>();
            mockSkillSection.Setup(ss => ss.EscapeArtist)
                            .Returns(mockSkill.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Skills)
                         .Returns(mockSkillSection.Object);

            VestOfEscape item = new VestOfEscape();

            // Act
            item.ApplyTo(mockCharacter.Object);

            // Assert
            Assert.IsTrue(appliedToSkillCorrectly,
                         "Vest of Escape did not apply its bonus to Escape Artist correctly.");
        }
        #endregion
    }
}