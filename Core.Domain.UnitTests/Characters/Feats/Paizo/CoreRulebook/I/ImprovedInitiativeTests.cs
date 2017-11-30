using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Feats.Paizo.CoreRulebook;
using Core.Domain.Characters.ModifierTrackers;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Feats.Paizo.CoreRulebook.I
{
	[TestFixture]
    [Parallelizable]
	public class ImprovedInitiativeTests
	{
		#region Properties
		[Test(Description = "Ensures a fresh instance of Improved Initiative has correct settings.")]
		public void Default()
		{
            // Arrange
            ImprovedInitiative feat = new ImprovedInitiative();

			// Assert
			Assert.AreEqual("Improved Initiative", feat.Name);
		}
		#endregion

		#region ApplyTo()
		[Test(Description = "Ensures that Improved Initiative cannot be applied to a null character.")]
		public void ApplyTo_NullICharacter_Throws()
		{
			// Arrange
			ICharacter character = null;
			ImprovedInitiative feat = new ImprovedInitiative();

			// Act
			TestDelegate applyTo = () => feat.ApplyTo(character);

			// Assert
			Assert.Throws<ArgumentNullException>(applyTo);
		}


		[Test(Description = "Ensures that Improved Initiative has the correct effect on a character it is being applied to.")]
		public void ApplyTo_RaisesInitiativeByFour()
		{
			// Arrange
			var bonusTracker = Mock.Of<IModifierTracker>();

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Initiative.UntypedBonuses)
                         .Returns(bonusTracker);

            ImprovedInitiative feat = new ImprovedInitiative();

			// Act
			feat.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(bonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 4 == calc())),
                        "Improved Initiative did not correctly apply a +4 untyped bonus to the character's initiative.");
		}
		#endregion
	}
}