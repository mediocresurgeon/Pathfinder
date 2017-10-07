using System;
using Core.Domain.Characters.Spellcasting;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
    [TestFixture]
    public class SpellRegisteredEventArgsTests
    {
        #region Constructor
        [Test(Description = "Ensures that the constructor will reject null arguments.")]
        public void Constructor_NullEventICastableSpell_Throws()
        {
            // Arrange
            ICastableSpell castableSpell = null;

            // Act
            TestDelegate constructor = () => new SpellRegisteredEventArgs(castableSpell);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor,
                                                 "Null arguments are not allowed.");
        }
        #endregion

        #region .Spell
        [Test(Description = "Ensures that the ICastableSpell given to the constructor can be retrieved later.")]
        public void Spell_RoundTrip()
        {
			// Arrange
            ICastableSpell castableSpell = new Mock<ICastableSpell>().Object;
            SpellRegisteredEventArgs eventArgs = new SpellRegisteredEventArgs(castableSpell);

            // Act
            var result = eventArgs.Spell;

            // Assert
            Assert.AreSame(castableSpell, result,
                           "The .Spell property should return a reference to the same object which was given to the constructor.");
        }
        #endregion
    }
}