using System;
using Core.Domain.Characters.SpellRegistries;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
    [TestFixture]
    public class SpellLikeAbilityCollectionTests
    {
        #region Add()
        [Test(Description = "Ensures that calling the Add() method with a null argument throws an ArgumentNullException.")]
        public void Add_NullISpellLikeAbility_Throws()
        {
            // Arrange
            ISpellLikeAbility sla = null;
            SpellLikeAbilityCollection slaCollection = new SpellLikeAbilityCollection();

            // Act
            TestDelegate addNull = () => slaCollection.Add(sla);

            // Assert
            Assert.Throws<ArgumentNullException>(addNull,
                                                 "Null arguments are not allowed.");
        }
		#endregion

		#region GetAll()
		[Test(Description = "Ensures that spells Add()ed can be retrieved using GetAll().")]
		public void Add_GetAll_RoundTrip()
        {
			// Arrange
			var mockSpell0 = new Mock<ISpell>();
			mockSpell0.Setup(s => s.Level).Returns(0);
            var mockSla0 = new Mock<ISpellLikeAbility>();
			mockSla0.Setup(c => c.Spell).Returns(mockSpell0.Object);
			var sla0 = mockSla0.Object;

			var mockSpell1 = new Mock<ISpell>();
			mockSpell1.Setup(s => s.Level).Returns(1);
			var mockSla1 = new Mock<ISpellLikeAbility>();
			mockSla1.Setup(c => c.Spell).Returns(mockSpell1.Object);
			var sla1 = mockSla1.Object;

            SpellLikeAbilityCollection slaCollections = new SpellLikeAbilityCollection();
			slaCollections.Add(sla0);
			slaCollections.Add(sla1);

			// Act
            var result = slaCollections.GetAll();

			// Assert
			Assert.AreEqual(2, result.Length,
							"Collection should only have a single element inside of it.");
			Assert.Contains(sla0, result,
							"Collection should contain a reference to the object added using the Add() method.");
			Assert.Contains(sla1, result,
							"Collection should contain a reference to the object added using the Add() method.");
        }
        #endregion
    }
}