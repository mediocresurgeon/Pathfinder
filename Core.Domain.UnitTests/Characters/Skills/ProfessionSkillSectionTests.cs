using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    [Parallelizable]
    public class ProfessionSkillSectionTests
    {
        #region Constructor
        [Test(Description = "Ensures that a null ICharacter argument throws an ArgumentNullException.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new ProfessionSkillSection(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures Profession (Architect) is instantiated correctly.")]
        public void Default_Architect()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Architect;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Architect)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Baker) is instantiated correctly.")]
        public void Default_Baker()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Baker;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Baker)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Barrister) is instantiated correctly.")]
        public void Default_Barrister()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Barrister;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Barrister)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Brewer) is instantiated correctly.")]
        public void Default_Brewer()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Brewer;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Brewer)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Butcher) is instantiated correctly.")]
        public void Default_Butcher()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Butcher;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Butcher)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Clerk) is instantiated correctly.")]
        public void Default_Clerk()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Clerk;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Clerk)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Cook) is instantiated correctly.")]
        public void Default_Cook()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Cook;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Cook)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Courtesan) is instantiated correctly.")]
        public void Default_Courtesan()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Courtesan;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Courtesan)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Driver) is instantiated correctly.")]
        public void Default_Driver()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Driver;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Driver)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Engineer) is instantiated correctly.")]
        public void Default_Engineer()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Engineer;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Engineer)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Farmer) is instantiated correctly.")]
        public void Default_Farmer()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Farmer;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Farmer)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Fisherman) is instantiated correctly.")]
        public void Default_Fisherman()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Fisherman;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Fisherman)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Gambler) is instantiated correctly.")]
        public void Default_Gambler()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Gambler;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Gambler)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Gardener) is instantiated correctly.")]
        public void Default_Gardener()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Gardener;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Gardener)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Herbalist) is instantiated correctly.")]
        public void Default_Herbalist()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Herbalist;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Herbalist)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Innkeeper) is instantiated correctly.")]
        public void Default_Innkeeper()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Innkeeper;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Innkeeper)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Librarian) is instantiated correctly.")]
        public void Default_Librarian()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Librarian;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Librarian)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Merchant) is instantiated correctly.")]
        public void Default_Merchant()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Merchant;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Merchant)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Midwife) is instantiated correctly.")]
        public void Default_Midwife()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Midwife;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Midwife)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Miller) is instantiated correctly.")]
        public void Default_Miller()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Miller;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Miller)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Miner) is instantiated correctly.")]
        public void Default_Miner()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Miner;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Miner)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Porter) is instantiated correctly.")]
        public void Default_Porter()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Porter;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Porter)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Sailor) is instantiated correctly.")]
        public void Default_Sailor()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Sailor;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Sailor)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Scribe) is instantiated correctly.")]
        public void Default_Scribe()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Scribe;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Scribe)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Shepherd) is instantiated correctly.")]
        public void Default_Shepherd()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Shepherd;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Shepherd)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Stable Master) is instantiated correctly.")]
        public void Default_StableMaster()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.StableMaster;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Stable Master)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Soldier) is instantiated correctly.")]
        public void Default_Soldier()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Soldier;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Soldier)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Tanner) is instantiated correctly.")]
        public void Default_Tanner()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Tanner;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Tanner)", skill.ToString());
        }


        [Test(Description = "Ensures Profession (Trapper) is instantiated correctly.")]
        public void Default_Trapper()
        {
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

            var professions = new ProfessionSkillSection(mockCharacter.Object);

            // Act
            var skill = professions.Trapper;

            // Assert
            Assert.IsNotNull(skill);
            Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Trapper)", skill.ToString());
        }


		[Test(Description = "Ensures Profession (Woodcutter) is instantiated correctly.")]
		public void Default_Woodcutter()
		{
			// Arrange
            var wisdom = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Wisdom)
                             .Returns(wisdom);

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);

			var professions = new ProfessionSkillSection(mockCharacter.Object);

			// Act
			var skill = professions.Woodcutter;

			// Assert
			Assert.IsNotNull(skill);
			Assert.IsInstanceOf<Profession>(skill);
            Assert.AreEqual("Profession (Woodcutter)", skill.ToString());
		}
        #endregion
    }
}