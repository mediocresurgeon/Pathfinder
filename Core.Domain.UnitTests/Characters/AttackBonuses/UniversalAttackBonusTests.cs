using Core.Domain.Characters.AttackBonuses;
using Core.Domain.Characters.ModifierTrackers;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.AttackBonuses
{
    [TestFixture]
    public class UniversalAttackBonusTests
    {
        [Test(Description = "Ensures UniversalAttackBonus is created with sensible defaults.")]
        public void Default()
        {
            // Arrange
            UniversalAttackBonus attackBonus = new UniversalAttackBonus();

            // Assert
            Assert.IsInstanceOf<EnhancementBonusTracker>(attackBonus.EnhancementBonuses);
            Assert.IsInstanceOf<UntypedBonusTracker>(attackBonus.UntypedBonuses);
            Assert.IsInstanceOf<PenaltyTracker>(attackBonus.Penalties);
        }
    }
}