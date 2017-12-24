using System;
using Core.Domain.Characters;
using Core.Domain.Characters.DamageReduction;
using Core.Domain.Items.Armor.Paizo.CoreRulebook;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Armor.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class SplintMailTests
    {
        #region Steel
        [Test(Description = "Ensures sensible defaults for a fresh instance of small steel splint mail.")]
        public void Steel_Small()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Small, SplintMailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(7, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(200, armor.GetMarketPrice());
            Assert.AreEqual(22.5, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Splint Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium steel splint mail.")]
        public void Steel_Medium()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Medium, SplintMailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(7, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(200, armor.GetMarketPrice());
            Assert.AreEqual(45, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Splint Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large steel splint mail.")]
        public void Steel_Large()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Large, SplintMailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(7, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(400, armor.GetMarketPrice());
            Assert.AreEqual(90, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Splint Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork medium steel splint mail.")]
        public void Steel_Medium_Masterwork()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Medium, SplintMailMaterial.Steel) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(350, armor.GetMarketPrice());
            Assert.AreEqual("Masterwork Splint Mail", armor.ToString());
        }
        #endregion

        #region Adamantine
        [Test(Description = "Ensures sensible defaults for a fresh instance of small adamantine splint mail.")]
        public void Adamantine_Small_Default()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Small, SplintMailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(15_200, armor.GetMarketPrice());
            Assert.AreEqual(22.5, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Splint Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium adamantine splint mail.")]
        public void Adamantine_Medium_Default()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Medium, SplintMailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(15_200, armor.GetMarketPrice());
            Assert.AreEqual(45, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Splint Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large adamantine splint mail.")]
        public void Adamantine_Large_Default()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Large, SplintMailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(15_400, armor.GetMarketPrice());
            Assert.AreEqual(90, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Splint Mail", armor.ToString());
        }


        [Test(Description = "Ensures that equipped an adamantine splint mail applies damage reduction to the character.")]
        public void Adamantine_ApplyTo_DamageReduction()
        {
            // Arrange
            var damageReductionTracker = Mock.Of<IDamageReductionTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.DamageReduction)
                         .Returns(damageReductionTracker);
            var armor = new SplintMail(SizeCategory.Medium, SplintMailMaterial.Adamantine);

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(damageReductionTracker)
                .Verify(drt => drt.Add(It.Is<Func<byte>>(calc => 3 == calc()),
                                       It.Is<String>(bpb => "—" == bpb)),
                        "Equipping an adamantine splint mail should bestow DR 3/— on the character wearing it.");
        }
        #endregion

        #region Mithral
        [Test(Description = "Ensures sensible defaults for a fresh instance of small mithral splint mail.")]
        public void Mithral_Small()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Small, SplintMailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(9_200, armor.GetMarketPrice());
            Assert.AreEqual(11.25, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Splint Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium mithral splint mail.")]
        public void Mithral_Medium()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Medium, SplintMailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(9_200, armor.GetMarketPrice());
            Assert.AreEqual(22.5, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Splint Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large mithral splint mail.")]
        public void Mithral_Large()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Large, SplintMailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(9_400, armor.GetMarketPrice());
            Assert.AreEqual(45, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Splint Mail", armor.ToString());
        }
        #endregion

        #region Dragonhide
        [Test(Description = "Ensures sensible defaults for a fresh instance of small-size dragonhide splint mail.")]
        public void Dragonhide_Small()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Small, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(22.5, armor.GetWeight());
            Assert.AreEqual(700, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Splint Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium-size dragonhide splint mail.")]
        public void Dragonhide_Medium()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Medium, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(45, armor.GetWeight());
            Assert.AreEqual(700, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Splint Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large-size dragonhide splint mail.")]
        public void Dragonhide_Large()
        {
            // Arrange
            var armor = new SplintMail(SizeCategory.Large, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(0, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(90, armor.GetWeight());
            Assert.AreEqual(1100, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Splint Mail", armor.ToString());
        }
        #endregion
    }
}