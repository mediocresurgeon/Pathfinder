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
            IAbilityScore dexterity = new Mock<IAbilityScore>().Object;

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
            Assert.IsInstanceOf<DeflectionBonusTracker>(ac.DeflectionBonuses);
            Assert.IsInstanceOf<DodgeBonusTracker>(ac.DodgeBonuses);
            Assert.IsInstanceOf<NaturalArmorBonusTracker>(ac.NaturalArmorBonuses);
            Assert.IsInstanceOf<NaturalArmorBonusTracker>(ac.NaturalArmorEnhancementBonuses);
            Assert.IsInstanceOf<ShieldBonusTracker>(ac.ShieldBonuses);
            Assert.IsInstanceOf<SizeBonusTracker>(ac.SizeBonuses);
            Assert.IsInstanceOf<UntypedBonusTracker>(ac.UntypedBonuses);
            Assert.IsInstanceOf<PenaltyTracker>(ac.Penalties);
        }
        #endregion


        #region Character.Size
        [Test(Description = "Ensures that a small character has correct size bonus an penalty aggregation.")]
        public void SizeBonuses_Small()
        {
            // Arrange
            IAbilityScore dexterity = new Mock<IAbilityScore>().Object;

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
            var bonus = ac.SizeBonuses.GetTotal();
            var penalty = ac.Penalties.GetTotal();

            // Assert
            Assert.AreEqual(1, bonus);
            Assert.AreEqual(0, penalty);
        }


        [Test(Description = "Ensures that a medium character has correct size bonus an penalty aggregation.")]
        public void SizeBonuses_Medium()
        {
            // Arrange
            IAbilityScore dexterity = new Mock<IAbilityScore>().Object;

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
            var bonus = ac.SizeBonuses.GetTotal();
            var penalty = ac.Penalties.GetTotal();

            // Assert
            Assert.AreEqual(0, bonus);
            Assert.AreEqual(0, penalty);
        }


        [Test(Description = "Ensures that a large character has correct size bonus an penalty aggregation.")]
        public void SizeBonuses_Large()
        {
            // Arrange
            IAbilityScore dexterity = new Mock<IAbilityScore>().Object;

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
            var bonus = ac.SizeBonuses.GetTotal();
            var penalty = ac.Penalties.GetTotal();

            // Assert
            Assert.AreEqual(0, bonus);
            Assert.AreEqual(1, penalty);
        }
        #endregion


        #region Max Dex
        [Test(Description = "Ensures that the MaxDex object has sensible defaults.")]
        public void MaxKeyAbilityScore_Default()
        {
			// Arrange
			IAbilityScore dexterity = new Mock<IAbilityScore>().Object;

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
			IAbilityScore dexterity = new Mock<IAbilityScore>().Object;

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
            ac.ArmorBonuses.Add(5);
            ac.DeflectionBonuses.Add(7);
            ac.DodgeBonuses.Add(11);
            ac.NaturalArmorBonuses.Add(13);
            ac.NaturalArmorEnhancementBonuses.Add(17);
            ac.ShieldBonuses.Add(19);
            ac.UntypedBonuses.Add(23);
            ac.Penalties.Add(29);
            ac.MaxKeyAbilityScore.Add(2);

            // Act
            var result = ac.GetTotal();

            // Assert
            Assert.AreEqual(79, result,
                            "79 = (10 base) + (3 dex; +2 max dex) + (1 size) + (5 armor) + (7 deflection) + (11 dodge) + (13 natural) + (17 natural enhancement) + (19 shield) + (23 untyped) - (29 penalties)");
        }
        #endregion
    }
}