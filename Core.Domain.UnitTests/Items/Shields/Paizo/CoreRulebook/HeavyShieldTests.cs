using System;
using Core.Domain.Characters;
using Core.Domain.Items.Shields.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Paizo.CoreRulebook
{
    [TestFixture]
    public class HeavyShieldTests
    {
        #region Steel, basic
        [Test(Description = "Ensures sensible defaults for a small-size steel heavy shield.")]
        public void Small_Steel_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Steel);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(7.5, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(20, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
        }


        [Test(Description = "Ensures sensible defaults for a small-size masterwork steel heavy shield.")]
        public void Small_Steel_Masterwork()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Steel) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(7.5, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(170, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size steel heavy shield.")]
        public void Medium_Steel_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Steel);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(15, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(20, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size masterwork steel heavy shield.")]
        public void Medium_Steel_Masterwork()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Steel) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(15, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(170, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
        }


        [Test(Description = "Ensures sensible defaults for a large-size steel heavy shield.")]
        public void Large_Steel_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Steel);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(30, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(40, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
        }


        [Test(Description = "Ensures sensible defaults for a large-size masterwork steel heavy shield.")]
        public void Large_Steel_Masterwork()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Steel) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(30, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(190, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
        }
        #endregion

        #region Wood, basic
        [Test(Description = "Ensures sensible defaults for a small-size wood heavy shield.")]
        public void Small_Wood_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Wood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(5, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(7, shield.GetHitPoints());
            Assert.AreEqual(7, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
        }


        [Test(Description = "Ensures sensible defaults for a small-size masterwork wood heavy shield.")]
        public void Small_Wood_Masterwork()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(5, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(7, shield.GetHitPoints());
            Assert.AreEqual(157, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size wood heavy shield.")]
        public void Medium_Wood_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(10, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(15, shield.GetHitPoints());
            Assert.AreEqual(7, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size masterwork wood heavy shield.")]
        public void Medium_Wood_Masterwork()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(10, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(15, shield.GetHitPoints());
            Assert.AreEqual(157, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
        }


        [Test(Description = "Ensures sensible defaults for a large-size wood heavy shield.")]
        public void Large_Wood_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Wood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(20, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(30, shield.GetHitPoints());
            Assert.AreEqual(14, shield.GetMarketPrice());
            Assert.AreEqual(2, shield.GetArmorCheckPenalty());
        }


        [Test(Description = "Ensures sensible defaults for a large-size masterwork wood heavy shield.")]
        public void Large_Wood_Masterwork()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(20, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(30, shield.GetHitPoints());
            Assert.AreEqual(164, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
        }
        #endregion

        #region Darkwood, basic
        [Test(Description = "Ensures sensible defaults for a small-size darkwood heavy shield.")]
        public void Small_Darkwood_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Darkwood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(2.5, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(7, shield.GetHitPoints());
            Assert.AreEqual(207, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Darkwood shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a medium-size darkwood heavy shield.")]
        public void Medium_Darkwood_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Darkwood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(5, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(15, shield.GetHitPoints());
            Assert.AreEqual(257, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Darkwood shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a large-size darkwood heavy shield.")]
        public void Large_Darkwood_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Darkwood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(10, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(30, shield.GetHitPoints());
            Assert.AreEqual(364, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Darkwood shields are always masterwork.");
        }
        #endregion

        #region Dragonhide, basic
        [Test(Description = "Ensures sensible defaults for a small-size dragonhide heavy shield.")]
        public void Small_Dragonhide_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Dragonhide);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(5, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(7, shield.GetHitPoints());
            Assert.AreEqual(314, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Dragonhide shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a medium-size dragonhide heavy shield.")]
        public void Medium_Dragonhide_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Dragonhide);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(10, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(15, shield.GetHitPoints());
            Assert.AreEqual(314, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Dragonhide shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a large-size dragonhide heavy shield.")]
        public void Large_Dragonhide_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Dragonhide);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(20, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(30, shield.GetHitPoints());
            Assert.AreEqual(328, shield.GetMarketPrice());
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Dragonhide shields are always masterwork.");
        }
        #endregion
    
        #region Mithral, basic
        [Test(Description = "Ensures sensible defaults for a small-size mithril heavy shield.")]
        public void Small_Mithril_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Mithril);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(3.75, shield.Weight);
            Assert.AreEqual(15, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(1020, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Mithral shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a medium-size mithril heavy shield.")]
        public void Medium_Mithril_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Mithril);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(7.5, shield.Weight);
            Assert.AreEqual(15, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(1020, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Mithral shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a large-size mithril heavy shield.")]
        public void Large_Mithril_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Mithril);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(15, shield.Weight);
            Assert.AreEqual(15, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(1040, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Mithral shields are always masterwork.");
        }
        #endregion
    }
}