using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AttackBonuses;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.AttackBonuses
{
    [TestFixture]
    public class AttackBonusSectionTests
    {
        [Test(Description = "Ensures that AttackBonusSection cannot be instanciated with a null ICharacter reference.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new AttackBonusSection(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures a fresh instance of AttackBonusSection is created with sensible defaults.")]
        public void Default()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            AttackBonusSection attackBonusSection = new AttackBonusSection(character);

            // Assert
            Assert.IsInstanceOf<BaseAttackBonus>(attackBonusSection.BaseAttackBonus);
            Assert.IsInstanceOf<UniversalAttackBonus>(attackBonusSection.GenericMeleeAttackBonus);
            Assert.IsInstanceOf<UniversalAttackBonus>(attackBonusSection.GenericRangedAttackBonus);
            Assert.IsInstanceOf<UniversalAttackBonus>(attackBonusSection.GenericThrowingAttackBonus);
        }
    }
}