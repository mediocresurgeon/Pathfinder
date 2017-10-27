using System;
using Core.Domain.Dice;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Dice
{
    [TestFixture]
    public class DiceGroupTests
    {
        // Used for Roll() tests.
        private readonly Random random = new Random();

        #region Properties
        [Test(Description = "Ensures that values passed into DiceGroup constructor can be read from properties.")]
        public void Default()
        {
            // Arrange
            var dice = new DiceGroup(1, 6);

            // Assert
            Assert.AreEqual(1, dice.Quantity);
            Assert.AreEqual(6, dice.Quality);
            Assert.AreEqual("1d6", dice.ToString());
        }
        #endregion

        #region Equals()
        [Test(Description = "Ensures that null values are never equal to an instance of DiceGroup.")]
        public void Equals_Null_NotEqual()
        {
            // Arrange
            var dice = new DiceGroup(1, 6);

            // Act
            bool equal = dice.Equals(null);

            // Assert
            Assert.IsFalse(equal,
                          "An instance of DiceGroup should never be equal to null.");
        }


        [Test(Description = "Ensures that reference values are never equal to an instance of DiceGroup.")]
        public void Equals_Object_NotEqual()
        {
            // Arrange
            var dice = new DiceGroup(1, 6);
            var obj = new Object();

            // Act
            bool equal = dice.Equals(obj);

            // Assert
            Assert.IsFalse(equal,
                          "An instance of DiceGroup should never be equal to a plain object.");
        }


        [Test(Description = "Ensures that DiceGroups with different quantities are never considered equal.")]
        public void Equals_DiffQuantity_NotEqual()
        {
            // Arrange
            var dice1 = new DiceGroup(1, 6);
            var dice2 = new DiceGroup(2, 6);

            // Act
            bool equal1 = dice1.Equals(dice2);
            bool equal2 = dice2.Equals(dice1);

            // Assert
            Assert.IsFalse(equal1,
                          "An instance of DiceGroup should not be equal if they have different quantities.");
            Assert.IsFalse(equal2,
                          "An instance of DiceGroup should not be equal if they have different quantities.");
        }


        [Test(Description = "Ensures that DiceGroups with different qualities are never considered equal.")]
        public void Equals_DiffQuality_NotEqual()
        {
            // Arrange
            var dice1 = new DiceGroup(1, 6);
            var dice2 = new DiceGroup(1, 8);

            // Act
            bool equal1 = dice1.Equals(dice2);
            bool equal2 = dice2.Equals(dice1);

            // Assert
            Assert.IsFalse(equal1,
                          "An instance of DiceGroup should not be equal if they have different qualities.");
            Assert.IsFalse(equal2,
                          "An instance of DiceGroup should not be equal if they have different qualities.");
        }


        [Test(Description = "Ensures that null values are never equal to an instance of DiceGroup.")]
        public void Equals_SameValues_Equal()
        {
            // Arrange
            var dice1 = new DiceGroup(1, 6);
            var dice2 = new DiceGroup(1, 6);

            // Act
            bool equal1 = dice1.Equals(dice2);
            bool equal2 = dice2.Equals(dice1);

            Assert.IsTrue(equal1,
                          "DiceGroups with the same Quantity and Quality values are equal.");
            Assert.IsTrue(equal2,
                          "DiceGroups with the same Quantity and Quality values are equal.");
        }
        #endregion

        #region == operator
        [Test(Description = "Ensures that null values are never equal to an instance of DiceGroup.")]
        public void EqualsOp_NullRight_NotEqual()
        {
            // Arrange
            var dice = new DiceGroup(1, 6);

            // Act
            bool equal = dice == null;

            // Assert
            Assert.IsFalse(equal,
                          "An instance of DiceGroup should never be equal to null.");
        }


        [Test(Description = "Ensures that null values are never equal to an instance of DiceGroup.")]
        public void EqualsOp_NullLeft_NotEqual()
        {
            // Arrange
            var dice = new DiceGroup(1, 6);

            // Act
            bool equal = null == dice;

            // Assert
            Assert.IsFalse(equal,
                          "An instance of DiceGroup should never be equal to null.");
        }


        [Test(Description = "Ensures that DiceGroups with different quantities are never considered equal.")]
        public void EqualsOp_DiffQuantity_NotEqual()
        {
            // Arrange
            var dice1 = new DiceGroup(1, 6);
            var dice2 = new DiceGroup(2, 6);

            // Act
            bool equal1 = dice1 == dice2;
            bool equal2 = dice2 == dice1;

            // Assert
            Assert.IsFalse(equal1,
                          "An instance of DiceGroup should not be equal if they have different quantities.");
            Assert.IsFalse(equal2,
                          "An instance of DiceGroup should not be equal if they have different quantities.");
        }


        [Test(Description = "Ensures that DiceGroups with different qualities are never considered equal.")]
        public void EqualsOp_DiffQuality_NotEqual()
        {
            // Arrange
            var dice1 = new DiceGroup(1, 6);
            var dice2 = new DiceGroup(1, 8);

            // Act
            bool equal1 = dice1 == dice2;
            bool equal2 = dice2 == dice1;

            // Assert
            Assert.IsFalse(equal1,
                          "An instance of DiceGroup should not be equal if they have different qualities.");
            Assert.IsFalse(equal2,
                          "An instance of DiceGroup should not be equal if they have different qualities.");
        }


        [Test(Description = "Ensures DiceGroups with identical quantities and qualities are equal.")]
        public void EqualsOp_SameValues_Equal()
        {
            // Arrange
            var dice1 = new DiceGroup(1, 6);
            var dice2 = new DiceGroup(1, 6);

            // Act
            bool equal1 = dice1 == dice2;
            bool equal2 = dice2 == dice1;

            Assert.IsTrue(equal1,
                          "DiceGroups with the same Quantity and Quality values are equal.");
            Assert.IsTrue(equal2,
                          "DiceGroups with the same Quantity and Quality values are equal.");
        }
        #endregion

        #region != operator
        [Test(Description = "Ensures that null values are never equal to an instance of DiceGroup.")]
        public void NotEqualsOp_NullRight_NotEqual()
        {
            // Arrange
            var dice = new DiceGroup(1, 6);

            // Act
            bool unequal = dice != null;

            // Assert
            Assert.IsTrue(unequal,
                          "An instance of DiceGroup should never be equal to null.");
        }


        [Test(Description = "Ensures that null values are never equal to an instance of DiceGroup.")]
        public void NotEqualsOp_NullLeft_NotEqual()
        {
            // Arrange
            var dice = new DiceGroup(1, 6);

            // Act
            bool unequal = null != dice;

            // Assert
            Assert.IsTrue(unequal,
                          "An instance of DiceGroup should never be equal to null.");
        }


        [Test(Description = "Ensures that DiceGroups with different quantities are never considered equal.")]
        public void NotEqualsOp_DiffQuantity_NotEqual()
        {
            // Arrange
            var dice1 = new DiceGroup(1, 6);
            var dice2 = new DiceGroup(2, 6);

            // Act
            bool unequal1 = dice1 != dice2;
            bool unequal2 = dice2 != dice1;

            // Assert
            Assert.IsTrue(unequal1,
                          "An instance of DiceGroup should not be equal if they have different quantities.");
            Assert.IsTrue(unequal2,
                          "An instance of DiceGroup should not be equal if they have different quantities.");
        }


        [Test(Description = "Ensures that DiceGroups with different qualities are never considered equal.")]
        public void NotEqualsOp_DiffQuality_NotEqual()
        {
            // Arrange
            var dice1 = new DiceGroup(1, 6);
            var dice2 = new DiceGroup(1, 8);

            // Act
            bool unequal1 = dice1 != dice2;
            bool unequal2 = dice2 != dice1;

            // Assert
            Assert.IsTrue(unequal1,
                          "An instance of DiceGroup should not be equal if they have different qualities.");
            Assert.IsTrue(unequal2,
                          "An instance of DiceGroup should not be equal if they have different qualities.");
        }


        [Test(Description = "Ensures DiceGroups with identical quantities and qualities are equal.")]
        public void NotEqualsOp_SameValues_Equal()
        {
            // Arrange
            var dice1 = new DiceGroup(1, 6);
            var dice2 = new DiceGroup(1, 6);

            // Act
            bool unequal1 = dice1 != dice2;
            bool unequal2 = dice2 != dice1;

            Assert.IsFalse(unequal1,
                          "DiceGroups with the same Quantity and Quality values are equal.");
            Assert.IsFalse(unequal2,
                          "DiceGroups with the same Quantity and Quality values are equal.");
        }
        #endregion

        #region + operator
        [Test(Description = "Ensures that DiceGroups with different qualities cannot be added together.")]
        public void Plus_DifferentQualities_Throws()
        {
            // Arrange
            var dice1 = new DiceGroup(1, 6);
            var dice2 = new DiceGroup(1, 8);

            // Act
            TestDelegate add = () =>
            {
                var result = dice1 + dice2; // the result of this operation is never used
            };

            // Assert
            Assert.Throws<InvalidOperationException>(add,
                                                     "Attempting to add two DiceGroups with different qualities should result in an InvalidOperationException.");
        }


        [Test(Description = "Ensures that DiceGroups with different qualities cannot be added together.")]
        public void Plus_SameQualities_Throws()
        {
            // Arrange
            var dice1 = new DiceGroup(2, 6);
            var dice2 = new DiceGroup(3, 6);

            // Act
            var result = dice1 + dice2;

            // Assert
            Assert.AreEqual(5, result.Quantity,
                           "Adding a DiceGroup of Quantity 2 with a DiceGroup of Quantity 3 should result in a DiceGroup of Quantity 5.");
            Assert.AreEqual(6, result.Quality,
                            "Adding two DiceGroups of Quality 6 should result in a DiceGroup of Quality 6.");
        }
        #endregion

        #region Roll()
        [Test(Description = "Ensures that rolling a die can produce different results.")]
        public void Roll_Nondeterministic()
        {
            // This test has nonstandard form.
            // If the dice roll 1000 times and never produce a bad result, we can call the test successful.
            // Yes, this means the test is non-exhaustive.

            DiceGroup die = new DiceGroup(1, 6);

            var firstResult = die.Roll(random);

            for (int i = 0; i < 999; i++)
            {
                var newResult = die.Roll(random);
                if (firstResult != newResult)
                    Assert.Pass($"First result: { firstResult }\nSecond result: { newResult }");
            }
            Assert.Fail("Rolled dice 1000 times and acheived the same result each time--DiceGroup.Roll() is non-random!");
        }


        [Test(Description = "Ensures that rolling a die never results in a result less than 1.")]
        public void Roll_NotLessThanOne()
        {
            // This test has nonstandard form.
            // If the dice roll 1000 times and never produce a bad result, we can call the test successful.
            // Yes, this means the test is non-exhaustive.

            DiceGroup die = new DiceGroup(1, 6);

            for (int i = 0; i < 1000; i++)
            {
                var result = die.Roll(random);
                Assert.Greater(result, 0,
                            "Rolling 1d6 should never result in a zero.");
            }
        }


        [Test(Description = "Ensures that rolling a die never results in a result exceeding its quality.")]
        public void Roll_NotMoreThanQuality()
        {
            // This test has nonstandard form.
            // If the dice roll 1000 times and never produce a bad result, we can call the test successful.
            // Yes, this means the test is non-exhaustive.

            DiceGroup die = new DiceGroup(1, 6);

            for (int i = 0; i < 1000; i++)
            {
                var result = die.Roll(random);
                Assert.Less(result, 7,
                            "Rolling 1d6 should never result in a number greater than 6.");
            }
        }


        [Test(Description = "Ensures that rolling two dice never results in an impossible result.")]
        public void Roll_ManyDice_WithinLimits()
        {
            // This test has nonstandard form.
            // If the dice roll 1000 times and never produce a bad result, we can call the test successful.
            // Yes, this means the test is non-exhaustive.

            DiceGroup die = new DiceGroup(2, 6);

            for (int i = 0; i < 1000; i++)
            {
                var result = die.Roll(random);
                Assert.Greater(result, 1,
                            "Rolling 2d6 should never result in a number greater than 2.");
                Assert.Less(result, 13,
                            "Rolling 2d6 should never result in a number greater than 12.");
            }
        }
        #endregion
    }
}