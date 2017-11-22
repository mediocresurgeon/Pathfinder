using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    public class SkillSectionTests
    {
        #region Constructor
        [Test(Description = "Ensures that a null ICharacter argument throws an ArgumentNullException.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null; 

            // Act
            TestDelegate constructor = () => new SkillSection(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Raw skills
        [Test(Description = "Ensures Acrobatics is instantiated correctly.")]
        public void Default_Acrobatics()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

			var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Acrobatics;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(dexterity, skill.KeyAbilityScore);
            Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Acrobatics", skill.ToString());
        }


        [Test(Description = "Ensures Appraise is instantiated correctly.")]
        public void Default_Appraise()
		{
			// Arrange
			var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

			// Act
			var skill = skills.Appraise;

			// Assert
			Assert.IsNotNull(skill);
            Assert.AreSame(intelligence, skill.KeyAbilityScore);
			Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Appraise", skill.ToString());
		}


		[Test(Description = "Ensures Bluff is instantiated correctly.")]
		public void Default_Bluff()
		{
			// Arrange
			var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

			// Act
			var skill = skills.Bluff;

			// Assert
			Assert.IsNotNull(skill);
			Assert.AreSame(charisma, skill.KeyAbilityScore);
			Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Bluff", skill.ToString());
		}


        [Test(Description = "Ensures Climb is instantiated correctly.")]
        public void Default_Climb()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Climb;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Climb>(skill);
        }


        [Test(Description = "Ensures Diplomacy is instantiated correctly.")]
        public void Default_Diplomacy()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Diplomacy;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(charisma, skill.KeyAbilityScore);
            Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Diplomacy", skill.ToString());
        }


        [Test(Description = "Ensures Disable Device is instantiated correctly.")]
        public void Default_DisableDevice()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.DisableDevice;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(dexterity, skill.KeyAbilityScore);
            Assert.IsFalse(skill.CanBeUsedUntrained);
            Assert.AreEqual("Disable Device", skill.ToString());
        }


        [Test(Description = "Ensures Disguise is instantiated correctly.")]
        public void Default_Disguise()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Disguise;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(charisma, skill.KeyAbilityScore);
            Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Disguise", skill.ToString());
        }


        [Test(Description = "Ensures Escape Artist is instantiated correctly.")]
        public void Default_EscapeArtist()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.EscapeArtist;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(dexterity, skill.KeyAbilityScore);
            Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Escape Artist", skill.ToString());
        }


        [Test(Description = "Ensures Fly is instantiated correctly.")]
        public void Default_Fly()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Fly;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Fly>(skill);
        }


        [Test(Description = "Ensures Handle Animal is instantiated correctly.")]
        public void Default_HandleAnimal()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.HandleAnimal;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(charisma, skill.KeyAbilityScore);
            Assert.IsFalse(skill.CanBeUsedUntrained);
            Assert.AreEqual("Handle Animal", skill.ToString());
        }


        [Test(Description = "Ensures Heal is instantiated correctly.")]
        public void Default_Heal()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Heal;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(wisdom, skill.KeyAbilityScore);
            Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Heal", skill.ToString());
        }


        [Test(Description = "Ensures Intimidate is instantiated correctly.")]
        public void Default_Intimidate()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Intimidate;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(charisma, skill.KeyAbilityScore);
            Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Intimidate", skill.ToString());
        }


        [Test(Description = "Ensures Linguistics is instantiated correctly.")]
        public void Default_Linguistics()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Linguistics;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(intelligence, skill.KeyAbilityScore);
            Assert.IsFalse(skill.CanBeUsedUntrained);
            Assert.AreEqual("Linguistics", skill.ToString());
        }


        [Test(Description = "Ensures Perception is instantiated correctly.")]
        public void Default_Perception()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Perception;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(wisdom, skill.KeyAbilityScore);
            Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Perception", skill.ToString());
        }


        [Test(Description = "Ensures Ride is instantiated correctly.")]
        public void Default_Ride()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Ride;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(dexterity, skill.KeyAbilityScore);
            Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Ride", skill.ToString());
        }


        [Test(Description = "Ensures Sense Motive is instantiated correctly.")]
        public void Default_SenseMotive()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.SenseMotive;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(wisdom, skill.KeyAbilityScore);
            Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Sense Motive", skill.ToString());
        }


        [Test(Description = "Ensures Sleight of Hand is instantiated correctly.")]
        public void Default_SleightOfHand()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.SleightOfHand;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(dexterity, skill.KeyAbilityScore);
            Assert.IsFalse(skill.CanBeUsedUntrained);
            Assert.AreEqual("Sleight of Hand", skill.ToString());
        }


        [Test(Description = "Ensures Spellcraft is instantiated correctly.")]
        public void Default_Spellcraft()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Spellcraft;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(intelligence, skill.KeyAbilityScore);
            Assert.IsFalse(skill.CanBeUsedUntrained);
            Assert.AreEqual("Spellcraft", skill.ToString());
        }


        [Test(Description = "Ensures Stealth is instantiated correctly.")]
        public void Default_Stealth()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Stealth;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Stealth>(skill);
        }


        [Test(Description = "Ensures Survival is instantiated correctly.")]
        public void Default_Survival()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Survival;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(wisdom, skill.KeyAbilityScore);
            Assert.IsTrue(skill.CanBeUsedUntrained);
            Assert.AreEqual("Survival", skill.ToString());
        }


        [Test(Description = "Ensures Swim is instantiated correctly.")]
        public void Default_Swim()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.Swim;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Swim>(skill);
        }


        [Test(Description = "Ensures Use Magic Device is instantiated correctly.")]
        public void Default_UseMagicDevice()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skill = skills.UseMagicDevice;

            // Assert
            Assert.IsNotNull(skill);
            Assert.AreSame(charisma, skill.KeyAbilityScore);
            Assert.IsFalse(skill.CanBeUsedUntrained);
            Assert.AreEqual("Use Magic Device", skill.ToString());
        }
        #endregion

        #region Subsections
        [Test(Description = "Ensures that Craft is instantiated correctly.")]
        public void Default_Craft()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skillSection = skills.Craft;

            // Assert
            Assert.IsNotNull(skillSection);
            Assert.IsInstanceOf<CraftSkillSection>(skillSection);
        }


        [Test(Description = "Ensures that Knowledge is instantiated correctly.")]
        public void Default_Knowledge()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skillSection = skills.Knowledge;

            // Assert
            Assert.IsNotNull(skillSection);
            Assert.IsInstanceOf<KnowledgeSkillSection>(skillSection);
        }


        [Test(Description = "Ensures that Perform is instantiated correctly.")]
        public void Default_Perform()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skillSection = skills.Perform;

            // Assert
            Assert.IsNotNull(skillSection);
            Assert.IsInstanceOf<PerformSkillSection>(skillSection);
        }


        [Test(Description = "Ensures that Profession is instantiated correctly.")]
        public void Default_Profession()
        {
            // Arrange
            var strength     = Mock.Of<IAbilityScore>();
            var dexterity    = Mock.Of<IAbilityScore>();
            var constitution = Mock.Of<IAbilityScore>();
            var intelligence = Mock.Of<IAbilityScore>();
            var wisdom       = Mock.Of<IAbilityScore>();
            var charisma     = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Strength)
                             .Returns(strength);
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);
            mockAbilityScores.Setup(abs => abs.Constitution)
                             .Returns(constitution);
            mockAbilityScores.Setup(abs => abs.Intelligence)
                             .Returns(intelligence);
            mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);
            mockAbilityScores.Setup(abs => abs.Charisma)
                             .Returns(charisma);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var skills = new SkillSection(mockCharacter.Object);

            // Act
            var skillSection = skills.Profession;

            // Assert
            Assert.IsNotNull(skillSection);
            Assert.IsInstanceOf<ProfessionSkillSection>(skillSection);
        }
        #endregion
    }
}