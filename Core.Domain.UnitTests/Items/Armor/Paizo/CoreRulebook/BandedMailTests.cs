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
    public class BandedMailTests
    {
        #region Steel
        [Test(Description = "Ensures sensible defaults for a fresh instance of small steel banded mail.")]
        public void Steel_Small()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Small, BandedMailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(250, armor.GetMarketPrice());
            Assert.AreEqual(17.5, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Banded Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium steel banded mail.")]
        public void Steel_Medium()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Medium, BandedMailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(250, armor.GetMarketPrice());
            Assert.AreEqual(35, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Banded Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large steel banded mail.")]
        public void Steel_Large()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Large, BandedMailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(6, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(500, armor.GetMarketPrice());
            Assert.AreEqual(70, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Banded Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork medium steel splint mail.")]
        public void Steel_Medium_Masterwork()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Medium, BandedMailMaterial.Steel) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(400, armor.GetMarketPrice());
            Assert.AreEqual("Masterwork Banded Mail", armor.ToString());
        }
        #endregion

        #region Adamantine
        [Test(Description = "Ensures sensible defaults for a fresh instance of small adamantine banded mail.")]
        public void Adamantine_Small_Default()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Small, BandedMailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(15_250, armor.GetMarketPrice());
            Assert.AreEqual(17.5, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Banded Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium adamantine banded mail.")]
        public void Adamantine_Medium_Default()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Medium, BandedMailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(15_250, armor.GetMarketPrice());
            Assert.AreEqual(35, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Banded Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large adamantine banded mail.")]
        public void Adamantine_Large_Default()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Large, BandedMailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(15_500, armor.GetMarketPrice());
            Assert.AreEqual(70, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Banded Mail", armor.ToString());
        }


        [Test(Description = "Ensures that equipped an adamantine banded mail applies damage reduction to the character.")]
        public void Adamantine_ApplyTo_DamageReduction()
        {
            // Arrange
            var damageReductionTracker = Mock.Of<IDamageReductionTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.DamageReduction)
                         .Returns(damageReductionTracker);
            var armor = new BandedMail(SizeCategory.Medium, BandedMailMaterial.Adamantine);

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(damageReductionTracker)
                .Verify(drt => drt.Add(It.Is<Func<byte>>(calc => 3 == calc()),
                                       It.Is<String>(bpb => "—" == bpb)),
                        "Equipping an adamantine banded mail should bestow DR 3/— on the character wearing it.");
        }
        #endregion

        #region Mithral
        [Test(Description = "Ensures sensible defaults for a fresh instance of small mithral banded mail.")]
        public void Mithral_Small()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Small, BandedMailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(9_250, armor.GetMarketPrice());
            Assert.AreEqual(8.75, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Banded Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium mithral banded mail.")]
        public void Mithral_Medium()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Medium, BandedMailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(9_250, armor.GetMarketPrice());
            Assert.AreEqual(17.5, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Banded Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large mithral banded mail.")]
        public void Mithral_Large()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Large, BandedMailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(7, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(9_500, armor.GetMarketPrice());
            Assert.AreEqual(35, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Banded Mail", armor.ToString());
        }
        #endregion

        #region Dragonhide
        [Test(Description = "Ensures sensible defaults for a fresh instance of small-size dragonhide banded mail.")]
        public void Dragonhide_Small()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Small, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(17.5, armor.GetWeight());
            Assert.AreEqual(800, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Banded Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium-size dragonhide banded mail.")]
        public void Dragonhide_Medium()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Medium, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(35, armor.GetWeight());
            Assert.AreEqual(800, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Banded Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large-size dragonhide banded mail.")]
        public void Dragonhide_Large()
        {
            // Arrange
            var armor = new BandedMail(SizeCategory.Large, DragonhideColor.Red);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(1, armor.MaximumDexterityBonus());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual(70, armor.GetWeight());
            Assert.AreEqual(1300, armor.MundaneMarketPrice());
            Assert.AreEqual(Dragonhide.Hardness, armor.Hardness.MaterialHardness);
            Assert.AreEqual("Red Dragonhide Banded Mail", armor.ToString());
        }
        #endregion
    }
}