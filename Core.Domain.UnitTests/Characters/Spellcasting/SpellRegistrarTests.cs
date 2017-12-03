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
    [Parallelizable]
    public class SpellRegistrarTests
    {
		#region Constructor
		[Test(Description = "Ensures that SpellRegistrar cannot be created with a null ICharacter argument.")]
		public void Constructor_NullCharacter_Throws()
		{
			// Arrange
			ICharacter character = null;

			// Act
			TestDelegate constructor = () => new SpellRegistrar(character);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor);
		}
		#endregion

		#region Register()
		[Test(Description = "Ensures that calling Register() with a null ISpell argument throws an ArgumentNullException.")]
		public void Register1_NullISpell_Throws()
		{
			// Arrange
			ISpell spell = null;
			var abilityScore = Mock.Of<IAbilityScore>();

			var character = Mock.Of<ICharacter>();
			SpellRegistrar spellReg = new SpellRegistrar(character);

			// Act
			TestDelegate registerMethod = () => spellReg.Register(spell, abilityScore);

			// Assert
			Assert.Throws<ArgumentNullException>(registerMethod,
												 "Null arguments are not allowed.");
		}


		[Test(Description = "Ensures that calling Register() with a null IAbilityScore argument throws an ArgumentNullException.")]
		public void Register1_NullIAbilityScore_Throws()
		{
			// Arrange
			var spell = Mock.Of<ISpell>();
			IAbilityScore abilityScore = null;

			var character = Mock.Of<ICharacter>();
			SpellRegistrar spellReg = new SpellRegistrar(character);

			// Act
			TestDelegate registerMethod = () => spellReg.Register(spell, abilityScore);

			// Assert
			Assert.Throws<ArgumentNullException>(registerMethod,
												 "Null arguments are not allowed.");
		}


		[Test(Description = "Ensures that calling Register() with sensible arguments results in a configured ICastableSpell.")]
		public void Register1_Returns_ConfiguredISpellLikeAbility()
		{
			// Arrange
			var mockSpell = new Mock<ISpell>();
			mockSpell.Setup(s => s.Level)
                     .Returns(7);
			ISpell spell = mockSpell.Object;

			var mockAbilityScore = new Mock<IAbilityScore>();
			mockAbilityScore.Setup(ab => ab.GetBonus())
                            .Returns(4);
			IAbilityScore abilityScore = mockAbilityScore.Object;

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Level)
                         .Returns(19);
			ICharacter character = mockCharacter.Object;

			SpellRegistrar spellReg = new SpellRegistrar(character);

			// Act
            ICastableSpell castable = spellReg.Register(spell, abilityScore);

			// Assert
			Assert.AreSame(spell, castable.Spell);
		}


		[Test(Description = "Ensures that calling Register() with a null ISpell argument throws an ArgumentNullException.")]
		public void Register2_NullISpell_Throws()
		{
			// Arrange
			Func<byte> casterLevel = () => 10;
			ISpell spell = null;
			var abilityScore = Mock.Of<IAbilityScore>();

			var character = Mock.Of<ICharacter>();
			SpellRegistrar spellReg = new SpellRegistrar(character);

			// Act
			TestDelegate registerMethod = () => spellReg.Register(spell, abilityScore, casterLevel);

			// Assert
			Assert.Throws<ArgumentNullException>(registerMethod,
												 "Null arguments are not allowed.");
		}


		[Test(Description = "Ensures that calling Register() with a null IAbilityScore argument throws an ArgumentNullException.")]
		public void Register2_NullIAbilityScore_Throws()
		{
			// Arrange
			Func<byte> casterLevel = () => 10;
			var spell = Mock.Of<ISpell>();
			IAbilityScore abilityScore = null;

			var character = Mock.Of<ICharacter>();
			SpellRegistrar spellReg = new SpellRegistrar(character);

			// Act
			TestDelegate registerMethod = () => spellReg.Register(spell, abilityScore, casterLevel);

			// Assert
			Assert.Throws<ArgumentNullException>(registerMethod,
												 "Null arguments are not allowed.");
		}


		[Test(Description = "Ensures that calling Register() with sensible arguments results in a configured ICastableSpell.")]
		public void Register2_Returns_ConfiguredISpellLikeAbility()
		{
			// Arrange
			Func<byte> casterLevel = () => 9;

			var mockSpell = new Mock<ISpell>();
			mockSpell.Setup(s => s.Level)
                     .Returns(7);
			ISpell spell = mockSpell.Object;

			var mockAbilityScore = new Mock<IAbilityScore>();
			mockAbilityScore.Setup(ab => ab.GetBonus())
                            .Returns(4);
			IAbilityScore abilityScore = mockAbilityScore.Object;

			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Level)
                         .Returns(19);
			ICharacter character = mockCharacter.Object;

			SpellRegistrar spellReg = new SpellRegistrar(character);

			// Act
            ICastableSpell castable = spellReg.Register(spell, abilityScore, casterLevel);

			// Assert
			Assert.IsNotNull(castable);
			Assert.AreSame(spell, castable.Spell);
		}
		#endregion

		#region GetSpellLikeAbilities()
		[Test(Description = "Ensures that registered spells can be retrieved later.")]
		public void GetSpellLikeAbilities_Register1_RoundTrip()
		{
			// Arrange
			var spell = Mock.Of<ISpell>();
			var abilityScore = Mock.Of<IAbilityScore>();

			var character = Mock.Of<ICharacter>();
			SpellRegistrar spellReg = new SpellRegistrar(character);

            ICastableSpell castable = spellReg.Register(spell, abilityScore);

			// Act
            var result = spellReg.GetSpells();

			// Assert
            Assert.That(result,
                        Has.Exactly(1).Matches<ICastableSpell>(sp => castable == sp));
		}


		[Test(Description = "Ensures that registered spells can be retrieved later.")]
		public void GetSpellLikeAbilities_Register2_RoundTrip()
		{
			// Arrange
			Func<byte> casterLevel = () => 10;
			var spell = Mock.Of<ISpell>();
			var abilityScore = Mock.Of<IAbilityScore>();

			var character = Mock.Of<ICharacter>();
			SpellRegistrar spellReg = new SpellRegistrar(character);

			ICastableSpell castable = spellReg.Register(spell, abilityScore, casterLevel);

			// Act
            var result = spellReg.GetSpells();

			// Assert
            Assert.That(result,
                        Has.Exactly(1).Matches<ICastableSpell>(sp => castable == sp));
		}
        #endregion

        #region OnRegistered()
        [Test(Description = "Ensures that calling SpellRegistrar.OnRegistered() with a null argument throws an exception.")]
        public void OnRegistered_NullHandler_Throws()
        {
            // Arrange
            var spell = Mock.Of<ISpell>();
            var abilityScore = Mock.Of<IAbilityScore>();

            var character = Mock.Of<ICharacter>();
            SpellRegistrar spellReg = new SpellRegistrar(character);

            // Act
            TestDelegate onReg = () => spellReg.OnRegistered(null);

            // Assert
            Assert.Throws<ArgumentNullException>(onReg);
        }
        #endregion

        #region OnSpellLikeAbilityRegistered()
        [Test(Description = "Ensures that calling the Register() method triggers the OnSpellRegistered event.")]
		public void Register1_TriggersEvent()
		{
			// Arrange
			var spell = Mock.Of<ISpell>();
			var abilityScore = Mock.Of<IAbilityScore>();

			var character = Mock.Of<ICharacter>();
			SpellRegistrar spellReg = new SpellRegistrar(character);

			bool wasCalled = false; // This tracks whether the event was fired.
			OnSpellRegisteredEventHandler handler = (sender, e) => wasCalled = true;
            spellReg.OnRegistered(handler);

			// Act
			spellReg.Register(spell, abilityScore);

			// Assert
			Assert.IsTrue(wasCalled);
		}


		[Test(Description = "Ensures that calling the Register() method triggers the OnSpellRegistered event.")]
		public void Register2_TriggersEvent()
		{
			// Arrange
			Func<byte> casterLevel = () => 10;
			var spell = Mock.Of<ISpell>();
			var abilityScore = Mock.Of<IAbilityScore>();

			var character = Mock.Of<ICharacter>();
			SpellRegistrar spellReg = new SpellRegistrar(character);

			bool wasCalled = false; // This tracks whether the event was fired.
			OnSpellRegisteredEventHandler handler = (sender, e) => wasCalled = true;
			spellReg.OnRegistered(handler);

			// Act
			spellReg.Register(spell, abilityScore, casterLevel);

			// Assert
			Assert.IsTrue(wasCalled);
		}
		#endregion
	}
}