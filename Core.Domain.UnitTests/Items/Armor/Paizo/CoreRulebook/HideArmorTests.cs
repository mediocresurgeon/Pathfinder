using Core.Domain.Characters;
using Core.Domain.Items.Armor.Paizo.CoreRulebook;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Armor.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class HideArmorTests
    {
        #region Default material
        [Test(Description = "Ensures sensible defaults for a fresh instance of small-size hide armor.")]
        public void DefaultMaterial_Small()
        {
            // Arrange
            var armor = new HideArmor(SizeCategory.Small);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(12.5, armor.GetWeight());
            Assert.AreEqual(15, armor.MundaneMarketPrice());
            Assert.AreEqual(Leather.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Hide Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium-size hide armor.")]
        public void DefaultMaterial_Medium()
        {
            // Arrange
            var armor = new HideArmor(SizeCategory.Medium);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(15, armor.MundaneMarketPrice());
            Assert.AreEqual(Leather.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Hide Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large-size hide armor.")]
        public void DefaultMaterial_Large()
        {
            // Arrange
            var armor = new HideArmor(SizeCategory.Large);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(50, armor.GetWeight());
            Assert.AreEqual(30, armor.MundaneMarketPrice());
            Assert.AreEqual(Leather.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Hide Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork leather armor.")]
        public void DefaultMaterial_Medium_Masterwork()
        {
            // Arrange
            var armor = new HideArmor(SizeCategory.Medium) {
                IsMasterwork = true
            };

            // Assert
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(165, armor.MundaneMarketPrice());
            Assert.AreEqual("Masterwork Hide Armor", armor.ToString());
        }
        #endregion

        #region Dragonhide
        [Test(Description = "Ensures sensible defaults for a fresh instance of small-size dragonhide hide armor.")]
        public void Dragonhide_Small()
        {
            // Arrange
            var armor = new HideArmor(SizeCategory.Small, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(12.5, armor.GetWeight());
            Assert.AreEqual(330, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Hide Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium-size dragonhide leather armor.")]
        public void Dragonhide_Medium()
        {
            // Arrange
            var armor = new HideArmor(SizeCategory.Medium, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(25, armor.GetWeight());
            Assert.AreEqual(330, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Hide Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large-size dragonhide leather armor.")]
        public void Dragonhide_Large()
        {
            // Arrange
            var armor = new HideArmor(SizeCategory.Large, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(50, armor.GetWeight());
            Assert.AreEqual(360, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Hide Armor", armor.ToString());
        }
        #endregion
    }
}