using System;
using Core.Domain.Characters;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
    [TestFixture]
    public class RegisteredSpellTests
    {
        #region Constructor
        [Test]
        public void Constructor_NullSpell_Throws()
        {
            // Arrange
            var character = new Character(1);

            // Act
            TestDelegate register = () => character.SpellRegistrar.Register(null, character.Charisma);

            // Assert
            Assert.Throws<ArgumentNullException>(register);
        }


        [Test]
        public void Constructor_NullKeyAbility_Throws()
        {
            var character = new Character(1);
            var mockSpell = new Mock<ISpell>().Object;

            // Act
            TestDelegate register = () => character.SpellRegistrar.Register(mockSpell, null);

            // Assert
            Assert.Throws<ArgumentNullException>(register);
        }


        [Test]
        public void SpellProperty_Returns_SpellFromConstructor()
        {
            var character = new Character(1);
            var mockSpell = new Mock<ISpell>().Object;

            // Act
            var registeredSpell = character.SpellRegistrar.Register(mockSpell, character.Charisma);

            // Assert
            Assert.AreSame(mockSpell, registeredSpell.Spell);
        }
        #endregion

        #region GetDifficultyClass
        [Test]
        public void GetDC_DisallowsSavingThrow_SimpleCase()
        {
            // Arrange
            var mockSpell = new Mock<ISpell>();
            mockSpell.Setup(Spell => Spell.AllowsSavingThrow).Returns(false);

            var character = new Character(1);

            var registeredSpell = character.SpellRegistrar.Register(mockSpell.Object, character.Charisma);

            // Act
            var dc = registeredSpell.GetDifficultyClass();

            // Assert
            Assert.IsNull(dc);
        }


        [Test]
        public void GetDC_AllowsSavingThrow_SimpleCase()
        {
            // Arrange
            var mockSpell = new Mock<ISpell>();
            mockSpell.Setup(spell => spell.Level).Returns(5);
            mockSpell.Setup(Spell => Spell.AllowsSavingThrow).Returns(true);

            var character = new Character(1);
            character.Charisma.BaseScore = 18;

            var registeredSpell = character.SpellRegistrar.Register(mockSpell.Object, character.Charisma);

            // Act
            var dc = registeredSpell.GetDifficultyClass();

            // Assert
            Assert.AreEqual(19, dc);
        }
        #endregion

        #region GetEffectiveCasterLevel
        [Test]
        public void GetECL_Nonspecified_UseCharacterLevel()
        {
            // Arrange
            var mockSpell = new Mock<ISpell>();
            var character = new Character(12);

            var registeredSpell = character.SpellRegistrar.Register(mockSpell.Object, character.Charisma);

            // Act
            var ecl = registeredSpell.GetEffectiveCasterLevel();

            // Assert
            Assert.AreEqual(12, ecl);
        }


		[Test]
		public void GetECL_Specified_UseCharacterLevel()
		{
			// Arrange
			var mockSpell = new Mock<ISpell>();
			var character = new Character(12);
            byte casterLevel = 18;

			var registeredSpell = character.SpellRegistrar.Register(mockSpell.Object, character.Charisma, casterLevel);

			// Act
			var ecl = registeredSpell.GetEffectiveCasterLevel();

			// Assert
			Assert.AreEqual(18, ecl);
		}
        #endregion
    }
}