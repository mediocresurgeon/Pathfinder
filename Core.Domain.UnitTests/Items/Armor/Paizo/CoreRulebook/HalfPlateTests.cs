using System;
using Core.Domain.Characters;
using Core.Domain.Characters.DamageReduction;
using Core.Domain.Items.Armor.Paizo.CoreRulebook;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Armor.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class HalfPlateTests
    {
        #region Steel
        [Test(Description = "Ensures sensible defaults for a fresh instance of small steel half-plate.")]
        public void Steel_Small()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Small, HalfPlateMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(8, armor.GetArmorBonus());
            Assert.AreEqual(7, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(600, armor.GetMarketPrice());
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Half-Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium steel half-plate.")]
        public void Steel_Medium()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Medium, HalfPlateMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(8, armor.GetArmorBonus());
            Assert.AreEqual(7, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(600, armor.GetMarketPrice());
            Assert.AreEqual(50, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Half-Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large steel half-plate.")]
        public void Steel_Large()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Large, HalfPlateMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(8, armor.GetArmorBonus());
            Assert.AreEqual(7, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(1200, armor.GetMarketPrice());
            Assert.AreEqual(100, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Half-Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork medium steel half-plate.")]
        public void Steel_Medium_Masterwork()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Medium, HalfPlateMaterial.Steel) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(750, armor.GetMarketPrice());
            Assert.AreEqual("Masterwork Half-Plate", armor.ToString());
        }
        #endregion

        #region Adamantine
        [Test(Description = "Ensures sensible defaults for a fresh instance of small adamantine half-plate.")]
        public void Adamantine_Small_Default()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Small, HalfPlateMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(8, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(15_600, armor.GetMarketPrice());
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Half-Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium adamantine half-plate.")]
        public void Adamantine_Medium_Default()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Medium, HalfPlateMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(8, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(15_600, armor.GetMarketPrice());
            Assert.AreEqual(50, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Half-Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large adamantine half-plate.")]
        public void Adamantine_Large_Default()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Large, HalfPlateMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(8, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(16_200, armor.GetMarketPrice());
            Assert.AreEqual(100, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Half-Plate", armor.ToString());
        }


        [Test(Description = "Ensures that equipped an adamantine half-plate applies damage reduction to the character.")]
        public void Adamantine_ApplyTo_DamageReduction()
        {
            // Arrange
            var damageReductionTracker = Mock.Of<IDamageReductionTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.DamageReduction)
                         .Returns(damageReductionTracker);
            var armor = new HalfPlate(SizeCategory.Medium, HalfPlateMaterial.Adamantine);

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(damageReductionTracker)
                .Verify(drt => drt.Add(It.Is<Func<byte>>(calc => 3 == calc()),
                                       It.Is<String>(bpb => "—" == bpb)),
                        "Equipping an adamantine half-plate should bestow DR 3/— on the character wearing it.");
        }
        #endregion

        #region Mithral
        [Test(Description = "Ensures sensible defaults for a fresh instance of small mithral half-plate.")]
        public void Mithral_Small()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Small, HalfPlateMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(8, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(9_600, armor.GetMarketPrice());
            Assert.AreEqual(12.5, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Half-Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium mithral half-plate.")]
        public void Mithral_Medium()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Medium, HalfPlateMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(8, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(9_600, armor.GetMarketPrice());
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Half-Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large mithral half-plate.")]
        public void Mithral_Large()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Large, HalfPlateMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(8, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_200, armor.GetMarketPrice());
            Assert.AreEqual(50, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Half-Plate", armor.ToString());
        }
        #endregion

        #region Dragonhide
        [Test(Description = "Ensures sensible defaults for a fresh instance of small-size dragonhide half-plate.")]
        public void Dragonhide_Small()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Small, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(1500, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Half-Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium-size dragonhide half-plate.")]
        public void Dragonhide_Medium()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Medium, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(50, armor.GetWeight());
            Assert.AreEqual(1500, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Half-Plate", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large-size dragonhide half-plate.")]
        public void Dragonhide_Large()
        {
            // Arrange
            var armor = new HalfPlate(SizeCategory.Large, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(100, armor.GetWeight());
            Assert.AreEqual(2700, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Half-Plate", armor.ToString());
        }
        #endregion
    }
}