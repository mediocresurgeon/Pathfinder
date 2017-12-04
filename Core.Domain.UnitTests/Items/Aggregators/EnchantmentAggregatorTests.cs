using System;
using System.Reflection;
using Core.Domain.Characters;
using Core.Domain.Items;
using Core.Domain.Items.Aggregators;
using Core.Domain.Items.Enchantments;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Aggregators
{
    [TestFixture]
    [Parallelizable]
    public class EnchantmentAggregatorTests
    {
        #region Constructor
        [Test(Description = "Ensures that a null itemToEnchant argument throws an exception.")]
        public void Constructor_NullItem_Throws()
        {
            // Arrange
            IItem item = null;
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1;

            // Act
            TestDelegate constructor = () => {
                var mockAggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true };
                var aggregator = mockAggregator.Object;
            };

            // Assert
            var outerException = Assert.Throws<TargetInvocationException>(constructor);
            Assert.IsInstanceOf<ArgumentNullException>(outerException.InnerException);
        }


        [Test(Description = "Ensures that a null applyEnchantmentToItem argument throws an exception.")]
        public void Constructor_NullAction_Throws()
        {
            // Arrange
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = null;
            double costCoefficient = 1;

            // Act
            TestDelegate constructor = () => {
                var mockAggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true };
                var aggregator = mockAggregator.Object;
            };

            // Assert
            var outerException = Assert.Throws<TargetInvocationException>(constructor);
            Assert.IsInstanceOf<ArgumentNullException>(outerException.InnerException);
        }


        [Test(Description = "Ensures that a negative enhancementBonusCostCoefficient argument throws an exception.")]
        public void Constructor_NegativeCoefficient_Throws()
        {
            // Arrange
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = -1;

            // Act
            TestDelegate constructor = () => {
                var mockAggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true };
                var aggregator = mockAggregator.Object;
            };

            // Assert
            var outerException = Assert.Throws<TargetInvocationException>(constructor);
            Assert.IsInstanceOf<ArgumentOutOfRangeException>(outerException.InnerException);
        }


        [Test(Description = "Ensures sensble defults for a fresh instance of EnchantmentAggregator.")]
        public void Default()
        {
            // Arrange
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1;
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            var (enhancementName, otherNames) = aggregator.GetNames();

            // Assert
            Assert.AreEqual(0, aggregator.GetMarketPrice());
            Assert.IsNull(aggregator.GetCasterLevel());
            Assert.IsNull(enhancementName);
            Assert.IsEmpty(otherNames);
            Assert.IsEmpty(aggregator.GetEnchantments());
            Assert.IsEmpty(aggregator.GetSchools());
        }
        #endregion

        #region EnchantWith()
        [Test(Description = "Ensures that calling EnchantWith() with a null argument throws an exception.")]
        public void EnchantWith_NullArgument_Throws()
        {
            // Arrange
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1;
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            TestDelegate enchantWith = () => aggregator.EnchantWith(null);

            // Assert
            Assert.Throws<ArgumentNullException>(enchantWith);
        }


        [Test(Description = "Ensures that calling EnchantWith() without first feeding it an EnhancementBonus will throw an exception.")]
        public void EnchantWith_NotEnhancementBonus_Throws()
        {
            // Arrange
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1;
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            TestDelegate enchantWith = () => aggregator.EnchantWith(Mock.Of<IEnchantment>());

            // Assert
            Assert.Throws<InvalidOperationException>(enchantWith);
        }


        [Test(Description = "Ensures that calling EnchantWith() with duplicate IEnchantment types throws an exception.")]
        public void EnchantWith_EnhancementTwice_Throws()
        {
            // Arrange
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1;
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            aggregator.EnchantWith(new EnhancementBonus(1));                                  // Okay
            TestDelegate enchantWith = () => aggregator.EnchantWith(new EnhancementBonus(1)); // Throws an exception

            // Assert
            Assert.Throws<InvalidOperationException>(enchantWith);
        }


        [Test(Description = "Ensures that calling EnchantWith() calls the Action delegate provided in the constructor.")]
        public void EnchantWith_CallsAction()
        {
            // Arrange
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1;
            IEnchantment enchantment = new EnhancementBonus(1);
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            aggregator.EnchantWith(enchantment);

            // Assert
            Mock.Get(action).Verify(a => a(It.Is<IEnchantment>(ench => ench == enchantment),
                                           It.Is<IItem>(i => i == item)),
                                    "EnchantmentAggregator.EnchantWith() should call the Action delegate and feed it the item to be enchanted and the enchantment.");
        }
        #endregion

        #region GetEnchantments()
        [Test(Description = "Ensures that feeding .EnchantWith() an IEnchantment causes that same enchantment to be returned by calling .GetEnchantments().")]
        public void EnchantWith__RoundTrip()
        {
            // Arrange
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1;
            IEnchantment enchantment = new EnhancementBonus(1);
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            aggregator.EnchantWith(enchantment);
            var enchantments = aggregator.GetEnchantments();

            // Assert
            Assert.That(enchantments, Is.EquivalentTo(new IEnchantment[] { enchantment }),
                        "Enchantments put into the EnchantmentAggregator should make a round trip.");
        }
        #endregion

        #region GetSchools()
        [Test(Description = "Ensures that GetSchools() returns the school of the enhancement bonus if it is the only enchantment.")]
        public void GetSchools_OnlyEnhancementBonus()
        {
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1;
            IEnchantment enchantment = new EnhancementBonus(1);
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            aggregator.EnchantWith(enchantment);
            var schools = aggregator.GetSchools();

            // Assert
            Assert.That(schools, Is.EquivalentTo(enchantment.GetSchools()),
                        "If the only enchantment is an enhancement bonus, the enhancement bonus's schools should be returned.");
        }


        [Test(Description = "Ensures that GetSchools() excludes the enhancement bonus's schools if there is more than one enchantment.")]
        public void GetSchools_EnhancementBonusAndOneMore()
        {
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1;
            IEnchantment enchantment = new EnhancementBonus(1);
            var mockEnchantment = new Mock<IEnchantment>();
            mockEnchantment.Setup(e => e.GetSchools())
                           .Returns(new School[] { School.Necromancy });
            var necroEnch = mockEnchantment.Object;
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            aggregator.EnchantWith(enchantment);
            aggregator.EnchantWith(necroEnch);
            var schools = aggregator.GetSchools();

            // Assert
            Assert.That(schools, Is.EquivalentTo(necroEnch.GetSchools()),
                        "If there is at least one non-enhancement bonus enchantment, the enhancement bonus's schools should be ignored.");
        }
        #endregion

        #region GetCasterLevel()
        [Test(Description = "Ensures that .GetCasterLevel() returns the maximum caster level across all of the enchantments.")]
        public void GetCasterLevel_ReturnsMax()
        {
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1;
            IEnchantment enchantment = new EnhancementBonus(5); // caster level 15
            var mockEnchantment = new Mock<IEnchantment>();
            mockEnchantment.Setup(e => e.CasterLevel)
                           .Returns(10);
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            aggregator.EnchantWith(enchantment);
            aggregator.EnchantWith(mockEnchantment.Object);
            var casterLevel = aggregator.GetCasterLevel();

            // Assert
            Assert.AreEqual(15, casterLevel);
        }
        #endregion

        #region GetMarketPrice()
        [Test(Description = "Ensures that EnchantmentAggregator correctly calculates the market price when the enchantments have only special ability bonuses.")]
        public void GetMarketPrice_OnlySpecialAbilityBonuses()
        {
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1000;
            IEnchantment enchantment = new EnhancementBonus(5);
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            aggregator.EnchantWith(enchantment);
            var price = aggregator.GetMarketPrice();

            // Assert
            Assert.AreEqual(25000, price,
                            "25000 = 5^2 * 1000");
        }


        [Test(Description = "Ensures that EnchantmentAggregator correctly calculates the market price when the enchantments special ability bonuses and flat costs.")]
        public void GetMarketPrice_MixedCosts()
        {
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1000;
            IEnchantment enchantment = new EnhancementBonus(5);
            var mockEnchantment = new Mock<IEnchantment>();
            mockEnchantment.Setup(e => e.Cost)
                           .Returns(1000);
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            aggregator.EnchantWith(enchantment);
            aggregator.EnchantWith(mockEnchantment.Object);
            var price = aggregator.GetMarketPrice();

            // Assert
            Assert.AreEqual(26000, price,
                            "26000 = (5^2 * 1000) + (1000 flat costs)");
        }
        #endregion

        #region GetNames()
        [Test(Description = "Ensures that .GetNames() returns the names of all enchantments, with the enhancement bonus seperated from the rest of the collection.")]
        public void GetNames()
        {
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1000;
            IEnchantment enchantment = new EnhancementBonus(5);
            var mockEnchantment = new Mock<IEnchantment>();
            mockEnchantment.Setup(e => e.Name)
                           .Returns(new NameFragment("Other Enchantment", "http://example.com"));
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            aggregator.EnchantWith(enchantment);
            aggregator.EnchantWith(mockEnchantment.Object);
            var (enhName, otherNames) = aggregator.GetNames();

            // Assert
            Assert.AreEqual(enchantment.Name, enhName);
            Assert.That(otherNames, Is.EquivalentTo(new INameFragment[] { new NameFragment("Other Enchantment", "http://example.com") }));
        }
        #endregion

        #region ApplyTo()
        [Test(Description = "Ensures that .ApplyTo(ICharacter) rejects null arguments.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1000;
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;

            // Act
            TestDelegate applyTo = () => aggregator.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures that .ApplyTo(ICharacter) applies all existing enchantments to the ICharacter.")]
        public void ApplyTo_AllExistingEnchantments()
        {
            // Arrange
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1000;
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;
            var character = Mock.Of<ICharacter>();
            var otherEnchantment = Mock.Of<IEnchantment>();

            // Act
            aggregator.EnchantWith(new EnhancementBonus(1));
            aggregator.EnchantWith(otherEnchantment);
            aggregator.ApplyTo(character);

            // Assert
            Mock.Get(otherEnchantment)
                .Verify(e => e.ApplyTo(It.Is<ICharacter>(c => c == character)),
                        "Applying the enchantment aggregator to a character should apply all of its enchantments to the character.");
        }


        [Test(Description = "Ensures that .ApplyTo(ICharacter) applies all new enchantments to the ICharacter.")]
        public void ApplyTo_AllNewEnchantments()
        {
            // Arrange
            IItem item = Mock.Of<IItem>();
            Action<IEnchantment, IItem> action = Mock.Of<Action<IEnchantment, IItem>>();
            double costCoefficient = 1000;
            var aggregator = new Mock<EnchantmentAggregator<IEnchantment, IItem>>(MockBehavior.Loose, item, action, costCoefficient) { CallBase = true }.Object;
            var character = Mock.Of<ICharacter>();
            var otherEnchantment = Mock.Of<IEnchantment>();

            // Act
            aggregator.EnchantWith(new EnhancementBonus(1));
            aggregator.ApplyTo(character);
            aggregator.EnchantWith(otherEnchantment);

            // Assert
            Mock.Get(otherEnchantment)
                .Verify(e => e.ApplyTo(It.Is<ICharacter>(c => c == character)),
                        "Applying the enchantment aggregator to a character, then adding a new enchantment should apply the new enchantment to the character.");
        }
        #endregion
    }
}