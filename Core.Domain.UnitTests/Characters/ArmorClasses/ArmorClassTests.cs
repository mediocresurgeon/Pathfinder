using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ArmorClasses;
using Core.Domain.Characters.ModifierTrackers;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.ArmorClasses
{
    [TestFixture]
    public class ArmorClassTests
    {
        #region Constructor
        [Test(Description = "Ensures that Armor Class cannot be instanciated without an instance of ICharacter.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new ArmorClass(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion


        #region Properties
        [Test(Description = "Ensures sensible defaults for the ArmorClass of a small character.")]
        public void Default()
        {
            // Arrange
            var dexterity = Mock.Of<IAbilityScore>();

            var abilityScores = new Mock<IAbilityScoreSection>();
            abilityScores.Setup(abs => abs.Dexterity)
                         .Returns(dexterity);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(abilityScores.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);

            ArmorClass ac = new ArmorClass(mockCharacter.Object);

            // Assert
            Assert.AreSame(dexterity, ac.KeyAbilityScore);
            Assert.IsInstanceOf<ArmorBonusTracker>(ac.ArmorBonuses);
            Assert.IsInstanceOf<CircumstanceBonusTracker>(ac.CircumstanceBonuses);
            Assert.IsInstanceOf<DeflectionBonusTracker>(ac.DeflectionBonuses);
            Assert.IsInstanceOf<DodgeBonusTracker>(ac.DodgeBonuses);
            Assert.IsInstanceOf<InsightBonusTracker>(ac.InsightBonuses);
            Assert.IsInstanceOf<LuckBonusTracker>(ac.LuckBonuses);
            Assert.IsInstanceOf<MoraleBonusTracker>(ac.MoraleBonuses);
            Assert.IsInstanceOf<NaturalArmorBonusTracker>(ac.NaturalArmorBonuses);
            Assert.IsInstanceOf<NaturalArmorBonusTracker>(ac.NaturalArmorEnhancementBonuses);
            Assert.IsInstanceOf<ProfaneBonusTracker>(ac.ProfaneBonuses);
            Assert.IsInstanceOf<SacredBonusTracker>(ac.SacredBonuses);
            Assert.IsInstanceOf<ShieldBonusTracker>(ac.ShieldBonuses);
            Assert.IsInstanceOf<UntypedBonusTracker>(ac.UntypedBonuses);
            Assert.IsInstanceOf<PenaltyTracker>(ac.Penalties);
        }
        #endregion


        #region Character.Size
        [Test(Description = "Ensures that a small character has correct size bonus an penalty aggregation.")]
        public void SizeBonuses_Small()
        {
            // Arrange
            var dexterity = Mock.Of<IAbilityScore>();

            var abilityScores = new Mock<IAbilityScoreSection>();
            abilityScores.Setup(abs => abs.Dexterity)
                         .Returns(dexterity);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(abilityScores.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);

            ArmorClass ac = new ArmorClass(mockCharacter.Object);

            // Act
            var modifier = ac.GetSizeModifier();

            // Assert
            Assert.AreEqual(1, modifier);
        }


        [Test(Description = "Ensures that a medium character has correct size bonus an penalty aggregation.")]
        public void SizeBonuses_Medium()
        {
            // Arrange
            var dexterity = Mock.Of<IAbilityScore>();

            var abilityScores = new Mock<IAbilityScoreSection>();
            abilityScores.Setup(abs => abs.Dexterity)
                         .Returns(dexterity);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(abilityScores.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);

            ArmorClass ac = new ArmorClass(mockCharacter.Object);

            // Act
            var modifier = ac.GetSizeModifier();

            // Assert
            Assert.AreEqual(0, modifier);
        }


        [Test(Description = "Ensures that a large character has correct size bonus an penalty aggregation.")]
        public void SizeBonuses_Large()
        {
            // Arrange
            var dexterity = Mock.Of<IAbilityScore>();

            var abilityScores = new Mock<IAbilityScoreSection>();
            abilityScores.Setup(abs => abs.Dexterity)
                         .Returns(dexterity);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(abilityScores.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);

            ArmorClass ac = new ArmorClass(mockCharacter.Object);

            // Act
            var modifier = ac.GetSizeModifier();

            // Assert
            Assert.AreEqual(-1, modifier);
        }
        #endregion


        #region Max Dex
        [Test(Description = "Ensures that the MaxDex object has sensible defaults.")]
        public void MaxKeyAbilityScore_Default()
        {
			// Arrange
			var dexterity = Mock.Of<IAbilityScore>();

			var abilityScores = new Mock<IAbilityScoreSection>();
			abilityScores.Setup(abs => abs.Dexterity)
						 .Returns(dexterity);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
						 .Returns(abilityScores.Object);
			mockCharacter.Setup(c => c.Size)
						 .Returns(SizeCategory.Medium);

			ArmorClass ac = new ArmorClass(mockCharacter.Object);

            // Act
            var maxDex = ac.MaxKeyAbilityScore.GetTotal();

            Assert.AreEqual(Byte.MaxValue, maxDex,
                           "By default, an armor class has a max dex of +255.");
        }


		[Test(Description = "Ensures that the MaxDex object aggregates modifiers correctly.")]
		public void MaxKeyAbilityScore_Aggregates()
		{
			// Arrange
			var dexterity = Mock.Of<IAbilityScore>();

			var abilityScores = new Mock<IAbilityScoreSection>();
			abilityScores.Setup(abs => abs.Dexterity)
						 .Returns(dexterity);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
						 .Returns(abilityScores.Object);
			mockCharacter.Setup(c => c.Size)
						 .Returns(SizeCategory.Medium);

			ArmorClass ac = new ArmorClass(mockCharacter.Object);
            ac.MaxKeyAbilityScore.Add(5);
            ac.MaxKeyAbilityScore.Add(1);
            ac.MaxKeyAbilityScore.Add(3);

			// Act
			var maxDex = ac.MaxKeyAbilityScore.GetTotal();

			Assert.AreEqual(1, maxDex,
                            "An armor class has max dex equal to the smallest allowed max dex.  (If there is a max dex of 5, 3, and 1, the actual max dex is 1.)");
		}
        #endregion


        #region GetTotal()
        [Test(Description = "Ensures GetTotal() aggregates bonuses correctly.")]
        public void GetTotal_Aggregates()
        {
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(abs => abs.GetModifier())
                            .Returns(3);

			var abilityScores = new Mock<IAbilityScoreSection>();
			abilityScores.Setup(abs => abs.Dexterity)
                         .Returns(mockAbilityScore.Object);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
						 .Returns(abilityScores.Object);
			mockCharacter.Setup(c => c.Size)
						 .Returns(SizeCategory.Small);

			ArmorClass ac = new ArmorClass(mockCharacter.Object);
            ac.ArmorBonuses.Add(3);
            ac.CircumstanceBonuses.Add(4);
            ac.DeflectionBonuses.Add(5);
            ac.DodgeBonuses.Add(6);
            ac.InsightBonuses.Add(7);
            ac.LuckBonuses.Add(8);
            ac.MoraleBonuses.Add(9);
            ac.NaturalArmorBonuses.Add(10);
            ac.NaturalArmorEnhancementBonuses.Add(11);
            ac.ProfaneBonuses.Add(12);
            ac.SacredBonuses.Add(13);
            ac.ShieldBonuses.Add(14);
            ac.UntypedBonuses.Add(15);
            ac.Penalties.Add(16);
            ac.MaxKeyAbilityScore.Add(2);

            // Act
            var result = ac.GetTotal();

            // Assert
            Assert.AreEqual(114, result,
                            "114 = (10 base) + (3 dex; +2 max dex) + (1 size) + (3 armor) + (4 circumstance) + (5 deflection) + (6 dodge) + (7 insight) + (8 luck) + (9 morale) + (10 natural) + (11 natural enhancement) + (12 profane) + (13 sacred) + (14 shield) + (15 untyped) - (16 penalties)");
        }
        #endregion
    }
}