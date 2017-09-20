using System;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.SpellRegistries;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
    [TestFixture]
    public class SpellRegistrarTests
    {
        [Test]
        public void Constructor_CharacterNull_Throws()
        {
            // Act
            TestDelegate constructor = () => new SpellRegistrar(null);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test]
        public void Register_NullSpell_Throws()
        {
			// Arrange
			var character = new Character(1);

            // Act
            TestDelegate registerSpell = () => character.SpellRegistrar.Register(null, character.Charisma);

            // Assert
            Assert.Throws<ArgumentNullException>(registerSpell);
        }


		[Test]
		public void Register_NullAbilityScore_Throws()
		{
			// Arrange
            var character = new Character(1);
			var mockSpell = new Mock<ISpell>().Object;

			// Act
			TestDelegate registerSpell = () => character.SpellRegistrar.Register(mockSpell, null);

			// Assert
			Assert.Throws<ArgumentNullException>(registerSpell);
		}


        [Test]
        public void Register_PassesThroughCasterLevel()
        {
			// Arrange
			var character = new Character(1);
			var mockSpell = new Mock<ISpell>().Object;
            byte casterLevel = 20;

            // Act
            var registeredSpell = character.SpellRegistrar.Register(mockSpell, character.Charisma, casterLevel);
            var ecl = registeredSpell.GetEffectiveCasterLevel();

            // Assert
            Assert.AreEqual(casterLevel, ecl);
        }


        [Test]
        public void Register_InputCanBeRetrieved()
        {
            // Arrange
            var character = new Character(1);
            var mockSpell = new Mock<ISpell>().Object;

            // Act
            character.SpellRegistrar.Register(mockSpell, character.Charisma);
            var registeredSpells = character.SpellRegistrar
                                            .GetRegisteredSpells()
                                            .Select(rs => rs.Spell)
                                            .ToArray();

            // Assert
            Assert.Contains(mockSpell, registeredSpells);
        }


        [Test]
        public void Registering_NewSpell_FiresEvent()
        {
			// Arrange
			var character = new Character(1);
			var mockSpell = new Mock<ISpell>().Object;

            bool eventFired = false; // We mutate this variable are read from it later

            OnSpellRegisteredEventHandler handler =
                (obj, args) => eventFired = true;

            character.SpellRegistrar.OnSpellRegistered(handler);

            // Act
            character.SpellRegistrar.Register(mockSpell, character.Charisma);

            // Assert
            Assert.IsTrue(eventFired);
        }


		[Test]
		public void Registering_DuplicateSpell_FiresEventOnlyOnce()
		{
			// Arrange
			var character = new Character(1);
			var mockSpell = new Mock<ISpell>().Object;

			int eventFiredCount = 0; // We mutate this variable are read from it later

            OnSpellRegisteredEventHandler handler =
                (obj, args) => eventFiredCount++;;

            character.SpellRegistrar.OnSpellRegistered(handler);

			// Act
			character.SpellRegistrar.Register(mockSpell, character.Charisma);
            character.SpellRegistrar.Register(mockSpell, character.Charisma);

            // Assert
            Assert.AreEqual(1, eventFiredCount);
		}
    }
}