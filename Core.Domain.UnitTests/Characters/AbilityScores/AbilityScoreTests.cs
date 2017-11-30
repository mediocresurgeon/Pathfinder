using Core.Domain.Characters.AbilityScores;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.AbilityScores
{
    [TestFixture]
    [Parallelizable]
    public class AbilityScoreTests
    {
		[Test(Description = "Setting a BaseScore property to a number should allow it to be retrieved later.")]
		public void NonNullBaseScore_PropertyHasValue()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 8;

			// Act
			var baseScore = abilityScore.BaseScore;

			// Assert
			Assert.IsTrue(baseScore.HasValue);
			Assert.AreEqual(8, baseScore.Value);
		}


        [Test(Description = "An ability score with a null BaseScore should have no value on its corresponding property.")]
        public void NoBaseScore_PropertyHasNoValue()
        {
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = null;

            // Act
            var baseScore = abilityScore.BaseScore;

            // Assert
            Assert.IsFalse(baseScore.HasValue,
                          "Setting the BaseScore of an abilityscore to null should result in the retrieval of a null value.");
        }


		[Test(Description = "An ability score with a null BaseScore should not have a total value.")]
		public void NoBaseScore_GetTotal_NoValue()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = null;

			// Act
			var totalScore = abilityScore.GetTotal();

			// Assert
			Assert.IsFalse(totalScore.HasValue,
						  "An ability score with a null base score should have a null total score.");
		}


        [Test(Description = "An ability score with a null BaseScore should have a modifier of zero.")]
        public void NoBaseScore_GetModifier_Zero()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = null;

			// Act
			var modifier = abilityScore.GetModifier();

            // Assert
            Assert.AreEqual(0, modifier,
                            "An ability score with a null BaseScore should have a modifier of zero.");
		}


		[Test(Description = "An ability score with a null BaseScore should have a bonus of zero.")]
		public void NoBaseScore_GetBonus_Zero()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = null;

			// Act
			var bonus = abilityScore.GetBonus();

			// Assert
			Assert.AreEqual(0, bonus,
							"An ability score with a null BaseScore should have a bonus of zero.");
		}


        [Test(Description = "Ensures that even ability scores below 10 are calculated correctly.")]
        public void BaseScoreSix_Aggregates()
        {
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 6;

            // Assert
            Assert.IsTrue(abilityScore.GetTotal().HasValue,
                         "Ability scores with a non-null base score should always have a total.");
            Assert.AreEqual(6, abilityScore.GetTotal().Value,
                           "Ability scores with non-null base bases should have a total equal to their base score by default.");
            Assert.AreEqual(-2, abilityScore.GetModifier(),
                            "Modifier for ability score 6 is -2.");
            Assert.AreEqual(0, abilityScore.GetBonus(),
                           "Bonuses for ability scores below 12 are always zero.");
        }


		[Test(Description = "Ensures that odd ability scores below 10 are calculated correctly.")]
		public void BaseScoreSeven_Aggregates()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 7;

			// Assert
			Assert.IsTrue(abilityScore.GetTotal().HasValue,
			              "Ability scores with a non-null base score should always have a total.");
            Assert.AreEqual(7, abilityScore.GetTotal().Value,
						   "Ability scores with non-null base bases should have a total equal to their base score by default.");
			Assert.AreEqual(-2, abilityScore.GetModifier(),
							"Modifier for ability score 7 is -2.");
			Assert.AreEqual(0, abilityScore.GetBonus(),
						   "Bonuses for ability scores below 12 are always zero.");
		}


		[Test(Description = "Ensures that ability score of 10 is calculated correctly.")]
		public void BaseScoreTen_Aggregates()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 10;

			// Assert
			Assert.IsTrue(abilityScore.GetTotal().HasValue,
			              "Ability scores with a non-null base score should always have a total.");
            Assert.AreEqual(10, abilityScore.GetTotal().Value,
						   "Ability scores with non-null base bases should have a total equal to their base score by default.");
			Assert.AreEqual(0, abilityScore.GetModifier(),
							"Modifier for ability score 10 is 0.");
			Assert.AreEqual(0, abilityScore.GetBonus(),
						   "Bonuses for ability scores below 12 are always zero.");
		}


		[Test(Description = "Ensures that ability score of 11 is calculated correctly.")]
		public void BaseScoreEleven_Aggregates()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 11;

			// Assert
			Assert.IsTrue(abilityScore.GetTotal().HasValue,
						  "Ability scores with a non-null base score should always have a total.");
            Assert.AreEqual(11, abilityScore.GetTotal().Value,
						   "Ability scores with non-null base bases should have a total equal to their base score by default.");
			Assert.AreEqual(0, abilityScore.GetModifier(),
							"Modifier for ability score 11 is 0.");
			Assert.AreEqual(0, abilityScore.GetBonus(),
						   "Bonuses for ability scores below 12 are always zero.");
		}

		[Test(Description = "Ensures that even ability scores above 10 are calculated correctly.")]
		public void BaseScoreEighteen_Aggregates()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 18;

			// Assert
			Assert.IsTrue(abilityScore.GetTotal().HasValue,
						  "Ability scores with a non-null base score should always have a total.");
            Assert.AreEqual(18, abilityScore.GetTotal().Value,
						   "Ability scores with non-null base bases should have a total equal to their base score by default.");
			Assert.AreEqual(4, abilityScore.GetModifier(),
							"Modifier for ability score 18 is 4.");
			Assert.AreEqual(abilityScore.GetModifier(), abilityScore.GetBonus(),
						   "Bonuses for ability scores above 12 are equal to their modifier.");
		}


		[Test(Description = "Ensures that odd ability scores above 19 are calculated correctly.")]
		public void BaseScoreNineteen_Aggregates()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 19;

			// Assert
			Assert.IsTrue(abilityScore.GetTotal().HasValue,
						  "Ability scores with a non-null base score should always have a total.");
            Assert.AreEqual(19, abilityScore.GetTotal().Value,
						   "Ability scores with non-null base bases should have a total equal to their base score by default.");
			Assert.AreEqual(4, abilityScore.GetModifier(),
							"Modifier for ability score 19 is 4.");
			Assert.AreEqual(abilityScore.GetModifier(), abilityScore.GetBonus(),
						   "Bonuses for ability scores above 12 are equal to their modifier.");
		}


		[Test(Description = "Ensures enhancement bonuses are aggregated correctly.")]
		public void EnhancementBonuses_Aggregates()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 10;
            abilityScore.EnhancementBonuses.Add(() => 6);

			// Act
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(total.HasValue,
                          "An ability score with a non-null base score should have a non-null total.");
			Assert.AreEqual(16, total.Value,
                           "An ability score of 10 with an enhancement bonus of +6 should have a total of 16.");
			Assert.AreEqual(3, abilityScore.GetModifier(),
                           "An ability score of 16 should have a +3 modifier.");
			Assert.AreEqual(3, abilityScore.GetBonus(),
                           "An ability score of 16 should have a +3 bonus.");
		}


		[Test(Description = "Ensures inherent bonuses are aggregated correctly.")]
		public void InherentBonuses_Aggregates()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 10;
            abilityScore.InherentBonuses.Add(() => 6);

			// Act
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(total.HasValue,
						  "An ability score with a non-null base score should have a non-null total.");
			Assert.AreEqual(16, total.Value,
						   "An ability score of 10 with an inherent bonus of +6 should have a total of 16.");
			Assert.AreEqual(3, abilityScore.GetModifier(),
						   "An ability score of 16 should have a +3 modifier.");
			Assert.AreEqual(3, abilityScore.GetBonus(),
						   "An ability score of 16 should have a +3 bonus.");
		}


		[Test(Description = "Ensures morale bonuses are aggregated correctly.")]
		public void MoraleBonuses_Aggregates()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 10;
            abilityScore.MoraleBonuses.Add(() => 6);

			// Act
			byte? total = abilityScore.GetTotal();

			// Assert
            Assert.IsTrue(total.HasValue,
						  "An ability score with a non-null base score should have a non-null total.");
			Assert.AreEqual(16, total.Value,
						   "An ability score of 10 with a morale bonus of +6 should have a total of 16.");
			Assert.AreEqual(3, abilityScore.GetModifier(),
						   "An ability score of 16 should have a +3 modifier.");
			Assert.AreEqual(3, abilityScore.GetBonus(),
						   "An ability score of 16 should have a +3 bonus.");
		}


		[Test(Description = "Ensures penalties are aggregated correctly.")]
		public void TypicalPenalties_Aggregates()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 10;
            abilityScore.Penalties.Add(() => 6);

			// Act
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(total.HasValue,
						  "An ability score with a non-null base score should have a non-null total.");
			Assert.AreEqual(4, total.Value,
						   "An ability score of 10 with a penalty of -6 should have a total of 4.");
			Assert.AreEqual(-3, abilityScore.GetModifier(),
						   "An ability score of 4 should have a -3 modifier.");
			Assert.AreEqual(0, abilityScore.GetBonus(),
						   "An ability score of less than 12 should have a bonus of zero.");
		}


		[Test(Description = "Ensures that a penalty which would reduce an ability score to below zero is treated as though it was zero.")]
		public void BigPenalties_Aggregates()
		{
			// Arrange
			AbilityScore abilityScore = new AbilityScore();
			abilityScore.BaseScore = 1;
			abilityScore.Penalties.Add(() => 6);

			// Act
			byte? total = abilityScore.GetTotal();

			// Assert
			Assert.IsTrue(total.HasValue,
						  "An ability score with a non-null base score should have a non-null total.");
			Assert.AreEqual(0, total.Value,
						   "A negative total ability score should be reported as though it was zero.");
			Assert.AreEqual(-5, abilityScore.GetModifier(),
						   "An ability score of 0 should have a -5 modifier.");
			Assert.AreEqual(0, abilityScore.GetBonus(),
						   "An ability score of less than 12 should have a bonus of zero.");
		}
    }
}