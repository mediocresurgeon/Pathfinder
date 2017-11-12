using System;
using Core.Domain.Characters;
using Core.Domain.Items.Shields.Paizo.CoreRulebook;
using Core.Domain.Spells;
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
            Assert.AreEqual("Heavy Steel Shield", shield.ToString());
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
            Assert.AreEqual("Masterwork Heavy Steel Shield", shield.ToString());
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
            Assert.AreEqual("Heavy Steel Shield", shield.ToString());
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
            Assert.AreEqual("Masterwork Heavy Steel Shield", shield.ToString());
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
            Assert.AreEqual("Heavy Steel Shield", shield.ToString());
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
            Assert.AreEqual("Masterwork Heavy Steel Shield", shield.ToString());
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
            Assert.AreEqual("Heavy Wooden Shield", shield.ToString());
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
            Assert.AreEqual("Masterwork Heavy Wooden Shield", shield.ToString());
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
            Assert.AreEqual("Heavy Wooden Shield", shield.ToString());
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
            Assert.AreEqual("Masterwork Heavy Wooden Shield", shield.ToString());
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
            Assert.AreEqual("Heavy Wooden Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a large-size masterwork wood heavy shield.")]
        public void Large_Wood_Masterwork()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Wood)
            {
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
            Assert.AreEqual("Masterwork Heavy Wooden Shield", shield.ToString());
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
            Assert.AreEqual("Darkwood Heavy Shield", shield.ToString());
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
            Assert.AreEqual("Darkwood Heavy Shield", shield.ToString());
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
            Assert.AreEqual("Darkwood Heavy Shield", shield.ToString());
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
            Assert.AreEqual("Dragonhide Heavy Shield", shield.ToString());
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
            Assert.AreEqual("Dragonhide Heavy Shield", shield.ToString());
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
            Assert.AreEqual("Dragonhide Heavy Shield", shield.ToString());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Dragonhide shields are always masterwork.");
        }
        #endregion

        #region Mithral, basic
        [Test(Description = "Ensures sensible defaults for a small-size mithral heavy shield.")]
        public void Small_Mithral_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Mithral);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(3.75, shield.Weight);
            Assert.AreEqual(15, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(1020, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Mithral Heavy Shield", shield.ToString());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Mithral shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a medium-size mithral heavy shield.")]
        public void Medium_Mithral_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Mithral);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(7.5, shield.Weight);
            Assert.AreEqual(15, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(1020, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Mithral Heavy Shield", shield.ToString());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Mithral shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a large-size mithral heavy shield.")]
        public void Large_Mithral_Default()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Mithral);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(15, shield.Weight);
            Assert.AreEqual(15, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(1040, shield.GetMarketPrice());
            Assert.AreEqual(0, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Mithral Heavy Shield", shield.ToString());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Mithral shields are always masterwork.");
        }
        #endregion

        #region Enchantment - Enhancement bonus
        [Test(Description = "Ensures that it is not possible to enchant a shield which is not masterwork.")]
        public void EnchantWith_EnhancementBonus_NotMasterwork_Throws()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood);

            // Act
            TestDelegate enchant = () => shield.EnchantWithEnhancementBonus(1);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant, 
                                                     "Only shields of Masterwork quality may be enchanted.");
        }


        [Test(Description = "Ensures that it is not possible to enchant a shield with a +0 enhancement bonus.")]
        public void EnchantWith_EnhancementBonus_0_Throws()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithEnhancementBonus(0);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(enchant,
                                                       "It is not possible to enchant a shield with a +0 enhancement bonus.");
        }


        [Test(Description = "Ensures that it is not possible to enchant a shield with a +6 enhancement bonus.")]
        public void EnchantWith_EnhancementBonus_6_Throws()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithEnhancementBonus(6);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(enchant,
                                                       "It is not possible to enchant a shield with a +6 enhancement bonus.");
        }


        [Test(Description = "Ensures that adding a +1 enchancement bonus has the intended effects.")]
        public void EnchantWith_EnhancementBonus_1()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1);

            // Assert
            Assert.AreEqual(1157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(7, shield.GetHardness());
            Assert.AreEqual(25, shield.GetHitPoints());
            Assert.AreEqual(3, shield.GetShieldBonus());
            Assert.AreEqual(3, shield.CasterLevel.Value);
            Assert.Contains(School.Abjuration, shield.GetSchools());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "It should not be possible to remove Masterwork quality from an enchanted item.");
        }


        [Test(Description = "Ensures that adding a +2 enchancement bonus has the intended effects.")]
        public void EnchantWith_EnhancementBonus_2()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(2);

            // Assert
            Assert.AreEqual(4157, shield.GetMarketPrice());
            Assert.AreEqual("+2 Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(9, shield.GetHardness());
            Assert.AreEqual(35, shield.GetHitPoints());
            Assert.AreEqual(4, shield.GetShieldBonus());
            Assert.AreEqual(6, shield.CasterLevel.Value);
            Assert.Contains(School.Abjuration, shield.GetSchools());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "It should not be possible to remove Masterwork quality from an enchanted item.");
        }


        [Test(Description = "Ensures that adding a +3 enchancement bonus has the intended effects.")]
        public void EnchantWith_EnhancementBonus_3()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(3);

            // Assert
            Assert.AreEqual(9157, shield.GetMarketPrice());
            Assert.AreEqual("+3 Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(11, shield.GetHardness());
            Assert.AreEqual(45, shield.GetHitPoints());
            Assert.AreEqual(5, shield.GetShieldBonus());
            Assert.AreEqual(9, shield.CasterLevel.Value);
            Assert.Contains(School.Abjuration, shield.GetSchools());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "It should not be possible to remove Masterwork quality from an enchanted item.");
        }


        [Test(Description = "Ensures that adding a +4 enchancement bonus has the intended effects.")]
        public void EnchantWith_EnhancementBonus_4()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(4);

            // Assert
            Assert.AreEqual(16157, shield.GetMarketPrice());
            Assert.AreEqual("+4 Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(13, shield.GetHardness());
            Assert.AreEqual(55, shield.GetHitPoints());
            Assert.AreEqual(6, shield.GetShieldBonus());
            Assert.AreEqual(12, shield.CasterLevel.Value);
            Assert.Contains(School.Abjuration, shield.GetSchools());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "It should not be possible to remove Masterwork quality from an enchanted item.");
        }


        [Test(Description = "Ensures that adding a +5 enchancement bonus has the intended effects.")]
        public void EnchantWith_EnhancementBonus_5()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(5);

            // Assert
            Assert.AreEqual(25157, shield.GetMarketPrice());
            Assert.AreEqual("+5 Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(15, shield.GetHardness());
            Assert.AreEqual(65, shield.GetHitPoints());
            Assert.AreEqual(7, shield.GetShieldBonus());
            Assert.AreEqual(15, shield.CasterLevel.Value);
            Assert.Contains(School.Abjuration, shield.GetSchools());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "It should not be possible to remove Masterwork quality from an enchanted item.");
        }
        #endregion
    }
}