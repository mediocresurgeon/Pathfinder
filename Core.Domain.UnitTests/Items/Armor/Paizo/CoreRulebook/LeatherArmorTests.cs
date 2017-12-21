using Core.Domain.Characters;
using Core.Domain.Items.Armor.Paizo.CoreRulebook;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Armor.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class LeatherArmorTests
    {
        #region Default material
        [Test(Description = "Ensures sensible defaults for a fresh instance of small-size leather armor.")]
        public void DefaultMaterial_Small()
        {
            // Arrange
            var armor = new LeatherArmor(SizeCategory.Small);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(8, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(7.5, armor.GetWeight());
            Assert.AreEqual(10, armor.MundaneMarketPrice());
            Assert.AreEqual(Leather.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Leather Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium-size leather armor.")]
        public void DefaultMaterial_Medium()
        {
            // Arrange
            var armor = new LeatherArmor(SizeCategory.Medium);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(8, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(15, armor.GetWeight());
            Assert.AreEqual(10, armor.MundaneMarketPrice());
            Assert.AreEqual(Leather.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Leather Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large-size leather armor.")]
        public void DefaultMaterial_Large()
        {
            // Arrange
            var armor = new LeatherArmor(SizeCategory.Large);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(8, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(30, armor.GetWeight());
            Assert.AreEqual(20, armor.MundaneMarketPrice());
            Assert.AreEqual(Leather.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Leather Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork leather armor.")]
        public void DefaultMaterial_Medium_Masterwork()
        {
            // Arrange
            var armor = new LeatherArmor(SizeCategory.Medium) {
                IsMasterwork = true
            };

            // Assert
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(160, armor.MundaneMarketPrice());
            Assert.AreEqual("Masterwork Leather Armor", armor.ToString());
        }
        #endregion

        #region Dragonhide
        [Test(Description = "Ensures sensible defaults for a fresh instance of small-size dragonhide leather armor.")]
        public void Dragonhide_Small()
        {
            // Arrange
            var armor = new LeatherArmor(SizeCategory.Small, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(8, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(7.5, armor.GetWeight());
            Assert.AreEqual(320, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Leather Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium-size dragonhide leather armor.")]
        public void Dragonhide_Medium()
        {
            // Arrange
            var armor = new LeatherArmor(SizeCategory.Medium, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(8, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(15, armor.GetWeight());
            Assert.AreEqual(320, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Leather Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large-size dragonhide leather armor.")]
        public void Dragonhide_Large()
        {
            // Arrange
            var armor = new LeatherArmor(SizeCategory.Large, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(8, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(30, armor.GetWeight());
            Assert.AreEqual(340, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Leather Armor", armor.ToString());
        }
        #endregion
    }
}