using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
    [TestFixture]
    public class CastableSpellTests
    {
        #region Constructor
        [Test(Description = "Ensures that null ISpell arguments are not possible.")]
        public void Constructor1_NullISpell_Throws()
        {
            // Arrange
            ISpell spell = null;
            var abilityScore = Mock.Of<IAbilityScore>();
            Func<byte> casterLevel = () => 1;

            // Act
            TestDelegate constructor = () => new CastableSpell(spell, abilityScore, casterLevel);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor,
                                                "Null arguments should not be accepted.");
        }


        [Test(Description = "Ensures that null IAbilityScore arguments are not possible.")]
        public void Constructor1_NullIAbilityScore_Throws()
        {
            // Arrange
            var spell = Mock.Of<ISpell>();
            IAbilityScore abilityScore = null;
            Func<byte> casterLevel = () => 1;

            // Act
            TestDelegate constructor = () => new CastableSpell(spell, abilityScore, casterLevel);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor,
                                                "Null arguments should not be accepted.");
        }


        [Test(Description = "Ensures that null Func<byte> arguments are not possible.")]
        public void Constructor1_NullFunc_Throws()
        {
            // Arrange
            var spell = Mock.Of<ISpell>();
            IAbilityScore abilityScore = null;
            Func<byte> casterLevel = null;

            // Act
            TestDelegate constructor = () => new CastableSpell(spell, abilityScore, casterLevel);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor,
                                                "Null arguments should not be accepted.");
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures sensible defaults for a fresh instance of CastableSpell.")]
        public void Default()
        {
            // Arrange
            var spell = Mock.Of<ISpell>();
            var abilityScore = Mock.Of<IAbilityScore>();
            Func<byte> casterLevel = () => 1;

            CastableSpell castable = new CastableSpell(spell, abilityScore, casterLevel);

            // Act
            Assert.IsInstanceOf<CasterLevel>(castable.CasterLevel);
            Assert.AreSame(spell, castable.Spell);
        }
        #endregion

        #region GetDifficultyClass()
        [Test(Description = "Ensures the GetDifficultyClass() returns null when the spell does not allow a saving throw.")]
		public void GetDifficultyClass_NoSavingThrow()
		{
			// Arrange
			var mockSpell = new Mock<ISpell>();
			mockSpell.Setup(s => s.AllowsSavingThrow)
                     .Returns(false);
			var abilityScore = Mock.Of<IAbilityScore>();
            Func<byte> casterLevel = () => 1;

            CastableSpell castable = new CastableSpell(mockSpell.Object, abilityScore, casterLevel);

			// Act
			var result = castable.GetDifficultyClass();

			// Assert
			Assert.IsFalse(result.HasValue,
                          "Spells which do not allow saving throws should not have a DC associated with them.");
		}


        [Test(Description = "Ensures the GetDifficultyClass() can calculate the simplest DC case correctly.")]
        public void GetDifficultyClass_Basic()
        {
            // Arrange
            var mockSpell = new Mock<ISpell>();
            mockSpell.Setup(s => s.AllowsSavingThrow)
                     .Returns(true);
            mockSpell.Setup(s => s.Level)
                     .Returns(3);
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(a => a.GetBonus())
                            .Returns(5);

            Func<byte> casterLevel = () => 1;

            CastableSpell castable = new CastableSpell(mockSpell.Object, mockAbilityScore.Object, casterLevel);

            // Act
            var result = castable.GetDifficultyClass();

			// Assert
			Assert.IsTrue(result.HasValue);
			Assert.AreEqual(18, result.Value,
					  "The DC should be: 20 = (10 base) + (5 ability) + (3 level) + (2 untyped)");
        }


		[Test(Description = "Ensures the GetDifficultyClass() can calculate complicated DCs, such as from Spell Focus.")]
		public void GetDifficultyClass_SpellFocus()
		{
			// Arrange
			var mockSpell = new Mock<ISpell>();
            mockSpell.Setup(s => s.AllowsSavingThrow)
                     .Returns(true);
			mockSpell.Setup(s => s.Level)
                     .Returns(3);
			var mockAbilityScore = new Mock<IAbilityScore>();
			mockAbilityScore.Setup(a => a.GetBonus())
                            .Returns(5);
            Func<byte> casterLevel = () => 1;

            CastableSpell castable = new CastableSpell(mockSpell.Object, mockAbilityScore.Object, casterLevel);
            castable.AddDifficultyClassBonus(2);

			// Act
			var result = castable.GetDifficultyClass();

            // Assert
            Assert.IsTrue(result.HasValue);
                  Assert.AreEqual(20, result.Value,
                            "The DC should be: 20 = (10 base) + (5 ability) + (3 level) + (2 untyped)");
		}
		#endregion
	}
}