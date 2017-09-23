using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.SpellRegistries;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
	[TestFixture]
	public class SpellLikeAbilityTests
	{
		#region Constructor 1
		[Test(Description = "Ensures that null ISpell arguments are not possible.")]
		public void Constructor1_NullISpell_Throws()
		{
            // Arrange
            byte usesPerDay = 1;
			ISpell spell = null;
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;
			byte casterLevel = 1;

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
			ISpell spell = new Mock<ISpell>().Object;
			IAbilityScore abilityScore = null;
			byte casterLevel = 1;

			// Act
			TestDelegate constructor = () => new SpellLikeAbility(usesPerDay, spell, abilityScore, casterLevel);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor,
												"Null arguments should not be accepted.");
		}
		#endregion

		#region Constructor 2
		[Test(Description = "Ensures that null ISpell arguments are not possible.")]
		public void Constructor2_NullISpell_Throws()
		{
			// Arrange
            byte usesPerDay = 1;
			ISpell spell = null;
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;
			ICharacter character = new Mock<ICharacter>().Object;

			// Act
			TestDelegate constructor = () => new SpellLikeAbility(usesPerDay, spell, abilityScore, character);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor,
												"Null arguments should not be accepted.");
		}


		[Test(Description = "Ensures that null IAbilityScore arguments are not possible.")]
		public void Constructor2_NullIAbilityScore_Throws()
		{
			// Arrange
            byte usesPerDay = 1;
			ISpell spell = new Mock<ISpell>().Object;
			IAbilityScore abilityScore = null;
			ICharacter character = new Mock<ICharacter>().Object;

			// Act
			TestDelegate constructor = () => new SpellLikeAbility(usesPerDay, spell, abilityScore, character);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor,
												"Null arguments should not be accepted.");
		}


		[Test(Description = "Ensures that null ICharacter arguments are not possible.")]
		public void Constructor2_NullICharacter_Throws()
		{
			// Arrange
            byte usesPerDay = 1;
			ISpell spell = new Mock<ISpell>().Object;
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;
			ICharacter character = null;

			// Act
			TestDelegate constructor = () => new SpellLikeAbility(usesPerDay, spell, abilityScore, character);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor,
												"Null arguments should not be accepted.");
		}
		#endregion

		#region .Spell
		[Test(Description = "Ensures the ISpell given to the constructor is returned from the Spell property.")]
		public void ISpell_Property_IsReturned()
		{
			// Arrange
            byte usesPerDay = 1;
			ISpell spell = new Mock<ISpell>().Object;
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;
			ICharacter character = new Mock<ICharacter>().Object;
			SpellLikeAbility sla = new SpellLikeAbility(usesPerDay, spell, abilityScore, character);

			// Act
			var result = sla.Spell;

			// Assert
			Assert.AreSame(spell, result);
		}
		#endregion

		#region .UsesPerDay
        [Test(Description = "Ensures the usesPerDay given to the constructor is returned from the UsesPerDay property.")]
		public void UsesPerDay_Property_IsReturned()
		{
			// Arrange
			byte usesPerDay = 55;
			ISpell spell = new Mock<ISpell>().Object;
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;
			ICharacter character = new Mock<ICharacter>().Object;
			SpellLikeAbility sla = new SpellLikeAbility(usesPerDay, spell, abilityScore, character);

			// Act
            var result = sla.UsesPerDay;

			// Assert
			Assert.AreEqual(55, result);
		}
        #endregion

        #region GetEffectiveCasterLevel()
        [Test(Description = "Ensures that by default, the character's level is used as the caster level.")]
		public void GetEffectiveCasterLevel_FromCharacter()
		{
			// Arrange
            byte usesPerDay = 1;
			ISpell spell = new Mock<ISpell>().Object;
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;
			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Level).Returns(20);
			SpellLikeAbility sla = new SpellLikeAbility(usesPerDay, spell, abilityScore, mockCharacter.Object);

			// Act
			var result = sla.GetEffectiveCasterLevel();

			// Assert
			Assert.AreEqual(20, result);
		}


		[Test(Description = "Ensures that a specific caster level overrides the character's level when determining the caster level.")]
		public void GetEffectiveCasterLevel_FromByte()
		{
			// Arrange
            byte usesPerDay = 1;
			ISpell spell = new Mock<ISpell>().Object;
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;
			byte casterLevel = 10;
			SpellLikeAbility sla = new SpellLikeAbility(usesPerDay, spell, abilityScore, casterLevel);

			// Act
			var result = sla.GetEffectiveCasterLevel();

			// Assert
			Assert.AreEqual(10, result);
		}
		#endregion

		#region GetDifficultyClass()
		[Test(Description = "Ensures the GetDifficultyClass() returns null when the spell does not allow a saving throw.")]
		public void GetDifficultyClass_NoSavingThrow()
		{
			// Arrange
            byte usesPerDay = 1;
			var mockSpell = new Mock<ISpell>();
			mockSpell.Setup(s => s.AllowsSavingThrow).Returns(false);
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;
			ICharacter character = new Mock<ICharacter>().Object;
			SpellLikeAbility sla = new SpellLikeAbility(usesPerDay, mockSpell.Object, abilityScore, character);

			// Act
			var result = sla.GetDifficultyClass();

			// Assert
			Assert.IsFalse(result.HasValue,
						  "Spells which do not allow saving throws should not have a DC associated with them.");
		}


		[Test(Description = "Ensures the GetDifficultyClass() can calculate the simplest DC case correctly.")]
		public void GetDifficultyClass_Basic()
		{
			// Arrange
            byte usesPerDay = 1;
			var mockSpell = new Mock<ISpell>();
			mockSpell.Setup(s => s.AllowsSavingThrow).Returns(true);
			mockSpell.Setup(s => s.Level).Returns(3);
			var mockAbilityScore = new Mock<IAbilityScore>();
			mockAbilityScore.Setup(a => a.GetBonus()).Returns(5);
			ICharacter character = new Mock<ICharacter>().Object;
			SpellLikeAbility sla = new SpellLikeAbility(usesPerDay, mockSpell.Object, mockAbilityScore.Object, character);

			// Act
			var result = sla.GetDifficultyClass();

			// Assert
			Assert.IsTrue(result.HasValue);
			Assert.AreEqual(18, result.Value,
					  "The DC should be: 20 = (10 base) + (5 ability) + (3 level) + (2 untyped)");
		}


		[Test(Description = "Ensures the GetDifficultyClass() can calculate complicated DCs, such as from Spell Focus.")]
		public void GetDifficultyClass_SpellFocus()
		{
			// Arrange
            byte usesPerDay = 1;
			var mockSpell = new Mock<ISpell>();
			mockSpell.Setup(s => s.AllowsSavingThrow).Returns(true);
			mockSpell.Setup(s => s.Level).Returns(3);
			var mockAbilityScore = new Mock<IAbilityScore>();
			mockAbilityScore.Setup(a => a.GetBonus()).Returns(5);
			ICharacter character = new Mock<ICharacter>().Object;
			SpellLikeAbility sla = new SpellLikeAbility(usesPerDay, mockSpell.Object, mockAbilityScore.Object, character);
			sla.AddDifficultyClassBonus(2);

			// Act
			var result = sla.GetDifficultyClass();

			// Assert
			Assert.IsTrue(result.HasValue);
			Assert.AreEqual(20, result.Value,
					  "The DC should be: 20 = (10 base) + (5 ability) + (3 level) + (2 untyped)");
		}
		#endregion
	}
}