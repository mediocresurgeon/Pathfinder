using System;
using Core.Domain.Items.Shields;
using Core.Domain.Items.Shields.Enchantments;
using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields
{
    [TestFixture]
    [Parallelizable]
    public class ShieldEnchantmentAggregatorTests
    {
        #region Constructor
        [Test(Description = "Ensures that an instance of ShieldEnchantmentAggregator cannot be created with a null Shield reference.")]
        public void Constructor_NullShield_Throws()
        {
            // Arrange
            Shield shield = null;

            // Act
            TestDelegate constructor = () => new ShieldEnchantmentAggregator(shield);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion


        #region EnchantWith<T>(T)
        [Test(Description = "Ensures that EnchantWith cannot be fed a null ShieldEnchantment.")]
        public void EnchantWith_NullEnchantment_Throws()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose, (byte)5, 1f, (byte)100, (byte)40) { CallBase = true }.Object;
            ShieldEnchantmentAggregator aggregator = new ShieldEnchantmentAggregator(shield);
            ShieldEnchantment enchantment = null;

            // Act
            TestDelegate enchantWith = () => aggregator.EnchantWith(enchantment);

            // Assert
            Assert.Throws<ArgumentNullException>(enchantWith);
        }


        [Test(Description = "Ensures that EnchantWith cannot be fed a non-Enhancement bonus until an enhancement bonus has been added.")]
        public void EnchantWith_NoEnhancementBonus_Throws()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose, (byte)5, 1f, (byte)100, (byte)40) { CallBase = true }.Object;
            ShieldEnchantmentAggregator aggregator = new ShieldEnchantmentAggregator(shield);
            var nonEnhancementBonus = Mock.Of<IShieldEnchantment>();

            // Act
            TestDelegate enchantWith = () => aggregator.EnchantWith(nonEnhancementBonus);

            // Assert
            Assert.Throws<InvalidOperationException>(enchantWith,
                                                     "It is not legal to enchant a shield with non-enhancement bonus enchantments until an enhancement bonus has been aplied first.");
        }


        [Test(Description = "Ensures that ShieldEnchantmentAggregator has the correct behavior for a situation in which the only enchantment is an EnhancementBonus.")]
        public void EnchantWith_OnlyEnhancementBonus()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose, (byte)5, 1f, (byte)100, (byte)40) { CallBase = true }.Object;
            ShieldEnchantmentAggregator aggregator = new ShieldEnchantmentAggregator(shield);
            IShieldEnchantment enhancementBonus = new EnhancementBonus(5);

            // Act
            aggregator.EnchantWith(enhancementBonus);

            // Assert
            Assert.AreEqual(15, aggregator.GetCasterLevel(),
                           "The caster level of a shield is equal to the greatest caster level among its enchantments.");
            Assert.AreEqual(25_000, aggregator.GetMarketPrice(),
                           "The market value of a shield's enchantments are equal to 1000 times its effective enhancement bonus, plus flat enchantment costs.");
            Assert.AreEqual(1, aggregator.GetSchools().Length,
                           "A shield enchanted with only an enhancement bonus should only have a single school.");
            Assert.Contains(School.Abjuration, aggregator.GetSchools(),
                           "A shield enchanted only with an enhancement bonus should have an Abjuration aura.");
        }


        [Test(Description = "Ensures that ShieldEnchantmentAggregator has the correct behavior for a situation in which the only enchantment is an EnhancementBonus.")]
        public void EnchantWith_TwoEnchantments()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose, (byte)5, 1f, (byte)100, (byte)40) { CallBase = true }.Object;
            ShieldEnchantmentAggregator aggregator = new ShieldEnchantmentAggregator(shield);
            IShieldEnchantment enhancementBonus = new EnhancementBonus(1);
            IShieldEnchantment animated = new Animated();

            // Act
            aggregator.EnchantWith(enhancementBonus);
            aggregator.EnchantWith(animated);

            // Assert
            Assert.AreEqual(12, aggregator.GetCasterLevel(),
                           "The caster level of a shield is equal to the greatest caster level among its enchantments.");
            Assert.AreEqual(9_000, aggregator.GetMarketPrice(),
                           "The market value of a shield's enchantments are equal to 1000 times its effective enhancement bonus, plus flat enchantment costs.");
            Assert.AreEqual(1, aggregator.GetSchools().Length,
                            "A shield enchanted with something other than an enhancement bonus should ignore the enhancement bonus's school (Abjuration).");
            Assert.Contains(School.Transmutation, aggregator.GetSchools(),
                            "A shield's schools should include all schools of its component enchantments, ignoring the enhancement bonus enchantment.");
        }
        #endregion
    }
}