using System;
using Core.Domain.Items.Shields;
using Core.Domain.Items.Shields.ShieldEnchantments.Enchantments;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields
{
    [TestFixture]
    public class ShieldEnchantmentAggregatorTests
    {
        [Test(Description = "Ensures that an instance of ShieldEnchantmentAggregator cannot be created with a null Shield reference.")]
        public void Constructor_NullShield_Throws()
        {
            // Arrange
            Shield shield = null;

            // Act
            TestDelegate constructor = () => new ShieldEnchantmentAggregator(shield);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        #region EnchantWith<T>(T)
        [Test(Description = "Ensures that EnchantWith cannot be fed a null ShieldEnchantment.")]
        public void EnchantWith_NullEnchantment_Throws()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose, (byte)5, 1f, (byte)100, (byte)40) { CallBase = true }.Object;
            ShieldEnchantmentAggregator aggregator = new ShieldEnchantmentAggregator(shield);
            ShieldEnchantment enchantment = null;

            // Act
            TestDelegate enchantWith = () => aggregator.EnchantWith(enchantment);

            // Assert
            Assert.Throws<ArgumentNullException>(enchantWith);
        }
        #endregion
    }
}