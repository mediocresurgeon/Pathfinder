using System;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.Movements;
using Core.Domain.Characters.Skills;
using Core.Domain.Items.Aggregators;
using Core.Domain.Items.Armor;
using Core.Domain.Items.Enchantments;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Armor
{
    [TestFixture]
    [Parallelizable]
    public class ArmorTests
    {
        #region Constructor
        [Test(Description = "Ensures that a fresh instance of Armor has sensible defaults.")]
        public void Default()
        {
            // Arrange
            byte baseArmorBonus = 4;
            byte materialHardness = 6;
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            baseArmorBonus,
                            materialHardness)
                            { CallBase = true }.Object;

            // Assert
            Assert.IsTrue(armor.MasterworkIsToggleable);
            Assert.IsInstanceOf<ArmorClassAggregator>(armor.ArmorClass);
            Assert.IsInstanceOf<HardnessAggregator>(armor.Hardness);
            Assert.IsInstanceOf<HitPointsAggregator>(armor.HitPoints);
            Assert.AreEqual(20, armor.HitPoints.BaseHitPoints());
            Assert.IsInstanceOf<ArmorEnchantmentAggregator>(armor.Enchantments);
            Assert.IsFalse(armor.IsMasterwork);
        }
        #endregion

        #region Masterwork
        [Test(Description = "Ensures that IsMasterwork can be toggles when MasterworkIsToggleable is true.")]
        public void Masterwork_Toggle()
        {
            // Arrange
            byte baseArmorBonus = 4;
            byte materialHardness = 6;
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            baseArmorBonus,
                            materialHardness)
                            { CallBase = true }.Object;

            // Act
            armor.IsMasterwork = true;

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
        }


        [Test(Description = "Ensures that toggling IsMasterwork when MasterworkIsToggleable is false will throw an exception.")]
        public void Masterwork_NotToggleable_Throws()
        {
            // Arrange
            byte baseArmorBonus = 4;
            byte materialHardness = 6;
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            baseArmorBonus,
                            materialHardness)
                            { CallBase = true }.Object;

            // Act
            armor.MasterworkIsToggleable = false;
            TestDelegate toggleMasterwork = () => armor.IsMasterwork = true;

            // Assert
            Assert.Throws<InvalidOperationException>(toggleMasterwork);
        }


        [Test(Description = "Ensures that a redundant assignment of IsMasterwork when MasterworkIsToggleable is false will not throw an exception.")]
        public void Masterwork_RedundantSet_NotToggleable_Throws()
        {
            // Arrange
            byte baseArmorBonus = 4;
            byte materialHardness = 6;
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            baseArmorBonus,
                            materialHardness)
                            { CallBase = true }.Object;

            // Act
            armor.MasterworkIsToggleable = false;
            TestDelegate redundantAssignment = () => armor.IsMasterwork = false; // property is already false

            // Assert
            Assert.DoesNotThrow(redundantAssignment);
        }
        #endregion

        #region GetArmorBonus()
        [Test(Description = "Ensures that Armor.GetArmorBonus() has correct logic.")]
        public void GetArmorBonus()
        {
            // Arrange
            var mockArmorClassAgg = new Mock<IArmorClassAggregator>();
            mockArmorClassAgg.Setup(ac => ac.GetTotal())
                             .Returns(11);
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            mockArmorClassAgg.Object,
                            hardnessAgg,
                            hitPointsAgg,
                            enchantmentAgg)
                            { CallBase = true }.Object;

            // Act
            var result = armor.GetArmorBonus();

            // Assert
            mockArmorClassAgg.Verify(ac => ac.GetTotal(),
                                     "Armor.GetArmorBonus() did not call Armor.ArmorClass.GetTotal().  (Where did it get its total from??)");
            Assert.AreEqual(11, result);
        }
        #endregion

        #region GetHardness()
        [Test(Description = "Ensures that Armor.GetHardness() has correct logic.")]
        public void GetHardness()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var mockHardnessAgg = new Mock<IHardnessAggregator>();
            mockHardnessAgg.Setup(h => h.GetTotal())
                           .Returns(7);
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            mockHardnessAgg.Object,
                            hitPointsAgg,
                            enchantmentAgg)
                            { CallBase = true }.Object;

            // Act
            var result = armor.GetHardness();

            // Assert
            mockHardnessAgg.Verify(h => h.GetTotal(),
                                   "Armor.GetHardness() did not call Armor.Hardness.GetTotal().  (Where did it get its total from??)");
            Assert.AreEqual(7, result);
        }
        #endregion

        #region GetHitPoints()
        [Test(Description = "Ensures that Armor.GetHitPoints() has correct logic.")]
        public void GetHitPoints()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var mockHitPointsAgg = new Mock<IHitPointsAggregator>();
            mockHitPointsAgg.Setup(hp => hp.GetTotal())
                            .Returns(23);
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            mockHitPointsAgg.Object,
                            enchantmentAgg)
                            { CallBase = true }.Object;

            // Act
            var result = armor.GetHitPoints();

            // Assert
            mockHitPointsAgg.Verify(hp => hp.GetTotal(),
                                    "Armor.GetHitPoints() did not call Armor.HitPoints.GetTotal().  (Where did it get its total from??)");
            Assert.AreEqual(23, result);
        }
        #endregion

        #region GetCasterLevel()
        [Test(Description = "Ensures that Armor.GetCasterLevel() has correct logic.")]
        public void GetCasterLevel()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetCasterLevel())
                              .Returns(17);
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;

            // Act
            var result = armor.GetCasterLevel();

            // Assert
            mockEnchantmentAgg.Verify(e => e.GetCasterLevel(),
                                      "Armor.GetCasterLevel() did not call Armor.Enchantments.GetCasterLevel().  (Where did it get its total from??)");
            Assert.AreEqual(17, result);
        }
        #endregion

        #region GetSchools()
        [Test(Description = "Ensures that Armor.GetSchools() has correct logic.")]
        public void GetSchools()
        {
            // Arrange
            var schools = new School[] { School.Abjuration, School.Conjuration, School.Necromancy };

            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetSchools())
                              .Returns(schools);
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;

            // Act
            var result = armor.GetSchools();

            // Assert
            mockEnchantmentAgg.Verify(e => e.GetSchools(),
                                      "Armor.GetSchools() did not call Armor.Enchantments.GetSchools().  (Where did it get its total from??)");
            Assert.That(result, Is.EquivalentTo(schools));
        }
        #endregion

        #region GetArmorCheckPenalty()
        [Test(Description = "Ensures that Armor.GetArmorCheckPenalty() has correct logic.")]
        public void GetArmorCheckPenalty()
        {
            // Arrange
            var mockAcpFunc = new Mock<Func<byte>>();
            mockAcpFunc.Setup(f => f())
                       .Returns(3);

            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var mockArmor = new Mock<Core.Domain.Items.Armor.Armor>(
                                MockBehavior.Loose,
                                armorClassAgg,
                                hardnessAgg,
                                hitPointsAgg,
                                enchantmentAgg)
                                { CallBase = true };
            mockArmor.Setup(a => a.ArmorCheckPenalty)
                     .Returns(mockAcpFunc.Object);
            var armor = mockArmor.Object;

            // Act
            var result = armor.GetArmorCheckPenalty();

            // Assert
            mockAcpFunc.Verify(f => f(),
                               "Armor.GetArmorCheckPenalty() did not call Armor.ArmorCheckPenalty.  (Where did it get its total from??)");
            Assert.AreEqual(3, result);
        }
        #endregion

        #region GetWeight()
        [Test(Description = "Ensures that Armor.GetWeight() has correct logic.")]
        public void GetWeight()
        {
            // Arrange
            var mockWeightFunc = new Mock<Func<double>>();
            mockWeightFunc.Setup(f => f())
                          .Returns(29);

            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var mockArmor = new Mock<Core.Domain.Items.Armor.Armor>(
                                MockBehavior.Loose,
                                armorClassAgg,
                                hardnessAgg,
                                hitPointsAgg,
                                enchantmentAgg)
                                { CallBase = true };
            mockArmor.Setup(a => a.Weight)
                     .Returns(mockWeightFunc.Object);
            var armor = mockArmor.Object;

            // Act
            var result = armor.GetWeight();

            // Assert
            mockWeightFunc.Verify(f => f(),
                                  "Armor.GetWeight() did not call Armor.Weight.  (Where did it get its total from??)");
            Assert.AreEqual(29, result);
        }
        #endregion

        #region GetMarketPrice()
        [Test(Description = "Ensures that Armor.GetMarketPrice() has correct logic.")]
        public void GetMarketPrice()
        {
            // Arrange
            var mockMundanePriceFunc = new Mock<Func<double>>();
            mockMundanePriceFunc.Setup(f => f())
                                .Returns(7);

            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetMarketPrice())
                              .Returns(11);
            var mockArmor = new Mock<Core.Domain.Items.Armor.Armor>(
                                MockBehavior.Loose,
                                armorClassAgg,
                                hardnessAgg,
                                hitPointsAgg,
                                mockEnchantmentAgg.Object)
                                { CallBase = true };
            mockArmor.Setup(a => a.MundaneMarketPrice)
                     .Returns(mockMundanePriceFunc.Object);
            var armor = mockArmor.Object;

            // Act
            var result = armor.GetMarketPrice();

            // Assert
            mockMundanePriceFunc.Verify(f => f(),
                                        "Armor.GetMarketPrice() did not call Armor.MundaneMarketPrice.  (This indicates it isn't using all of the necessary data.)");
            mockEnchantmentAgg.Verify(e => e.GetMarketPrice(),
                                      "Armor.GetMarketPrice() did not call Armor.Enchantments.GetMarketPrice().  (This indicates it isn't using all of the necessary data.)");
            Assert.AreEqual(18, result);
        }
        #endregion

        #region ApplyTo()
        [Test(Description = "Ensures that .ApplyTo(ICharacter) cannot be fed a null ICharacter.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            enchantmentAgg)
                            { CallBase = true }.Object;

            // Act
            TestDelegate applyTo = () => armor.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures that .ApplyTo() applies armor effects to a character correctly.")]
        public void ApplyTo_HappyPath()
        {
            // Arrange
            var penalties20 = Mock.Of<IModifierTracker>();
            var mockMovement20 = new Mock<IMovement>();
            mockMovement20.Setup(m => m.BaseSpeed)
                          .Returns(4);
            mockMovement20.Setup(m => m.Penalties)
                          .Returns(penalties20);
            var penalties30 = Mock.Of<IModifierTracker>();
            var mockMovement30 = new Mock<IMovement>();
            mockMovement30.Setup(m => m.BaseSpeed)
                          .Returns(6);
            mockMovement30.Setup(m => m.Penalties)
                          .Returns(penalties30);
            var mockMovementModes = new Mock<IMovementSection>();
            mockMovementModes.Setup(ms => ms.GetAll())
                             .Returns(new IMovement[] { mockMovement20.Object, mockMovement30.Object });

            var affectedSkillPenalty = Mock.Of<IModifierTracker>();
            var mockAffectedSkill = new Mock<ISkill>();
            mockAffectedSkill.Setup(s => s.ArmorCheckPenaltyApplies)
                             .Returns(true);
            mockAffectedSkill.Setup(s => s.Penalties)
                             .Returns(affectedSkillPenalty);
            var unaffectedSkillPenalty = Mock.Of<IModifierTracker>();
            var mockUnaffectedSkill = new Mock<ISkill>();
            mockUnaffectedSkill.Setup(s => s.ArmorCheckPenaltyApplies)
                             .Returns(false);
            mockUnaffectedSkill.Setup(s => s.Penalties)
                               .Returns(unaffectedSkillPenalty);
            var mockSkillSection = new Mock<ISkillSection>();
            mockSkillSection.Setup(ss => ss.GetAllSkills())
                            .Returns(new ISkill[] { mockUnaffectedSkill.Object, mockAffectedSkill.Object });

            var armorBonus = Mock.Of<IModifierTracker>();

            var maxDexBonus = Mock.Of<IModifierTracker>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockMovementModes.Object);
            mockCharacter.Setup(c => c.Skills)
                         .Returns(mockSkillSection.Object);
            mockCharacter.Setup(c => c.ArmorClass.ArmorBonuses)
                         .Returns(armorBonus);
            mockCharacter.Setup(c => c.ArmorClass.MaxKeyAbilityScore)
                         .Returns(maxDexBonus);
            var character = mockCharacter.Object;

            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var mockArmor = new Mock<Core.Domain.Items.Armor.Armor>(
                                MockBehavior.Loose,
                                armorClassAgg,
                                hardnessAgg,
                                hitPointsAgg,
                                enchantmentAgg)
                                { CallBase = true };
            mockArmor.Setup(a => a.GetArmorBonus())
                     .Returns(5);
            mockArmor.Setup(a => a.GetArmorCheckPenalty())
                     .Returns(2);
            mockArmor.Setup(a => a.GetMaximumDexterityBonus())
                     .Returns(10);
            mockArmor.Setup(a => a.SpeedPenalty)
                     .Returns(.25f);
            
            var armor = mockArmor.Object;

            // Act
            armor.ApplyTo(character);

            // Assert
            Mock.Get(penalties20)
                .Verify(p => p.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Armor with a 25% speed penalty should reduce 4 squares of speed by 1 square.");
            Mock.Get(penalties30)
                .Verify(p => p.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Armor with a 25% speed penalty should reduce 6 squares of speed by 2 squares.");
            Mock.Get(affectedSkillPenalty)
                .Verify(s => s.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Armor with an armor check penalty of 2 should apply a -2 penalty to affected skills.");
            Mock.Get(unaffectedSkillPenalty)
                .Verify(s => s.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Armor should not penalize skills which aren't subject to armor check penalties.");
            Mock.Get(maxDexBonus)
                .Verify(mdb => mdb.Add(It.Is<Func<byte>>(calc => 10 == calc())),
                        "Armor should add its maximum dexterity bonus to a character's ArmorClass.MaxKeyAbilityScore.");
            Mock.Get(armorBonus)
                .Verify(ab => ab.Add(It.Is<Func<byte>>(calc => 5 == calc())),
                        "Armor should add its armor bonus to the character's ArmorClass.ArmorBonus.");
            Mock.Get(enchantmentAgg)
                .Verify(e => e.ApplyTo(It.Is<ICharacter>(c => c == character)),
                        "Armor should attempt to apply the effects of its enchantments to the character.");
        }
        #endregion

        #region GetName()
        [Test(Description = "Ensures that GetName() calculates the name of non-masterwork, non-enchanted armor correctly.")]
        public void GetName_Plain()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var mockArmor = new Mock<Core.Domain.Items.Armor.Armor>(
                                MockBehavior.Loose,
                                armorClassAgg,
                                hardnessAgg,
                                hitPointsAgg,
                                enchantmentAgg)
                                { CallBase = true };
            mockArmor.Setup(a => a.MundaneName)
                     .Returns(() => new INameFragment[] { new NameFragment("fancy armor", "http://example.com") });
            var armor = mockArmor.Object;

            // Act
            var result = armor.GetName();

            // Assert
            Assert.That(result, Is.EquivalentTo(new INameFragment[] { new NameFragment("fancy armor", "http://example.com") }));
            Assert.AreEqual("fancy armor", armor.ToString());
        }


        [Test(Description = "Ensures that GetName() calculates the name of masterwork, non-enchanted armor correctly which is not masterwork by virtue of its material.")]
        public void GetName_Masterwork()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var mockArmor = new Mock<Core.Domain.Items.Armor.Armor>(
                                MockBehavior.Loose,
                                armorClassAgg,
                                hardnessAgg,
                                hitPointsAgg,
                                enchantmentAgg)
                                { CallBase = true };
            mockArmor.Setup(a => a.MundaneName)
                     .Returns(() => new INameFragment[] { new NameFragment("fancy armor", "http://example.com") });
            var armor = mockArmor.Object;
            armor.IsMasterwork = true;

            // Act
            var result = armor.GetName();

            // Assert
            Assert.That(result, Is.EquivalentTo(new INameFragment[] { new NameFragment("Masterwork fancy armor", "http://example.com") }));
            Assert.AreEqual("Masterwork fancy armor", armor.ToString());
        }


        [Test(Description = "Ensures that GetName() calculates the name of masterwork, non-enchanted armor correctly which is masterwork by virtue of its material.")]
        public void GetName_Masterwork_NotToggleable()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var mockArmor = new Mock<Core.Domain.Items.Armor.Armor>(
                                MockBehavior.Loose,
                                armorClassAgg,
                                hardnessAgg,
                                hitPointsAgg,
                                enchantmentAgg) { CallBase = true };
            mockArmor.Setup(a => a.MundaneName)
                     .Returns(() => new INameFragment[] { new NameFragment("material", "http://example.com"), new NameFragment("fancy armor", "http://example.com") });
            var armor = mockArmor.Object;
            armor.IsMasterwork = true;
            armor.MasterworkIsToggleable = false;

            // Act
            var result = armor.GetName();

            // Assert
            Assert.That(result, Is.EquivalentTo(new INameFragment[] { new NameFragment("material", "http://example.com"), new NameFragment("fancy armor", "http://example.com") }));
            Assert.AreEqual("material fancy armor", armor.ToString());
        }


        [Test(Description = "Ensures that GetName() calculates the name of enchanted armor correctly.")]
        public void GetName_Enchanted()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetNames())
                              .Returns((new NameFragment("+5", "http://example.com"), new INameFragment[] { new NameFragment("Amazing", "http://example.com") }));
            var mockArmor = new Mock<Core.Domain.Items.Armor.Armor>(
                                MockBehavior.Loose,
                                armorClassAgg,
                                hardnessAgg,
                                hitPointsAgg,
                                mockEnchantmentAgg.Object)
                                { CallBase = true };
            mockArmor.Setup(a => a.MundaneName)
                     .Returns(() => new INameFragment[] { new NameFragment("material", "http://example.com"), new NameFragment("fancy armor", "http://example.com") });
            var armor = mockArmor.Object;
            armor.IsMasterwork = true;
            armor.MasterworkIsToggleable = false;

            // Act
            var result = armor.GetName();

            // Assert
            Assert.That(result, Is.EquivalentTo(new INameFragment[] {
                new NameFragment("+5", "http://example.com"),
                new NameFragment("Amazing", "http://example.com"),
                new NameFragment("material", "http://example.com"),
                new NameFragment("fancy armor", "http://example.com")
            }));
            Assert.AreEqual("+5 Amazing material fancy armor", armor.ToString());
        }
        #endregion

        #region Enchantment - Enhancement bonus
        [Test(Description = "Ensures that Armor.EnchantWithEnhancementBonus cannot be called if the armor is not masterwork.")]
        public void EnchantWith_EnhancementBonus_NotMasterwork_Throws()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            enchantmentAgg) { CallBase = true }.Object;

            // Act
            TestDelegate enchant = () => armor.EnchantWithEnhancementBonus(3);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant,
                                                     "Armor must be Masterwork for it to be enchanted.");
        }


        [Test(Description = "Ensures that Armor.EnchantWithEnhancementBonus has correct logic.")]
        public void EnchantWith_EnhancementBonus()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var enchantmentAgg = Mock.Of<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            enchantmentAgg)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithEnhancementBonus(3);

            // Assert
            Mock.Get(enchantmentAgg)
                .Verify(agg => agg.EnchantWith(It.Is<EnhancementBonus>(e => 3 == e.SpecialAbilityBonus)),
                        "Armor was not successfully enchanted with +3 enhancement bonus.");
            Assert.IsFalse(armor.MasterworkIsToggleable);
        }
        #endregion

        #region Enchantment - Acid Resistance
        [Test(Description = "Ensures that Armor.EnchantWithAcidResistance has correct logic.")]
        public void EnchantWith_AcidResistance()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithAcidResistance(EnergyResistanceMagnitude.Improved);

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<AcidResistance>()),
                                      "Armor was not successfully enchanted with Acid Resistance.");
        }
        #endregion

        #region Enchantment - Cold Resistance
        [Test(Description = "Ensures that Armor.EnchantWithColdResistance has correct logic.")]
        public void EnchantWith_ColdResistance()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithColdResistance(EnergyResistanceMagnitude.Improved);

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<ColdResistance>()),
                                      "Armor was not successfully enchanted with Cold Resistance.");
        }
        #endregion

        #region Enchantment - Electricity Resistance
        [Test(Description = "Ensures that Armor.EnchantWithElectricityResistance has correct logic.")]
        public void EnchantWith_ElectricityResistance()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithElectricityResistance(EnergyResistanceMagnitude.Improved);

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<ElectricityResistance>()),
                                      "Armor was not successfully enchanted with Electricity Resistance.");
        }
        #endregion

        #region Enchantment - Fire Resistance
        [Test(Description = "Ensures that Armor.EnchantWithFireResistance has correct logic.")]
        public void EnchantWith_FireResistance()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithFireResistance(EnergyResistanceMagnitude.Improved);

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<FireResistance>()),
                                      "Armor was not successfully enchanted with Fire Resistance.");
        }
        #endregion

        #region Enchantment - Sonic Resistance
        [Test(Description = "Ensures that Armor.EnchantWithSonicResistance has correct logic.")]
        public void EnchantWith_SonicResistance()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithSonicResistance(EnergyResistanceMagnitude.Improved);

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<SonicResistance>()),
                                      "Armor was not successfully enchanted with Sonic Resistance.");
        }
        #endregion

        #region Enchantment - Etherealness
        [Test(Description = "Ensures that Armor.EnchantWithEtherealness has correct logic.")]
        public void EnchantWith_Etherealness()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithEtherealness();

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<Etherealness>()),
                                      "Armor was not successfully enchanted with Etherealness.");
        }
        #endregion

        #region Enchantment - Fortification
        [Test(Description = "Ensures that Armor.EnchantWithFortification has correct logic.")]
        public void EnchantWith_Fortification()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithFortification(FortificationType.Medium);

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<Fortification>()),
                                      "Armor was not successfully enchanted with Fortification.");
        }
        #endregion

        #region Enchantment - Ghost Touch
        [Test(Description = "Ensures that Armor.EnchantWithGhostTouch has correct logic.")]
        public void EnchantWith_GhostTouch()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithGhostTouch();

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<GhostTouch>()),
                                      "Armor was not successfully enchanted with Ghost Touch.");
        }
        #endregion

        #region Enchantment - Glamered
        [Test(Description = "Ensures that Armor.EnchantWithGlamered has correct logic.")]
        public void EnchantWith_Glamered()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithGlamered();

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<Glamered>()),
                                      "Armor was not successfully enchanted with Glamered.");
        }
        #endregion

        #region Enchantment - Invulnerability
        [Test(Description = "Ensures that Armor.EnchantWithInvulnerability has correct logic.")]
        public void EnchantWith_Invulnerability()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithInvulnerability(false);

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<Invulnerability>()),
                                      "Armor was not successfully enchanted with Invulnerability.");
        }
        #endregion

        #region Enchantment - Shadow
        [Test(Description = "Ensures that Armor.EnchantWithShadow has correct logic.")]
        public void EnchantWith_Shadow()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithShadow(ShadowStrength.Improved);

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<Shadow>()),
                                      "Armor was not successfully enchanted with Shadow.");
        }
        #endregion

        #region Enchantment - Slick
        [Test(Description = "Ensures that Armor.EnchantWithSlick has correct logic.")]
        public void EnchantWith_Slick()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithSlick(SlickStrength.Improved);

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<Slick>()),
                                      "Armor was not successfully enchanted with Slick.");
        }
        #endregion

        #region Enchantment - Spell Resistance
        [Test(Description = "Ensures that Armor.EnchantWithSpellResistance has correct logic.")]
        public void EnchantWith_SpellResistance()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithSpellResistance(SpellResistanceMagnitude.SR15);

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<SpellResistance>()),
                                      "Armor was not successfully enchanted with Spell Resistance.");
        }
        #endregion

        #region Enchantment - Undead Controlling
        [Test(Description = "Ensures that Armor.EnchantWithUndeadControlling has correct logic.")]
        public void EnchantWith_UndeadControlling()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithUndeadControlling();

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<UndeadControlling>()),
                                      "Armor was not successfully enchanted with Undead Controlling.");
        }
        #endregion

        #region Enchantment - Wild
        [Test(Description = "Ensures that Armor.EnchantWithWild has correct logic.")]
        public void EnchantWith_Wild()
        {
            // Arrange
            var armorClassAgg = Mock.Of<IArmorClassAggregator>();
            var hardnessAgg = Mock.Of<IHardnessAggregator>();
            var hitPointsAgg = Mock.Of<IHitPointsAggregator>();
            var mockEnchantmentAgg = new Mock<IEnchantmentAggregator<IArmorEnchantment, Core.Domain.Items.Armor.Armor>>();
            mockEnchantmentAgg.Setup(e => e.GetEnchantments())
                              .Returns(new IArmorEnchantment[] { new EnhancementBonus(3) });
            var armor = new Mock<Core.Domain.Items.Armor.Armor>(
                            MockBehavior.Loose,
                            armorClassAgg,
                            hardnessAgg,
                            hitPointsAgg,
                            mockEnchantmentAgg.Object)
                            { CallBase = true }.Object;
            armor.IsMasterwork = true;

            // Act
            armor.EnchantWithWild();

            // Assert
            mockEnchantmentAgg.Verify(agg => agg.EnchantWith(It.IsAny<Wild>()),
                                      "Armor was not successfully enchanted with Wild.");
        }
        #endregion
    }
}