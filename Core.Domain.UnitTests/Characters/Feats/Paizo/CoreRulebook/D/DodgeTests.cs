using System;
using Core.Domain.Characters;
using Core.Domain.Characters.ArmorClasses;
using Core.Domain.Characters.Feats.Paizo.CoreRulebook;
using Core.Domain.Characters.ModifierTrackers;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Feats.Paizo.CoreRulebook.D
{
    [TestFixture]
    public class DodgeTests
    {
        #region Constructor
        [Test(Description = "Ensures sensible defaults for a fresh instance of Dodge.")]
        public void Default()
        {
            // Arrange
            Dodge feat = new Dodge();

            // Assert
            Assert.AreEqual("Dodge", feat.Name);
        }
        #endregion

        #region ApplyTo()
        [Test(Description = "Ensures that callying ApplyTo with a null ICharacter reference throws an exception.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;
            Dodge feat = new Dodge();

            // Act
            TestDelegate constructor = () => feat.ApplyTo(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures that applying Dodge to a character results in the character's AC dodge bonus increasing by one.")]
        public void ApplyTo_RaisesAcDodgeByOne()
        {
            bool featAppliedCorrectly = false; // We'll check on this later

            var mockDodgeTracker = new Mock<IModifierTracker>();
            mockDodgeTracker.Setup(t => t.Add(It.Is<byte>(input => 1 == input)))
                            .Callback(() => featAppliedCorrectly = true);

            var mockArmorClass = new Mock<IArmorClass>();
            mockArmorClass.Setup(ac => ac.DodgeBonuses)
                          .Returns(mockDodgeTracker.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass)
                         .Returns(mockArmorClass.Object);

            Dodge feat = new Dodge();

            // Act
            feat.ApplyTo(mockCharacter.Object);

            // Assert
            Assert.IsTrue(featAppliedCorrectly,
                         "Dodge bonus did not correctly add a +1 bonus to the character's armor class's dodge bonus tracker.");
        }
        #endregion
    }
}