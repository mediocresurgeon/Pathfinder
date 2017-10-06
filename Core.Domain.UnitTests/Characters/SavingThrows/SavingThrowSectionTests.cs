using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.SavingThrows;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SavingThrows
{
    [TestFixture]
    public class SavingThrowSectionTests
    {
        [Test(Description = "Ensures a SavingThrowSection cannot be created with a null ICharacter reference.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new SavingThrowSection(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures a clean instance of SavingThrowSection has senbile defaults.")]
        public void Default()
        {
            // Arrange
            IAbilityScore dexterity = new Mock<IAbilityScore>().Object;
            IAbilityScore constitution = new Mock<IAbilityScore>().Object;
            IAbilityScore wisdom = new Mock<IAbilityScore>().Object;

            var mockAbilityScoreSection = new Mock<IAbilityScoreSection>();
            mockAbilityScoreSection.Setup(abs => abs.Dexterity)
                                   .Returns(dexterity);
            mockAbilityScoreSection.Setup(abs => abs.Constitution)
                                   .Returns(constitution);
            mockAbilityScoreSection.Setup(abs => abs.Wisdom)
								   .Returns(wisdom);
            
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScoreSection.Object);

            SavingThrowSection savingThrowSection = new SavingThrowSection(mockCharacter.Object);

            // Assert
            Assert.IsInstanceOf<SavingThrow>(savingThrowSection.Fortitude);
			Assert.AreSame(constitution, savingThrowSection.Fortitude.KeyAbilityScore,
						   "Fortitude saving throw should be configured to use the character's constitution.");
            Assert.IsInstanceOf<SavingThrow>(savingThrowSection.Reflex);
            Assert.AreSame(dexterity, savingThrowSection.Reflex.KeyAbilityScore,
                           "Reflex saving throw should be configured to use the character's dexterity.");
            Assert.IsInstanceOf<SavingThrow>(savingThrowSection.Will);
			Assert.AreSame(wisdom, savingThrowSection.Will.KeyAbilityScore,
						   "Will saving throw should be configured to use the character's wisdom.");
        }
    }
}