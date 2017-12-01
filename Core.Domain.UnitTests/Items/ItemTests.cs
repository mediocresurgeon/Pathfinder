using System;
using Core.Domain.Items;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items
{
    [TestFixture]
    [Parallelizable]
    public class ItemTests
    {
        [Test(Description = "Ensures that the aura strength of an item with no caster level is calculated correctly.")]
        public void AuraStrength_NullCasterLevel_None()
        {
            // Arrange
            var mockItem = new Mock<Item>() { CallBase = true };
            mockItem.Setup(i => i.GetCasterLevel())
                    .Returns((byte?)null);
            var item = mockItem.Object;

            // Act
            var auraStrength = item.GetAuraStrength();

            // Assert
            Assert.AreEqual(MagicalAuraStrength.None, auraStrength);
        }


        [Test(Description = "Ensures that the aura strength of an item with no caster level is calculated correctly.")]
        public void AuraStrength_CasterLevel0_None()
        {
            // Arrange
            var mockItem = new Mock<Item>() { CallBase = true };
            mockItem.Setup(i => i.GetCasterLevel())
                    .Returns(0);
            var item = mockItem.Object;

            // Act
            var auraStrength = item.GetAuraStrength();

            // Assert
            Assert.AreEqual(MagicalAuraStrength.None, auraStrength);
        }


        [Test(Description = "Ensures that the aura strength of an item with a caster level of 1 is calculated correctly.")]
        public void AuraStrength_CasterLevel1_Faint()
        {
            // Arrange
            var mockItem = new Mock<Item>() { CallBase = true };
            mockItem.Setup(i => i.GetCasterLevel())
                    .Returns(1);
            var item = mockItem.Object;

            // Act
            var auraStrength = item.GetAuraStrength();

            // Assert
            Assert.AreEqual(MagicalAuraStrength.Faint, auraStrength);
        }


        [Test(Description = "Ensures that the aura strength of an item with a caster level of 6 is calculated correctly.")]
        public void AuraStrength_CasterLevel5_Faint()
        {
            // Arrange
            var mockItem = new Mock<Item>() { CallBase = true };
            mockItem.Setup(i => i.GetCasterLevel())
                    .Returns(5);
            var item = mockItem.Object;

            // Act
            var auraStrength = item.GetAuraStrength();

            // Assert
            Assert.AreEqual(MagicalAuraStrength.Faint, auraStrength);
        }


        [Test(Description = "Ensures that the aura strength of an item with a caster level of 6 is calculated correctly.")]
        public void AuraStrength_CasterLevel6_Moderate()
        {
            // Arrange
            var mockItem = new Mock<Item>() { CallBase = true };
            mockItem.Setup(i => i.GetCasterLevel())
                    .Returns(6);
            var item = mockItem.Object;

            // Act
            var auraStrength = item.GetAuraStrength();

            // Assert
            Assert.AreEqual(MagicalAuraStrength.Moderate, auraStrength);
        }


        [Test(Description = "Ensures that the aura strength of an item with a caster level of 11 is calculated correctly.")]
        public void AuraStrength_CasterLevel11_Moderate()
        {
            // Arrange
            var mockItem = new Mock<Item>() { CallBase = true };
            mockItem.Setup(i => i.GetCasterLevel())
                    .Returns(11);
            var item = mockItem.Object;

            // Act
            var auraStrength = item.GetAuraStrength();

            // Assert
            Assert.AreEqual(MagicalAuraStrength.Moderate, auraStrength);
        }


        [Test(Description = "Ensures that the aura strength of an item with a caster level of 12 is calculated correctly.")]
        public void AuraStrength_CasterLevel12_Strong()
        {
            // Arrange
            var mockItem = new Mock<Item>() { CallBase = true };
            mockItem.Setup(i => i.GetCasterLevel())
                    .Returns(12);
            var item = mockItem.Object;

            // Act
            var auraStrength = item.GetAuraStrength();

            // Assert
            Assert.AreEqual(MagicalAuraStrength.Strong, auraStrength);
        }


        [Test(Description = "Ensures that the aura strength of an item with a caster level of 20 is calculated correctly.")]
        public void AuraStrength_CasterLevel20_Strong()
        {
            // Arrange
            var mockItem = new Mock<Item>() { CallBase = true };
            mockItem.Setup(i => i.GetCasterLevel())
                    .Returns(20);
            var item = mockItem.Object;

            // Act
            var auraStrength = item.GetAuraStrength();

            // Assert
            Assert.AreEqual(MagicalAuraStrength.Strong, auraStrength);
        }


        [Test(Description = "Ensures that the aura strength of an item with a caster level of 21 is calculated correctly.")]
        public void AuraStrength_CasterLevel21_Overwhelming()
        {
            // Arrange
            var mockItem = new Mock<Item>() { CallBase = true };
            mockItem.Setup(i => i.GetCasterLevel())
                    .Returns(21);
            var item = mockItem.Object;

            // Act
            var auraStrength = item.GetAuraStrength();

            // Assert
            Assert.AreEqual(MagicalAuraStrength.Overwhelming, auraStrength);
        }
    }
}
