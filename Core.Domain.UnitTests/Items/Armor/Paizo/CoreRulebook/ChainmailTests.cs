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
    public class ChainmailTests
    {
        #region Steel
        [Test(Description = "Ensures sensible defaults for a fresh instance of small steel chainmail.")]
        public void Steel_Small()
        {
            // Arrange
            var armor = new Chainmail(SizeCategory.Small, ChainmailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(150, armor.GetMarketPrice());
            Assert.AreEqual(20, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Chainmail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium steel chainmail.")]
        public void Steel_Medium()
        {
            // Arrange
            var armor = new Chainmail(SizeCategory.Medium, ChainmailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(150, armor.GetMarketPrice());
            Assert.AreEqual(40, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Chainmail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large steel chainmail.")]
        public void Steel_Large()
        {
            // Arrange
            var armor = new Chainmail(SizeCategory.Large, ChainmailMaterial.Steel);

            // Assert
            Assert.IsFalse(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(5, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(300, armor.GetMarketPrice());
            Assert.AreEqual(80, armor.GetWeight());
            Assert.AreEqual(.25, armor.SpeedPenalty);
            Assert.AreEqual("Chainmail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of masterwork medium steel chainmail.")]
        public void Steel_Medium_Masterwork()
        {
            // Arrange
            var armor = new Chainmail(SizeCategory.Medium, ChainmailMaterial.Steel) {
                IsMasterwork = true
            };

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(300, armor.GetMarketPrice());
            Assert.AreEqual("Masterwork Chainmail", armor.ToString());
        }
        #endregion

        #region Adamantine
        [Test(Description = "Ensures sensible defaults for a fresh instance of small adamantine chainmail.")]
        public void Adamantine_Small_Default()
        {
            // Arrange
            var armor = new Chainmail(SizeCategory.Small, ChainmailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_150, armor.GetMarketPrice());
            Assert.AreEqual(20, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Chainmail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium adamantine chainmail.")]
        public void Adamantine_Medium_Default()
        {
            // Arrange
            var armor = new Chainmail(SizeCategory.Medium, ChainmailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_150, armor.GetMarketPrice());
            Assert.AreEqual(40, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Chainmail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large adamantine chainmail.")]
        public void Adamantine_Large_Default()
        {
            // Arrange
            var armor = new Chainmail(SizeCategory.Large, ChainmailMaterial.Adamantine);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(4, armor.ArmorCheckPenalty());
            Assert.AreEqual(2, armor.MaximumDexterityBonus());
            Assert.AreEqual(10_300, armor.GetMarketPrice());
            Assert.AreEqual(80, armor.GetWeight());
            Assert.AreEqual(0.25, armor.SpeedPenalty);
            Assert.AreEqual("Adamantine Chainmail", armor.ToString());
        }


        [Test(Description = "Ensures that equipped an adamantine chainmail applies damage reduction to the character.")]
        public void Adamantine_ApplyTo_DamageReduction()
        {
            // Arrange
            var damageReductionTracker = Mock.Of<IDamageReductionTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.DamageReduction)
                         .Returns(damageReductionTracker);
            var armor = new Chainmail(SizeCategory.Medium, ChainmailMaterial.Adamantine);

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(damageReductionTracker)
                .Verify(drt => drt.Add(It.Is<Func<byte>>(calc => 2 == calc()),
                                       It.Is<String>(bpb => "—" == bpb)),
                        "Equipping an adamantine chainmail should bestow DR 2/— on the character wearing it.");
        }
        #endregion

        #region Mithral
        [Test(Description = "Ensures sensible defaults for a fresh instance of small mithral chainmail.")]
        public void Mithral_Small()
        {
            // Arrange
            var armor = new Chainmail(SizeCategory.Small, ChainmailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(4150, armor.GetMarketPrice());
            Assert.AreEqual(10, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Chainmail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of medium mithral chainmail.")]
        public void Mithral_Medium()
        {
            // Arrange
            var armor = new Chainmail(SizeCategory.Medium, ChainmailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(4150, armor.GetMarketPrice());
            Assert.AreEqual(20, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Chainmail", armor.ToString());
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of large mithral chainmail.")]
        public void Mithral_Large()
        {
            // Arrange
            var armor = new Chainmail(SizeCategory.Large, ChainmailMaterial.Mithral);

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.IsFalse(armor.MasterworkIsToggleable);
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(2, armor.ArmorCheckPenalty());
            Assert.AreEqual(4, armor.MaximumDexterityBonus());
            Assert.AreEqual(4300, armor.GetMarketPrice());
            Assert.AreEqual(40, armor.GetWeight());
            Assert.AreEqual(0, armor.SpeedPenalty);
            Assert.AreEqual("Mithral Chainmail", armor.ToString());
        }
        #endregion
    }
}