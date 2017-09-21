using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.SpellRegistries;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
    [TestFixture]
    public class RegisteredSpellTests
    {
        #region Constructor
        [Test(Description = "Ensures that a NullArgumentException is thrown when the constructor is given a null ISpell argument.")]
        public void Constructor_NullSpell_Throws()
        {
            // Arrange
            var abilityScore = new Mock<IAbilityScore>().Object;
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Charisma).Returns(abilityScore);
            var character = mockCharacter.Object;
            var spellRegistrar = new SpellRegistrar(character);

            // Act
            TestDelegate register = () => spellRegistrar.Register(null, character.Charisma);

            // Assert
            Assert.Throws<ArgumentNullException>(register,
                                                 "Null arguments are not allowed.");
        }


        [Test(Description = "Ensures that a NullArgumentException is thrown when the constructor is given a null IAbilityScore argument.")]
        public void Constructor_NullKeyAbility_Throws()
        {
            // Assert
            var character = new Mock<ICharacter>().Object;
            var spell = new Mock<ISpell>().Object;
            var spellRegistrar = new SpellRegistrar(character);

            // Act
            TestDelegate register = () => spellRegistrar.Register(spell, null);

            // Assert
            Assert.Throws<ArgumentNullException>(register,
                                                "Null arguments are not allowed.");
        }


        [Test(Description = "Ensures that a RegisteredSpell wraps an ISpell correctly.")]
        public void SpellProperty_Returns_SpellFromConstructor()
        {
			// Assert
			var abilityScore = new Mock<IAbilityScore>().Object;
			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Charisma).Returns(abilityScore);
			var character = mockCharacter.Object;
			var spellRegistrar = new SpellRegistrar(character);
            var mockSpell = new Mock<ISpell>().Object;

            // Act
            var registeredSpell = spellRegistrar.Register(mockSpell, abilityScore);
            var spell = registeredSpell.Spell;

            // Assert
            Assert.AreSame(mockSpell, spell);
        }
        #endregion

        #region AddDfficultyClassBonus
        [Test(Description = "Ensures that bonuses added via AddDfficultyClassBonus(byte) are taken into account when calculating the total DC.")]
        public void AddDfficultyClassBonus_GetDC()
        {
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(a => a.GetBonus()).Returns(4);
            var abilityScore = mockAbilityScore.Object;
			
            var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Charisma).Returns(abilityScore);
			var character = mockCharacter.Object;

			var mockSpell = new Mock<ISpell>();
            mockSpell.Setup(s => s.Level).Returns(2);
            mockSpell.Setup(s => s.AllowsSavingThrow).Returns(true);
            var spell = mockSpell.Object;

            var spellRegistrar = new SpellRegistrar(character);

            var registeredSpell = spellRegistrar.Register(mockSpell.Object, character.Charisma);

            // Act
            registeredSpell.AddDifficultyClassBonus(10);

            // Assert
            Assert.AreEqual(26, registeredSpell.GetDifficultyClass(),
                            "10 base + 2 level + 4 ability + 10 untyped = DC 26");

        }
        #endregion

        #region GetDifficultyClass
        [Test(Description = "Ensures that registered spells which do not allow saving throws do not have a DC associated with them.")]
        public void GetDC_DisallowsSavingThrow_SimpleCase()
        {
			// Arrange
			var abilityScore = new Mock<IAbilityScore>().Object;

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Charisma).Returns(abilityScore);
			var character = mockCharacter.Object;

            var mockSpell = new Mock<ISpell>();
            mockSpell.Setup(Spell => Spell.AllowsSavingThrow).Returns(false);

            var spellRegistrar = new SpellRegistrar(character);

            var registeredSpell = spellRegistrar.Register(mockSpell.Object, character.Charisma);

            // Act
            var dc = registeredSpell.GetDifficultyClass();

            // Assert
            Assert.IsFalse(dc.HasValue,
                           "Spells which do not allow saving throws should not have a DC associated with them.");
        }


        [Test(Description = "Ensures that spells which allow saving throws have a correct DC associated with them.")]
        public void GetDC_AllowsSavingThrow_SimpleCase()
        {
			// Arrange
			var mockAbilityScore = new Mock<IAbilityScore>();
			mockAbilityScore.Setup(a => a.GetBonus()).Returns(5);
			var abilityScore = mockAbilityScore.Object;

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Charisma).Returns(abilityScore);
			var character = mockCharacter.Object;

			var mockSpell = new Mock<ISpell>();
			mockSpell.Setup(s => s.Level).Returns(5);
			mockSpell.Setup(s => s.AllowsSavingThrow).Returns(true);
			var spell = mockSpell.Object;

			var spellRegistrar = new SpellRegistrar(character);

            var registeredSpell = spellRegistrar.Register(mockSpell.Object, character.Charisma);

            // Act
            var dc = registeredSpell.GetDifficultyClass();

			// Assert
			Assert.AreEqual(20, dc,
							"The DC of a spell's saving throw is: 10 + (spell level) + (associated ability score bonus)");
        }
        #endregion

        #region GetEffectiveCasterLevel
        [Test(Description = "Ensures correct calculation of a spell's effective caster level when it is not explicity specified.")]
        public void GetECL_Nonspecified_UseCharacterLevel()
        {
			// Arrange
			var mockAbilityScore = new Mock<IAbilityScore>();
			mockAbilityScore.Setup(a => a.GetBonus()).Returns(4);
			var abilityScore = mockAbilityScore.Object;

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Charisma).Returns(abilityScore);
            mockCharacter.Setup(c => c.Level).Returns(12);
			var character = mockCharacter.Object;

            var spell = new Mock<ISpell>().Object;

            var spellRegistrar = new SpellRegistrar(character);

            // Act
            var registeredSpell = spellRegistrar.Register(spell, character.Charisma);
            var ecl = registeredSpell.GetEffectiveCasterLevel();

            // Assert
            Assert.AreEqual(12, ecl,
                           "Unless otherwise specified, a registered spell's effective caster level is equal to the character's level.");
        }


		[Test(Description = "Ensures that a specified effective caster level overrides other calculations, such as using the character's level.")]
		public void GetECL_Specified_UseCharacterLevel()
		{
			// Arrange
			var mockAbilityScore = new Mock<IAbilityScore>();
			mockAbilityScore.Setup(a => a.GetBonus()).Returns(4);
			var abilityScore = mockAbilityScore.Object;

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Charisma).Returns(abilityScore);
			mockCharacter.Setup(c => c.Level).Returns(12);
			var character = mockCharacter.Object;

			var spell = new Mock<ISpell>().Object;

            var spellRegistrar = new SpellRegistrar(character);

			// Act
            var registeredSpell = spellRegistrar.Register(spell, character.Charisma, 18); // Note the specified caster level!
			var ecl = registeredSpell.GetEffectiveCasterLevel();

			// Assert
			Assert.AreEqual(18, ecl,
                            "The registered spell's caster level should be used when specified (instead of the character's level).");
		}
        #endregion
    }
}