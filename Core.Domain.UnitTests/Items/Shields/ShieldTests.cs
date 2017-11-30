using System;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.Skills;
using Core.Domain.Items;
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
    public class ShieldTests
    {
        #region Constructor
        [Test(Description = "Ensures that Shield has sensible defaults.")]
        public void Default()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose, (byte)5, 1f, (byte)100, (byte)40) { CallBase = true }.Object;

            // Assert
            Assert.IsFalse(shield.IsMasterwork);
            Assert.IsTrue(shield.MasterworkIsToggleable);
            Assert.IsInstanceOf<ShieldBonusAggregator>(shield.ArmorClass);
            Assert.IsInstanceOf<ShieldEnchantmentAggregator>(shield.Enchantments);
            Assert.IsInstanceOf<ShieldHardnessAggregator>(shield.Hardness);
            Assert.IsInstanceOf<ShieldHitPointAggregator>(shield.HitPoints);
        }


        [Test(Description = "Ensures that the constructor intended to enable dependency injection works as intended.")]
        public void InjectionConstructor_TypicalCase()
        {
            // Arrange
            var shieldAgg = Mock.Of<IShieldBonusAggregator>();
            var hardnessAgg = Mock.Of<IShieldHardnessAggregator>();
            var hitPointAgg = Mock.Of<IShieldHitPointAggregator>();
            var enchantmentAgg = Mock.Of<IShieldEnchantmentAggregator>();

            // Act
            Shield shield = new Mock<Shield>(MockBehavior.Loose, shieldAgg, hardnessAgg, hitPointAgg, enchantmentAgg) { CallBase = true }.Object;

            // Assert
            Assert.AreSame(enchantmentAgg, shield.Enchantments);
            Assert.AreSame(shieldAgg, shield.ArmorClass);
            Assert.AreSame(hardnessAgg, shield.Hardness);
            Assert.AreSame(hitPointAgg, shield.HitPoints);
        }
        #endregion

        #region MasterworkIsToggleable
        [Test(Description = "Ensures that if MasterworkIsToggleable is true, toggling Masterwork will not throw.")]
        public void MasterworkIsToggleable_True_ToggleMasterwork()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;

            // Act
            TestDelegate toggleMasterwork = () => shield.IsMasterwork = !shield.IsMasterwork;

            Assert.DoesNotThrow(toggleMasterwork);
        }


        [Test(Description = "Ensures that if MasterworkIsToggleable is false, toggling Masterwork throws an exception.")]
        public void MasterworkIsToggleable_False_ToggleMasterwork_Throws()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;
            shield.MasterworkIsToggleable = false;

            // Act
            TestDelegate toggleMasterwork = () => shield.IsMasterwork = !shield.IsMasterwork;

            Assert.Throws<InvalidOperationException>(toggleMasterwork,
                                                     "If a shield's masterwork status is not toggleable, changing its masterwork status should throw an exception.");
        }


        [Test(Description = "Ensures that if MasterworkIsToggleable is false, setting IsMasterwork to its original value should not throw an exception.")]
        public void MasterworkIsToggleable_False_NotQuiteToggleMasterwork_Okay()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;
            shield.MasterworkIsToggleable = false;

            // Act
            TestDelegate redundantToggleMasterwork = () => shield.IsMasterwork = shield.IsMasterwork; // Set it to itself

            Assert.DoesNotThrow(redundantToggleMasterwork,
                                "If a shield's masterwork status is not toggleable, setting IsMasterwork to its current value is a redundant command which can be quietly ignored.");
        }
        #endregion

        #region StandardArmorCheckPenaltyCalculation
        [Test(Description = "Ensures that a shield which isn't masterwork has no adjustment to its armor check penalty.")]
        public void StandardArmorCheckPenaltyCalculation_NotMasterwork_SameACP()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;
            // By default, a shield is not masterwork

            // Act
            var result = shield.StandardArmorCheckPenaltyCalculation(5);

            // Assert
            Assert.AreEqual(5, result,
                            "A shield which isn't masterwork should not try to apply an ajustment its to armor check penalty.");
        }


        [Test(Description = "Ensures that a shield which is masterwork has its armor check penalty reduced by 1.")]
        public void StandardArmorCheckPenaltyCalculation_Masterwork_AdjustedACP()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            var result = shield.StandardArmorCheckPenaltyCalculation(5);

            // Assert
            Assert.AreEqual(4, result, "A shield which is masterwork should have its armor check penalty reduced by 1.");
        }


        [Test(Description = @"Ensures that a shield which is masterwork but has a zero armor check penalty
                              does not have its armor check penalty reduced further.")]
        public void StandardArmorCheckPenaltyCalculation_Masterwork_ZeroACP()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            var result = shield.StandardArmorCheckPenaltyCalculation(0);

            // Assert
            Assert.AreEqual(0, result,
                            "A shield which is masterwork but has a base armor check penalty of zero should have a resultant armor check penalty of zero.");
        }
        #endregion

        #region StandardMundaneMarketPriceCalculation
        [Test(Description = "Ensures that a shield which isn't masterwork does not have an adjusted price.")]
        public void StandardMundaneMarketPriceCalculation_NotMasterwork_SamePrice()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;
            // By default, a shield is not masterwork

            // Act
            var result = shield.StandardMundaneMarketPriceCalculation(50);

            // Assert
            Assert.AreEqual(50, result,
                            "A non-masterwork shield should not have its price adjusted.");
        }


        [Test(Description = "Ensures that a shield which is masterwork has an adjusted price.")]
        public void StandardMundaneMarketPriceCalculation_Masterwork_IncreasedPrice()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            var result = shield.StandardMundaneMarketPriceCalculation(50);

            // Assert
            Assert.AreEqual(200, result,
                            "A masterwork shield should have its price adjusted by +150gp.");
        }
        #endregion

        #region GetArmorCheckPenalty()
        [Test(Description = "Ensures that calling Shield.GetArmorCheckPenalty() calls the function returned by Shield.ArmorCheckPenalty.")]
        public void GetArmorCheckPenalty_Calls_ArmorCheckPenalty()
        {
            // Arrange
            Func<byte> armorCheckPenaltyCalculation = () => 5;
            var  mockShield = new Mock<Shield>(MockBehavior.Loose,
                                               Mock.Of<IShieldBonusAggregator>(),
                                               Mock.Of<IShieldHardnessAggregator>(),
                                               Mock.Of<IShieldHitPointAggregator>(),
                                               Mock.Of<IShieldEnchantmentAggregator>())
                                               { CallBase = true };
            mockShield.Setup(s => s.ArmorCheckPenalty)
                      .Returns(armorCheckPenaltyCalculation);
            var shield = mockShield.Object;

            // Act
            var result = shield.GetArmorCheckPenalty();

            // Assert
            mockShield.Verify(s => s.ArmorCheckPenalty,
                              "Shield.GetArmorCheckPenalty() should call Shield.ArmorCheckPenalty at least once to view its results.");
            Assert.AreEqual(5, result);
        }
        #endregion

        #region GetCasterLevel
        [Test(Description = "Ensures that calling Shield.CasterLevel uses the logic from Shield.Enchantments.GetCasterLevel.")]
        public void CasterLevel_Calls_EnchantmentsGetCasterLevel()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(agg => agg.GetCasterLevel())
                            .Returns(20);
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             mockEnchantments.Object)
                                             { CallBase = true }.Object;

            // Act
            var result = shield.CasterLevel;

            // Assert
            mockEnchantments.Verify(agg => agg.GetCasterLevel(),
                                    "Calling Shield.CasterLevel should call Shield.Enchantments.GetCasterLevel() at least once to view their results.");
            Assert.AreEqual(20, result);
        }
        #endregion

        #region GetSchools()
        [Test(Description = "Ensures that calling Shield.GetSchools() uses the logic from Shield.Enchantments.GetSchools().")]
        public void GetSchools_Calls_EnchantmentsGetSchools()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(agg => agg.GetSchools())
                            .Returns(new School[] { School.Divination, School.Necromancy });
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             mockEnchantments.Object)
                                             { CallBase = true }.Object;

            // Act
            var result = shield.GetSchools();

            // Assert
            mockEnchantments.Verify(agg => agg.GetSchools(),
                                    "Calling Shield.GetSchools() should call Shield.Enchantments.GetSchools() at least once to view their results.");
            Assert.AreEqual(2, result.Length);
            Assert.Contains(School.Divination, result);
            Assert.Contains(School.Necromancy, result);
        }
        #endregion

        #region GetHardness()
        [Test(Description = "Ensures that calling Shield.GetHardness() uses the logic from Shield.Hardness.GetTotal().")]
        public void GetHardness_CallsHardnessGetTotal()
        {
            // Arrange
            var mockHardness = new Mock<IShieldHardnessAggregator>();
            mockHardness.Setup(agg => agg.GetTotal())
                            .Returns(17);
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             mockHardness.Object,
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;

            // Act
            var result = shield.GetHardness();

            // Assert
            mockHardness.Verify(agg => agg.GetTotal(),
                                "Calling Shield.GetHardness() should call Shield.Hardness.GetTotal() at least once.");
            Assert.AreEqual(17, result);
        }
        #endregion

        #region GetHitPoints()
        [Test(Description = "Ensures that calling Shield.GetHitPoints() uses the logic from Shield.HitPoints.GetTotal().")]
        public void GetHitPoints_CallsHitPointsGetTotal()
        {
            // Arrange
            var mockHitPoints = new Mock<IShieldHitPointAggregator>();
            mockHitPoints.Setup(agg => agg.GetTotal())
                         .Returns(17);
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             mockHitPoints.Object,
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;

            // Act
            var result = shield.GetHitPoints();

            // Assert
            mockHitPoints.Verify(agg => agg.GetTotal(),
                                 "Calling Shield.GetHitPoints() should call Shield.HitPoints.GetTotal() at least once.");
            Assert.AreEqual(17, result);
        }
        #endregion

        #region GetMarketPrice()
        [Test(Description = "Ensures that calling Shield.GetMarketPrice() uses the logic from Shield.MundaneMarketPrice and Shield.Enchantments.Get")]
        public void GetMarketPrice_AggregatesFromMundaneMarketPriceAndEnchantments()
        {
            // Arrange
            Func<double> mundanePrice = () => 997;
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(agg => agg.GetMarketPrice())
                            .Returns(991);
            var mockShield = new Mock<Shield>(MockBehavior.Loose,
                                              Mock.Of<IShieldBonusAggregator>(),
                                              Mock.Of<IShieldHardnessAggregator>(),
                                              Mock.Of<IShieldHitPointAggregator>(),
                                              mockEnchantments.Object)
                                              { CallBase = true };
            mockShield.Setup(s => s.MundaneMarketPrice)
                      .Returns(mundanePrice);

            var shield = mockShield.Object;

            // Act
            var result = shield.GetMarketPrice();

            // Assert
            mockEnchantments.Verify(e => e.GetMarketPrice(),
                                    "Calling Shield.GetMarketPrice() should call Shield.Enchantments.GetMarketPrice() at leaste once.");
            mockShield.Verify(s => s.MundaneMarketPrice,
                              "Calling Shield.GetMarketPrice() should call Shield.MundaneMarketPrice at least once.");
            Assert.AreEqual(1988, result,
                            "Shield.GetMarketPrice() should return the sum of Shield.Enchantments.GetMarketPrice() and Shield.MundaneMarketPrice().");
        }
        #endregion

        #region GetShieldBonus()
        [Test(Description = "Ensures that calling Shield.GetShieldBonus() uses the logic from Shield.ArmorClass.GetTotal().")]
        public void GetShieldBonus_CallsArmorClassGetTotal()
        {
            // Arrange
            var mockShieldBonus = new Mock<IShieldBonusAggregator>();
            mockShieldBonus.Setup(agg => agg.GetTotal())
                           .Returns(7);
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             mockShieldBonus.Object,
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;

            // Act
            var result = shield.GetShieldBonus();

            // Assert
            mockShieldBonus.Verify(agg => agg.GetTotal(),
                                 "Calling Shield.GetShieldBonus() should call Shield.ArmorClass.GetTotal() at least once.");
            Assert.AreEqual(7, result);
        }
        #endregion

        #region GetName() and ToString()
        [Test(Description = "Ensures that non-masterwork shields have correct names.")]
        public void BuildName_NotMasterwork_NoMaterial_NoEnchantments()
        {
            // Arrange
            var mockNameFragment = new Mock<INameFragment>();
            mockNameFragment.Setup(nf => nf.Text)
                            .Returns("shield name");
            mockNameFragment.Setup(nf => nf.WebAddress)
                            .Returns("http://shieldUrl.com");
            Func<INameFragment[]> nameBuilder = () => new INameFragment[] { mockNameFragment.Object };

            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetNames())
                            .Returns((null, new INameFragment[0]));

            var mockShield = new Mock<Shield>(MockBehavior.Loose,
                                              Mock.Of<IShieldBonusAggregator>(),
                                              Mock.Of<IShieldHardnessAggregator>(),
                                              Mock.Of<IShieldHitPointAggregator>(),
                                              mockEnchantments.Object)
                                              { CallBase = true };
            mockShield.Setup(s => s.MundaneName)
                      .Returns(nameBuilder);

            var shield = mockShield.Object;

            // Act
            var result = shield.GetName();

            // Assert
            mockShield.Verify(agg => agg.MundaneName,
                                 "Calling Shield.GetName() should call Shield.MundaneName at least once.");
            mockEnchantments.Verify(agg => agg.GetNames(),
                                    "Calling Shield.GetName() should call Shield.Enchantments.GetNames() at least once.");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("shield name", result[0].Text);
            Assert.AreEqual("http://shieldUrl.com", result[0].WebAddress);
            Assert.AreEqual("shield name", shield.ToString());
        }


        [Test(Description = "Ensures that masterwork shields have correct names.")]
        public void BuildName_Masterwork_NoMaterial_NoEnchantments()
        {
            // Arrange
            var mockNameFragment = new Mock<INameFragment>();
            mockNameFragment.Setup(nf => nf.Text)
                            .Returns("shield name");
            mockNameFragment.Setup(nf => nf.WebAddress)
                            .Returns("http://shieldUrl.com");
            Func<INameFragment[]> nameBuilder = () => new INameFragment[] { mockNameFragment.Object };

            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetNames())
                            .Returns((null, new INameFragment[0]));

            var mockShield = new Mock<Shield>(MockBehavior.Loose,
                                              Mock.Of<IShieldBonusAggregator>(),
                                              Mock.Of<IShieldHardnessAggregator>(),
                                              Mock.Of<IShieldHitPointAggregator>(),
                                              mockEnchantments.Object)
                                              { CallBase = true };
            mockShield.Setup(s => s.MundaneName)
                      .Returns(nameBuilder);
            
            var shield = mockShield.Object;
            shield.IsMasterwork = true;

            // Act
            var result = shield.GetName();

            // Assert
            mockShield.Verify(agg => agg.MundaneName,
                                 "Calling Shield.GetName() should call Shield.MundaneName at least once.");
            mockEnchantments.Verify(agg => agg.GetNames(),
                                    "Calling Shield.GetName() should call Shield.Enchantments.GetNames() at least once.");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("Masterwork shield name", result[0].Text);
            Assert.AreEqual("http://shieldUrl.com", result[0].WebAddress);
            Assert.AreEqual("Masterwork shield name", shield.ToString());
        }


        [Test(Description = "Ensures that non-masterwork shields with special materials have correct names.")]
        public void BuildName_NotMasterwork_HasMaterial_NoEnchantments()
        {
            // Arrange
            var mockMaterialName = new Mock<INameFragment>();
            mockMaterialName.Setup(nf => nf.Text)
                            .Returns("material");
            mockMaterialName.Setup(nf => nf.WebAddress)
                            .Returns("http://materialUrl.com");
            var mockShieldName = new Mock<INameFragment>();
            mockShieldName.Setup(nf => nf.Text)
                          .Returns("shield name");
            mockShieldName.Setup(nf => nf.WebAddress)
                          .Returns("http://shieldUrl.com");

            Func<INameFragment[]> nameBuilder = () => new INameFragment[] { mockMaterialName.Object, mockShieldName.Object };

            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetNames())
                            .Returns((null, new INameFragment[0]));

            var mockShield = new Mock<Shield>(MockBehavior.Loose,
                                              Mock.Of<IShieldBonusAggregator>(),
                                              Mock.Of<IShieldHardnessAggregator>(),
                                              Mock.Of<IShieldHitPointAggregator>(),
                                              mockEnchantments.Object)
                                              { CallBase = true };
            mockShield.Setup(s => s.MundaneName)
                      .Returns(nameBuilder);

            var shield = mockShield.Object;

            // Act
            var result = shield.GetName();

            // Assert
            mockShield.Verify(agg => agg.MundaneName,
                                 "Calling Shield.GetName() should call Shield.MundaneName at least once.");
            mockEnchantments.Verify(agg => agg.GetNames(),
                                    "Calling Shield.GetName() should call Shield.Enchantments.GetNames() at least once.");
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("material", result[0].Text);
            Assert.AreEqual("http://materialUrl.com", result[0].WebAddress);
            Assert.AreEqual("shield name", result[1].Text);
            Assert.AreEqual("http://shieldUrl.com", result[1].WebAddress);
            Assert.AreEqual("material shield name", shield.ToString());
        }


        [Test(Description = "Ensures that masterwork shields with special materials have correct names.")]
        public void BuildName_Masterwork_HasMaterial_NoEnchantments()
        {
            // Arrange
            var mockMaterialName = new Mock<INameFragment>();
            mockMaterialName.Setup(nf => nf.Text)
                            .Returns("material");
            mockMaterialName.Setup(nf => nf.WebAddress)
                            .Returns("http://materialUrl.com");
            var mockShieldName = new Mock<INameFragment>();
            mockShieldName.Setup(nf => nf.Text)
                          .Returns("shield name");
            mockShieldName.Setup(nf => nf.WebAddress)
                          .Returns("http://shieldUrl.com");

            Func<INameFragment[]> nameBuilder = () => new INameFragment[] { mockMaterialName.Object, mockShieldName.Object };

            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetNames())
                            .Returns((null, new INameFragment[0]));

            var mockShield = new Mock<Shield>(MockBehavior.Loose,
                                              Mock.Of<IShieldBonusAggregator>(),
                                              Mock.Of<IShieldHardnessAggregator>(),
                                              Mock.Of<IShieldHitPointAggregator>(),
                                              mockEnchantments.Object)
                                              { CallBase = true };
            mockShield.Setup(s => s.MundaneName)
                      .Returns(nameBuilder);

            var shield = mockShield.Object;
            shield.IsMasterwork = true;

            // Act
            var result = shield.GetName();

            // Assert
            mockShield.Verify(agg => agg.MundaneName,
                                 "Calling Shield.GetName() should call Shield.MundaneName at least once.");
            mockEnchantments.Verify(agg => agg.GetNames(),
                                    "Calling Shield.GetName() should call Shield.Enchantments.GetNames() at least once.");
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("Masterwork material", result[0].Text);
            Assert.AreEqual("http://materialUrl.com", result[0].WebAddress);
            Assert.AreEqual("shield name", result[1].Text);
            Assert.AreEqual("http://shieldUrl.com", result[1].WebAddress);
            Assert.AreEqual("Masterwork material shield name", shield.ToString());
        }


        [Test(Description = "Ensures that shields with special materials which are always masterwork have correct names.")]
        public void BuildName_ReqMasterwork_HasMaterial_NoEnchantments()
        {
            // Arrange
            var mockMaterialName = new Mock<INameFragment>();
            mockMaterialName.Setup(nf => nf.Text)
                            .Returns("material");
            mockMaterialName.Setup(nf => nf.WebAddress)
                            .Returns("http://materialUrl.com");
            var mockShieldName = new Mock<INameFragment>();
            mockShieldName.Setup(nf => nf.Text)
                          .Returns("shield name");
            mockShieldName.Setup(nf => nf.WebAddress)
                          .Returns("http://shieldUrl.com");

            Func<INameFragment[]> nameBuilder = () => new INameFragment[] { mockMaterialName.Object, mockShieldName.Object };

            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetNames())
                            .Returns((null, new INameFragment[0]));

            var mockShield = new Mock<Shield>(MockBehavior.Loose,
                                              Mock.Of<IShieldBonusAggregator>(),
                                              Mock.Of<IShieldHardnessAggregator>(),
                                              Mock.Of<IShieldHitPointAggregator>(),
                                              mockEnchantments.Object)
                                              { CallBase = true };
            mockShield.Setup(s => s.MundaneName)
                      .Returns(nameBuilder);

            var shield = mockShield.Object;
            shield.IsMasterwork = true;
            shield.MasterworkIsToggleable = false;

            // Act
            var result = shield.GetName();

            // Assert
            mockShield.Verify(agg => agg.MundaneName,
                              "Calling Shield.GetName() should call Shield.MundaneName at least once.");
            mockEnchantments.Verify(agg => agg.GetNames(),
                                    "Calling Shield.GetName() should call Shield.Enchantments.GetNames() at least once.");
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("material", result[0].Text);
            Assert.AreEqual("http://materialUrl.com", result[0].WebAddress);
            Assert.AreEqual("shield name", result[1].Text);
            Assert.AreEqual("http://shieldUrl.com", result[1].WebAddress);
            Assert.AreEqual("material shield name", shield.ToString());
        }


        [Test(Description = "Ensures that shields with special materials and an enhancement bonus have correct names.")]
        public void BuildName_HasMaterial_EnhancementBonus()
        {
            // Arrange
            var mockMaterialName = new Mock<INameFragment>();
            mockMaterialName.Setup(nf => nf.Text)
                            .Returns("material");
            mockMaterialName.Setup(nf => nf.WebAddress)
                            .Returns("http://materialUrl.com");
            var mockShieldName = new Mock<INameFragment>();
            mockShieldName.Setup(nf => nf.Text)
                          .Returns("shield name");
            mockShieldName.Setup(nf => nf.WebAddress)
                          .Returns("http://shieldUrl.com");

            Func<INameFragment[]> nameBuilder = () => new INameFragment[] { mockMaterialName.Object, mockShieldName.Object };

            var mockEnhancementBonusName = new Mock<INameFragment>();
            mockEnhancementBonusName.Setup(nf => nf.Text)
                                    .Returns("+1");
            mockEnhancementBonusName.Setup(nf => nf.WebAddress)
                                    .Returns("http://enhancementBonusUrl.com");

            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetNames())
                            .Returns((mockEnhancementBonusName.Object, new INameFragment[0]));

            var mockShield = new Mock<Shield>(MockBehavior.Loose,
                                              Mock.Of<IShieldBonusAggregator>(),
                                              Mock.Of<IShieldHardnessAggregator>(),
                                              Mock.Of<IShieldHitPointAggregator>(),
                                              mockEnchantments.Object)
                                              { CallBase = true };
            mockShield.Setup(s => s.MundaneName)
                      .Returns(nameBuilder);

            var shield = mockShield.Object;
            shield.IsMasterwork = true;
            shield.MasterworkIsToggleable = false;

            // Act
            var result = shield.GetName();

            // Assert
            mockShield.Verify(agg => agg.MundaneName,
                              "Calling Shield.GetName() should call Shield.MundaneName at least once.");
            mockEnchantments.Verify(agg => agg.GetNames(),
                                    "Calling Shield.GetName() should call Shield.Enchantments.GetNames() at least once.");
            Assert.AreEqual(3, result.Length);

            Assert.AreEqual("+1", result[0].Text);
            Assert.AreEqual("http://enhancementBonusUrl.com", result[0].WebAddress);
            Assert.AreEqual("material", result[1].Text);
            Assert.AreEqual("http://materialUrl.com", result[1].WebAddress);
            Assert.AreEqual("shield name", result[2].Text);
            Assert.AreEqual("http://shieldUrl.com", result[2].WebAddress);
            Assert.AreEqual("+1 material shield name", shield.ToString());
        }


        [Test(Description = "Ensures that shields with special materials and multiple enchantments have correct names.")]
        public void BuildName_HasMaterial_MultipleEnchantments()
        {
            // Arrange
            var mockMaterialName = new Mock<INameFragment>();
            mockMaterialName.Setup(nf => nf.Text)
                            .Returns("material");
            mockMaterialName.Setup(nf => nf.WebAddress)
                            .Returns("http://materialUrl.com");
            var mockShieldName = new Mock<INameFragment>();
            mockShieldName.Setup(nf => nf.Text)
                          .Returns("shield name");
            mockShieldName.Setup(nf => nf.WebAddress)
                          .Returns("http://shieldUrl.com");

            Func<INameFragment[]> nameBuilder = () => new INameFragment[] { mockMaterialName.Object, mockShieldName.Object };

            var mockEnhancementBonusName = new Mock<INameFragment>();
            mockEnhancementBonusName.Setup(nf => nf.Text)
                                    .Returns("+1");
            mockEnhancementBonusName.Setup(nf => nf.WebAddress)
                                    .Returns("http://enhancementBonusUrl.com");

            var mockEnchantmentName = new Mock<INameFragment>();
            mockEnchantmentName.Setup(nf => nf.Text)
                               .Returns("enchantment");
            mockEnchantmentName.Setup(nf => nf.WebAddress)
                               .Returns("http://enchantmentUrl.com");

            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetNames())
                            .Returns((mockEnhancementBonusName.Object, new INameFragment[] { mockEnchantmentName.Object }));

            var mockShield = new Mock<Shield>(MockBehavior.Loose,
                                              Mock.Of<IShieldBonusAggregator>(),
                                              Mock.Of<IShieldHardnessAggregator>(),
                                              Mock.Of<IShieldHitPointAggregator>(),
                                              mockEnchantments.Object)
                                              { CallBase = true };
            mockShield.Setup(s => s.MundaneName)
                      .Returns(nameBuilder);

            var shield = mockShield.Object;
            shield.IsMasterwork = true;
            shield.MasterworkIsToggleable = false;

            // Act
            var result = shield.GetName();

            // Assert
            mockShield.Verify(agg => agg.MundaneName,
                              "Calling Shield.GetName() should call Shield.MundaneName at least once.");
            mockEnchantments.Verify(agg => agg.GetNames(),
                                    "Calling Shield.GetName() should call Shield.Enchantments.GetNames() at least once.");
            Assert.AreEqual(4, result.Length);

            Assert.AreEqual("+1", result[0].Text);
            Assert.AreEqual("http://enhancementBonusUrl.com", result[0].WebAddress);
            Assert.AreEqual("enchantment", result[1].Text);
            Assert.AreEqual("http://enchantmentUrl.com", result[1].WebAddress);
            Assert.AreEqual("material", result[2].Text);
            Assert.AreEqual("http://materialUrl.com", result[2].WebAddress);
            Assert.AreEqual("shield name", result[3].Text);
            Assert.AreEqual("http://shieldUrl.com", result[3].WebAddress);
            Assert.AreEqual("+1 enchantment material shield name", shield.ToString());
        }
        #endregion

        #region ApplyTo(ICharacter)
        [Test(Description = "Ensures that a Shield cannot be applied to a null ICharacter.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            Shield shield = new Mock<Shield>(MockBehavior.Loose,
                                             Mock.Of<IShieldBonusAggregator>(),
                                             Mock.Of<IShieldHardnessAggregator>(),
                                             Mock.Of<IShieldHitPointAggregator>(),
                                             Mock.Of<IShieldEnchantmentAggregator>())
                                             { CallBase = true }.Object;
            ICharacter character = null;

            // Act
            TestDelegate applyTo = () => shield.ApplyTo(character);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures that applying a Shield affects an ICharacter's armor class.")]
        public void ApplyTo_ICharacter_ShieldBonusToAC()
        {
            // Arrange
            var shieldBonus = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass.ShieldBonuses)
                         .Returns(shieldBonus);

            var mockShield = new Mock<Shield>(MockBehavior.Loose,
                                              Mock.Of<IShieldBonusAggregator>(),
                                              Mock.Of<IShieldHardnessAggregator>(),
                                              Mock.Of<IShieldHitPointAggregator>(),
                                              Mock.Of<IShieldEnchantmentAggregator>())
                                              { CallBase = true };
            mockShield.Setup(s => s.GetShieldBonus())
                      .Returns(10);
            var shield = mockShield.Object;

            // Act
            shield.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(shieldBonus)
                .Verify(sb => sb.Add(It.Is<Func<byte>>(calc => 10 == calc())),
                        "Applying a shield to an ICharacter should add the shield's shield bonus to the character's armor class.");
        }


        [Test(Description = "Ensures that applying a Shield affects an ICharacter's skills.")]
        [Parallelizable]
        public void ApplyTo_ICharacter_ArmorCheckPenaltyToSkills()
        {
            // Arrange
            var unaffectedPenalty = Mock.Of<IModifierTracker>();
            var mockUnaffectedSkill = new Mock<ISkill>();
            mockUnaffectedSkill.Setup(s => s.Penalties)
                               .Returns(unaffectedPenalty);
            mockUnaffectedSkill.Setup(s => s.ArmorCheckPenaltyApplies)
                                      .Returns(false);

            var affectedPenalty = Mock.Of<IModifierTracker>();
            var mockAffectedSkill = new Mock<ISkill>();
            mockAffectedSkill.Setup(s => s.Penalties)
                             .Returns(affectedPenalty);
            mockAffectedSkill.Setup(s => s.ArmorCheckPenaltyApplies)
                                      .Returns(true);

            var shieldBonus = Mock.Of<IModifierTracker>();
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Skills.GetAllSkills())
                         .Returns(new ISkill[] { mockUnaffectedSkill.Object, mockAffectedSkill.Object });

            var mockShield = new Mock<Shield>(MockBehavior.Loose,
                                              Mock.Of<IShieldBonusAggregator>(),
                                              Mock.Of<IShieldHardnessAggregator>(),
                                              Mock.Of<IShieldHitPointAggregator>(),
                                              Mock.Of<IShieldEnchantmentAggregator>())
                                              { CallBase = true };
            mockShield.Setup(s => s.GetArmorCheckPenalty())
                      .Returns(5);
            var shield = mockShield.Object;

            // Act
            shield.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(unaffectedPenalty)
                .Verify(p => p.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Skills where an armor check penalty does not apply should not be affected by a shield's armor check penalty.");
            Mock.Get(affectedPenalty)
                .Verify(p => p.Add(It.Is<Func<byte>>(calc => 5 == calc())),
                        "Armor check penalty skills should be affected by a shield's armor check penalty.");
        }


        [Test(Description = "Ensures that applying a Shield to a Character notifies any enchantments in the shield that they need to be applied to the character as well.")]
        public void ApplyTo_ICharacter_Enchantments()
        {
            // Arrange

            var enchantmentAggregator = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantmentAggregator)
                                          { CallBase = true }.Object;
            var character = Mock.Of<ICharacter>();

            // Act
            shield.ApplyTo(character);

            // Assert
            Mock.Get(enchantmentAggregator)
                .Verify(agg => agg.ApplyTo(It.Is<ICharacter>(input => character == input)),
                        "Calling Shield.ApplyTo(ICharacter) should call this shield's Enchantments.ApplyTo(ICharacter) method, passing in the same ICharacter as an argument.");
        }
        #endregion
    
        #region Enchantment - Enhancement Bonus
        [Test(Description = "Ensures that a shield cannot have a magical enhancement bonus if it is not masterwork.")]
        public void EnchantWith_EnhancementBonus_NotMasterwork_Throws()
        {
            // Arrange
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          Mock.Of<IShieldEnchantmentAggregator>())
                                          { CallBase = true }.Object;

            // Act
            TestDelegate enchant = () => shield.EnchantWithEnhancementBonus(1);

            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures that a shield cannot have a magical enhancement bonus of less than 1.")]
        public void EnchantWith_EnhancementBonus_Zero_Throws()
        {
            // Arrange
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          Mock.Of<IShieldEnchantmentAggregator>())
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithEnhancementBonus(0);

            Assert.Throws<ArgumentOutOfRangeException>(enchant);
        }


        [Test(Description = "Ensures that a shield cannot have a magical enhancement bonus of more than 5.")]
        public void EnchantWith_EnhancementBonus_Six_Throws()
        {
            // Arrange
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          Mock.Of<IShieldEnchantmentAggregator>())
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithEnhancementBonus(6);

            Assert.Throws<ArgumentOutOfRangeException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with a +1 enhancement bonus.")]
        public void EnchantWith_EnhancementBonus_1()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithEnhancementBonus(1);

            // Assert
            Mock.Get(enchantments)
                .Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is EnhancementBonus
                                                                     && 1 == ench.SpecialAbilityBonus)),
                        "Enchanting a shield with a +1 Enhancement Bonus should store an EnhancementBonus object inside of the SHield.Enchantments object.");
            Assert.IsFalse(shield.MasterworkIsToggleable,
                           "Enchanting a shield should prevent the shield's masterwork status from being revoked.");
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with a +5 enhancement bonus.")]
        public void EnchantWith_EnhancementBonus_5()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithEnhancementBonus(5);

            // Assert
            Mock.Get(enchantments)
                .Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is EnhancementBonus
                                                                     && 5 == ench.SpecialAbilityBonus)),
                        "Enchanting a shield with a +5 Enhancement Bonus should store an EnhancementBonus object inside of the SHield.Enchantments object.");
            Assert.IsFalse(shield.MasterworkIsToggleable,
                           "Enchanting a shield should prevent the shield's masterwork status from being revoked.");
        }
        #endregion

        #region Enchantment - Acid Resistance
        [Test(Description = "Ensures that Acid Resistance cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_AcidResistance_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithAcidResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Acid Resistance.")]
        public void EnchantWith_AcidResistance_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithAcidResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is AcidResistance)));
        }
        #endregion

        #region Enchantment - Animated
        [Test(Description = "Ensures that Animated cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_Animated_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithAnimated();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Animated.")]
        public void EnchantWith_Animated_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithAnimated();

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is Animated)));
        }
        #endregion

        #region Enchantment - Arrow Catching
        [Test(Description = "Ensures that Arrow Catching cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_ArrowCatching_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithAnimated();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Arrow Catching.")]
        public void EnchantWith_ArrowCatching_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithArrowCatching();

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is ArrowCatching)));
        }
        #endregion

        #region Enchantment - Arrow Deflection
        [Test(Description = "Ensures that Arrow Deflection cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_ArrowDeflection_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithArrowDeflection();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Arrow Deflection.")]
        public void EnchantWith_ArrowDeflection_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithArrowDeflection();

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is ArrowDeflection)));
        }
        #endregion

        #region Enchantment - Blinding
        [Test(Description = "Ensures that Blinding cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_Blinding_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithBlinding();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Blinding.")]
        public void EnchantWith_Blinding_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithBlinding();

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is Blinding)));
        }
        #endregion

        #region Enchantment - Cold Resistance
        [Test(Description = "Ensures that Cold Resistance cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_ColdResistance_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithColdResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Cold Resistance.")]
        public void EnchantWith_ColdResistance_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithColdResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is ColdResistance)));
        }
        #endregion

        #region Enchantment - Electricity Resistance
        [Test(Description = "Ensures that Electricity Resistance cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_ElectricityResistance_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithElectricityResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Electricity Resistance.")]
        public void EnchantWith_ElectricityResistance_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithElectricityResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is ElectricityResistance)));
        }
        #endregion

        #region Enchantment - Fire Resistance
        [Test(Description = "Ensures that Fire Resistance cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_FireResistance_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithFireResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Fire Resistance.")]
        public void EnchantWith_FireResistance_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithFireResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is FireResistance)));
        }
        #endregion

        #region Enchantment - Fortification
        [Test(Description = "Ensures that Fortification cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_Fortification_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithFortification(FortificationType.Light);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Fortification.")]
        public void EnchantWith_Fortification_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithFortification(FortificationType.Light);

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is Fortification)));
        }
        #endregion

        #region Enchantment - Ghost Touch
        [Test(Description = "Ensures that Ghost Touch cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_GhostTouch_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithGhostTouch();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Ghost Touch.")]
        public void EnchantWith_GhostTouch_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithGhostTouch();

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is GhostTouch)));
        }
        #endregion

        #region Enchantment - Sonic Resistance
        [Test(Description = "Ensures that Sonic Resistance cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_SonicResistance_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithSonicResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Sonic Resistance.")]
        public void EnchantWith_SonicResistance_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithSonicResistance(EnergyResistanceMagnitude.Regular);

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is SonicResistance)));
        }
        #endregion

        #region Enchantment - Spell Resistance
        [Test(Description = "Ensures that SpellResistance cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_SpellResistance_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithSpellResistance(SpellResistanceMagnitude.SR13);

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Spell Resistance.")]
        public void EnchantWith_SpellResistance_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithSpellResistance(SpellResistanceMagnitude.SR13);

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is SpellResistance)));
        }
        #endregion

        #region Enchantment - Reflecting
        [Test(Description = "Ensures that Reflecting cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_Reflecting_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithReflecting();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Reflecting.")]
        public void EnchantWith_Reflecting_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithReflecting();

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is Reflecting)));
        }
        #endregion

        #region Enchantment - Undead Controlling
        [Test(Description = "Ensures that Undead Controlling cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_UndeadControlling_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithUndeadControlling();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Undead Controlling.")]
        public void EnchantWith_UndeadControlling_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithUndeadControlling();

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is UndeadControlling)));
        }
        #endregion

        #region Enchantment - Wild
        [Test(Description = "Ensures that Wild cannot be added to a shield lacking an enhancement bonus.")]
        public void EnchantWith_Wild_NoEnhancement_Throws()
        {
            // Arrange
            var enchantments = Mock.Of<IShieldEnchantmentAggregator>();
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          enchantments)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            TestDelegate enchant = () => shield.EnchantWithWild();

            // Assert
            Assert.Throws<InvalidOperationException>(enchant);
        }


        [Test(Description = "Ensures correct behavior for a shield enchanted with Wild.")]
        public void EnchantWith_Wild_HappyPath()
        {
            // Arrange
            var mockEnchantments = new Mock<IShieldEnchantmentAggregator>();
            mockEnchantments.Setup(e => e.GetEnchantments())
                            .Returns(new IShieldEnchantment[] { new EnhancementBonus(1) });
            var shield = new Mock<Shield>(MockBehavior.Loose,
                                          Mock.Of<IShieldBonusAggregator>(),
                                          Mock.Of<IShieldHardnessAggregator>(),
                                          Mock.Of<IShieldHitPointAggregator>(),
                                          mockEnchantments.Object)
                                          { CallBase = true }.Object;
            shield.IsMasterwork = true;

            // Act
            shield.EnchantWithWild();

            // Assert
            mockEnchantments.Verify(e => e.EnchantWith(It.Is<IShieldEnchantment>(ench => ench is Wild)));
        }
        #endregion
    }
}