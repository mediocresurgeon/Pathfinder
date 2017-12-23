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
    public class SpellLikeAbilityRegistrarTests
    {
        #region Constructor
        [Test(Description = "Ensures that SpellLikeAbilityRegistrar cannot be created with a null ICharacter argument.")]
        public void Constructor_NullCharacter_Throws()
        {
            // Arrange
            ICharacter character = null;

            // Act
            TestDelegate constructor = () => new SpellLikeAbilityRegistrar(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Register()
        [Test(Description = "Ensures that calling Register() with a null ISpell argument throws an ArgumentNullException.")]
        public void Register1_NullISpell_Throws()
        {
            // Arrange
            byte usesPerDay = 3;
            ISpell spell = null;
            var abilityScore = Mock.Of<IAbilityScore>();

            var character = Mock.Of<ICharacter>();
            SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            // Act
            TestDelegate registerMethod = () => slaReg.Register(usesPerDay, spell, abilityScore);

            // Assert
            Assert.Throws<ArgumentNullException>(registerMethod,
                                                 "Null arguments are not allowed.");
        }


        [Test(Description = "Ensures that calling Register() with a null IAbilityScore argument throws an ArgumentNullException.")]
        public void Register1_NullIAbilityScore_Throws()
        {
            // Arrange
            byte usesPerDay = 3;
            var spell = Mock.Of<ISpell>();
            IAbilityScore abilityScore = null;

            var character = Mock.Of<ICharacter>();
            SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            // Act
            TestDelegate registerMethod = () => slaReg.Register(usesPerDay, spell, abilityScore);

            // Assert
            Assert.Throws<ArgumentNullException>(registerMethod,
                                                 "Null arguments are not allowed.");
        }


        [Test(Description = "Ensures that calling Register() with sensible arguments results in a configured ISpellLikeAbility.")]
        public void Register1_Returns_ConfiguredISpellLikeAbility()
        {
            // Arrange
            byte usesPerDay = 3;

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

            SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            // Act
            ISpellLikeAbility sla = slaReg.Register(usesPerDay, spell, abilityScore);

            // Assert
            Assert.IsNotNull(sla);
            Assert.AreEqual(usesPerDay, sla.UsesPerDay);
            Assert.AreSame(spell, sla.Spell);
        }


        [Test(Description = "Ensures that calling Register() with a null ISpell argument throws an ArgumentNullException.")]
        public void Register2_NullISpell_Throws()
        {
            // Arrange
            byte usesPerDay = 3;
            ISpell spell = null;
            var abilityScore = Mock.Of<IAbilityScore>();
            Func<byte> casterLevel = () => 10;

            var character = Mock.Of<ICharacter>();
            SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            // Act
            TestDelegate registerMethod = () => slaReg.Register(usesPerDay, spell, abilityScore, casterLevel);

            // Assert
            Assert.Throws<ArgumentNullException>(registerMethod,
                                                 "Null arguments are not allowed.");
        }


        [Test(Description = "Ensures that calling Register() with a null IAbilityScore argument throws an ArgumentNullException.")]
        public void Register2_NullIAbilityScore_Throws()
        {
            // Arrange
            byte usesPerDay = 3;
            var spell = Mock.Of<ISpell>();
            IAbilityScore abilityScore = null;
            Func<byte> casterLevel = () => 10;

            var character = Mock.Of<ICharacter>();
            SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            // Act
            TestDelegate registerMethod = () => slaReg.Register(usesPerDay, spell, abilityScore, casterLevel);

            // Assert
            Assert.Throws<ArgumentNullException>(registerMethod,
                                                 "Null arguments are not allowed.");
        }


        [Test(Description = "Ensures that calling Register() with a null IAbilityScore argument throws an ArgumentNullException.")]
        public void Register2_NullCasterLevel_Throws()
        {
            // Arrange
            byte usesPerDay = 3;
            var spell = Mock.Of<ISpell>();
            var abilityScore = Mock.Of<IAbilityScore>();
            Func<byte> casterLevel = null;

            var character = Mock.Of<ICharacter>();
            SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            // Act
            TestDelegate registerMethod = () => slaReg.Register(usesPerDay, spell, abilityScore, casterLevel);

            // Assert
            Assert.Throws<ArgumentNullException>(registerMethod,
                                                 "Null arguments are not allowed.");
        }


        [Test(Description = "Ensures that calling Register() with sensible arguments results in a configured ISpellLikeAbility.")]
        public void Register2_Returns_ConfiguredISpellLikeAbility()
        {
            // Arrange
            byte usesPerDay = 3;
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

            SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            // Act
            ISpellLikeAbility sla = slaReg.Register(usesPerDay, spell, abilityScore, casterLevel);

            // Assert
            Assert.IsNotNull(sla);
            Assert.AreEqual(usesPerDay, sla.UsesPerDay);
            Assert.AreSame(spell, sla.Spell);
        }
        #endregion

        #region GetSpellLikeAbilities()
        [Test(Description = "Ensures that registered spell-like abilities can be retrieved later.")]
        public void GetSpellLikeAbilities_Register1_RoundTrip()
        {
            // Arrange
			byte usesPerDay = 3;
            var spell = Mock.Of<ISpell>();
			var abilityScore = Mock.Of<IAbilityScore>();

			var character = Mock.Of<ICharacter>();
			SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            ISpellLikeAbility sla = slaReg.Register(usesPerDay, spell, abilityScore);

            // Act
            var result = slaReg.GetSpellLikeAbilities();

            // Assert
            Assert.That(result,
                        Has.Exactly(1).Matches<ISpellLikeAbility>(rSla => sla == rSla));
        }


		[Test(Description = "Ensures that registered spell-like abilities can be retrieved later.")]
		public void GetSpellLikeAbilities_Register2_RoundTrip()
		{
			// Arrange
			byte usesPerDay = 3;
            Func<byte> casterLevel = () => 10;
			var spell = Mock.Of<ISpell>();
			var abilityScore = Mock.Of<IAbilityScore>();

			var character = Mock.Of<ICharacter>();
			SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

			ISpellLikeAbility sla = slaReg.Register(usesPerDay, spell, abilityScore, casterLevel);

			// Act
			var result = slaReg.GetSpellLikeAbilities();

			// Assert
            Assert.That(result,
                        Has.Exactly(1).Matches<ISpellLikeAbility>(rSla => sla == rSla));
		}
		#endregion

		#region OnSpellLikeAbilityRegistered()
        [Test(Description = "Ensures that calling the Register() method triggers the OnSpellLikeAbilityRegistered event.")]
        public void Register1_TriggersEvent()
        {
			// Arrange
			byte usesPerDay = 3;
			var spell = Mock.Of<ISpell>();
			var abilityScore = Mock.Of<IAbilityScore>();

			var character = Mock.Of<ICharacter>();
			SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            bool wasCalled = false; // This tracks whether the event was fired.
            slaReg.OnRegistered += (sender, e) => {
                wasCalled = true;
            };

			// Act
			slaReg.Register(usesPerDay, spell, abilityScore);

			// Assert
            Assert.IsTrue(wasCalled);
        }


		[Test(Description = "Ensures that calling the Register() method triggers the OnSpellLikeAbilityRegistered event.")]
		public void Register2_TriggersEvent()
		{
			// Arrange
			byte usesPerDay = 3;
            Func<byte> casterLevel = () => 10;
			var spell = Mock.Of<ISpell>();
			var abilityScore = Mock.Of<IAbilityScore>();

			var character = Mock.Of<ICharacter>();
			SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

			bool wasCalled = false; // This tracks whether the event was fired.
            slaReg.OnRegistered += (sender, e) => {
                wasCalled = true;
            };

			// Act
            slaReg.Register(usesPerDay, spell, abilityScore, casterLevel);

			// Assert
			Assert.IsTrue(wasCalled);
		}
		#endregion
	}
}