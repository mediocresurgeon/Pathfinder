using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Feats.Paizo.CoreRulebook;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.SavingThrows;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Feats.Paizo.CoreRulebook.L
{
    [TestFixture]
    public class LightningReflexesTests
    {
        #region Properties
        [Test(Description = "Ensures a fresh instance of Lightning Reflexes has correct settings.")]
		public void Default()
		{
            // Arrange
            LightningReflexes feat = new LightningReflexes();

			// Assert
			Assert.AreEqual("Lightning Reflexes", feat.Name);
		}
		#endregion

		#region ApplyTo()
		[Test(Description = "Ensures that Lightning Reflexes cannot be applied to a null character.")]
		public void ApplyTo_NullICharacter_Throws()
		{
			// Arrange
			ICharacter character = null;
			LightningReflexes feat = new LightningReflexes();

			// Act
			TestDelegate applyTo = () => feat.ApplyTo(character);

			// Assert
			Assert.Throws<ArgumentNullException>(applyTo);
		}


        [Test(Description = "Ensures that Lightning Reflexes has the correct effect on a character it is being applied to.")]
        public void ApplyTo_RaisesReflexByTwo()
		{
			// Arrange
			bool featApppliedCorrectly = false; // We'll check on this later.

			var mockUntypedBonusTracker = new Mock<IModifierTracker>();
			mockUntypedBonusTracker.Setup(ubt => ubt.Add(It.Is<byte>(val => 2 == val)))
								   .Callback(() => featApppliedCorrectly = true);

			var mockReflex = new Mock<ISavingThrow>();
			mockReflex.Setup(fort => fort.UntypedBonuses)
						 .Returns(mockUntypedBonusTracker.Object);

			var mockSavingThrowSection = new Mock<ISavingThrowSection>();
            mockSavingThrowSection.Setup(sts => sts.Reflex)
								  .Returns(mockReflex.Object);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.SavingThrows)
						 .Returns(mockSavingThrowSection.Object);

            LightningReflexes feat = new LightningReflexes();

			// Act
			feat.ApplyTo(mockCharacter.Object);

			// Assert
			Assert.IsTrue(featApppliedCorrectly,
						 "Lightning Reflexes did not correctly apply a +2 untyped bonus to the character's Reflex saving throw.");
		}
		#endregion
	}
}