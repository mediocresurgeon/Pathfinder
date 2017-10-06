using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Feats.Paizo.CoreRulebook;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.SavingThrows;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Feats.Paizo.CoreRulebook.G
{
    [TestFixture]
    public class GreatFortitudeTests
    {
        #region Properties
        [Test(Description = "Ensures a fresh instance of Great Fortitude has correct settings.")]
        public void Default()
        {
            // Arrange
            GreatFortitude feat = new GreatFortitude();

            // Assert
            Assert.AreEqual("Great Fortitude", feat.Name);
        }
        #endregion

        #region ApplyTo()
        [Test(Description = "Ensures that Great Fortitude cannot be applied to a null character.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;
            GreatFortitude feat = new GreatFortitude();

            // Act
            TestDelegate applyTo = () => feat.ApplyTo(character);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures that Great Fortitude has the correct effect on a character it is being applied to.")]
        public void ApplyTo_RaisesFortitudeByTwo()
        {
            // Arrange
            bool featApppliedCorrectly = false; // We'll check on this later.

            var mockUntypedBonusTracker = new Mock<IModifierTracker>();
            mockUntypedBonusTracker.Setup(ubt => ubt.Add(It.Is<byte>(val => 2 == val)))
                                   .Callback(() => featApppliedCorrectly = true);
            
            var mockFortitude = new Mock<ISavingThrow>();
            mockFortitude.Setup(fort => fort.UntypedBonuses)
                         .Returns(mockUntypedBonusTracker.Object);

            var mockSavingThrowSection = new Mock<ISavingThrowSection>();
            mockSavingThrowSection.Setup(sts => sts.Fortitude)
                                  .Returns(mockFortitude.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SavingThrows)
                         .Returns(mockSavingThrowSection.Object);
            
            GreatFortitude feat = new GreatFortitude();

            // Act
            feat.ApplyTo(mockCharacter.Object);

            // Assert
            Assert.IsTrue(featApppliedCorrectly,
                         "Great Fortitude did not correctly apply a +2 untyped bonus to the character's Fortitude saving throw.");
        }
        #endregion
    }
}