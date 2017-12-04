using System;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Aggregators;
using Core.Domain.Items.Enchantments;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Items.Shields;
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
                                                      "Magical enhancement bonuses cannot have a magnitude of +0.");
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
                                                       "Magical enhancement bonuses cannot have a magnitude of higher than +5.");
        }


        [Test(Description = "Ensures sensible defaults for a +1 magical enhancement bonus.")]
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
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Abjuration == s));
            Assert.AreEqual("+1", enchantment.Name.Text);
        }


        [Test(Description = "Ensures sensible defaults for a +2 magical enhancement bonus.")]
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
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Abjuration == s));
            Assert.AreEqual("+2", enchantment.Name.Text);
        }


        [Test(Description = "Ensures sensible defaults for a +3 magical enhancement bonus.")]
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
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Abjuration == s));
            Assert.AreEqual("+3", enchantment.Name.Text);
        }


        [Test(Description = "Ensures sensible defaults for a +4 magical enhancement bonus.")]
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
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Abjuration == s));
            Assert.AreEqual("+4", enchantment.Name.Text);
        }


        [Test(Description = "Ensures sensible defaults for a +5 magical enhancement bonus.")]
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
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Abjuration == s));
            Assert.AreEqual("+5", enchantment.Name.Text);
        }
        #endregion

        #region Shields
        [Test(Description = "Ensures that a shield enchanted with a +1 enhancement bonus is modified correctly.")]
        public void Shield_PlusOne_Enchant()
        {
            // Arrange
            var armorEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockShieldBonusAgg = new Mock<IArmorClassAggregator>();
            mockShieldBonusAgg.Setup(agg => agg.EnhancementBonuses)
                              .Returns(armorEnhancementBonus);
            IArmorClassAggregator shieldBonus = mockShieldBonusAgg.Object;

            var hardnessEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHardnessAgg = new Mock<IHardnessAggregator>();
            mockHardnessAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hardnessEnhancementBonus);
            IHardnessAggregator hardness = mockHardnessAgg.Object;

            var hitPointsEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHitPointAgg = new Mock<IHitPointsAggregator>();
            mockHitPointAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hitPointsEnhancementBonus);
            IHitPointsAggregator hitPoints = mockHitPointAgg.Object;

            IEnchantmentAggregator<IShieldEnchantment, Shield> enchantments = null;

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
                        "A +10 bonus was not applied to the shield's hit points correctly.");
        }


        [Test(Description = "Ensures that a shield enchanted with a +5 enhancement bonus is modified correctly.")]
        public void Shield_PlusFive_Enchant()
        {
            // Arrange
            var armorEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockShieldBonusAgg = new Mock<IArmorClassAggregator>();
            mockShieldBonusAgg.Setup(agg => agg.EnhancementBonuses)
                              .Returns(armorEnhancementBonus);
            IArmorClassAggregator shieldBonus = mockShieldBonusAgg.Object;

            var hardnessEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHardnessAgg = new Mock<IHardnessAggregator>();
            mockHardnessAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hardnessEnhancementBonus);
            IHardnessAggregator hardness = mockHardnessAgg.Object;

            var hitPointsEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHitPointAgg = new Mock<IHitPointsAggregator>();
            mockHitPointAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hitPointsEnhancementBonus);
            IHitPointsAggregator hitPoints = mockHitPointAgg.Object;

            IEnchantmentAggregator<IShieldEnchantment, Shield> enchantments = null;

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
                        "A +50 bonus was not applied to the shield's hit points correctly.");
        }
        #endregion

        #region Armor
        [Test(Description = "Ensures that armor enchanted with a +1 enhancement bonus is modified correctly.")]
        public void Armor_PlusOne_Enchant()
        {
            // Arrange
            var armorEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockArmorBonusAgg = new Mock<IArmorClassAggregator>();
            mockArmorBonusAgg.Setup(agg => agg.EnhancementBonuses)
                             .Returns(armorEnhancementBonus);
            IArmorClassAggregator armorBonus = mockArmorBonusAgg.Object;

            var hardnessEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHardnessAgg = new Mock<IHardnessAggregator>();
            mockHardnessAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hardnessEnhancementBonus);
            IHardnessAggregator hardness = mockHardnessAgg.Object;

            var hitPointsEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHitPointAgg = new Mock<IHitPointsAggregator>();
            mockHitPointAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hitPointsEnhancementBonus);
            IHitPointsAggregator hitPoints = mockHitPointAgg.Object;

            var armor = new Mock<Core.Domain.Items.Armor.Armor>(MockBehavior.Loose, armorBonus, hardness, hitPoints, null) { CallBase = true }.Object;

            IArmorEnchantment enchantment = new EnhancementBonus(1);

            // Act
            enchantment.Enchant(armor);

            // Assert
            Mock.Get(armorEnhancementBonus)
                .Verify(ac => ac.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "A +1 bonus was not applied to the armor's armor class bonus correctly.");
            Mock.Get(hardnessEnhancementBonus)
                .Verify(bhn => bhn.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "A +2 bonus was not applied to the armor's hardness correctly.");
            Mock.Get(hitPointsEnhancementBonus)
                .Verify(hp => hp.Add(It.Is<Func<byte>>(calc => 10 == calc())),
                        "A +10 bonus was not applied to the armor's hit points correctly.");
        }


        [Test(Description = "Ensures that armor enchanted with a +5 enhancement bonus is modified correctly.")]
        public void Armor_PlusFive_Enchant()
        {
            // Arrange
            var armorEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockArmorBonusAgg = new Mock<IArmorClassAggregator>();
            mockArmorBonusAgg.Setup(agg => agg.EnhancementBonuses)
                             .Returns(armorEnhancementBonus);
            IArmorClassAggregator armorBonus = mockArmorBonusAgg.Object;

            var hardnessEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHardnessAgg = new Mock<IHardnessAggregator>();
            mockHardnessAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hardnessEnhancementBonus);
            IHardnessAggregator hardness = mockHardnessAgg.Object;

            var hitPointsEnhancementBonus = Mock.Of<IModifierTracker>();
            var mockHitPointAgg = new Mock<IHitPointsAggregator>();
            mockHitPointAgg.Setup(agg => agg.EnhancementBonuses)
                           .Returns(hitPointsEnhancementBonus);
            IHitPointsAggregator hitPoints = mockHitPointAgg.Object;

            var armor = new Mock<Core.Domain.Items.Armor.Armor>(MockBehavior.Loose, armorBonus, hardness, hitPoints, null) { CallBase = true }.Object;

            IArmorEnchantment enchantment = new EnhancementBonus(5);

            // Act
            enchantment.Enchant(armor);

            // Assert
            Mock.Get(armorEnhancementBonus)
                .Verify(ac => ac.Add(It.Is<Func<byte>>(calc => 5 == calc())),
                        "A +5 bonus was not applied to the armor's armor class bonus correctly.");
            Mock.Get(hardnessEnhancementBonus)
                .Verify(bhn => bhn.Add(It.Is<Func<byte>>(calc => 10 == calc())),
                        "A +10 bonus was not applied to the armor's hardness correctly.");
            Mock.Get(hitPointsEnhancementBonus)
                .Verify(hp => hp.Add(It.Is<Func<byte>>(calc => 50 == calc())),
                        "A +50 bonus was not applied to the armor's hit points correctly.");
        }
        #endregion
    }
}