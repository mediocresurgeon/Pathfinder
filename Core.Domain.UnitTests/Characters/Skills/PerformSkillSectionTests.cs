using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    public class PerformSkillSectionTests
    {
        #region Constructor
        [Test(Description = "Ensures that a null ICharacter argument throws an ArgumentNullException.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new PerformSkillSection(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures Perform (Act) is instantiated correctly.")]
        public void Default_Act()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var performs = new PerformSkillSection(mockCharacter.Object);

            // Act
            var skill = performs.Act;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Perform>(skill);
            Assert.AreEqual("Perform (Act)", skill.ToString());
        }


        [Test(Description = "Ensures Perform (Comedy) is instantiated correctly.")]
        public void Default_Comedy()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var performs = new PerformSkillSection(mockCharacter.Object);

            // Act
            var skill = performs.Comedy;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Perform>(skill);
            Assert.AreEqual("Perform (Comedy)", skill.ToString());
        }


        [Test(Description = "Ensures Perform (Dance) is instantiated correctly.")]
        public void Default_Dance()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var performs = new PerformSkillSection(mockCharacter.Object);

            // Act
            var skill = performs.Dance;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Perform>(skill);
            Assert.AreEqual("Perform (Dance)", skill.ToString());
        }


        [Test(Description = "Ensures Perform (Keyboard Instruments) is instantiated correctly.")]
        public void Default_KeyboardInstruments()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var performs = new PerformSkillSection(mockCharacter.Object);

            // Act
            var skill = performs.KeyboardInstruments;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Perform>(skill);
            Assert.AreEqual("Perform (Keyboard Instruments)", skill.ToString());
        }


        [Test(Description = "Ensures Perform (Oratory) is instantiated correctly.")]
        public void Default_Oratory()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var performs = new PerformSkillSection(mockCharacter.Object);

            // Act
            var skill = performs.Oratory;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Perform>(skill);
            Assert.AreEqual("Perform (Oratory)", skill.ToString());
        }


        [Test(Description = "Ensures Perform (Percussion Instruments) is instantiated correctly.")]
        public void Default_PercussionInstruments()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var performs = new PerformSkillSection(mockCharacter.Object);

            // Act
            var skill = performs.PercussionInstruments;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Perform>(skill);
            Assert.AreEqual("Perform (Percussion Instruments)", skill.ToString());
        }


        [Test(Description = "Ensures Perform (String Instruments) is instantiated correctly.")]
        public void Default_StringInstruments()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var performs = new PerformSkillSection(mockCharacter.Object);

            // Act
            var skill = performs.StringInstruments;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Perform>(skill);
            Assert.AreEqual("Perform (String Instruments)", skill.ToString());
        }


        [Test(Description = "Ensures Perform (Wind Instruments) is instantiated correctly.")]
        public void Default_WindInstruments()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var performs = new PerformSkillSection(mockCharacter.Object);

            // Act
            var skill = performs.WindInstruments;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Perform>(skill);
            Assert.AreEqual("Perform (Wind Instruments)", skill.ToString());
        }


        [Test(Description = "Ensures Perform (Sing) is instantiated correctly.")]
        public void Default_Sing()
        {
            // Arrange
            var strength     = new Mock<IAbilityScore>().Object;
            var dexterity    = new Mock<IAbilityScore>().Object;
            var constitution = new Mock<IAbilityScore>().Object;
            var intelligence = new Mock<IAbilityScore>().Object;
            var wisdom       = new Mock<IAbilityScore>().Object;
            var charisma     = new Mock<IAbilityScore>().Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.Constitution)
                         .Returns(constitution);
            mockCharacter.Setup(c => c.Intelligence)
                         .Returns(intelligence);
            mockCharacter.Setup(c => c.Wisdom)
                         .Returns(wisdom);
            mockCharacter.Setup(c => c.Charisma)
                         .Returns(charisma);

            var performs = new PerformSkillSection(mockCharacter.Object);

            // Act
            var skill = performs.Sing;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Perform>(skill);
            Assert.AreEqual("Perform (Sing)", skill.ToString());
        }
        #endregion
    }
}