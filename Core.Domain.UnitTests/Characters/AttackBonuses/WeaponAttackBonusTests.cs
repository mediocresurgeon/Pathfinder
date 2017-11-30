using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.AttackBonuses;
using Core.Domain.Characters.ModifierTrackers;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.AttackBonuses
{
    [TestFixture]
    [Parallelizable]
    public class WeaponAttackBonusTests
    {
        #region Constructor
        [Test(Description = "Ensures that WeaponAttackBonus cannot be created with a null ICharacter reference.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;
            var abilityScore = Mock.Of<IAbilityScore>();
            var attackBonus = Mock.Of<IUniversalAttackBonus>();

            // Act
            TestDelegate constructor = () => new WeaponAttackBonus(character, abilityScore, attackBonus);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures that WeaponAttackBonus cannot be created with a null IAbilityScore reference.")]
        public void Constructor_NullIAbilityScore_Throws()
        {
            // Arrange
            var character = Mock.Of<ICharacter>();
            IAbilityScore abilityScore = null;
            var attackBonus = Mock.Of<IUniversalAttackBonus>();

            // Act
            TestDelegate constructor = () => new WeaponAttackBonus(character, abilityScore, attackBonus);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures that WeaponAttackBonus cannot be created with a null IAttackBonus reference.")]
        public void Constructor_NullIAttackBonus_Throws()
        {
            // Arrange
            var character = Mock.Of<ICharacter>();
            var abilityScore = Mock.Of<IAbilityScore>();
            IUniversalAttackBonus attackBonus = null;

            // Act
            TestDelegate constructor = () => new WeaponAttackBonus(character, abilityScore, attackBonus);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region KeyAbilityScore
        [Test(Description = "Ensures that the IAbilityScore passed into the constructor is returned by calling the KeyAbilityScore property.")]
        public void KeyAbilityScore_PassThrough()
        {
            // Arrange
            var character = Mock.Of<ICharacter>();
            var abilityScore = Mock.Of<IAbilityScore>();
            var attackBonus = Mock.Of<IUniversalAttackBonus>();

            WeaponAttackBonus wab = new WeaponAttackBonus(character, abilityScore, attackBonus);

            // Act
            IAbilityScore keyAbilityScore = wab.KeyAbilityScore;

            // Assert
            Assert.AreSame(abilityScore, keyAbilityScore,
                           $"By default, the key ability score returned from the { nameof(WeaponAttackBonus.KeyAbilityScore) } property should be the same instance that was passed into the constructor.");
        }


        [Test(Description = "Ensures that KeyAbilityScore property cannot be assigned a null value.")]
        public void KeyAbilityScore_NullAssignment_Throws()
        {
            // Arrange
            var character = Mock.Of<ICharacter>();
            var abilityScore = Mock.Of<IAbilityScore>();
            var attackBonus = Mock.Of<IUniversalAttackBonus>();

            WeaponAttackBonus wab = new WeaponAttackBonus(character, abilityScore, attackBonus);

            // Act
            TestDelegate assignment = () => wab.KeyAbilityScore = null;

            // Assert
            Assert.Throws<ArgumentNullException>(assignment,
                                                 "Assigning a null value to WeaponAttackBonus.KeyAbilityScore should throw an ArgumentNullException.");
        }
        #endregion

        #region Bonuses and penalties
        [Test(Description = "Ensures that universal enhancement bonuses to attack are transfered correctly.")]
        public void EnhancementBonuses_GetTotal()
        {
            // Arrange
            var character = Mock.Of<ICharacter>();
            var abilityScore = Mock.Of<IAbilityScore>();

            var mockModifierTracker = new Mock<IModifierTracker>();
            mockModifierTracker.Setup(mt => mt.GetTotal())
                               .Returns(1);

            var mockAttackBonus = new Mock<IUniversalAttackBonus>();
            mockAttackBonus.Setup(mab => mab.EnhancementBonuses)
                           .Returns(mockModifierTracker.Object);

            WeaponAttackBonus wab = new WeaponAttackBonus(character, abilityScore, mockAttackBonus.Object);

            // Act
            var result = wab.EnhancementBonuses.GetTotal();

            // Assert
            Assert.AreEqual(1, result,
                           "Universal enhancement bonuses to attack should be applied to weapon attack bonuses.");
        }


        [Test(Description = "Ensures that universal untyped bonuses to attack are transfered correctly.")]
        public void UntypedBonuses_GetTotal()
        {
            // Arrange
            var character = Mock.Of<ICharacter>();
            var abilityScore = Mock.Of<IAbilityScore>();

            var mockModifierTracker = new Mock<IModifierTracker>();
            mockModifierTracker.Setup(mt => mt.GetTotal())
                               .Returns(1);

            var mockAttackBonus = new Mock<IUniversalAttackBonus>();
            mockAttackBonus.Setup(mab => mab.UntypedBonuses)
                           .Returns(mockModifierTracker.Object);

            WeaponAttackBonus wab = new WeaponAttackBonus(character, abilityScore, mockAttackBonus.Object);

            // Act
            var result = wab.UntypedBonuses.GetTotal();

            // Assert
            Assert.AreEqual(1, result,
                           "Universal untyped bonuses to attack should be applied to weapon attack bonuses.");
        }


        [Test(Description = "Ensures that universal penalties to attack are transfered correctly.")]
        public void Penalties_GetTotal()
        {
            // Arrange
            var character = Mock.Of<ICharacter>();
            var abilityScore = Mock.Of<IAbilityScore>();

            var mockModifierTracker = new Mock<IModifierTracker>();
            mockModifierTracker.Setup(mt => mt.GetTotal())
                               .Returns(1);

            var mockAttackBonus = new Mock<IUniversalAttackBonus>();
            mockAttackBonus.Setup(mab => mab.Penalties)
                           .Returns(mockModifierTracker.Object);

            WeaponAttackBonus wab = new WeaponAttackBonus(character, abilityScore, mockAttackBonus.Object);

            // Act
            var result = wab.Penalties.GetTotal();

            // Assert
            Assert.AreEqual(1, result,
                           "Universal penalties to attack should be applied to weapon attack bonuses.");
        }
        #endregion

        #region GetSizeModifier()
        [Test(Description = "Ensures that the attack bonus for being a small character is calculated correctly.")]
        public void GetSizeModifier_Small_Pos1()
        {
            // Arrange
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);
            var abilityScore = Mock.Of<IAbilityScore>();
            var attackBonus = Mock.Of<IUniversalAttackBonus>();

            WeaponAttackBonus wab = new WeaponAttackBonus(mockCharacter.Object, abilityScore, attackBonus);

            // Act
            var result = wab.GetSizeModifier();

            // Assert
            Assert.AreEqual(1, result,
                           "A small character should receive a +1 bonus to attack rolls.");
        }


        [Test(Description = "Ensures that the attack bonus for being a medium character is calculated correctly.")]
        public void GetSizeModifier_Medium_Zero()
        {
            // Arrange
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);
            var abilityScore = Mock.Of<IAbilityScore>();
            var attackBonus = Mock.Of<IUniversalAttackBonus>();

            WeaponAttackBonus wab = new WeaponAttackBonus(mockCharacter.Object, abilityScore, attackBonus);

            // Act
            var result = wab.GetSizeModifier();

            // Assert
            Assert.AreEqual(0, result,
                           "A medium character should receive a +0 bonus to attack rolls.");
        }


        [Test(Description = "Ensures that the attack penalty for being a large character is calculated correctly.")]
        public void GetSizeModifier_Large_Neg1()
        {
            // Arrange
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);
            var abilityScore = Mock.Of<IAbilityScore>();
            var attackBonus = Mock.Of<IUniversalAttackBonus>();

            WeaponAttackBonus wab = new WeaponAttackBonus(mockCharacter.Object, abilityScore, attackBonus);

            // Act
            var result = wab.GetSizeModifier();

            // Assert
            Assert.AreEqual(-1, result,
                           "A large character should receive a -1 penalty to attack rolls.");
        }
        #endregion

        #region GetTotal()
        // Arrange
        [Test(Description = "Ensures that GetTotal() aggregates bonus correctly.")]
        public void GetTotal_Aggregates()
        {
            // Arrange
            var universalAttackBonus = Mock.Of<IUniversalAttackBonus>();

            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(mas => mas.GetModifier())
                            .Returns(2);

            var mockBaseAttackBonus = new Mock<IBaseAttackBonus>();
            mockBaseAttackBonus.Setup(mbab => mbab.GetTotal())
                               .Returns(20);

            var mockAttackBonusSection = new Mock<IAttackBonusSection>();
            mockAttackBonusSection.Setup(mbabs => mbabs.BaseAttackBonus)
                                  .Returns(mockBaseAttackBonus.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Size)
                             .Returns(SizeCategory.Small);
            mockCharacter.Setup(c => c.AttackBonuses)
                         .Returns(mockAttackBonusSection.Object);

            WeaponAttackBonus wab = new WeaponAttackBonus(mockCharacter.Object, mockAbilityScore.Object, universalAttackBonus);
            wab.EnhancementBonuses.Add(() => 3);
            wab.UntypedBonuses.Add(() => 4);
            wab.Penalties.Add(() => 5);

            // Act
            var total = wab.GetTotal();

            // Assert
            Assert.AreEqual(25, total,
                            "+25 = (20 BAB) + (1 size) + (2 ability) + (3 enhancement) + (4 untyped) - (5 penalties)");
        }
        #endregion
    }
}