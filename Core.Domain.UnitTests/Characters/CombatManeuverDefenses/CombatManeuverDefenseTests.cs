using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ArmorClasses;
using Core.Domain.Characters.AttackBonuses;
using Core.Domain.Characters.CombatManeuverDefenses;
using Core.Domain.Characters.ModifierTrackers;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.CombatManeuverDefenses
{
    [TestFixture]
    public class CombatManeuverDefenseTests
    {
        #region Constructor
        [Test(Description = "Ensures that an instance of CombatManeuverDefense cannot be instanciated with a null ICharacter reference.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new CombatManeuverDefense(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures that a fresh instance of CombatManeuverBonus has sensible default values.")]
        public void Default()
        {
            // Arrange
            ICharacter character = new Mock<ICharacter>().Object;
            CombatManeuverDefense cmd = new CombatManeuverDefense(character);

            // Arrange
            Assert.IsInstanceOf<CircumstanceBonusTracker>(cmd.CircumstanceBonuses);
            Assert.IsInstanceOf<DeflectionBonusTracker>(cmd.DeflectionBonuses);
            Assert.IsInstanceOf<DodgeBonusTracker>(cmd.DodgeBonuses);
            Assert.IsInstanceOf<InsightBonusTracker>(cmd.InsightBonuses);
            Assert.IsInstanceOf<LuckBonusTracker>(cmd.LuckBonuses);
            Assert.IsInstanceOf<MoraleBonusTracker>(cmd.MoraleBonuses);
            Assert.IsInstanceOf<ProfaneBonusTracker>(cmd.ProfaneBonuses);
            Assert.IsInstanceOf<SacredBonusTracker>(cmd.SacredBonuses);
            Assert.IsInstanceOf<UntypedBonusTracker>(cmd.UntypedBonuses);
            Assert.IsInstanceOf<PenaltyTracker>(cmd.Penalties);
        }


        [Test(Description = "Ensures that circumstance bonuses added to ArmorClass are confired to CMD as well.")]
        public void ACBonus_Circumstance()
        {
            // Arrange
            byte acBonus = 10;

            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(acBonus);

            var mockArmorClass = new Mock<IArmorClass>();
            mockArmorClass.Setup(ac => ac.CircumstanceBonuses)
                          .Returns(mockBonusTracker.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass)
                         .Returns(mockArmorClass.Object);

            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var result = cmd.CircumstanceBonuses.GetTotal();

            // Assert
            Assert.AreEqual(acBonus, result,
                           "Circumstance bonuses to AC should also affect CMD.");
        }


        [Test(Description = "Ensures that deflection bonuses added to ArmorClass are confired to CMD as well.")]
        public void ACBonus_Deflection()
        {
            // Arrange
            byte acBonus = 10;

            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(acBonus);

            var mockArmorClass = new Mock<IArmorClass>();
            mockArmorClass.Setup(ac => ac.DeflectionBonuses)
                          .Returns(mockBonusTracker.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass)
                         .Returns(mockArmorClass.Object);

            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var result = cmd.DeflectionBonuses.GetTotal();

            // Assert
            Assert.AreEqual(acBonus, result,
                           "Deflection bonuses to AC should also affect CMD.");
        }


        [Test(Description = "Ensures that dodge bonuses added to ArmorClass are confired to CMD as well.")]
        public void ACBonus_Dodge()
        {
            // Arrange
            byte acBonus = 10;

            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(acBonus);

            var mockArmorClass = new Mock<IArmorClass>();
            mockArmorClass.Setup(ac => ac.DodgeBonuses)
                          .Returns(mockBonusTracker.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass)
                         .Returns(mockArmorClass.Object);

            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var result = cmd.DodgeBonuses.GetTotal();

            // Assert
            Assert.AreEqual(acBonus, result,
                           "Dodge bonuses to AC should also affect CMD.");
        }


        [Test(Description = "Ensures that insight bonuses added to ArmorClass are confired to CMD as well.")]
        public void ACBonus_Insight()
        {
            // Arrange
            byte acBonus = 10;

            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(acBonus);

            var mockArmorClass = new Mock<IArmorClass>();
            mockArmorClass.Setup(ac => ac.InsightBonuses)
                          .Returns(mockBonusTracker.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass)
                         .Returns(mockArmorClass.Object);

            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var result = cmd.InsightBonuses.GetTotal();

            // Assert
            Assert.AreEqual(acBonus, result,
                           "Insight bonuses to AC should also affect CMD.");
        }


        [Test(Description = "Ensures that luck bonuses added to ArmorClass are confired to CMD as well.")]
        public void ACBonus_Luck()
        {
            // Arrange
            byte acBonus = 10;

            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(acBonus);

            var mockArmorClass = new Mock<IArmorClass>();
            mockArmorClass.Setup(ac => ac.LuckBonuses)
                          .Returns(mockBonusTracker.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass)
                         .Returns(mockArmorClass.Object);

            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var result = cmd.LuckBonuses.GetTotal();

            // Assert
            Assert.AreEqual(acBonus, result,
                           "Luck bonuses to AC should also affect CMD.");
        }


        [Test(Description = "Ensures that morale bonuses added to ArmorClass are confired to CMD as well.")]
        public void ACBonus_Morale()
        {
            // Arrange
            byte acBonus = 10;

            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(acBonus);

            var mockArmorClass = new Mock<IArmorClass>();
            mockArmorClass.Setup(ac => ac.MoraleBonuses)
                          .Returns(mockBonusTracker.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass)
                         .Returns(mockArmorClass.Object);

            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var result = cmd.MoraleBonuses.GetTotal();

            // Assert
            Assert.AreEqual(acBonus, result,
                           "Morale bonuses to AC should also affect CMD.");
        }


        [Test(Description = "Ensures that profane bonuses added to ArmorClass are confired to CMD as well.")]
        public void ACBonus_Profane()
        {
            // Arrange
            byte acBonus = 10;

            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(acBonus);

            var mockArmorClass = new Mock<IArmorClass>();
            mockArmorClass.Setup(ac => ac.ProfaneBonuses)
                          .Returns(mockBonusTracker.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass)
                         .Returns(mockArmorClass.Object);

            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var result = cmd.ProfaneBonuses.GetTotal();

            // Assert
            Assert.AreEqual(acBonus, result,
                           "Profane bonuses to AC should also affect CMD.");
        }


        [Test(Description = "Ensures that sacred bonuses added to ArmorClass are confired to CMD as well.")]
        public void ACBonus_Sacred()
        {
            // Arrange
            byte acBonus = 10;

            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(acBonus);

            var mockArmorClass = new Mock<IArmorClass>();
            mockArmorClass.Setup(ac => ac.SacredBonuses)
                          .Returns(mockBonusTracker.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass)
                         .Returns(mockArmorClass.Object);

            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var result = cmd.SacredBonuses.GetTotal();

            // Assert
            Assert.AreEqual(acBonus, result,
                           "Sacred bonuses to AC should also affect CMD.");
        }


        [Test(Description = "Ensures that penalties added to ArmorClass are confired to CMD as well.")]
        public void ACBonus_Penalties()
        {
            // Arrange
            byte penalty = 10;

            var mockBonusTracker = new Mock<IModifierTracker>();
            mockBonusTracker.Setup(bt => bt.GetTotal())
                            .Returns(penalty);

            var mockArmorClass = new Mock<IArmorClass>();
            mockArmorClass.Setup(ac => ac.Penalties)
                          .Returns(mockBonusTracker.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass)
                         .Returns(mockArmorClass.Object);

            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var result = cmd.Penalties.GetTotal();

            // Assert
            Assert.AreEqual(penalty, result,
                           "Penalties to AC should also affect CMD.");
        }
        #endregion

        #region GetSizeModifier()
        [Test(Description = "Ensures the size modifier to CMD is calculated correctly for a small character.")]
        public void GetSizeModifier_Small()
        {
            // Arrange
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);
            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var sizeMod = cmd.GetSizeModifier();

            // Assert
            Assert.AreEqual(-1, sizeMod,
                           "Small characters should have a -1 size modifier to their CMD.");
        }


        [Test(Description = "Ensures the size modifier to CMD is calculated correctly for a medium character.")]
        public void GetSizeModifier_Medium()
        {
            // Arrange
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);
            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var sizeMod = cmd.GetSizeModifier();

            // Assert
            Assert.AreEqual(0, sizeMod,
                           "Medium characters should have a +0 size modifier to their CMD.");
        }


        [Test(Description = "Ensures the size modifier to CMD is calculated correctly for a large character.")]
        public void GetSizeModifier_Large()
        {
            // Arrange
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);
            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var sizeMod = cmd.GetSizeModifier();

            // Assert
            Assert.AreEqual(1, sizeMod,
                           "Large characters should have a +1 size modifier to their CMD.");
        }
        #endregion

        #region GetTotal()
        [Test(Description = "Ensures a plain medium-sized character with +0 BAB has a CMD of 10.")]
        public void GetTotal_Default()
        {
            // Arrange
            var mockBaseAttackBonus = new Mock<IBaseAttackBonus>();
            mockBaseAttackBonus.Setup(bab => bab.GetTotal())
                               .Returns(0);

            var mockAttackBonusesSection = new Mock<IAttackBonusSection>();
            mockAttackBonusesSection.Setup(abs => abs.BaseAttackBonus)
                                    .Returns(mockBaseAttackBonus.Object);

            var mockStrength = new Mock<IAbilityScore>();
            mockStrength.Setup(str => str.GetModifier())
                        .Returns(0);

            var mockDexterity = new Mock<IAbilityScore>();
            mockDexterity.Setup(dex => dex.GetModifier())
                        .Returns(0);

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(mockStrength.Object);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(mockDexterity.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AttackBonuses)
                         .Returns(mockAttackBonusesSection.Object);
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);

            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);

            // Act
            var result = cmd.GetTotal();

            // Assert
            Assert.AreEqual(10, result,
                            "A medium-sized character with +0 BAB, 10 strength, and 10 dexterity should have a CMD of 10.");

        }


        [Test(Description = "Ensures that bonuses and penalties to CMD are aggregated correctly.")]
        public void GetTotal_Aggregates()
        {
            // Arrange
            var mockBaseAttackBonus = new Mock<IBaseAttackBonus>();
            mockBaseAttackBonus.Setup(bab => bab.GetTotal())
                               .Returns(20);

            var mockAttackBonusesSection = new Mock<IAttackBonusSection>();
            mockAttackBonusesSection.Setup(abs => abs.BaseAttackBonus)
                                    .Returns(mockBaseAttackBonus.Object);

            var mockStrength = new Mock<IAbilityScore>();
            mockStrength.Setup(str => str.GetModifier())
                        .Returns(3);

            var mockDexterity = new Mock<IAbilityScore>();
            mockDexterity.Setup(dex => dex.GetModifier())
                        .Returns(2);

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(mockStrength.Object);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(mockDexterity.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AttackBonuses)
                         .Returns(mockAttackBonusesSection.Object);
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);

            CombatManeuverDefense cmd = new CombatManeuverDefense(mockCharacter.Object);
            cmd.CircumstanceBonuses.Add(2);
            cmd.DeflectionBonuses.Add(2);
            cmd.DodgeBonuses.Add(2);
            cmd.InsightBonuses.Add(2);
            cmd.LuckBonuses.Add(2);
            cmd.MoraleBonuses.Add(2);
            cmd.ProfaneBonuses.Add(2);
            cmd.SacredBonuses.Add(2);
            cmd.UntypedBonuses.Add(2);
            cmd.Penalties.Add(10);

            // Act
            var result = cmd.GetTotal();

            // Assert
            Assert.AreEqual(44, result,
                            "44 = 10 + (20 BAB) + (1 large) + (2 dex) + (3 str) + (2 circumstance) + (2 deflection) + (2 dodge) + (2 insight) + (2 luck) + (2 morale) + (2 profane) + (2 sacred) + (2 untyped) - (10 penalties)");

        }
        #endregion
    }
}