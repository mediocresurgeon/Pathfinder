using System;
using Core.Domain.Characters;
using Core.Domain.Characters.BaseAttackBonuses;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.BaseAttackBonuses
{
    [TestFixture]
    public class BaseAttackBonusTests
    {
        #region Constructor
        [Test(Description = "Ensures that BaseAttackBonus cannot be created with a null ICharacter reference.")]
        public void Construtor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new BaseAttackBonus(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


		[Test(Description = "Ensures that BaseAttackBonus has sensible defaults.")]
		public void Default()
		{
			// Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            var bab = new BaseAttackBonus(character);

            // Assert
            Assert.AreEqual(BaseAttackProgression.AsCleric, bab.Rate,
                            "By default, a BaseAttackBonus should have medium progression (as a cleric).");
		}
        #endregion

        #region AsWizard
        [Test(Description = "Ensures that the base attack bonus of a level 1 wizard is calculated correctly.")]
        public void Wizard_Level1()
        {
            // Arrange
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level)
                         .Returns(1);

            BaseAttackBonus bab = new BaseAttackBonus(mockCharacter.Object) { Rate = BaseAttackProgression.AsWizard };

            // Act
            var result = bab.GetTotal();

            // Assert
            Assert.AreEqual(0, result,
                           "A level 1 wizard should have a BAB of +0.");
        }


        [Test(Description = "Ensures that the base attack bonus of a level 2 wizard is calculated correctly.")]
        public void Wizard_Level2()
        {
            // Arrange
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level)
                         .Returns(2);

            BaseAttackBonus bab = new BaseAttackBonus(mockCharacter.Object) { Rate = BaseAttackProgression.AsWizard };

            // Act
            var result = bab.GetTotal();

            // Assert
            Assert.AreEqual(1, result,
                           "A level 2 wizard should have a BAB of +1.");
        }


        [Test(Description = "Ensures that the base attack bonus of a level 3 wizard is calculated correctly.")]
        public void Wizard_Level3()
        {
            // Arrange
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level)
                         .Returns(3);

            BaseAttackBonus bab = new BaseAttackBonus(mockCharacter.Object) { Rate = BaseAttackProgression.AsWizard };

            // Act
            var result = bab.GetTotal();

            // Assert
            Assert.AreEqual(1, result,
                           "A level 3 wizard should have a BAB of +1.");
        }
		#endregion

		#region AsCleric
		[Test(Description = "Ensures that the base attack bonus of a level 1 cleric is calculated correctly.")]
		public void Cleric_Level1()
		{
			// Arrange
			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Level)
						 .Returns(1);

            BaseAttackBonus bab = new BaseAttackBonus(mockCharacter.Object) { Rate = BaseAttackProgression.AsCleric };

			// Act
			var result = bab.GetTotal();

			// Assert
			Assert.AreEqual(0, result,
						   "A level 1 cleric should have a BAB of +0.");
		}


		[Test(Description = "Ensures that the base attack bonus of a level 2 cleric is calculated correctly.")]
		public void Cleric_Level2()
		{
			// Arrange
			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Level)
						 .Returns(2);

            BaseAttackBonus bab = new BaseAttackBonus(mockCharacter.Object) { Rate = BaseAttackProgression.AsCleric };

			// Act
			var result = bab.GetTotal();

			// Assert
			Assert.AreEqual(1, result,
						   "A level 2 cleric should have a BAB of +1.");
		}


		[Test(Description = "Ensures that the base attack bonus of a level 3 cleric is calculated correctly.")]
		public void Cleric_Level3()
		{
			// Arrange
			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Level)
						 .Returns(3);

            BaseAttackBonus bab = new BaseAttackBonus(mockCharacter.Object) { Rate = BaseAttackProgression.AsCleric };

			// Act
			var result = bab.GetTotal();

			// Assert
			Assert.AreEqual(2, result,
						   "A level 3 cleric should have a BAB of +2.");
		}
		#endregion

		#region AsFighter
		[Test(Description = "Ensures that the base attack bonus of a level 1 fighter is calculated correctly.")]
		public void Fighter_Level1()
		{
			// Arrange
			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Level)
						 .Returns(1);

            BaseAttackBonus bab = new BaseAttackBonus(mockCharacter.Object) { Rate = BaseAttackProgression.AsFighter };

			// Act
			var result = bab.GetTotal();

			// Assert
			Assert.AreEqual(1, result,
						   "A level 1 fighter should have a BAB of +1.");
		}


		[Test(Description = "Ensures that the base attack bonus of a level 2 fighter is calculated correctly.")]
		public void Fighter_Level2()
		{
			// Arrange
			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Level)
						 .Returns(2);

            BaseAttackBonus bab = new BaseAttackBonus(mockCharacter.Object) { Rate = BaseAttackProgression.AsFighter };

            // Act
            var result = bab.GetTotal();

			// Assert
			Assert.AreEqual(2, result,
						   "A level 2 fighter should have a BAB of +2.");
		}


		[Test(Description = "Ensures that the base attack bonus of a level 3 fighter is calculated correctly.")]
		public void Fighter_Level3()
		{
			// Arrange
			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Level)
						 .Returns(3);

            BaseAttackBonus bab = new BaseAttackBonus(mockCharacter.Object) { Rate = BaseAttackProgression.AsFighter };

            // Act
            var result = bab.GetTotal();

			// Assert
			Assert.AreEqual(3, result,
						   "A level 3 fighter should have a BAB of +3.");
		}
		#endregion
	}
}