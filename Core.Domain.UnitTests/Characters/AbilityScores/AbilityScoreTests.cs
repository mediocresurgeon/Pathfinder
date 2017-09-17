using Core.Domain.Characters.AbilityScores;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.AbilityScores
{
    [TestFixture]
    public class AbilityScoreTests
    {
        [Test]
        public void NoBaseScore()
        {
            // Arrange
            AbilityScore abilityScore = new Strength { BaseScore = null };

            // Assert
            Assert.IsFalse(abilityScore.BaseScore.HasValue);
            Assert.IsFalse(abilityScore.GetTotal().HasValue);
            Assert.AreEqual(0, abilityScore.GetModifier());
            Assert.AreEqual(0, abilityScore.GetBonus());
        }


		[Test]
		public void BaseScoreEight()
		{
			// Arrange
			AbilityScore abilityScore = new Strength { BaseScore = 8 };

			// Act
			byte? baseScore = abilityScore.BaseScore;
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(baseScore.HasValue);
			Assert.AreEqual(8, baseScore.Value);
			Assert.IsTrue(total.HasValue);
			Assert.AreEqual(8, total.Value);
			Assert.AreEqual(-1, abilityScore.GetModifier());
			Assert.AreEqual(0, abilityScore.GetBonus());
		}


		[Test]
		public void BaseScoreNine()
		{
			// Arrange
			AbilityScore abilityScore = new Strength { BaseScore = 9 };

            // Act
            byte? baseScore = abilityScore.BaseScore;
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(baseScore.HasValue);
            Assert.AreEqual(9, baseScore.Value);
			Assert.IsTrue(total.HasValue);
			Assert.AreEqual(9, total.Value);
			Assert.AreEqual(-1, abilityScore.GetModifier());
			Assert.AreEqual(0, abilityScore.GetBonus());
		}


		[Test]
		public void BaseScoreTen()
		{
			// Arrange
			AbilityScore abilityScore = new Strength { BaseScore = 10 };

			// Act
			byte? baseScore = abilityScore.BaseScore;
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(baseScore.HasValue);
			Assert.AreEqual(10, baseScore.Value);
			Assert.IsTrue(total.HasValue);
			Assert.AreEqual(10, total.Value);
			Assert.AreEqual(0, abilityScore.GetModifier());
			Assert.AreEqual(0, abilityScore.GetBonus());
		}


		[Test]
		public void BaseScoreEleven()
		{
			// Arrange
			AbilityScore abilityScore = new Strength { BaseScore = 11 };

			// Act
			byte? baseScore = abilityScore.BaseScore;
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(baseScore.HasValue);
			Assert.AreEqual(11, baseScore.Value);
			Assert.IsTrue(total.HasValue);
			Assert.AreEqual(11, total.Value);
			Assert.AreEqual(0, abilityScore.GetModifier());
			Assert.AreEqual(0, abilityScore.GetBonus());
		}


		[Test]
		public void BaseScoreTwelve()
		{
			// Arrange
			AbilityScore abilityScore = new Strength { BaseScore = 12 };

			// Act
			byte? baseScore = abilityScore.BaseScore;
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(baseScore.HasValue);
			Assert.AreEqual(12, baseScore.Value);
			Assert.IsTrue(total.HasValue);
			Assert.AreEqual(12, total.Value);
			Assert.AreEqual(1, abilityScore.GetModifier());
			Assert.AreEqual(1, abilityScore.GetBonus());
		}


		[Test]
		public void EnhancementBonuses()
		{
			// Arrange
			AbilityScore abilityScore = new Strength { BaseScore = 10 };
            abilityScore.EnhancementBonuses.Add(6);

			// Act
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(total.HasValue);
			Assert.AreEqual(16, total.Value);
			Assert.AreEqual(3, abilityScore.GetModifier());
			Assert.AreEqual(3, abilityScore.GetBonus());
		}


		[Test]
		public void InherentBonuses()
		{
			// Arrange
			AbilityScore abilityScore = new Strength { BaseScore = 10 };
            abilityScore.InherentBonuses.Add(6);

			// Act
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(total.HasValue);
			Assert.AreEqual(16, total.Value);
			Assert.AreEqual(3, abilityScore.GetModifier());
			Assert.AreEqual(3, abilityScore.GetBonus());
		}


		[Test]
		public void MoraleBonuses()
		{
			// Arrange
			AbilityScore abilityScore = new Strength { BaseScore = 10 };
            abilityScore.MoraleBonuses.Add(6);

			// Act
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(total.HasValue);
			Assert.AreEqual(16, total.Value);
			Assert.AreEqual(3, abilityScore.GetModifier());
			Assert.AreEqual(3, abilityScore.GetBonus());
		}


		[Test]
		public void Penalties()
		{
			// Arrange
			AbilityScore abilityScore = new Strength { BaseScore = 10 };
            abilityScore.Penalties.Add(6);

			// Act
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(total.HasValue);
			Assert.AreEqual(4, total.Value);
			Assert.AreEqual(-3, abilityScore.GetModifier());
			Assert.AreEqual(0, abilityScore.GetBonus());
		}


		[Test]
		public void BigPenalties()
		{
			// Arrange
			AbilityScore abilityScore = new Strength { BaseScore = 0 };
			abilityScore.Penalties.Add(6);

			// Act
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(total.HasValue);
			Assert.AreEqual(0, total.Value);
			Assert.AreEqual(-5, abilityScore.GetModifier());
			Assert.AreEqual(0, abilityScore.GetBonus());
		}
    }
}