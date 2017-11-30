using System;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Shields;
using Core.Domain.Items.Shields.Enchantments;
using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class EnhancementBonusTests
    {
        #region Constructor
        [Test(Description = "Ensures that an enhancement bonus of less than 1 cannot be created.")]
        public void Constructor_BonusZero_Throws()
        {
            // Arrange
            byte bonus = 0;

            // Act
            TestDelegate constructor = () => new EnhancementBonus(bonus);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(constructor,
                                                      "Shields should not be enchantable with a +0 enhancement bonus.");
        }


        [Test(Description = "Ensures that an enhancement bonus of more than 5 cannot be created.")]
        public void Constructor_BonusSix_Throws()
        {
            // Arrange
            byte bonus = 6;

            // Act
            TestDelegate constructor = () => new EnhancementBonus(bonus);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(constructor,
                                                       "Shields should not be enchantable with a +6 enhancement bonus.");
        }
        #endregion

        #region +1
        [Test(Description = "Ensures sensible defaults for a shield's +1 enhancement bonus.")]
        public void PlusOne_Defaults()
        {
            // Arrange
            byte bonus = 1;

            // Act
            IShieldEnchantment enchantment = new EnhancementBonus(bonus);

            // Assert
            Assert.AreEqual(1, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(3, enchantment.CasterLevel);
            Assert.AreEqual(0, enchantment.Cost);
            Assert.AreEqual(1, enchantment.GetSchools().Length);
            Assert.AreEqual(School.Abjuration, enchantment.GetSchools()[0]);
            Assert.AreEqual("+1", enchantment.Name.Text);
        }


        [Test(Description = "Ensures that a shield enchanted with a +1 enhancement bonus is modified correctly.")]
        public void PlusOne_Enchant()
        {
            // Arrange
            var armorEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockShieldBonusAgg = new Mock<IShieldBonusAggregator>();
            mockShieldBonusAgg.Setup(agg => agg.EnhancementBonuses)
                              .Returns(armorEnhancementBonus);
            IShieldBonusAggregator shieldBonus = mockShieldBonusAgg.Object;

            var hardnessEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHardnessAgg = new Mock<IShieldHardnessAggregator>();
            mockHardnessAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hardnessEnhancementBonus);
            IShieldHardnessAggregator hardness = mockHardnessAgg.Object;

            var hitPointsEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHitPointAgg = new Mock<IShieldHitPointAggregator>();
            mockHitPointAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hitPointsEnhancementBonus);
            IShieldHitPointAggregator hitPoints = mockHitPointAgg.Object;

            IShieldEnchantmentAggregator enchantments = null;

            var shield = new Mock<Shield>(MockBehavior.Loose, shieldBonus, hardness, hitPoints, enchantments) { CallBase = true }.Object;

            IShieldEnchantment enchantment = new EnhancementBonus(1);

            // Act
            enchantment.Enchant(shield);

            // Assert
            Mock.Get(armorEnhancementBonus)
                .Verify(ac => ac.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "A +1 bonus was not applied to the shield's armor class bonus correctly.");
            Mock.Get(hardnessEnhancementBonus)
                .Verify(bhn => bhn.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "A +2 bonus was not applied to the shield's hardness correctly.");
            Mock.Get(hitPointsEnhancementBonus)
                .Verify(hp => hp.Add(It.Is<Func<byte>>(calc => 10 == calc())),
                        "A +10 bonus was not applied to the shield's hardness correctly.");
        }
        #endregion

        #region +2
        [Test(Description = "Ensures sensible defaults for a shield's +2 enhancement bonus.")]
        public void PlusTwo_Defaults()
        {
            // Arrange
            byte bonus = 2;

            // Act
            IShieldEnchantment enchantment = new EnhancementBonus(bonus);

            // Assert
            Assert.AreEqual(2, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(6, enchantment.CasterLevel);
            Assert.AreEqual(0, enchantment.Cost);
            Assert.AreEqual(1, enchantment.GetSchools().Length);
            Assert.AreEqual(School.Abjuration, enchantment.GetSchools()[0]);
            Assert.AreEqual("+2", enchantment.Name.Text);
        }


        [Test(Description = "Ensures that a shield enchanted with a +2 enhancement bonus is modified correctly.")]
        public void PlusTwo_Enchant()
        {
            // Arrange
            var armorEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockShieldBonusAgg = new Mock<IShieldBonusAggregator>();
            mockShieldBonusAgg.Setup(agg => agg.EnhancementBonuses)
                              .Returns(armorEnhancementBonus);
            IShieldBonusAggregator shieldBonus = mockShieldBonusAgg.Object;

            var hardnessEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHardnessAgg = new Mock<IShieldHardnessAggregator>();
            mockHardnessAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hardnessEnhancementBonus);
            IShieldHardnessAggregator hardness = mockHardnessAgg.Object;

            var hitPointsEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHitPointAgg = new Mock<IShieldHitPointAggregator>();
            mockHitPointAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hitPointsEnhancementBonus);
            IShieldHitPointAggregator hitPoints = mockHitPointAgg.Object;

            IShieldEnchantmentAggregator enchantments = null;

            var shield = new Mock<Shield>(MockBehavior.Loose, shieldBonus, hardness, hitPoints, enchantments) { CallBase = true }.Object;

            IShieldEnchantment enchantment = new EnhancementBonus(2);

            // Act
            enchantment.Enchant(shield);

            // Assert
            Mock.Get(armorEnhancementBonus)
                .Verify(ac => ac.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "A +2 bonus was not applied to the shield's armor class bonus correctly.");
            Mock.Get(hardnessEnhancementBonus)
                .Verify(bhn => bhn.Add(It.Is<Func<byte>>(calc => 4 == calc())),
                        "A +4 bonus was not applied to the shield's hardness correctly.");
            Mock.Get(hitPointsEnhancementBonus)
                .Verify(hp => hp.Add(It.Is<Func<byte>>(calc => 20 == calc())),
                        "A +20 bonus was not applied to the shield's hardness correctly.");
        }
        #endregion

        #region +3
        [Test(Description = "Ensures sensible defaults for a shield's +3 enhancement bonus.")]
        public void PlusThree_Defaults()
        {
            // Arrange
            byte bonus = 3;

            // Act
            IShieldEnchantment enchantment = new EnhancementBonus(bonus);

            // Assert
            Assert.AreEqual(3, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(9, enchantment.CasterLevel);
            Assert.AreEqual(0, enchantment.Cost);
            Assert.AreEqual(1, enchantment.GetSchools().Length);
            Assert.AreEqual(School.Abjuration, enchantment.GetSchools()[0]);
            Assert.AreEqual("+3", enchantment.Name.Text);
        }


        [Test(Description = "Ensures that a shield enchanted with a +3 enhancement bonus is modified correctly.")]
        public void PlusThree_Enchant()
        {
            // Arrange
            var armorEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockShieldBonusAgg = new Mock<IShieldBonusAggregator>();
            mockShieldBonusAgg.Setup(agg => agg.EnhancementBonuses)
                              .Returns(armorEnhancementBonus);
            IShieldBonusAggregator shieldBonus = mockShieldBonusAgg.Object;

            var hardnessEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHardnessAgg = new Mock<IShieldHardnessAggregator>();
            mockHardnessAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hardnessEnhancementBonus);
            IShieldHardnessAggregator hardness = mockHardnessAgg.Object;

            var hitPointsEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHitPointAgg = new Mock<IShieldHitPointAggregator>();
            mockHitPointAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hitPointsEnhancementBonus);
            IShieldHitPointAggregator hitPoints = mockHitPointAgg.Object;

            IShieldEnchantmentAggregator enchantments = null;

            var shield = new Mock<Shield>(MockBehavior.Loose, shieldBonus, hardness, hitPoints, enchantments) { CallBase = true }.Object;

            IShieldEnchantment enchantment = new EnhancementBonus(3);

            // Act
            enchantment.Enchant(shield);

            // Assert
            Mock.Get(armorEnhancementBonus)
                .Verify(ac => ac.Add(It.Is<Func<byte>>(calc => 3 == calc())),
                        "A +3 bonus was not applied to the shield's armor class bonus correctly.");
            Mock.Get(hardnessEnhancementBonus)
                .Verify(bhn => bhn.Add(It.Is<Func<byte>>(calc => 6 == calc())),
                        "A +6 bonus was not applied to the shield's hardness correctly.");
            Mock.Get(hitPointsEnhancementBonus)
                .Verify(hp => hp.Add(It.Is<Func<byte>>(calc => 30 == calc())),
                        "A +30 bonus was not applied to the shield's hardness correctly.");
        }
        #endregion

        #region +4
        [Test(Description = "Ensures sensible defaults for a shield's +4 enhancement bonus.")]
        public void PlusFour_Defaults()
        {
            // Arrange
            byte bonus = 4;

            // Act
            IShieldEnchantment enchantment = new EnhancementBonus(bonus);

            // Assert
            Assert.AreEqual(4, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(12, enchantment.CasterLevel);
            Assert.AreEqual(0, enchantment.Cost);
            Assert.AreEqual(1, enchantment.GetSchools().Length);
            Assert.AreEqual(School.Abjuration, enchantment.GetSchools()[0]);
            Assert.AreEqual("+4", enchantment.Name.Text);
        }


        [Test(Description = "Ensures that a shield enchanted with a +4 enhancement bonus is modified correctly.")]
        public void PlusFour_Enchant()
        {
            // Arrange
            var armorEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockShieldBonusAgg = new Mock<IShieldBonusAggregator>();
            mockShieldBonusAgg.Setup(agg => agg.EnhancementBonuses)
                              .Returns(armorEnhancementBonus);
            IShieldBonusAggregator shieldBonus = mockShieldBonusAgg.Object;

            var hardnessEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHardnessAgg = new Mock<IShieldHardnessAggregator>();
            mockHardnessAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hardnessEnhancementBonus);
            IShieldHardnessAggregator hardness = mockHardnessAgg.Object;

            var hitPointsEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHitPointAgg = new Mock<IShieldHitPointAggregator>();
            mockHitPointAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hitPointsEnhancementBonus);
            IShieldHitPointAggregator hitPoints = mockHitPointAgg.Object;

            IShieldEnchantmentAggregator enchantments = null;

            var shield = new Mock<Shield>(MockBehavior.Loose, shieldBonus, hardness, hitPoints, enchantments) { CallBase = true }.Object;

            IShieldEnchantment enchantment = new EnhancementBonus(4);

            // Act
            enchantment.Enchant(shield);

            // Assert
            Mock.Get(armorEnhancementBonus)
                .Verify(ac => ac.Add(It.Is<Func<byte>>(calc => 4 == calc())),
                        "A +4 bonus was not applied to the shield's armor class bonus correctly.");
            Mock.Get(hardnessEnhancementBonus)
                .Verify(bhn => bhn.Add(It.Is<Func<byte>>(calc => 8 == calc())),
                        "A +8 bonus was not applied to the shield's hardness correctly.");
            Mock.Get(hitPointsEnhancementBonus)
                .Verify(hp => hp.Add(It.Is<Func<byte>>(calc => 40 == calc())),
                        "A +40 bonus was not applied to the shield's hardness correctly.");
        }
        #endregion

        #region +5
        [Test(Description = "Ensures sensible defaults for a shield's +5 enhancement bonus.")]
        public void PlusFive_Defaults()
        {
            // Arrange
            byte bonus = 5;

            // Act
            IShieldEnchantment enchantment = new EnhancementBonus(bonus);

            // Assert
            Assert.AreEqual(5, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(15, enchantment.CasterLevel);
            Assert.AreEqual(0, enchantment.Cost);
            Assert.AreEqual(1, enchantment.GetSchools().Length);
            Assert.AreEqual(School.Abjuration, enchantment.GetSchools()[0]);
            Assert.AreEqual("+5", enchantment.Name.Text);
        }


        [Test(Description = "Ensures that a shield enchanted with a +5 enhancement bonus is modified correctly.")]
        public void PlusFive_Enchant()
        {
            // Arrange
            var armorEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockShieldBonusAgg = new Mock<IShieldBonusAggregator>();
            mockShieldBonusAgg.Setup(agg => agg.EnhancementBonuses)
                              .Returns(armorEnhancementBonus);
            IShieldBonusAggregator shieldBonus = mockShieldBonusAgg.Object;

            var hardnessEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHardnessAgg = new Mock<IShieldHardnessAggregator>();
            mockHardnessAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hardnessEnhancementBonus);
            IShieldHardnessAggregator hardness = mockHardnessAgg.Object;

            var hitPointsEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHitPointAgg = new Mock<IShieldHitPointAggregator>();
            mockHitPointAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hitPointsEnhancementBonus);
            IShieldHitPointAggregator hitPoints = mockHitPointAgg.Object;

            IShieldEnchantmentAggregator enchantments = null;

            var shield = new Mock<Shield>(MockBehavior.Loose, shieldBonus, hardness, hitPoints, enchantments) { CallBase = true }.Object;

            IShieldEnchantment enchantment = new EnhancementBonus(5);

            // Act
            enchantment.Enchant(shield);

            // Assert
            Mock.Get(armorEnhancementBonus)
                .Verify(ac => ac.Add(It.Is<Func<byte>>(calc => 5 == calc())),
                        "A +5 bonus was not applied to the shield's armor class bonus correctly.");
            Mock.Get(hardnessEnhancementBonus)
                .Verify(bhn => bhn.Add(It.Is<Func<byte>>(calc => 10 == calc())),
                        "A +10 bonus was not applied to the shield's hardness correctly.");
            Mock.Get(hitPointsEnhancementBonus)
                .Verify(hp => hp.Add(It.Is<Func<byte>>(calc => 50 == calc())),
                        "A +50 bonus was not applied to the shield's hardness correctly.");
        }
        #endregion
    }
}