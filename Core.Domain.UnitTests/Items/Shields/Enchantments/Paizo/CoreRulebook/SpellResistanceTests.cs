using System;
using System.ComponentModel;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    public class SpellResistanceTests
    {
        [Test(Description = "Ensures that Spell Resistance will not accept nonstandard enum values.")]
        public void SpellResistance_NonstandardEnum_Throws()
        {
            // Arrange
            SpellResistanceMagnitude badValue = (SpellResistanceMagnitude)(-1);

            // Act
            TestDelegate constructor = () => new SpellResistance(badValue);

            // Assert
            Assert.Throws<InvalidEnumArgumentException>(constructor);
        }


        [Test(Description = "Ensures Spell Resistance (13) cannot be applied to a null ICharacter.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            var enchantment = new SpellResistance(SpellResistanceMagnitude.SR13);

            // Act
            TestDelegate applyTo = () => enchantment.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        #region SR 13
        [Test(Description = "Ensures that a fresh instance of Spell Resistance (13) has sensible defaults.")]
        public void SpellResistance_13_Default()
        {
            // Arrange
            var enchantment = new SpellResistance(SpellResistanceMagnitude.SR13);

            // Assert
            Assert.AreEqual("Spell Resistance (13)", enchantment.Name.Text);
            Assert.AreEqual(2, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(15, enchantment.CasterLevel);
            Assert.AreEqual(1, enchantment.GetSchools().Length);
            Assert.Contains(School.Abjuration, enchantment.GetSchools());
        }


        [Test(Description = "Ensures that Spell Resistance (13) bestows spell resistance 13 onto characters.")]
        public void SpellResistance_13_ApplyTo()
        {
            // Arrange
            var spellResistanceTracker = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SpellResistance)
                         .Returns(spellResistanceTracker);

            var enchantment = new SpellResistance(SpellResistanceMagnitude.SR13);

            // Act
            enchantment.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(spellResistanceTracker)
                .Verify(srt => srt.Add(It.Is<Func<byte>>(calc => 13 == calc())),
                        "Applying a Spell Reistance (13) enchantment to a character should give the character 13 spell resistance.");
        }
        #endregion

        #region SR 15
        [Test(Description = "Ensures that a fresh instance of Spell Resistance (15) has sensible defaults.")]
        public void SpellResistance_15_Default()
        {
            // Arrange
            var enchantment = new SpellResistance(SpellResistanceMagnitude.SR15);

            // Assert
            Assert.AreEqual("Spell Resistance (15)", enchantment.Name.Text);
            Assert.AreEqual(3, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(15, enchantment.CasterLevel);
            Assert.AreEqual(1, enchantment.GetSchools().Length);
            Assert.Contains(School.Abjuration, enchantment.GetSchools());
        }


        [Test(Description = "Ensures that Spell Resistance (15) bestows spell resistance 15 onto characters.")]
        public void SpellResistance_15_ApplyTo()
        {
            // Arrange
            var spellResistanceTracker = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SpellResistance)
                         .Returns(spellResistanceTracker);

            var enchantment = new SpellResistance(SpellResistanceMagnitude.SR15);

            // Act
            enchantment.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(spellResistanceTracker)
                .Verify(srt => srt.Add(It.Is<Func<byte>>(calc => 15 == calc())),
                        "Applying a Spell Reistance (15) enchantment to a character should give the character 15 spell resistance.");
        }
        #endregion

        #region SR 17
        [Test(Description = "Ensures that a fresh instance of Spell Resistance (17) has sensible defaults.")]
        public void SpellResistance_17_Default()
        {
            // Arrange
            var enchantment = new SpellResistance(SpellResistanceMagnitude.SR17);

            // Assert
            Assert.AreEqual("Spell Resistance (17)", enchantment.Name.Text);
            Assert.AreEqual(4, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(15, enchantment.CasterLevel);
            Assert.AreEqual(1, enchantment.GetSchools().Length);
            Assert.Contains(School.Abjuration, enchantment.GetSchools());
        }


        [Test(Description = "Ensures that Spell Resistance (17) bestows spell resistance 17 onto characters.")]
        public void SpellResistance_17_ApplyTo()
        {
            // Arrange
            var spellResistanceTracker = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SpellResistance)
                         .Returns(spellResistanceTracker);

            var enchantment = new SpellResistance(SpellResistanceMagnitude.SR17);

            // Act
            enchantment.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(spellResistanceTracker)
                .Verify(srt => srt.Add(It.Is<Func<byte>>(calc => 17 == calc())),
                        "Applying a Spell Reistance (17) enchantment to a character should give the character 17 spell resistance.");
        }
        #endregion

        #region SR 19
        [Test(Description = "Ensures that a fresh instance of Spell Resistance (19) has sensible defaults.")]
        public void SpellResistance_19_Default()
        {
            // Arrange
            var enchantment = new SpellResistance(SpellResistanceMagnitude.SR19);

            // Assert
            Assert.AreEqual("Spell Resistance (19)", enchantment.Name.Text);
            Assert.AreEqual(5, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(15, enchantment.CasterLevel);
            Assert.AreEqual(1, enchantment.GetSchools().Length);
            Assert.Contains(School.Abjuration, enchantment.GetSchools());
        }


        [Test(Description = "Ensures that Spell Resistance (19) bestows spell resistance 19 onto characters.")]
        public void SpellResistance_19_ApplyTo()
        {
            // Arrange
            var spellResistanceTracker = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SpellResistance)
                         .Returns(spellResistanceTracker);
            var character = mockCharacter.Object;

            var enchantment = new SpellResistance(SpellResistanceMagnitude.SR19);

            // Act
            enchantment.ApplyTo(character);

            // Assert
            Mock.Get(spellResistanceTracker)
                .Verify(srt => srt.Add(It.Is<Func<byte>>(calc => 19 == calc())),
                        "Applying a Spell Reistance (19) enchantment to a character should give the character 19 spell resistance.");
        }
        #endregion
    }
}