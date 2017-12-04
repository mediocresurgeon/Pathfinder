using System;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
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
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(22.5, shield.GetWeight());
            Assert.AreEqual(Wood.Hardness, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(30, shield.GetMarketPrice());
            Assert.AreEqual(10, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size wood heavy shield.")]
        public void Medium_Wood_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Wood);

            // Assert
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(45, shield.GetWeight());
            Assert.AreEqual(Wood.Hardness, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(30, shield.GetMarketPrice());
            Assert.AreEqual(10, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a large-size wood heavy shield.")]
        public void Large_Wood_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Large, TowerShieldMaterial.Wood);

            // Assert
            Assert.IsFalse(shield.IsMasterwork);
            Assert.AreEqual(90, shield.GetWeight());
            Assert.AreEqual(Wood.Hardness, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(60, shield.GetMarketPrice());
            Assert.AreEqual(10, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size masterwork wood heavy shield.")]
        public void Medium_Wood_Masterwork()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Wood) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(45, shield.GetWeight());
            Assert.AreEqual(Wood.Hardness, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(180, shield.GetMarketPrice());
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
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(11.25, shield.GetWeight());
            Assert.AreEqual(Darkwood.Hardness, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(405, shield.GetMarketPrice());
            Assert.AreEqual(8, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Darkwood Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size darkwood heavy shield.")]
        public void Medium_Darkwood_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Darkwood);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(22.5, shield.GetWeight());
            Assert.AreEqual(Darkwood.Hardness, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(630, shield.GetMarketPrice());
            Assert.AreEqual(8, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Darkwood Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a large-size darkwood tower shield.")]
        public void Large_Darkwood_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Large, TowerShieldMaterial.Darkwood);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(45, shield.GetWeight());
            Assert.AreEqual(Darkwood.Hardness, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(1110, shield.GetMarketPrice());
            Assert.AreEqual(8, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Darkwood Tower Shield", shield.ToString());
        }
        #endregion

        #region Dragonhide
        [Test(Description = "Ensures sensible defaults for a small-size dragonhide tower shield.")]
        public void Small_Dragonhide_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Small, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(22.5, shield.GetWeight());
            Assert.AreEqual(Dragonhide.Hardness, shield.GetHardness());
            Assert.AreEqual(10, shield.GetHitPoints());
            Assert.AreEqual(360, shield.GetMarketPrice());
            Assert.AreEqual(9, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Red Dragonhide Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a medium-size dragonhide tower shield.")]
        public void Medium_Dragonhide_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Medium, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(45, shield.GetWeight());
            Assert.AreEqual(Dragonhide.Hardness, shield.GetHardness());
            Assert.AreEqual(20, shield.GetHitPoints());
            Assert.AreEqual(360, shield.GetMarketPrice());
            Assert.AreEqual(9, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Red Dragonhide Tower Shield", shield.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a large-size dragonhide tower shield.")]
        public void Large_Dragonhide_Default()
        {
            // Arrange
            var shield = new TowerShield(SizeCategory.Large, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.IsFalse(shield.MasterworkIsToggleable);
            Assert.AreEqual(90, shield.GetWeight());
            Assert.AreEqual(Dragonhide.Hardness, shield.GetHardness());
            Assert.AreEqual(40, shield.GetHitPoints());
            Assert.AreEqual(420, shield.GetMarketPrice());
            Assert.AreEqual(9, shield.GetArmorCheckPenalty());
            Assert.AreEqual("Red Dragonhide Tower Shield", shield.ToString());
        }
        #endregion

        #region ApplyTo
        [Test(Description = "Ensures that tower shields apply a max dex bonus to characters.")]
        public void ApplyTo()
        {
            // Arrange
            var meleeAttackPenaltyTracker = Mock.Of<IModifierTracker>();
            var maxDexTracker = Mock.Of<IModifierTracker>();
            var character = new Mock<ICharacter>();
            character.Setup(c => c.AttackBonuses.GenericMeleeAttackBonus.Penalties)
                     .Returns(meleeAttackPenaltyTracker);
            character.Setup(c => c.ArmorClass.MaxKeyAbilityScore)
                     .Returns(maxDexTracker);

            var shield = new TowerShield(SizeCategory.Medium, TowerShieldMaterial.Wood);

            // Act
            shield.ApplyTo(character.Object);

            // Assert
            Mock.Get(meleeAttackPenaltyTracker)
                .Verify(mdt => mdt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Tower shields give a -2 penalty to melee attack rolls.");
            Mock.Get(maxDexTracker)
                .Verify(mdt => mdt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Tower shields restrict a character's maximum dexterity bonus to AC to +2.");
        }
        #endregion
    }
}