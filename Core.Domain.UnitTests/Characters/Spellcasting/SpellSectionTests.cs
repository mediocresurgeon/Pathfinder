using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Spellcasting;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
    [TestFixture]
    [Parallelizable]
    public class SpellSectionTests
    {
        [Test(Description = "Ensures that a SpellSection cannot be created without an instance of ICharacter.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new SpellSection(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures sensible defaults for a fresh instance of SpellSection.")]
        public void Default()
        {
            // Arrange
            var character = Mock.Of<ICharacter>();

            // Act
            SpellSection spells = new SpellSection(character);

            // Assert
            Assert.IsNull(spells.Spellbook);
            Assert.IsInstanceOf<SpellRegistrar>(spells.Registrar);
            Assert.IsInstanceOf<CastableSpellCollection>(spells.Known);
            Assert.IsInstanceOf<CastableSpellCollection>(spells.Prepared);
        }
    }
}