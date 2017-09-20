using System;
using Core.Domain.Characters.SpellRegistries;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
    [TestFixture]
    public class RegisteredSpellsCollectionTests
    {
        [Test(Description = "Ensures that adding a null IRegisteredSpell will thrown an ArgumentNullException.")]
        public void Add_NullArg_Throws()
        {
            // Arrange
            RegisteredSpellCollection spells = new RegisteredSpellCollection();
            IRegisteredSpell spellToAdd = null;

            // Act
            TestDelegate addMethod = () => spells.Add(spellToAdd);

            // Assert
            Assert.Throws<ArgumentNullException>(addMethod,
                                                "Null arguments are not allowed.");
        }


        [Test(Description = "Ensures that GetSpellsByLevel(byte) filters the results correctly.")]
		public void GetSpellsByLevel_FiltersCorrectly()
		{
			// Arrange
			RegisteredSpellCollection spells = new RegisteredSpellCollection();

            var mockSpell0 = new Mock<ISpell>();
            mockSpell0.Setup(s => s.Level).Returns(0);
            var mockRegSpell0 = new Mock<IRegisteredSpell>();
            mockRegSpell0.Setup(rs => rs.Spell).Returns(mockSpell0.Object);
            var regSpell0 = mockRegSpell0.Object;
            spells.Add(regSpell0);

			var mockSpell1 = new Mock<ISpell>();
			mockSpell1.Setup(s => s.Level).Returns(1);
			var mockRegSpell1 = new Mock<IRegisteredSpell>();
			mockRegSpell1.Setup(rs => rs.Spell).Returns(mockSpell1.Object);
            var regSpell1 = mockRegSpell1.Object;
			spells.Add(regSpell1);

            // Act
            var level0spells = spells.GetSpellsByLevel(0);
            var level1spells = spells.GetSpellsByLevel(1);

            // Assert
            Assert.AreEqual(1, level0spells.Length);
            Assert.Contains(regSpell0, level0spells);
            Assert.AreEqual(1, level1spells.Length);
            Assert.Contains(regSpell1, level1spells);
		}
    }
}