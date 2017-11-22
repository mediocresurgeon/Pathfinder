using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
	[TestFixture]
	public class SpellLikeAbilityTests
	{
		#region Constructor
		[Test(Description = "Ensures that null ISpell arguments are not possible.")]
		public void Constructor1_NullISpell_Throws()
		{
            // Arrange
            byte usesPerDay = 1;
			ISpell spell = null;
			var abilityScore = Mock.Of<IAbilityScore>();
			Func<byte> casterLevel = () => 1;

			// Act
			TestDelegate constructor = () => new SpellLikeAbility(usesPerDay, spell, abilityScore, casterLevel);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor,
												"Null arguments should not be accepted.");
		}


		[Test(Description = "Ensures that null IAbilityScore arguments are not possible.")]
		public void Constructor1_NullIAbilityScore_Throws()
		{
			// Arrange
            byte usesPerDay = 1;
			var spell = Mock.Of<ISpell>();
			IAbilityScore abilityScore = null;
			Func<byte> casterLevel = () => 1;

			// Act
			TestDelegate constructor = () => new SpellLikeAbility(usesPerDay, spell, abilityScore, casterLevel);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor,
												"Null arguments should not be accepted.");
		}


        [Test(Description = "Ensures that null ISpell arguments are not possible.")]
        public void Constructor1_NullCasterLevel_Throws()
        {
            // Arrange
            byte usesPerDay = 1;
            var spell = Mock.Of<ISpell>();
            var abilityScore = Mock.Of<IAbilityScore>();
            Func<byte> casterLevel = null;

            // Act
            TestDelegate constructor = () => new SpellLikeAbility(usesPerDay, spell, abilityScore, casterLevel);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor,
                                                "Null arguments should not be accepted.");
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures that a fresh instance of SpellLikeAbility has sensible defaults.")]
        public void Default()
        {
            // Arrange
            byte usesPerDay = 55;
            var spell = Mock.Of<ISpell>();
            var abilityScore = Mock.Of<IAbilityScore>();
            Func<byte> casterLevel = () => 1;

            SpellLikeAbility sla = new SpellLikeAbility(usesPerDay, spell, abilityScore, casterLevel);

            // Assert
            Assert.AreEqual(usesPerDay, sla.UsesPerDay);
        }
        #endregion

	}
}