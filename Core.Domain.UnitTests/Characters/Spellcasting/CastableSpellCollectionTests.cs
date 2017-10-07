using System;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
    [TestFixture]
    public class CastableSpellCollectionTests
    {
        #region Add()
        [Test(Description = "Ensures that calling .Add(ICastableSpell) with a null argument throws an ArgumentNullException.")]
        public void Add_NullICastableSpell_Throws()
        {
            // Arrange
            CastableSpellCollection spellCollection = new CastableSpellCollection();
            ICastableSpell spell = null;

            // Act
            TestDelegate addNull = () => spellCollection.Add(spell);

            // Assert
            Assert.Throws<ArgumentNullException>(addNull,
                                                "Null arguments are not allowed.");
        }
		#endregion

		#region GetAll()
		[Test(Description = "Ensures that spells Add()ed can be retrieved using GetAll().")]
        public void Add_GetSpellsByLevel_RoundTrip()
        {
            // Arrange
            var mockSpell0 = new Mock<ISpell>();
            mockSpell0.Setup(s => s.Level).Returns(0);
            var mockCastable0 = new Mock<ICastableSpell>();
            mockCastable0.Setup(c => c.Spell).Returns(mockSpell0.Object);
            var castable0 = mockCastable0.Object;

			var mockSpell1 = new Mock<ISpell>();
			mockSpell1.Setup(s => s.Level).Returns(1);
			var mockCastable1 = new Mock<ICastableSpell>();
			mockCastable1.Setup(c => c.Spell).Returns(mockSpell1.Object);
            var castable1 = mockCastable1.Object;

            CastableSpellCollection spellCollection = new CastableSpellCollection();
            spellCollection.Add(castable0);
            spellCollection.Add(castable1);

            // Act
            var result = spellCollection.GetAll();

            // Assert
            Assert.AreEqual(2, result.Length,
                            "Collection should have exactly two elements inside of it.");
            Assert.Contains(castable0, result,
                            "Collection should contain a reference to the object added using the Add() method.");
			Assert.Contains(castable1, result,
							"Collection should contain a reference to the object added using the Add() method.");
        }
        #endregion
    }
}