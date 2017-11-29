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
            var bonusTracker = Mock.Of<IModifierTracker>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SavingThrows.Fortitude.UntypedBonuses)
                         .Returns(bonusTracker);
            
            GreatFortitude feat = new GreatFortitude();

            // Act
            feat.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(bonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Great Fortitude did not correctly apply a +2 untyped bonus to the character's Fortitude saving throw.");
        }
        #endregion
    }
}