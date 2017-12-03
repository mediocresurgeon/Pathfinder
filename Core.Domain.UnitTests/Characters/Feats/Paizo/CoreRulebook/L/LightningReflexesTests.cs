using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Feats.Paizo.CoreRulebook;
using Core.Domain.Characters.ModifierTrackers;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Feats.Paizo.CoreRulebook.L
{
    [TestFixture]
    [Parallelizable]
    public class LightningReflexesTests
    {
        #region Properties
        [Test(Description = "Ensures a fresh instance of Lightning Reflexes has correct settings.")]
		public void Default()
		{
            // Arrange
            LightningReflexes feat = new LightningReflexes();

			// Assert
            Assert.AreEqual("Lightning Reflexes", feat.Name.Text);
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
			var bonusTracker = Mock.Of<IModifierTracker>();
 
			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SavingThrows.Reflex.UntypedBonuses)
                         .Returns(bonusTracker);

            LightningReflexes feat = new LightningReflexes();

			// Act
			feat.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(bonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Lightning Reflexes did not correctly apply a +2 untyped bonus to the character's Reflex saving throw.");
		}
		#endregion
	}
}