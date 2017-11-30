using System;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Items.Shields.Paizo.CoreRulebook;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class TowerShieldTests
    {
        #region Wood, basic
        [Test(Description = "Ensures sensible defaults for a small-size tower shield.")]
        public void Small_Wood_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Small, TowerShieldMaterial.Wood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(22.5, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(30, shield.GetMarketPrice());
            Assert.AreEqual(10, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a small-size masterwork tower shield.")]
        public void Small_Wood_Masterwork()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Small, TowerShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(22.5, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(180, shield.GetMarketPrice());
            Assert.AreEqual(9, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Masterwork Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size wood heavy shield.")]
        public void Medium_Wood_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Wood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(45, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(30, shield.GetMarketPrice());
            Assert.AreEqual(10, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size masterwork wood heavy shield.")]
        public void Medium_Wood_Masterwork()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(45, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(180, shield.GetMarketPrice());
            Assert.AreEqual(9, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Masterwork Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a large-size wood heavy shield.")]
        public void Large_Wood_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Large, TowerShieldMaterial.Wood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(90, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(60, shield.GetMarketPrice());
            Assert.AreEqual(10, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a large-size masterwork wood heavy shield.")]
        public void Large_Wood_Masterwork()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Large, TowerShieldMaterial.Wood)
            {
                IsMasterwork = true
            };

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(90, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(210, shield.GetMarketPrice());
            Assert.AreEqual(9, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Masterwork Tower Shield", shield.ToString());
        }
        #endregion

        #region Darkwood, basic
        [Test(Description = "Ensures sensible defaults for a small-size darkwood heavy shield.")]
        public void Small_Darkwood_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Small, TowerShieldMaterial.Darkwood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(11.25, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(405, shield.GetMarketPrice());
            Assert.AreEqual(8, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Darkwood Tower Shield", shield.ToString());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Darkwood shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a medium-size darkwood heavy shield.")]
        public void Medium_Darkwood_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Darkwood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(22.5, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(630, shield.GetMarketPrice());
            Assert.AreEqual(8, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Darkwood Tower Shield", shield.ToString());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Darkwood shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a large-size darkwood tower shield.")]
        public void Large_Darkwood_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Large, TowerShieldMaterial.Darkwood);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(45, shield.Weight);
            Assert.AreEqual(5, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(1110, shield.GetMarketPrice());
            Assert.AreEqual(8, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Darkwood Tower Shield", shield.ToString());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Darkwood shields are always masterwork.");
        }
        #endregion

        #region Dragonhide, basic
        [Test(Description = "Ensures sensible defaults for a small-size dragonhide tower shield.")]
        public void Small_Dragonhide_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Small, TowerShieldMaterial.Dragonhide);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(22.5, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(360, shield.GetMarketPrice());
            Assert.AreEqual(9, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Dragonhide Tower Shield", shield.ToString());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Dragonhide shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a medium-size dragonhide tower shield.")]
        public void Medium_Dragonhide_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Dragonhide);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(45, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(360, shield.GetMarketPrice());
            Assert.AreEqual(9, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Dragonhide Tower Shield", shield.ToString());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Dragonhide shields are always masterwork.");
        }


        [Test(Description = "Ensures sensible defaults for a large-size dragonhide tower shield.")]
        public void Large_Dragonhide_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Large, TowerShieldMaterial.Dragonhide);

            // Assert
            Assert.IsNull(shield.CasterLevel);
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(90, shield.Weight);
            Assert.AreEqual(10, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(420, shield.GetMarketPrice());
            Assert.AreEqual(9, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Dragonhide Tower Shield", shield.ToString());
            Assert.Throws<InvalidOperationException>(() => shield.IsMasterwork = false,
                                                     "Dragonhide shields are always masterwork.");
        }
        #endregion

        #region Dragonhide - Energy Resistance 10
        [Test(Description = "Ensures that Dragonhide properly reduces the enchantment cost of Energy Resistance 10 by 25%.")]
        public void Dragonhide_AcidResistance10_ReducedCost()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Dragonhide);
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithAcidResistance(EnergyResistanceMagnitude.Regular);

            // Act
            var price = shield.GetMarketPrice();

            // Assert
            Assert.AreEqual(14_860, price, "[(30 tower shield + 150 masterwork) * (2 dragonhide)] + (1000 enhancement bonus) + [(18000 energy resistance) * (75% dragonhide discount)]");
        }
        #endregion

        #region Dragonhide - Energy Resistance 20
        [Test(Description = "Ensures that Dragonhide properly reduces the enchantment cost of Energy Resistance 20 by 25%.")]
        public void Dragonhide_ColdResistance20_ReducedCost()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Dragonhide);
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithColdResistance(EnergyResistanceMagnitude.Improved);

            // Act
            var price = shield.GetMarketPrice();

            // Assert
            Assert.AreEqual(32_860, price, "[(30 tower shield + 150 masterwork) * (2 dragonhide)] + (1000 enhancement bonus) + [(42000 energy resistance) * (75% dragonhide discount)]");
        }
        #endregion

        #region Dragonhide - Energy Resistance 30
        [Test(Description = "Ensures that Dragonhide properly reduces the enchantment cost of Energy Resistance 30 by 25%.")]
        public void Dragonhide_FireResistance30_ReducedCost()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Dragonhide);
            shield.EnchantWithEnhancementBonus(1)
                  .EnchantWithFireResistance(EnergyResistanceMagnitude.Greater);

            // Act
            var price = shield.GetMarketPrice();

            // Assert
            Assert.AreEqual(50_860, price, "[(30 tower shield + 150 masterwork) * (2 dragonhide)] + (1000 enhancement bonus) + [(66000 energy resistance) * (75% dragonhide discount)]");
        }
        #endregion

        #region ApplyTo
        [Test(Description = "Ensures that tower shields apply a max dex bonus to characters.")]
        public void ApplyTo()
        {
            // Arrange
            var maxDexTracker = Mock.Of<IModifierTracker>();
            var character = new Mock<ICharacter>();
            character.Setup(c => c.ArmorClass.MaxKeyAbilityScore)
                     .Returns(maxDexTracker);

            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Wood);

            // Act
            shield.ApplyTo(character.Object);

            // Assert
            Mock.Get(maxDexTracker)
                .Verify(mdt => mdt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Tower shields restrict a character's maximum dexterity bonus to AC to +2.");
        }
        #endregion
    }
}