using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using NUnit.Framework;

namespace Core.Domain.UnitTests.Characters
{
    [TestFixture]
    public class CharacterTests
    {
        #region ICharacter tests
        // These tests make sure that Character passes through its properties correctly to its interface.

        [Test]
        public void ICharacter_StrengthIsStrength()
        {
            // Arrange
            ICharacter character = new Character();

            // Assert
            Assert.IsInstanceOf<Strength>(character.Strength);
        }


        [Test]
        public void ICharacter_DexterityIsDexterity()
        {
            // Arrange
            ICharacter character = new Character();

            // Assert
            Assert.IsInstanceOf<Dexterity>(character.Dexterity);
        }


        [Test]
        public void ICharacter_ConstitutionIsConstitution()
        {
            // Arrange
            ICharacter character = new Character();

            // Assert
            Assert.IsInstanceOf<Constitution>(character.Constitution);
        }


        [Test]
        public void ICharacter_IntelligenceIsIntelligence()
        {
            // Arrange
            ICharacter character = new Character();

            // Assert
            Assert.IsInstanceOf<Intelligence>(character.Intelligence);
        }


        [Test]
        public void ICharacter_WisdomIsWisdom()
        {
            // Arrange
            ICharacter character = new Character();

            // Assert
            Assert.IsInstanceOf<Wisdom>(character.Wisdom);
        }


        [Test]
        public void ICharacter_CharismaIsCharisma()
        {
            // Arrange
            ICharacter character = new Character();

            // Assert
            Assert.IsInstanceOf<Charisma>(character.Charisma);
        }
        #endregion
    }
}