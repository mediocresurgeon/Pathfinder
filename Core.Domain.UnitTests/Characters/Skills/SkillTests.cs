﻿using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    public class SkillTests
    {
        [Test(Description = "Ensures that Skill has sensible defaults.")]
        public void DefaultValues()
        {
            // Arrange
            var character = new Mock<ICharacter>().Object;
            var abilityScore = new Mock<IAbilityScore>().Object;
            string skillName = "my skill";

            Skill skill = new Skill(character, abilityScore, skillName);

            // Assert
            Assert.AreSame(abilityScore, skill.KeyAbilityScore);
            Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.IsFalse(skill.IsClassSkill);
            Assert.AreEqual(0, skill.Ranks);
            Assert.IsInstanceOf<RacialBonusTracker>(skill.RacialBonuses);
            Assert.IsInstanceOf<SizeBonusTracker>(skill.SizeBonuses);
            Assert.IsInstanceOf<UntypedBonusTracker>(skill.UntypedBonuses);
            Assert.IsInstanceOf<PenaltyTracker>(skill.Penalties);
        }


        #region CanBeUsedUntrained
        [Test(Description = "Ensures that a skill which can be used untrained aggregates correctly.")]
        public void CanBeUsedUntrained_Default_Aggregates()
        {
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(a => a.GetModifier()).Returns(0);
            IAbilityScore abilityScore = mockAbilityScore.Object;

            ICharacter character = new Mock<ICharacter>().Object;

            string skillName = "my skill";

            Skill skill = new Skill(character, abilityScore, skillName);

            // Act
            var result = skill.GetTotal();

            // Assert
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(0, result.Value,
                           "An untrained skill with no bonuses and no ability score modifier should have a total of zero.");
        }


        [Test(Description = "Ensures that a skill which cannot be used untrained and has zero ranks does not return a total.")]
        public void CanBeUsedUntrained_FalseUntrained_Aggregates()
        {
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(a => a.GetModifier()).Returns(0);
            IAbilityScore abilityScore = mockAbilityScore.Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level).Returns(20);
            ICharacter character = mockCharacter.Object;

            string skillName = "my skill";

            Skill skill = new Skill(character, abilityScore, skillName)
            {
                Ranks              = 0,
                CanBeUsedUntrained = false
            };

            // Act
            var result = skill.GetTotal();

            // Assert
            Assert.IsFalse(result.HasValue,
                          "A skill which has zero ranks and cannot be used untrained should not have a total.");
        }


        [Test(Description = "Ensures that a skill which cannot be used untrained and has at least 1 rank returns a total.")]
        public void CanBeUsedUntrained_FalseTrained_Aggregates()
        {
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(a => a.GetModifier()).Returns(0);
            IAbilityScore abilityScore = mockAbilityScore.Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level).Returns(20);
            ICharacter character = mockCharacter.Object;

            string skillName = "my skill";

            Skill skill = new Skill(character, abilityScore, skillName)
            {
                Ranks              = 1,
                CanBeUsedUntrained = false
            };

            // Act
            var result = skill.GetTotal();

            // Assert
            Assert.IsTrue(result.HasValue,
                          "A skill which has at least one rank and cannot be used untrained should have a total.");
            Assert.AreEqual(1, result.Value);
        }
        #endregion

        #region IsClassSkill
        [Test(Description = "Ensures that a skill which can be used untrained aggregates correctly.")]
        public void IsClassSkill_OneRank_Aggregates()
        {
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(a => a.GetModifier()).Returns(0);
            IAbilityScore abilityScore = mockAbilityScore.Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level).Returns(20);
            ICharacter character = mockCharacter.Object;

            string skillName = "my skill";

            Skill skill = new Skill(character, abilityScore, skillName)
            {
                IsClassSkill = true,
                Ranks        = 1
            };

            // Act
            var result = skill.GetTotal();

            // Assert
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(4, result.Value,
                           "An trained class skill with no bonuses and no ability score modifier should have a total of 4.");
        }
        #endregion

        #region Ranks
        [Test(Description = "Ensures that a skill which can be used untrained aggregates correctly.")]
        public void Ranks_ExceedCharacterLevel_Throws()
        {
            // Arrange
            IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level).Returns(1);
            ICharacter character = mockCharacter.Object;

            string skillName = "my skill";

            Skill skill = new Skill(character, abilityScore, skillName)
            {
                IsClassSkill = true
            };

            // Act
            TestDelegate setRanks = () => skill.Ranks = 2;

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(setRanks,
                                                      "Setting skills ranks higher than the character's level is not allowed.");
        }
		#endregion

		#region GetTotal
		[Test(Description = "Ensures that GetTotal aggregates bonus from all sources correctly.")]
		public void GetTotal_Aggregates()
		{
			// Arrange
			var mockAbilityScore = new Mock<IAbilityScore>();
			mockAbilityScore.Setup(a => a.GetModifier()).Returns(5);
			IAbilityScore abilityScore = mockAbilityScore.Object;

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Level).Returns(1);
			ICharacter character = mockCharacter.Object;

            string skillName = "my skill";

            Skill skill = new Skill(character, abilityScore, skillName)
            {
                IsClassSkill = true,
                Ranks        = 1
            };
            skill.RacialBonuses.Add(7);
            skill.SizeBonuses.Add(11);
            skill.UntypedBonuses.Add(13);
            skill.Penalties.Add(17);

			// Act
			var result = skill.GetTotal();

            // Assert
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(23, result.Value,
                            "23 = (1 rank) + (3 trained) + (5 ability) + (7 racial) + (11 size) + (13 untyped) - (17 penalties)");
		}
        #endregion
    }
}