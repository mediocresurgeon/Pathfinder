using Core.Domain.Characters;
using Core.Domain.Items.Armor.Paizo.CoreRulebook;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Armor.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class StuddedLeatherArmorTests
    {
        #region Default material
        [Test(Description = "Ensures sensible defaults for a fresh instance of small-size studded leather armor.")]
        public void DefaultMaterial_Small()
        {
            // Arrange
            var armor = new StuddedLeatherArmor(SizeCategory.Small);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(10, armor.GetWeight());
            Assert.AreEqual(25, armor.MundaneMarketPrice());
            Assert.AreEqual(Leather.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Studded Leather Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium-size studded leather armor.")]
        public void DefaultMaterial_Medium()
        {
            // Arrange
            var armor = new StuddedLeatherArmor(SizeCategory.Medium);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(20, armor.GetWeight());
            Assert.AreEqual(25, armor.MundaneMarketPrice());
            Assert.AreEqual(Leather.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Studded Leather Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large-size studded leather armor.")]
        public void DefaultMaterial_Large()
        {
            // Arrange
            var armor = new StuddedLeatherArmor(SizeCategory.Large);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(40, armor.GetWeight());
            Assert.AreEqual(50, armor.MundaneMarketPrice());
            Assert.AreEqual(Leather.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Studded Leather Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork studded leather armor.")]
        public void DefaultMaterial_Medium_Masterwork()
        {
            // Arrange
            var armor = new StuddedLeatherArmor(SizeCategory.Medium) {
                IsMasterwork = true
            };

            // Assert
            Assert.AreEqual(0, armor.ArmorCheckPenalty());
            Assert.AreEqual(175, armor.MundaneMarketPrice());
            Assert.AreEqual("Masterwork Studded Leather Armor", armor.ToString());
        }
        #endregion

        #region Dragonhide
        [Test(Description = "Ensures sensible defaults for a fresh instance of small-size dragonhide leather armor.")]
        public void Dragonhide_Small()
        {
            // Arrange
            var armor = new StuddedLeatherArmor(SizeCategory.Small, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(0, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(10, armor.GetWeight());
            Assert.AreEqual(350, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Studded Leather Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium-size dragonhide leather armor.")]
        public void Dragonhide_Medium()
        {
            // Arrange
            var armor = new StuddedLeatherArmor(SizeCategory.Medium, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(0, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(20, armor.GetWeight());
            Assert.AreEqual(350, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Studded Leather Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large-size dragonhide leather armor.")]
        public void Dragonhide_Large()
        {
            // Arrange
            var armor = new StuddedLeatherArmor(SizeCategory.Large, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(0, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(40, armor.GetWeight());
            Assert.AreEqual(400, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Studded Leather Armor", armor.ToString());
        }
        #endregion
    }
}