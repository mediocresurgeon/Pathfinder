using System;
using Core.Domain.Characters;
using Core.Domain.Characters.DamageReduction;
using Core.Domain.Items.Armor.Paizo.CoreRulebook;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Armor.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class ScaleMailTests
    {
        #region Steel
        [Test(Description = "Ensures sensible defaults for a fresh instance of small steel scale mail.")]
        public void Steel_Small()
        {
            // Arrange
            var armor = new ScaleMail(SizeCategory.Small, ScaleMailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(50, armor.GetMarketPrice());
            Assert.AreEqual(15, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Scale Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium steel scale mail.")]
        public void Steel_Medium()
        {
            // Arrange
            var armor = new ScaleMail(SizeCategory.Medium, ScaleMailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(50, armor.GetMarketPrice());
            Assert.AreEqual(30, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Scale Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large steel scale mail.")]
        public void Steel_Large()
        {
            // Arrange
            var armor = new ScaleMail(SizeCategory.Large, ScaleMailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(100, armor.GetMarketPrice());
            Assert.AreEqual(60, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Scale Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork medium steel scale mail.")]
        public void Steel_Medium_Masterwork()
        {
            // Arrange
            var armor = new ScaleMail(SizeCategory.Medium, ScaleMailMaterial.Steel) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(200, armor.GetMarketPrice());
            Assert.AreEqual("Masterwork Scale Mail", armor.ToString());
        }
        #endregion

        #region Adamantine
        [Test(Description = "Ensures sensible defaults for a fresh instance of small adamantine scale mail.")]
        public void Adamantine_Small_Default()
        {
            // Arrange
            var armor = new ScaleMail(SizeCategory.Small, ScaleMailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_050, armor.GetMarketPrice());
            Assert.AreEqual(15, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Scale Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium adamantine scale mail.")]
        public void Adamantine_Medium_Default()
        {
            // Arrange
            var armor = new ScaleMail(SizeCategory.Medium, ScaleMailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_050, armor.GetMarketPrice());
            Assert.AreEqual(30, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Scale Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large adamantine scale mail.")]
        public void Adamantine_Large_Default()
        {
            // Arrange
            var armor = new ScaleMail(SizeCategory.Large, ScaleMailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.GetArmorBonus());
            Assert.AreEqual(3, armor.ArmorCheckPenalty());
            Assert.AreEqual(3, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_100, armor.GetMarketPrice());
            Assert.AreEqual(60, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Scale Mail", armor.ToString());
        }


        [Test(Description = "Ensures that equipped an adamantine scale mail applies damage reduction to the character.")]
        public void Adamantine_ApplyTo_DamageReduction()
        {
            // Arrange
            var damageReductionTracker = Mock.Of<IDamageReductionTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.DamageReduction)
                         .Returns(damageReductionTracker);
            var armor = new ScaleMail(SizeCategory.Medium, ScaleMailMaterial.Adamantine);

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(damageReductionTracker)
                .Verify(drt => drt.Add(It.Is<Func<byte>>(calc => 2 == calc()),
                                       It.Is<String>(bpb => "—" == bpb)),
                        "Equipping an adamantine scale mail should bestow DR 2/— on the character wearing it.");
        }
        #endregion

        #region Mithral
        [Test(Description = "Ensures sensible defaults for a fresh instance of small mithral scale mail.")]
        public void Mithral_Small()
        {
            // Arrange
            var armor = new ScaleMail(SizeCategory.Small, ScaleMailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.GetArmorBonus());
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(4050, armor.GetMarketPrice());
            Assert.AreEqual(7.5, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Scale Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium mithral scale mail.")]
        public void Mithral_Medium()
        {
            // Arrange
            var armor = new ScaleMail(SizeCategory.Medium, ScaleMailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.GetArmorBonus());
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(4050, armor.GetMarketPrice());
            Assert.AreEqual(15, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Scale Mail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large mithral scale mail.")]
        public void Mithral_Large()
        {
            // Arrange
            var armor = new ScaleMail(SizeCategory.Large, ScaleMailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(5, armor.GetArmorBonus());
            Assert.AreEqual(1, armor.ArmorCheckPenalty());
            Assert.AreEqual(5, armor.MaximumDexterityBonus());
            Assert.AreEqual(4100, armor.GetMarketPrice());
            Assert.AreEqual(30, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Scale Mail", armor.ToString());
        }
        #endregion
    }
}