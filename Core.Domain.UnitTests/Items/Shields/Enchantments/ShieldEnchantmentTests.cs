using System;
using System.Reflection;
using Core.Domain.Items.Shields.ShieldEnchantments.Enchantments;
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
                var mockEnchantment = new Mock<ShieldEnchantment>(MockBehavior.Loose, name, webAddress);
                var enchantment = mockEnchantment.Object;
            };

            // Assert
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
                var mockEnchantment = new Mock<ShieldEnchantment>(MockBehavior.Loose, name, webAddress);
                var enchantment = mockEnchantment.Object;
            };

            // Assert
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
                var mockEnchantment = new Mock<ShieldEnchantment>(MockBehavior.Loose, name, webAddress);
                var enchantment = mockEnchantment.Object;
            };

            // Assert
            var exception = Assert.Throws<TargetInvocationException>(constructor);
            Assert.That(exception.InnerException is ArgumentException);
        }
        #endregion
    }
}