using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Feats.Paizo.CoreRulebook;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.SavingThrows;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Feats.Paizo.CoreRulebook.I
{
    [TestFixture]
    public class IronWillTests
    {
		#region Properties
		[Test(Description = "Ensures a fresh instance of Iron Will has correct settings.")]
		public void Default()
		{
			// Arrange
			IronWill feat = new IronWill();

			// Assert
			Assert.AreEqual("Iron Will", feat.Name);
		}
		#endregion

		#region ApplyTo()
		[Test(Description = "Ensures that Iron Will cannot be applied to a null character.")]
		public void ApplyTo_NullICharacter_Throws()
		{
			// Arrange
			ICharacter character = null;
			IronWill feat = new IronWill();

			// Act
			TestDelegate applyTo = () => feat.ApplyTo(character);

			// Assert
			Assert.Throws<ArgumentNullException>(applyTo);
		}


		[Test(Description = "Ensures that Iron Will has the correct effect on a character it is being applied to.")]
		public void ApplyTo_RaisesWillByTwo()
		{
			// Arrange
			var bonusTracker = Mock.Of<IModifierTracker>();

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SavingThrows.Will.UntypedBonuses)
                         .Returns(bonusTracker);

			IronWill feat = new IronWill();

			// Act
			feat.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(bonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Iron Will did not correctly apply a +2 untyped bonus to the character's Will saving throw.");
		}
		#endregion
	}
}
