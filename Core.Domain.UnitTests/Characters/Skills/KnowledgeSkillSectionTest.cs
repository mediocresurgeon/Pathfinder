using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    public class KnowledgeSkillSectionTest
    {
        #region Constructor
        [Test(Description = "Ensures that a null ICharacter argument throws an ArgumentNullException.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new KnowledgeSkillSection(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures Knowledge (Arcana) is instantiated correctly.")]
        public void Default_Arcana()
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

            var knowledges = new KnowledgeSkillSection(mockCharacter.Object);

            // Act
            var skill = knowledges.Arcana;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Knowledge>(skill);
            Assert.AreEqual("Knowledge (Arcana)", skill.ToString());
        }


        [Test(Description = "Ensures Knowledge (Dungeoneering) is instantiated correctly.")]
        public void Default_Dungeoneering()
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

            var knowledges = new KnowledgeSkillSection(mockCharacter.Object);

            // Act
            var skill = knowledges.Dungeoneering;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Knowledge>(skill);
            Assert.AreEqual("Knowledge (Dungeoneering)", skill.ToString());
        }


        [Test(Description = "Ensures Knowledge (Engineering) is instantiated correctly.")]
        public void Default_Engineering()
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

            var knowledges = new KnowledgeSkillSection(mockCharacter.Object);

            // Act
            var skill = knowledges.Engineering;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Knowledge>(skill);
            Assert.AreEqual("Knowledge (Engineering)", skill.ToString());
        }


        [Test(Description = "Ensures Knowledge (Geography) is instantiated correctly.")]
        public void Default_Geography()
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

            var knowledges = new KnowledgeSkillSection(mockCharacter.Object);

            // Act
            var skill = knowledges.Geography;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Knowledge>(skill);
            Assert.AreEqual("Knowledge (Geography)", skill.ToString());
        }


        [Test(Description = "Ensures Knowledge (History) is instantiated correctly.")]
        public void Default_History()
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

            var knowledges = new KnowledgeSkillSection(mockCharacter.Object);

            // Act
            var skill = knowledges.History;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Knowledge>(skill);
            Assert.AreEqual("Knowledge (History)", skill.ToString());
        }


        [Test(Description = "Ensures Knowledge (Local) is instantiated correctly.")]
        public void Default_Local()
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

            var knowledges = new KnowledgeSkillSection(mockCharacter.Object);

            // Act
            var skill = knowledges.Local;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Knowledge>(skill);
            Assert.AreEqual("Knowledge (Local)", skill.ToString());
        }


        [Test(Description = "Ensures Knowledge (Nature) is instantiated correctly.")]
        public void Default_Nature()
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

            var knowledges = new KnowledgeSkillSection(mockCharacter.Object);

            // Act
            var skill = knowledges.Nature;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Knowledge>(skill);
            Assert.AreEqual("Knowledge (Nature)", skill.ToString());
        }


        [Test(Description = "Ensures Knowledge (Nobility) is instantiated correctly.")]
        public void Default_Nobility()
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

            var knowledges = new KnowledgeSkillSection(mockCharacter.Object);

            // Act
            var skill = knowledges.Nobility;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Knowledge>(skill);
            Assert.AreEqual("Knowledge (Nobility)", skill.ToString());
        }


        [Test(Description = "Ensures Knowledge (Planes) is instantiated correctly.")]
        public void Default_Planes()
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

            var knowledges = new KnowledgeSkillSection(mockCharacter.Object);

            // Act
            var skill = knowledges.Planes;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Knowledge>(skill);
            Assert.AreEqual("Knowledge (Planes)", skill.ToString());
        }


        [Test(Description = "Ensures Knowledge (Religion) is instantiated correctly.")]
        public void Default_Religion()
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

            var knowledges = new KnowledgeSkillSection(mockCharacter.Object);

            // Act
            var skill = knowledges.Religion;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Knowledge>(skill);
            Assert.AreEqual("Knowledge (Religion)", skill.ToString());
        }
        #endregion
    }
}