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
    public class FullPlateTests
    {
        #region Steel
        [Test(Description = "Ensures sensible defaults for a fresh instance of small steel full plate.")]
        public void Steel_Small()
        {
            // Arrange
            var armor = new FullPlate(SizeCategory.Small, FullPlateMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(9, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(1500, armor.GetMarketPrice());
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Full Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium steel full plate.")]
        public void Steel_Medium()
        {
            // Arrange
            var armor = new FullPlate(SizeCategory.Medium, FullPlateMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(9, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(1500, armor.GetMarketPrice());
            Assert.AreEqual(50, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Full Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large steel full plate.")]
        public void Steel_Large()
        {
            // Arrange
            var armor = new FullPlate(SizeCategory.Large, FullPlateMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(9, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(3000, armor.GetMarketPrice());
            Assert.AreEqual(100, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Full Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork medium steel full plate.")]
        public void Steel_Medium_Masterwork()
        {
            // Arrange
            var armor = new FullPlate(SizeCategory.Medium, FullPlateMaterial.Steel) { IsMasterwork = true };

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(1650, armor.GetMarketPrice());
            Assert.AreEqual("Masterwork Full Plate", armor.ToString());
        }
        #endregion

        #region Adamantine
        [Test(Description = "Ensures sensible defaults for a fresh instance of small adamantine full plate.")]
        public void Adamantine_Small_Default()
        {
            // Arrange
            var armor = new FullPlate(SizeCategory.Small, FullPlateMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(9, armor.GetArmorBonus());
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(16_500, armor.GetMarketPrice());
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Full Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium adamantine full plate.")]
        public void Adamantine_Medium_Default()
        {
            // Arrange
            var armor = new FullPlate(SizeCategory.Medium, FullPlateMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(9, armor.GetArmorBonus());
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(16_500, armor.GetMarketPrice());
            Assert.AreEqual(50, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Full Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large adamantine full plate.")]
        public void Adamantine_Large_Default()
        {
            // Arrange
            var armor = new FullPlate(SizeCategory.Large, FullPlateMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(9, armor.GetArmorBonus());
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(18_000, armor.GetMarketPrice());
            Assert.AreEqual(100, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Full Plate", armor.ToString());
        }


        [Test(Description = "Ensures that equipped an adamantine full plate applies damage reduction to the character.")]
        public void Adamantine_ApplyTo_DamageReduction()
        {
            // Arrange
            var damageReductionTracker = Mock.Of<IDamageReductionTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.DamageReduction)
                         .Returns(damageReductionTracker);
            var armor = new FullPlate(SizeCategory.Medium, FullPlateMaterial.Adamantine);

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(damageReductionTracker)
                .Verify(drt => drt.Add(It.Is<Func<byte>>(calc => 3 == calc()),
                                       It.Is<String>(bpb => "—" == bpb)),
                        "Equipping an adamantine full plate should bestow DR 3/— on the character wearing it.");
        }
        #endregion

        #region Mithral
        [Test(Description = "Ensures sensible defaults for a fresh instance of small mithral full plate.")]
        public void Mithral_Small()
        {
            // Arrange
            var armor = new FullPlate(SizeCategory.Small, FullPlateMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(9, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_500, armor.GetMarketPrice());
            Assert.AreEqual(12.5, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Full Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium mithral full plate.")]
        public void Mithral_Medium()
        {
            // Arrange
            var armor = new FullPlate(SizeCategory.Medium, FullPlateMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(9, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_500, armor.GetMarketPrice());
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Full Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large mithral full plate.")]
        public void Mithral_Large()
        {
            // Arrange
            var armor = new FullPlate(SizeCategory.Large, FullPlateMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(9, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(12_000, armor.GetMarketPrice());
            Assert.AreEqual(50, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Full Plate", armor.ToString());
        }
        #endregion
    }
}