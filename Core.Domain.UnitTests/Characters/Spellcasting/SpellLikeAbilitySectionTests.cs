using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Spellcasting;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
    [TestFixture]
    public class SpellLikeAbilitySectionTests
    {
        [Test(Description = "Ensures SpellLikeAbilitySection cannot be constructed with a null ICharacter argument.")]
        public void Constructor_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new SpellLikeAbilitySection(character);

            //Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures sensible default properties for SpellLikeAbilitiesSection.")]
        public void Default()
        {
            // Arrange
            var character = Mock.Of<ICharacter>();
            SpellLikeAbilitySection slaSection = new SpellLikeAbilitySection(character);

            // Assert
            Assert.IsInstanceOf<SpellLikeAbilityRegistrar>(slaSection.Registrar);
            Assert.IsInstanceOf<SpellLikeAbilityCollection>(slaSection.Known);
        }
    }
}