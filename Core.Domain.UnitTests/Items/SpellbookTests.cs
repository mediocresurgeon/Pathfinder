﻿using System;
using Core.Domain.Items;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items
{
    [TestFixture]
    public class SpellbookTests
    {
        [Test(Description = "Ensures that Spellbook.Add(ISpell) throws an ArgumentNullException when the ISpell is null.")]
        public void Add_NullArg_Throws()
        {
            // Arrange
            var spellbook = new Spellbook();

            // Act
            TestDelegate addNull = () => spellbook.Add(null);

            // Assert
            Assert.Throws<ArgumentNullException>(addNull);
        }


        [Test(Description = "Ensures that Spellbook.getSpellsByLevel(byte) returns the correct subset of spells.")]
        public void GetSpellsByLevel()
        {
			// Arrange
			var spellbook = new Spellbook();

            var mockLevel0 = new Mock<ISpell>();
            mockLevel0.Setup(s => s.Level).Returns(0);
            var level0 = mockLevel0.Object;
            spellbook.Add(level0);

            var mockLevel1 = new Mock<ISpell>();
            mockLevel1.Setup(s => s.Level).Returns(1);
            var level1 = mockLevel1.Object;
            spellbook.Add(level1);

			var mockLevel2 = new Mock<ISpell>();
			mockLevel2.Setup(s => s.Level).Returns(2);
			var level2 = mockLevel2.Object;
            spellbook.Add(level2);

            // Act
            var level1s = spellbook.GetSpellsByLevel(1);

            // Assert
            Assert.AreEqual(1, level1s.Length,
                            "Incorrect number of spells returned.");
            Assert.Contains(level1, level1s,
                            "Result did not contain the expected spell.");
        }


        [Test(Description = "Ensures the correct price of an empty spellbook.")]
        public void EmptySpellbook_MarketPrice()
        {
			// Arrange
			var spellbook = new Spellbook();

            // Act
            double marketPrice = spellbook.GetMarketPrice();

            // Assert
            Assert.AreEqual(15, marketPrice,
                            "Incorrect market price for empty spellbook.");
        }


		[Test(Description = "Ensures the correct price of a spellbook with a level 0 spell.")]
		public void NoobSpellbook_MarketPrice()
		{
			// Arrange
			var spellbook = new Spellbook();

			var mockLevel0 = new Mock<ISpell>();
			mockLevel0.Setup(s => s.Level).Returns(0);
			spellbook.Add(mockLevel0.Object);

			// Act
			double marketPrice = spellbook.GetMarketPrice();

			// Assert
			Assert.AreEqual(20, marketPrice,
							@"Incorrect market price for spellbook with one level 0 spell. 15 + 5 = 20gp");
		}


		[Test(Description = "Ensures the correct price of a spellbook with level 0, 1 and 2 spells.")]
		public void TypicalSpellbook_MarketPrice()
		{
			// Arrange
			var spellbook = new Spellbook();

            // Add 20 level 0 spells to spellbook
            for (int i = 0; i < 20; i++)
            {
				var mockLevel0 = new Mock<ISpell>();
				mockLevel0.Setup(s => s.Level).Returns(0);
				spellbook.Add(mockLevel0.Object);
            }

			// Add 8 level 1 spells to spellbook
			for (int i = 0; i < 8; i++)
			{
				var mockLevel1 = new Mock<ISpell>();
				mockLevel1.Setup(s => s.Level).Returns(1);
				spellbook.Add(mockLevel1.Object);
			}

			// Add 4 level 2 spells to spellbook
			for (int i = 0; i < 4; i++)
			{
				var mockLevel2 = new Mock<ISpell>();
				mockLevel2.Setup(s => s.Level).Returns(2);
				spellbook.Add(mockLevel2.Object);
			}

			// Act
			double marketPrice = spellbook.GetMarketPrice();

			// Assert
			Assert.AreEqual(355, marketPrice,
                            @"Incorrect market price for spellbook with one level 0 spell. 15 + (20 * 5) + ( 8 * 10 ) + (4 * 40) = 355");
		}
    }
}