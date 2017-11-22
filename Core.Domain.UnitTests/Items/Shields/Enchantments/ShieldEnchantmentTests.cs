using System;
using System.Reflection;
using Core.Domain.Items.Shields.Enchantments;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments
{
    [TestFixture]
    public class ShieldEnchantmentTests
    {
        #region Constructor
        [Test(Description = "Ensures that a shield enchantment cannot be created without a name.")]
        public void Constructor_NullName_Throws()
        {
            // Arrange
            string name = null;
            string webAddress = "https://example.com";

            // Act
            TestDelegate constructor = () =>
            {
                var mockEnchantment = new Mock<ShieldEnchantment>(MockBehavior.Loose, name, webAddress) { CallBase = true };
                var enchantment = mockEnchantment.Object;
            };

            // Assert
            var exception = Assert.Throws<TargetInvocationException>(constructor);
            Assert.That(exception.InnerException is ArgumentNullException);
        }


        [Test(Description = "Ensures that a shield enchantment cannot be created without a web address.")]
        public void Constructor_NullWebAddress_Throws()
        {
            // Arrange
            string name = "Some Enchantment";
            string webAddress = null;

            // Act
            TestDelegate constructor = () =>
            {
                var mockEnchantment = new Mock<ShieldEnchantment>(MockBehavior.Loose, name, webAddress) { CallBase = true };
                var enchantment = mockEnchantment.Object;
            };

            // Assert
            var exception = Assert.Throws<TargetInvocationException>(constructor);
            Assert.That(exception.InnerException is ArgumentNullException);
        }


        [Test(Description = "Ensures that a shield enchantment cannot be created without a valid web address.")]
        public void Constructor_MalformedWebAddress_Throws()
        {
            // Arrange
            string name = "Some Enchantment";
            string webAddress = "Not a web address!";

            // Act
            TestDelegate constructor = () =>
            {
                var mockEnchantment = new Mock<ShieldEnchantment>(MockBehavior.Loose, name, webAddress) { CallBase = true };
                var enchantment = mockEnchantment.Object;
            };

            // Assert
            var exception = Assert.Throws<TargetInvocationException>(constructor);
            Assert.That(exception.InnerException is ArgumentException);
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures that a fresh instance of ShieldEnchantment has sensible defaults.")]
        public void Default()
        {
            // Arrange
            string enchantmentName = "my enchantment";
            string enchantmentWebAddress = "https://example.com";
            ShieldEnchantment enchantment = new Mock<ShieldEnchantment>(MockBehavior.Loose, enchantmentName, enchantmentWebAddress) { CallBase = true }.Object;

            // Act
            var name = enchantment.Name;

            //Assert
            Assert.AreEqual(enchantmentName, name.Text);
            Assert.AreEqual(enchantmentWebAddress, name.WebAddress);
        }
        #endregion
    }
}