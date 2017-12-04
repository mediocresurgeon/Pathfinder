using Core.Domain.Characters;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using Core.Domain.Items.Shields.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class HeavyShieldTests
    {
        #region Steel
        [Test(Description = "Ensures sensible defaults for a small-size steel heavy shield.")]
        public void Small_Steel_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Steel);

            // Assert
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(7.5, shield.GetWeight());
            Assert.AreEqual(Steel.Hardness, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(20, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Heavy Steel Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size steel heavy shield.")]
        public void Medium_Steel_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Steel);

            // Assert
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(15, shield.GetWeight());
            Assert.AreEqual(Steel.Hardness, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(20, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Heavy Steel Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a large-size steel heavy shield.")]
        public void Large_Steel_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Steel);

            // Assert
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(30, shield.GetWeight());
            Assert.AreEqual(Steel.Hardness, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(40, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Heavy Steel Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size masterwork steel heavy shield.")]
        public void Medium_Steel_Masterwork()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Steel) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(170, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Masterwork Heavy Steel Shield", shield.ToString());
        }
        #endregion

        #region Wood
        [Test(Description = "Ensures sensible defaults for a small-size wood heavy shield.")]
        public void Small_Wood_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Wood);

            // Assert
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(5, shield.GetWeight());
            Assert.AreEqual(Wood.Hardness, shield.GetHardness());
            Assert.AreEqual(7, shield.GetHitPoints());
            Assert.AreEqual(7, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Heavy Wooden Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size wood heavy shield.")]
        public void Medium_Wood_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood);

            // Assert
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(10, shield.GetWeight());
            Assert.AreEqual(Wood.Hardness, shield.GetHardness());
            Assert.AreEqual(15, shield.GetHitPoints());
            Assert.AreEqual(7, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Heavy Wooden Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a large-size wood heavy shield.")]
        public void Large_Wood_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Wood);

            // Assert
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(20, shield.GetWeight());
            Assert.AreEqual(Wood.Hardness, shield.GetHardness());
            Assert.AreEqual(30, shield.GetHitPoints());
            Assert.AreEqual(14, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Heavy Wooden Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size masterwork wood heavy shield.")]
        public void Medium_Wood_Masterwork()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(157, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Masterwork Heavy Wooden Shield", shield.ToString());
        }
        #endregion

        #region Darkwood
        [Test(Description = "Ensures sensible defaults for a small-size darkwood heavy shield.")]
        public void Small_Darkwood_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Darkwood);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(2.5, shield.GetWeight());
            Assert.AreEqual(Darkwood.Hardness, shield.GetHardness());
            Assert.AreEqual(7, shield.GetHitPoints());
            Assert.AreEqual(207, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Darkwood Heavy Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size darkwood heavy shield.")]
        public void Medium_Darkwood_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Darkwood);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(5, shield.GetWeight());
            Assert.AreEqual(Darkwood.Hardness, shield.GetHardness());
            Assert.AreEqual(15, shield.GetHitPoints());
            Assert.AreEqual(257, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Darkwood Heavy Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a large-size darkwood heavy shield.")]
        public void Large_Darkwood_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Darkwood);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(10, shield.GetWeight());
            Assert.AreEqual(Darkwood.Hardness, shield.GetHardness());
            Assert.AreEqual(30, shield.GetHitPoints());
            Assert.AreEqual(364, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Darkwood Heavy Shield", shield.ToString());
        }
        #endregion

        #region Dragonhide
        [Test(Description = "Ensures sensible defaults for a small-size dragonhide heavy shield.")]
        public void Small_Dragonhide_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Small, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(5, shield.GetWeight());
            Assert.AreEqual(Dragonhide.Hardness, shield.GetHardness());
            Assert.AreEqual(7, shield.GetHitPoints());
            Assert.AreEqual(314, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Red Dragonhide Heavy Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size dragonhide heavy shield.")]
        public void Medium_Dragonhide_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(10, shield.GetWeight());
            Assert.AreEqual(Dragonhide.Hardness, shield.GetHardness());
            Assert.AreEqual(15, shield.GetHitPoints());
            Assert.AreEqual(314, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Red Dragonhide Heavy Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a large-size dragonhide heavy shield.")]
        public void Large_Dragonhide_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Large, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(20, shield.GetWeight());
            Assert.AreEqual(Dragonhide.Hardness, shield.GetHardness());
            Assert.AreEqual(30, shield.GetHitPoints());
            Assert.AreEqual(328, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Red Dragonhide Heavy Shield", shield.ToString());
        }
        #endregion

        #region Mithral
        [Test(Description = "Ensures sensible defaults for a small-size mithral heavy shield.")]
        public void Small_Mithral_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Mithral);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(3.75, shield.GetWeight());
            Assert.AreEqual(Mithral.Hardness, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(1020, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Mithral Heavy Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size mithral heavy shield.")]
        public void Medium_Mithral_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Mithral);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(7.5, shield.GetWeight());
            Assert.AreEqual(Mithral.Hardness, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(1020, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Mithral Heavy Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a large-size mithral heavy shield.")]
        public void Large_Mithral_Default()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Mithral);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(15, shield.GetWeight());
            Assert.AreEqual(Mithral.Hardness, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(1040, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Mithral Heavy Shield", shield.ToString());
        }
        #endregion
    }
}