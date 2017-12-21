using System;
using Core.Domain.Characters;
using Core.Domain.Characters.DamageReduction;
using Core.Domain.Items.Armor.Paizo.CoreRulebook;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Armor.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class ChainShirtTests
    {
        #region Steel
        [Test(Description = "Ensures sensible defaults for a fresh instance of small steel chain shirt.")]
        public void Steel_Small()
        {
            // Arrange
            var armor = new ChainShirt(SizeCategory.Small, ChainShirtMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(4, armor.GetArmorBonus());
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(100, armor.GetMarketPrice());
            Assert.AreEqual(12.5, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Chain Shirt", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium steel chain shirt.")]
        public void Steel_Medium()
        {
            // Arrange
            var armor = new ChainShirt(SizeCategory.Medium, ChainShirtMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(4, armor.GetArmorBonus());
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(100, armor.GetMarketPrice());
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Chain Shirt", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large steel chain shirt.")]
        public void Steel_Large()
        {
            // Arrange
            var armor = new ChainShirt(SizeCategory.Large, ChainShirtMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(4, armor.GetArmorBonus());
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(200, armor.GetMarketPrice());
            Assert.AreEqual(50, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Chain Shirt", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork medium steel chain shirt.")]
        public void Steel_Medium_Masterwork()
        {
            // Arrange
            var armor = new ChainShirt(SizeCategory.Medium, ChainShirtMaterial.Steel) { IsMasterwork = true };

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(250, armor.GetMarketPrice());
            Assert.AreEqual("Masterwork Chain Shirt", armor.ToString());
        }
        #endregion

        #region Adamantine
        [Test(Description = "Ensures sensible defaults for a fresh instance of small adamantine chain shirt.")]
        public void Adamantine_Small_Default()
        {
            // Arrange
            var armor = new ChainShirt(SizeCategory.Small, ChainShirtMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(4, armor.GetArmorBonus());
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(5100, armor.GetMarketPrice());
            Assert.AreEqual(12.5, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Chain Shirt", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium adamantine chain shirt.")]
        public void Adamantine_Medium_Default()
        {
            // Arrange
            var armor = new ChainShirt(SizeCategory.Medium, ChainShirtMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(4, armor.GetArmorBonus());
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(5100, armor.GetMarketPrice());
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Chain Shirt", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large adamantine chain shirt.")]
        public void Adamantine_Large_Default()
        {
            // Arrange
            var armor = new ChainShirt(SizeCategory.Large, ChainShirtMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(4, armor.GetArmorBonus());
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(5200, armor.GetMarketPrice());
            Assert.AreEqual(50, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Chain Shirt", armor.ToString());
        }


        [Test(Description = "Ensures that equipped an adamantine chain shirt applies damage reduction to the character.")]
        public void Adamantine_ApplyTo_DamageReduction()
        {
            // Arrange
            var damageReductionTracker = Mock.Of<IDamageReductionTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.DamageReduction)
                         .Returns(damageReductionTracker);
            var armor = new ChainShirt(SizeCategory.Medium, ChainShirtMaterial.Adamantine);

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(damageReductionTracker)
                .Verify(drt => drt.Add(It.Is<Func<byte>>(calc => 1 == calc()),
                                       It.Is<String>(bpb => "—" == bpb)),
                        "Equipping an adamantine chain shirt should bestow DR 1/— on the character wearing it.");
        }
        #endregion

        #region Mithral
        [Test(Description = "Ensures sensible defaults for a fresh instance of small mithral chain shirt.")]
        public void Mithral_Small()
        {
            // Arrange
            var armor = new ChainShirt(SizeCategory.Small, ChainShirtMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(4, armor.GetArmorBonus());
            Assert.AreEqual(0, armor.ArmorCheckPenalty());
            Assert.AreEqual(6, armor.MaximumDexterityBonus());
            Assert.AreEqual(1100, armor.GetMarketPrice());
            Assert.AreEqual(6.25, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Chain Shirt", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium mithral chain shirt.")]
        public void Mithral_Medium()
        {
            // Arrange
            var armor = new ChainShirt(SizeCategory.Medium, ChainShirtMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(4, armor.GetArmorBonus());
            Assert.AreEqual(0, armor.ArmorCheckPenalty());
            Assert.AreEqual(6, armor.MaximumDexterityBonus());
            Assert.AreEqual(1100, armor.GetMarketPrice());
            Assert.AreEqual(12.5, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Chain Shirt", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large mithral chain shirt.")]
        public void Mithral_Large()
        {
            // Arrange
            var armor = new ChainShirt(SizeCategory.Large, ChainShirtMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(4, armor.GetArmorBonus());
            Assert.AreEqual(0, armor.ArmorCheckPenalty());
            Assert.AreEqual(6, armor.MaximumDexterityBonus());
            Assert.AreEqual(1200, armor.GetMarketPrice());
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Chain Shirt", armor.ToString());
        }
        #endregion
    }
}