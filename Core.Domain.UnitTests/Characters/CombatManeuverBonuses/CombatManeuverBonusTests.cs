using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.AttackBonuses;
using Core.Domain.Characters.CombatManeuverBonuses;
using Core.Domain.Characters.ModifierTrackers;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.CombatManeuverBonuses
{
    [TestFixture]
    public class CombatManeuverBonusTests
    {
        #region Constructor
        [Test(Description = "Ensures that CombatManeuverBonus cannot be created without a non-null ICharacter reference.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new CombatManeuverBonus(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }

        [Test(Description = "Ensures that CombatManeuverBonus cannot be instanciated with a null AbilityScores property")]
        public void Constructor_NullAbilityScores_Throws()
        {
            // Arrange
            IAbilityScoreSection abilityScores = null;
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(abilityScores);

            // Act
            TestDelegate constructor = () => new CombatManeuverBonus(mockCharacter.Object);

            // Assert
            Assert.Throws<ArgumentException>(constructor);
        }


        [Test(Description = "Ensures that CombatManeuverBonus cannot be instanciated with a AbilityScores property which contains a null Strength property.")]
        public void Constructor_NullStrength_Throws()
        {
            // Arrange
            IAbilityScore strength = null;

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            // Act
            TestDelegate constructor = () => new CombatManeuverBonus(mockCharacter.Object);

            // Assert
            Assert.Throws<ArgumentException>(constructor);
        }
        #endregion

        #region Defaults
        [Test(Description = "Ensures that a fresh instance of CombatManeuverBonus has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var strength = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            CombatManeuverBonus cmb = new CombatManeuverBonus(mockCharacter.Object);

            // Assert
            Assert.AreSame(strength, cmb.KeyAbilityScore, "By default, CMB should be keyed to a character's strength score.");
            Assert.IsInstanceOf<EnhancementBonusTracker>(cmb.EnhancementBonuses);
            Assert.IsInstanceOf<UntypedBonusTracker>(cmb.UntypedBonuses);
            Assert.IsInstanceOf<PenaltyTracker>(cmb.Penalties);
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures null assignment to CombatManeuverBonus.KeyAbilityScore throws and exception.")]
        public void KeyAbilityScore_NullAssignment_Throws()
        {
            // Arrange
            var strength = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            CombatManeuverBonus cmb = new CombatManeuverBonus(mockCharacter.Object);

            // Act
            TestDelegate assignment = () => cmb.KeyAbilityScore = null;

            // Assert
            Assert.Throws<ArgumentNullException>(assignment,
                                                 "CombatManeuverBonus.KeyAbilityScore should not accept null assignment values.");
        }


        [Test(Description = "Ensures CMB reads enhancement bonuses from global melee attack bonus.")]
        public void EnhancementBonusTracker_ReadsMeleeAttackBonus()
        {
            // Arrange
            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(5);

            var mockUniversalMeleeAttackBonus = new Mock<IUniversalAttackBonus>();
            mockUniversalMeleeAttackBonus.Setup(umab => umab.EnhancementBonuses)
                                         .Returns(mockBonusTracker.Object);

            var mockAttackBonusSection = new Mock<IAttackBonusSection>();
            mockAttackBonusSection.Setup(abs => abs.GenericMeleeAttackBonus)
                                  .Returns(mockUniversalMeleeAttackBonus.Object);

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(Mock.Of<IAbilityScore>());

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.AttackBonuses)
                         .Returns(mockAttackBonusSection.Object);

            CombatManeuverBonus cmb = new CombatManeuverBonus(mockCharacter.Object);

            // Act
            var result = cmb.EnhancementBonuses.GetTotal();

            // Assert
            Assert.AreEqual(5, result,
                            "Enhancement bonuses which apply to all melee attack rolls should also be applied to CMB.");
        }


        [Test(Description = "Ensures CMB reads untyped bonuses from global melee attack bonus.")]
        public void UntypedBonusTracker_ReadsMeleeAttackBonus()
        {
            // Arrange
            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(5);

            var mockUniversalMeleeAttackBonus = new Mock<IUniversalAttackBonus>();
            mockUniversalMeleeAttackBonus.Setup(umab => umab.UntypedBonuses)
                                         .Returns(mockBonusTracker.Object);

            var mockAttackBonusSection = new Mock<IAttackBonusSection>();
            mockAttackBonusSection.Setup(abs => abs.GenericMeleeAttackBonus)
                                  .Returns(mockUniversalMeleeAttackBonus.Object);

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(Mock.Of<IAbilityScore>());

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.AttackBonuses)
                         .Returns(mockAttackBonusSection.Object);

            CombatManeuverBonus cmb = new CombatManeuverBonus(mockCharacter.Object);

            // Act
            var result = cmb.UntypedBonuses.GetTotal();

            // Assert
            Assert.AreEqual(5, result,
                            "Untyped bonuses which apply to all melee attack rolls should also be applied to CMB.");
        }


        [Test(Description = "Ensures CMB reads penalties from global melee attack bonus.")]
        public void PenaltyTracker_ReadsMeleeAttackBonus()
        {
            // Arrange
            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(5);

            var mockUniversalMeleeAttackBonus = new Mock<IUniversalAttackBonus>();
            mockUniversalMeleeAttackBonus.Setup(umab => umab.Penalties)
                                         .Returns(mockBonusTracker.Object);

            var mockAttackBonusSection = new Mock<IAttackBonusSection>();
            mockAttackBonusSection.Setup(abs => abs.GenericMeleeAttackBonus)
                                  .Returns(mockUniversalMeleeAttackBonus.Object);

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(Mock.Of<IAbilityScore>());

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.AttackBonuses)
                         .Returns(mockAttackBonusSection.Object);

            CombatManeuverBonus cmb = new CombatManeuverBonus(mockCharacter.Object);

            // Act
            var result = cmb.Penalties.GetTotal();

            // Assert
            Assert.AreEqual(5, result,
                            "Penalties which apply to all melee attack rolls should also be applied to CMB.");
        }
        #endregion

        #region GetSizeModifier()
        [Test(Description = "Ensures GetSizeModifer calculated the modifier for small characters correctly.")]
        public void GetSizeModifier_Small_Penalty1()
        {
            // Arrange
            var strength = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);

            CombatManeuverBonus cmb = new CombatManeuverBonus(mockCharacter.Object);

            // Act
            var result = cmb.GetSizeModifier();

            // Assert
            Assert.AreEqual(-1, result,
                            "A small character should receive a -1 penalty to CMB.");
        }


        [Test(Description = "Ensures GetSizeModifer calculated the modifier for medium characters correctly.")]
        public void GetSizeModifier_Medium_Zero()
        {
            // Arrange
            var strength = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);

            CombatManeuverBonus cmb = new CombatManeuverBonus(mockCharacter.Object);

            // Act
            var result = cmb.GetSizeModifier();

            // Assert
            Assert.AreEqual(0, result,
                            "A medium character should receive a 0 modifier to CMB.");
        }


        [Test(Description = "Ensures GetSizeModifer calculated the modifier for large characters correctly.")]
        public void GetSizeModifier_Large_Plus1()
        {
            // Arrange
            var strength = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);

            CombatManeuverBonus cmb = new CombatManeuverBonus(mockCharacter.Object);

            // Act
            var result = cmb.GetSizeModifier();

            // Assert
            Assert.AreEqual(1, result,
                            "A large character should receive a +1 bonus to CMB.");
        }
        #endregion

        #region GetTotal()
        [Test(Description = "Ensures GetTotal aggregates correctly.")]
        public void GetTotal_Aggregates()
        {
            // Arrange
            var mockBaseAttackBonus = new Mock<IBaseAttackBonus>();
            mockBaseAttackBonus.Setup(bab => bab.GetTotal())
                               .Returns(20);

            var mockAttackBonusSection = new Mock<IAttackBonusSection>();
            mockAttackBonusSection.Setup(abs => abs.BaseAttackBonus)
                                  .Returns(mockBaseAttackBonus.Object);

            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(ab => ab.GetModifier())
                            .Returns(2);

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(mockAbilityScore.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.AttackBonuses)
                         .Returns(mockAttackBonusSection.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);

            CombatManeuverBonus cmb = new CombatManeuverBonus(mockCharacter.Object);
            cmb.EnhancementBonuses.Add(3);
            cmb.UntypedBonuses.Add(4);
            cmb.Penalties.Add(5);

            // Act
            var result = cmb.GetTotal();

            // Assert
            Assert.AreEqual(25, result,
                            "25 = (20 BAB) + (1 size) + (2 strength) + (3 enhancement) + (4 untyped) - (5 penalty)");
        }
        #endregion
    }
}