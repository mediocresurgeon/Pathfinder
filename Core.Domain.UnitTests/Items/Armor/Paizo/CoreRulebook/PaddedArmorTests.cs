using Core.Domain.Characters;
using Core.Domain.Items.Armor.Paizo.CoreRulebook;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Armor.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class PaddedArmorTests
    {
        #region Default material
        [Test(Description = "Ensures sensible defaults for a fresh instance of small-size padded armor.")]
        public void DefaultMaterial_Small()
        {
            // Arrange
            var armor = new PaddedArmor(SizeCategory.Small);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(8, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(5, armor.GetWeight());
            Assert.AreEqual(5, armor.MundaneMarketPrice());
            Assert.AreEqual(Cloth.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Padded Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium-size padded armor.")]
        public void DefaultMaterial_Medium()
        {
            // Arrange
            var armor = new PaddedArmor(SizeCategory.Medium);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(8, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(10, armor.GetWeight());
            Assert.AreEqual(5, armor.MundaneMarketPrice());
            Assert.AreEqual(Cloth.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Padded Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large-size padded armor.")]
        public void DefaultMaterial_Large()
        {
            // Arrange
            var armor = new PaddedArmor(SizeCategory.Large);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(8, armor.MaximumDexterityBonus());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual(20, armor.GetWeight());
            Assert.AreEqual(10, armor.MundaneMarketPrice());
            Assert.AreEqual(Cloth.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Padded Armor", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork padded armor.")]
        public void DefaultMaterial_Medium_Masterwork()
        {
            // Arrange
            var armor = new PaddedArmor(SizeCategory.Medium) {
                IsMasterwork = true
            };

            // Assert
            Assert.AreEqual(0, armor.ArmorCheckPenalty());
            Assert.AreEqual(155, armor.MundaneMarketPrice());
            Assert.AreEqual("Masterwork Padded Armor", armor.ToString());
        }
        #endregion
    }
}