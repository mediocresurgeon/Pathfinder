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
        [Test(Description = "Ensures that an ArgumentNullException is thrown when the constructor is given a null Character argument.")]
        public void Constructor_CharacterNull_Throws()
        {
            // Act
            TestDelegate constructor = () => new SpellRegistrar(null);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor,
                                                 "Null arguments are not allowed.");
        }


        [Test(Description = "Ensures that an ArgumentNullException is thrown when attempting to register a null ISpell.")]
        public void Register_NullSpell_Throws()
        {
			// Arrange
			var character = new Character(1);

            // Act
            TestDelegate registerSpell = () => character.SpellRegistrar.Register(null, character.Charisma);

            // Assert
            Assert.Throws<ArgumentNullException>(registerSpell,
                                                 "Null arguments are not allowed.");
        }


		[Test(Description = "Ensures that an ArgumentNullException is thrown when attempting to associate a spell with a null IAbilityScore.")]
		public void Register_NullAbilityScore_Throws()
		{
			// Arrange
            var character = new Character(1);
			var mockSpell = new Mock<ISpell>().Object;

			// Act
			TestDelegate registerSpell = () => character.SpellRegistrar.Register(mockSpell, null);

			// Assert
			Assert.Throws<ArgumentNullException>(registerSpell,
                                                 "Null arguments are not allowed.");
		}


        [Test(Description = "Ensures that the SpellRegistrar passes through the ECL to the RegisteredSpell.")]
        public void Register_PassesThroughCasterLevel()
        {
			// Arrange
			var character = new Character(1);
			var mockSpell = new Mock<ISpell>().Object;
            byte casterLevel = 20;
            var registeredSpell = character.SpellRegistrar.Register(mockSpell, character.Charisma, casterLevel);

            // Act
            var ecl = registeredSpell.GetEffectiveCasterLevel();

            // Assert
            Assert.AreEqual(casterLevel, ecl,
                            "The effective caster level of the spell should use the specified value (when available) instead of reading the character's level.");
        }


        [Test(Description = "Ensures that registered spells can be retrieved.")]
        public void Register_InputCanBeRetrieved()
        {
            // Arrange
            var character = new Character(1);
            var mockSpell = new Mock<ISpell>().Object;
            character.SpellRegistrar.Register(mockSpell, character.Charisma);

            // Act
            var registeredSpells = character.SpellRegistrar
                                            .GetRegisteredSpells()
                                            .Select(rs => rs.Spell)
                                            .ToArray();

            // Assert
            Assert.Contains(mockSpell, registeredSpells,
                            "The collection of registered spells should include the spells which were registered.");
        }


        [Test(Description = "Ensures that registering a new spell should fire the OnSpellRegistered event.")]
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
            Assert.IsTrue(eventFired,
                          "The OnSpellRegistered event should trigger when registering a new spell.");
        }


		[Test(Description = "Ensures that OnSpellRegistered events are not triggered when a spell is accidentally registered twice.")]
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
            Assert.AreEqual(1, eventFiredCount,
                            "The OnSpellRegistered event should only trigger the first time a spell is registered.");
		}
    }
}