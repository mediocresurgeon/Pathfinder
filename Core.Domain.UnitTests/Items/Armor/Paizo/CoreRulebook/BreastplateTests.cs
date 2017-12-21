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
    public class BreastplateTests
    {
        #region Steel
        [Test(Description = "Ensures sensible defaults for a fresh instance of small steel breastplate.")]
        public void Steel_Small()
        {
            // Arrange
            var armor = new Breastplate(SizeCategory.Small, BreastplateMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(200, armor.GetMarketPrice());
            Assert.AreEqual(15, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Breastplate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium steel breastplate.")]
        public void Steel_Medium()
        {
            // Arrange
            var armor = new Breastplate(SizeCategory.Medium, BreastplateMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(200, armor.GetMarketPrice());
            Assert.AreEqual(30, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Breastplate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large steel breastplate.")]
        public void Steel_Large()
        {
            // Arrange
            // Arrange
            var armor = new Breastplate(SizeCategory.Large, BreastplateMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(400, armor.GetMarketPrice());
            Assert.AreEqual(60, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Breastplate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork medium steel breastplate.")]
        public void Steel_Medium_Masterwork()
        {
            // Arrange
            var armor = new Breastplate(SizeCategory.Medium, BreastplateMaterial.Steel) { IsMasterwork = true };

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(350, armor.GetMarketPrice());
            Assert.AreEqual("Masterwork Breastplate", armor.ToString());
        }
        #endregion

        #region Adamantine
        [Test(Description = "Ensures sensible defaults for a fresh instance of small adamantine breastplate.")]
        public void Adamantine_Small_Default()
        {
            // Arrange
            var armor = new Breastplate(SizeCategory.Small, BreastplateMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_200, armor.GetMarketPrice());
            Assert.AreEqual(15, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Breastplate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium adamantine breastplate.")]
        public void Adamantine_Medium_Default()
        {
            // Arrange
            var armor = new Breastplate(SizeCategory.Medium, BreastplateMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_200, armor.GetMarketPrice());
            Assert.AreEqual(30, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Breastplate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large adamantine breastplate.")]
        public void Adamantine_Large_Default()
        {
            // Arrange
            var armor = new Breastplate(SizeCategory.Large, BreastplateMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_400, armor.GetMarketPrice());
            Assert.AreEqual(60, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Breastplate", armor.ToString());
        }


        [Test(Description = "Ensures that equipped an adamantine breastplate applies damage reduction to the character.")]
        public void Adamantine_ApplyTo_DamageReduction()
        {
            // Arrange
            var damageReductionTracker = Mock.Of<IDamageReductionTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.DamageReduction)
                         .Returns(damageReductionTracker);
            var armor = new Breastplate(SizeCategory.Medium, BreastplateMaterial.Adamantine);

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(damageReductionTracker)
                .Verify(drt => drt.Add(It.Is<Func<byte>>(calc => 2 == calc()),
                                       It.Is<String>(bpb => "—" == bpb)),
                        "Equipping an adamantine breastplate should bestow DR 2/— on the character wearing it.");
        }
        #endregion

        #region Mithral
        [Test(Description = "Ensures sensible defaults for a fresh instance of small mithral breastplate.")]
        public void Mithral_Small()
        {
            // Arrange
            var armor = new Breastplate(SizeCategory.Small, BreastplateMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(4200, armor.GetMarketPrice());
            Assert.AreEqual(7.5, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Breastplate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium mithral breastplate.")]
        public void Mithral_Medium()
        {
            // Arrange
            var armor = new Breastplate(SizeCategory.Medium, BreastplateMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(4200, armor.GetMarketPrice());
            Assert.AreEqual(15, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Breastplate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large mithral breastplate.")]
        public void Mithral_Large()
        {
            // Arrange
            var armor = new Breastplate(SizeCategory.Large, BreastplateMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(4400, armor.GetMarketPrice());
            Assert.AreEqual(30, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Breastplate", armor.ToString());
        }
        #endregion
    }
}