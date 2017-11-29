using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.SavingThrows;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SavingThrows
{
    #region Constructor
    [TestFixture]
    public class SavingThrowTests
    {
        [Test(Description = "Ensures that a Saving Throw cannot be created without an instance of ICharacter.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;
            var abilityScore = Mock.Of<IAbilityScore>();

            // Act
            TestDelegate constructor = () => new SavingThrow(character, abilityScore);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures that a Saving Throw cannot be created without an instance of IAbilityScore.")]
        public void Constructor_NullIAbilityScore_Throws()
        {
            // Arrange
            var character = Mock.Of<ICharacter>();
            IAbilityScore abilityScore = null;

            // Act
            TestDelegate constructor = () => new SavingThrow(character, abilityScore);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures sensible defaults for a fresh instance of SavingThrow.")]
        public void Default()
        {
            // Arrange
            var character = Mock.Of<ICharacter>();
            var abilityScore = Mock.Of<IAbilityScore>();

            // Act
            SavingThrow savingThrow = new SavingThrow(character, abilityScore);

            // Assert
            Assert.AreSame(abilityScore, savingThrow.KeyAbilityScore);
            Assert.IsFalse(savingThrow.IsGood);
            Assert.IsInstanceOf<LuckBonusTracker>(savingThrow.LuckBonuses);
            Assert.IsInstanceOf<ResistanceBonusTracker>(savingThrow.ResistanceBonuses);
            Assert.IsInstanceOf<UntypedBonusTracker>(savingThrow.UntypedBonuses);
            Assert.IsInstanceOf<PenaltyTracker>(savingThrow.Penalties);
        }
        #endregion

        #region GetLevelBonus()
        [Test(Description = "Ensures a good saving throw for a level 1 character is calculated correctly.")]
        public void GetLevelBonus_Good_Level1()
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level)
                         .Returns(1);

            SavingThrow savingThrow = new SavingThrow(mockCharacter.Object, abilityScore) {
                IsGood = true
            };

            // Act
            var result = savingThrow.GetLevelBonus();

            // Assert
            Assert.AreEqual(2, result,
                           "A good saving throw at level 1 provides a +2 bonus.");
        }


        [Test(Description = "Ensures a bad saving throw for a level 1 character is calculated correctly.")]
        public void GetLevelBonus_Bad_Level1()
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level)
                         .Returns(1);

            SavingThrow savingThrow = new SavingThrow(mockCharacter.Object, abilityScore) {
                IsGood = false
            };

            // Act
            var result = savingThrow.GetLevelBonus();

            // Assert
            Assert.AreEqual(0, result,
                           "A bad saving throw at level 1 provides a +0 bonus.");
        }


        [Test(Description = "Ensures a good saving throw for a level 2 character is calculated correctly.")]
        public void GetLevelBonus_Good_Level2()
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level)
                         .Returns(2);

            SavingThrow savingThrow = new SavingThrow(mockCharacter.Object, abilityScore) {
                IsGood = true
            };

            // Act
            var result = savingThrow.GetLevelBonus();

            // Assert
            Assert.AreEqual(3, result,
                           "A good saving throw at level 2 provides a +3 bonus.");
        }


        [Test(Description = "Ensures a bad saving throw for a level 2 character is calculated correctly.")]
        public void GetLevelBonus_Bad_Level2()
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level)
                         .Returns(2);

            SavingThrow savingThrow = new SavingThrow(mockCharacter.Object, abilityScore) {
                IsGood = false
            };

            // Act
            var result = savingThrow.GetLevelBonus();

            // Assert
            Assert.AreEqual(0, result,
                           "A bad saving throw at level 2 provides a +0 bonus.");
        }


        [Test(Description = "Ensures a good saving throw for a level 3 character is calculated correctly.")]
        public void GetLevelBonus_Good_Level3()
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level)
                         .Returns(3);

            SavingThrow savingThrow = new SavingThrow(mockCharacter.Object, abilityScore) {
                IsGood = true
            };

            // Act
            var result = savingThrow.GetLevelBonus();

            // Assert
            Assert.AreEqual(3, result,
                           "A good saving throw at level 3 provides a +3 bonus.");
        }


        [Test(Description = "Ensures a bad saving throw for a level 3 character is calculated correctly.")]
        public void GetLevelBonus_Bad_Level3()
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level)
                         .Returns(3);

            SavingThrow savingThrow = new SavingThrow(mockCharacter.Object, abilityScore) {
                IsGood = false
            };

            // Act
            var result = savingThrow.GetLevelBonus();

            // Assert
            Assert.AreEqual(1, result,
                           "A bad saving throw at level 3 provides a +1 bonus.");
        }
        #endregion

        #region GetTotal()
        [Test(Description = "Ensures that GetTotal() aggregates bonuses and penalties correctly.")]
        public void GetTotal()
        {
			// Arrange
			var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(abs => abs.GetModifier())
                            .Returns(3);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Level)
						 .Returns(3);

            SavingThrow savingThrow = new SavingThrow(mockCharacter.Object, mockAbilityScore.Object) {
                IsGood = false
            };
            savingThrow.LuckBonuses.Add(() => 5);
            savingThrow.ResistanceBonuses.Add(() => 7);
            savingThrow.UntypedBonuses.Add(() => 11);
            savingThrow.Penalties.Add(() => 13);

            // Act
            var total = savingThrow.GetTotal();

            // Assert
            Assert.AreEqual(14, total,
                            "+14 = (1 level) + (3 ability) + (5 luck) + (7 resistance) + (11 untyped) - (13 penalties)");
        }
        #endregion
    }
}