using System;
using Core.Domain.Characters;
using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
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
            HeavyShield shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Steel)
            {
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
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Steel)
            {
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
            HeavyShield shield = new HeavyShield(SizeCategory.Large, HeavyShieldMaterial.Steel)
            {
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
            HeavyShield shield = new HeavyShield(SizeCategory.Small, HeavyShieldMaterial.Wood)
            {
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
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
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

        #region Dragonhide - Energy Resistance 10
        [Test(Description = "Ensures that Dragonhide properly reduces the enchantment cost of Energy Resistance 10 by 25%.")]
        public void Dragonhide_AcidResistance10_ReducedCost()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Dragonhide);
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithAcidResistance(EnergyResistanceMagnitude.Regular);

            // Act
            var price = shield.GetMarketPrice();

            // Assert
            Assert.AreEqual(14_814, price, "[(7 heavy shield + 150 masterwork) * (2 dragonhide)] + (1000 enhancement bonus) + [(18000 energy resistance) * (75% dragonhide discount)]");
        }
        #endregion

        #region Dragonhide - Energy Resistance 20
        [Test(Description = "Ensures that Dragonhide properly reduces the enchantment cost of Energy Resistance 20 by 25%.")]
        public void Dragonhide_ColdResistance20_ReducedCost()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Dragonhide);
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithColdResistance(EnergyResistanceMagnitude.Improved);

            // Act
            var price = shield.GetMarketPrice();

            // Assert
            Assert.AreEqual(32_814, price, "[(7 heavy shield + 150 masterwork) * (2 dragonhide)] + (1000 enhancement bonus) + [(42000 energy resistance) * (75% dragonhide discount)]");
        }
        #endregion

        #region Dragonhide - Energy Resistance 30
        [Test(Description = "Ensures that Dragonhide properly reduces the enchantment cost of Energy Resistance 30 by 25%.")]
        public void Dragonhide_FireResistance30_ReducedCost()
        {
            // Arrange
            HeavyShield shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Dragonhide);
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithFireResistance(EnergyResistanceMagnitude.Greater);

            // Act
            var price = shield.GetMarketPrice();

            // Assert
            Assert.AreEqual(50_814, price, "[(7 heavy shield + 150 masterwork) * (2 dragonhide)] + (1000 enhancement bonus) + [(66000 energy resistance) * (75% dragonhide discount)]");
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
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
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
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
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
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
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
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
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
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
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
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
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
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
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

        #region Enchantment - Acid Resistance
        [Test(Description = "Ensures that Acid Resistance cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_AcidResistance_Regular_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithAcidResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Acid Resistance until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Acid Resistance 10 has the correct configuration.")]
        public void EnchantWith_AcidResistance_Regular_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithAcidResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.AreEqual(19157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Acid Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(3, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }


        [Test(Description = "Ensures that a shield enchanted with Acid Resistance 20 has the correct configuration.")]
        public void EnchantWith_AcidResistance_Improved_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithAcidResistance(EnergyResistanceMagnitude.Improved);

            // Assert
            Assert.AreEqual(43157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Improved Acid Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(7, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }


        [Test(Description = "Ensures that a shield enchanted with Acid Resistance 30 has the correct configuration.")]
        public void EnchantWith_AcidResistance_Greater_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithAcidResistance(EnergyResistanceMagnitude.Greater);

            // Assert
            Assert.AreEqual(67157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Greater Acid Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(11, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Animated
        [Test(Description = "Ensures that Animated cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_Animated_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithAnimated();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Animated until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Animated has the correct configuration.")]
        public void EnchantWith_Animated_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithAnimated();

            // Assert
            Assert.AreEqual(9157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Animated Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(12, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Transmutation, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Arrow Catching
        [Test(Description = "Ensures that Arrow Catching cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_ArrowCatching_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithArrowCatching();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Arrow Catching until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Arrow Catching has the correct configuration.")]
        public void EnchantWith_ArrowCatching_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithArrowCatching();

            // Assert
            Assert.AreEqual(4157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Arrow Catching Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(8, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Arrow Deflection
        [Test(Description = "Ensures that Arrow Deflection cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_ArrowDeflection_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithArrowDeflection();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Arrow Deflection until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Arrow Deflection has the correct configuration.")]
        public void EnchantWith_ArrowDeflection_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithArrowDeflection();

            // Assert
            Assert.AreEqual(9157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Arrow Deflection Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(5, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Blinding
        [Test(Description = "Ensures that Blinding cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_Blinding_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithBlinding();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Blinding until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Blinding has the correct configuration.")]
        public void EnchantWith_Blinding_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithBlinding();

            // Assert
            Assert.AreEqual(4157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Blinding Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(7, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Evocation, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Cold Resistance
        [Test(Description = "Ensures that Cold Resistance cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_ColdResistance_Regular_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithColdResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Cold Resistance until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Cold Resistance 10 has the correct configuration.")]
        public void EnchantWith_ColdResistance_Regular_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithColdResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.AreEqual(19157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Cold Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(3, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }


        [Test(Description = "Ensures that a shield enchanted with Cold Resistance 20 has the correct configuration.")]
        public void EnchantWith_ColdResistance_Improved_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithColdResistance(EnergyResistanceMagnitude.Improved);

            // Assert
            Assert.AreEqual(43157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Improved Cold Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(7, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }


        [Test(Description = "Ensures that a shield enchanted with Cold Resistance 30 has the correct configuration.")]
        public void EnchantWith_ColdResistance_Greater_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithColdResistance(EnergyResistanceMagnitude.Greater);

            // Assert
            Assert.AreEqual(67157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Greater Cold Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(11, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Electricity Resistance
        [Test(Description = "Ensures that Electricity Resistance cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_ElectricityResistance_Regular_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithElectricityResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Electricity Resistance until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Electricity Resistance 10 has the correct configuration.")]
        public void EnchantWith_ElectricityResistance_Regular_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithElectricityResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.AreEqual(19157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Electricity Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(3, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }


        [Test(Description = "Ensures that a shield enchanted with Electricity Resistance 20 has the correct configuration.")]
        public void EnchantWith_ElectricityResistance_Improved_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithElectricityResistance(EnergyResistanceMagnitude.Improved);

            // Assert
            Assert.AreEqual(43157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Improved Electricity Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(7, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }


        [Test(Description = "Ensures that a shield enchanted with Electricity Resistance 30 has the correct configuration.")]
        public void EnchantWith_ElectricityResistance_Greater_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithElectricityResistance(EnergyResistanceMagnitude.Greater);

            // Assert
            Assert.AreEqual(67157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Greater Electricity Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(11, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Fire Resistance
        [Test(Description = "Ensures that Fire Resistance cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_FireResistance_Regular_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithFireResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Fire Resistance until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Fire Resistance 10 has the correct configuration.")]
        public void EnchantWith_FireResistance_Regular_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithFireResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.AreEqual(19157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Fire Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(3, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }


        [Test(Description = "Ensures that a shield enchanted with Fire Resistance 20 has the correct configuration.")]
        public void EnchantWith_FireResistance_Improved_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithFireResistance(EnergyResistanceMagnitude.Improved);

            // Assert
            Assert.AreEqual(43157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Improved Fire Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(7, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }


        [Test(Description = "Ensures that a shield enchanted with Fire Resistance 30 has the correct configuration.")]
        public void EnchantWith_FireResistance_Greater_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithFireResistance(EnergyResistanceMagnitude.Greater);

            // Assert
            Assert.AreEqual(67157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Greater Fire Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(11, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Light Fortification
        [Test(Description = "Ensures that Light Fortification cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_LightFortification_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithFortification(FortificationType.Light);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Light Fortification until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that Light Fortification cannot be added to a shield which has a previous Fortification enchantment.")]
        public void EnchantWith_LightFortification_AlreadyFortified()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithEnhancementBonus(1)
                                               .EnchantWithFortification(FortificationType.Medium)
                                               .EnchantWithFortification(FortificationType.Light);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Light Fortification if Medium Fortification has already been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Light Fortification has the correct configuration.")]
        public void EnchantWith_LightFortification_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithFortification(FortificationType.Light);

            // Assert
            Assert.AreEqual(4157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Light Fortification Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(13, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Medium Fortification
        [Test(Description = "Ensures that Medium Fortification cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_MediumFortification_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithFortification(FortificationType.Medium);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Medium Fortification until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that Medium Fortification cannot be added to a shield which has a previous Fortification enchantment.")]
        public void EnchantWith_MediumFortification_AlreadyFortified()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithEnhancementBonus(1)
                                               .EnchantWithFortification(FortificationType.Heavy)
                                               .EnchantWithFortification(FortificationType.Medium);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Medium Fortification if Heavy Fortification has already been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Medium Fortification has the correct configuration.")]
        public void EnchantWith_MediumFortification_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithFortification(FortificationType.Medium);

            // Assert
            Assert.AreEqual(16157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Medium Fortification Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(13, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Heavy Fortification
        [Test(Description = "Ensures that Heavy Fortification cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_HeavyFortification_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithFortification(FortificationType.Heavy);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Heavy Fortification until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that Heavy Fortification cannot be added to a shield which has a previous Fortification enchantment.")]
        public void EnchantWith_HeavyFortification_AlreadyFortified()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithEnhancementBonus(1)
                                               .EnchantWithFortification(FortificationType.Light)
                                               .EnchantWithFortification(FortificationType.Heavy);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Heavy Fortification if Light Fortification has already been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Heavy Fortification has the correct configuration.")]
        public void EnchantWith_HeavyFortification_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithFortification(FortificationType.Heavy);

            // Assert
            Assert.AreEqual(36157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Heavy Fortification Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(13, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Ghost Touch
        [Test(Description = "Ensures that Ghost Touch cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_GhostTouch_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithGhostTouch();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with GhostTouch until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Ghost Touch has the correct configuration.")]
        public void EnchantWith_GhostTouch_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithGhostTouch();

            // Assert
            Assert.AreEqual(16157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Ghost Touch Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(15, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Transmutation, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Reflecting
        [Test(Description = "Ensures that Reflecting cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_Reflecting_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithReflecting();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Reflecting until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Reflecting has the correct configuration.")]
        public void EnchantWith_Reflecting_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithReflecting();

            // Assert
            Assert.AreEqual(36157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Reflecting Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(14, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Sonic Resistance
        [Test(Description = "Ensures that Sonic Resistance cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_SonicResistance_Regular_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithSonicResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Sonic Resistance until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Sonic Resistance 10 has the correct configuration.")]
        public void EnchantWith_SonicResistance_Regular_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithSonicResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.AreEqual(19157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Sonic Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(3, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }


        [Test(Description = "Ensures that a shield enchanted with Sonic Resistance 20 has the correct configuration.")]
        public void EnchantWith_SonicResistance_Improved_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithSonicResistance(EnergyResistanceMagnitude.Improved);

            // Assert
            Assert.AreEqual(43157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Improved Sonic Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(7, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }


        [Test(Description = "Ensures that a shield enchanted with Sonic Resistance 30 has the correct configuration.")]
        public void EnchantWith_SonicResistance_Greater_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithSonicResistance(EnergyResistanceMagnitude.Greater);

            // Assert
            Assert.AreEqual(67157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Greater Sonic Resistance Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(11, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Spell Resistance 13
        [Test(Description = "Ensures that Spell Resistance (13) cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_SpellResistance13_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithSpellResistance(SpellResistanceMagnitude.SR13);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Spell Resistance until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Spell Resistance (13) has the correct configuration.")]
        public void EnchantWith_SpellResistance13_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithSpellResistance(SpellResistanceMagnitude.SR13);

            // Assert
            Assert.AreEqual(9157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Spell Resistance (13) Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(15, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Spell Resistance 15
        [Test(Description = "Ensures that Spell Resistance (15) cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_SpellResistance15_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithSpellResistance(SpellResistanceMagnitude.SR15);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Spell Resistance until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Spell Resistance (13) has the correct configuration.")]
        public void EnchantWith_SpellResistance15_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithSpellResistance(SpellResistanceMagnitude.SR15);

            // Assert
            Assert.AreEqual(16157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Spell Resistance (15) Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(15, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Spell Resistance 17
        [Test(Description = "Ensures that Spell Resistance (17) cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_SpellResistance17_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithSpellResistance(SpellResistanceMagnitude.SR17);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Spell Resistance until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Spell Resistance (17) has the correct configuration.")]
        public void EnchantWith_SpellResistance17_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithSpellResistance(SpellResistanceMagnitude.SR17);

            // Assert
            Assert.AreEqual(25157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Spell Resistance (17) Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(15, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Spell Resistance 19
        [Test(Description = "Ensures that Spell Resistance (19) cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_SpellResistance19_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithSpellResistance(SpellResistanceMagnitude.SR19);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Spell Resistance until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Spell Resistance (19) has the correct configuration.")]
        public void EnchantWith_SpellResistance19_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithSpellResistance(SpellResistanceMagnitude.SR19);

            // Assert
            Assert.AreEqual(36157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Spell Resistance (19) Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(15, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Abjuration, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Undead Controlling
        [Test(Description = "Ensures that Reflecting cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_UndeadControlling_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithUndeadControlling();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Undead Controlling until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Undead Controlling has the correct configuration.")]
        public void EnchantWith_UndeadControlling_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithUndeadControlling();

            // Assert
            Assert.AreEqual(50_157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Undead Controlling Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(13, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Necromancy, shield.GetSchools());
        }
        #endregion

        #region Enchantment - Wild
        [Test(Description = "Ensures that Ghost Touch cannot be added to a shield with no previous enchantments.")]
        public void EnchantWith_Wild_NoEnhancementBonus()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            TestDelegate enchant = () => shield.EnchantWithWild();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Shields cannot be enchanted with Wild until an enhancement bonus has been applied.");
        }


        [Test(Description = "Ensures that a shield enchanted with Wild has the correct configuration.")]
        public void EnchantWith_Wild_HappyPath()
        {
            // Arrange
            var shield = new HeavyShield(SizeCategory.Medium, HeavyShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Act
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithWild();

            // Assert
            Assert.AreEqual(16157, shield.GetMarketPrice());
            Assert.AreEqual("+1 Wild Heavy Wooden Shield", shield.ToString());
            Assert.AreEqual(9, shield.CasterLevel.Value);
            Assert.AreEqual(1, shield.GetSchools().Length);
            Assert.Contains(School.Transmutation, shield.GetSchools());
        }
        #endregion
    }
}