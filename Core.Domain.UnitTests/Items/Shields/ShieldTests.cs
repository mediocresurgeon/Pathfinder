using System;
using Core.Domain.Characters;
using Core.Domain.Items.Shields;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields
{
    [TestFixture]
    public class ShieldTests
    {
        [Test(Description = "Ensures that Shield has sensible defaults.")]
        public void Default()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose, (byte)5, 1f, (byte)100, (byte)40) { CallBase = true }.Object;

            // Assert
            Assert.IsFalse(shield.IsMasterwork);
            Assert.IsInstanceOf<ShieldBonusAggregator>(shield.ArmorClass);
            Assert.IsInstanceOf<ShieldEnchantmentAggregator>(shield.Enchantments);
            Assert.IsInstanceOf<ShieldHardnessAggregator>(shield.Hardness);
            Assert.IsInstanceOf<ShieldHitPointAggregator>(shield.HitPoints);
        }


        [Test(Description = "Ensures that a Shield cannot be applied to a null ICharacter.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose, (byte)5, 1f, (byte)100, (byte)40) { CallBase = true }.Object;
            ICharacter character = null; 

            // Act
            TestDelegate applyTo = () => shield.ApplyTo(character);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }
    }
}