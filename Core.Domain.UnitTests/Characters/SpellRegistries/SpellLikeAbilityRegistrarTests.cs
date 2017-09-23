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
            IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;

            ICharacter character = new Mock<ICharacter>().Object;
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
            ISpell spell = new Mock<ISpell>().Object;
            IAbilityScore abilityScore = null;

            ICharacter character = new Mock<ICharacter>().Object;
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
            mockSpell.Setup(s => s.Level).Returns(7);
            ISpell spell = mockSpell.Object;

            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(ab => ab.GetBonus()).Returns(4);
            IAbilityScore abilityScore = mockAbilityScore.Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level).Returns(19);
            mockCharacter.Setup(c => c.Charisma).Returns(abilityScore);
            ICharacter character = mockCharacter.Object;

            SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            // Act
            ISpellLikeAbility sla = slaReg.Register(usesPerDay, spell, character.Charisma);

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
            byte casterLevel = 10;
            ISpell spell = null;
            IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;

            ICharacter character = new Mock<ICharacter>().Object;
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
            byte casterLevel = 10;
            ISpell spell = new Mock<ISpell>().Object;
            IAbilityScore abilityScore = null;

            ICharacter character = new Mock<ICharacter>().Object;
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
            byte casterLevel = 9;

            var mockSpell = new Mock<ISpell>();
            mockSpell.Setup(s => s.Level).Returns(7);
            ISpell spell = mockSpell.Object;

            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(ab => ab.GetBonus()).Returns(4);
            IAbilityScore abilityScore = mockAbilityScore.Object;

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Level).Returns(19);
            mockCharacter.Setup(c => c.Charisma).Returns(abilityScore);
            ICharacter character = mockCharacter.Object;

            SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            // Act
            ISpellLikeAbility sla = slaReg.Register(usesPerDay, spell, character.Charisma, casterLevel);

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
            ISpell spell = new Mock<ISpell>().Object;
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;

			ICharacter character = new Mock<ICharacter>().Object;
			SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            ISpellLikeAbility sla = slaReg.Register(usesPerDay, spell, abilityScore);

            // Act
            var result = slaReg.GetSpellLikeAbilities();

            // Assert
            Assert.AreEqual(1, result.Length);
            Assert.Contains(sla, result);
        }


		[Test(Description = "Ensures that registered spell-like abilities can be retrieved later.")]
		public void GetSpellLikeAbilities_Register2_RoundTrip()
		{
			// Arrange
			byte usesPerDay = 3;
            byte casterLevel = 10;
			ISpell spell = new Mock<ISpell>().Object;
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;

			ICharacter character = new Mock<ICharacter>().Object;
			SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

			ISpellLikeAbility sla = slaReg.Register(usesPerDay, spell, abilityScore, casterLevel);

			// Act
			var result = slaReg.GetSpellLikeAbilities();

			// Assert
			Assert.AreEqual(1, result.Length);
			Assert.Contains(sla, result);
		}
		#endregion

		#region OnSpellLikeAbilityRegistered()
        [Test(Description = "Ensures that calling the Register() method triggers the OnSpellLikeAbilityRegistered event.")]
        public void Register1_TriggersEvent()
        {
			// Arrange
			byte usesPerDay = 3;
			ISpell spell = new Mock<ISpell>().Object;
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;

			ICharacter character = new Mock<ICharacter>().Object;
			SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

            bool wasCalled = false; // This tracks whether the event was fired.
            OnSpellLikeAbilityRegisteredEventHandler handler = (sender, e) => wasCalled = true;
            slaReg.OnSpellLikeAbilityRegistered(handler);

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
            byte casterLevel = 10;
			ISpell spell = new Mock<ISpell>().Object;
			IAbilityScore abilityScore = new Mock<IAbilityScore>().Object;

			ICharacter character = new Mock<ICharacter>().Object;
			SpellLikeAbilityRegistrar slaReg = new SpellLikeAbilityRegistrar(character);

			bool wasCalled = false; // This tracks whether the event was fired.
			OnSpellLikeAbilityRegisteredEventHandler handler = (sender, e) => wasCalled = true;
			slaReg.OnSpellLikeAbilityRegistered(handler);

			// Act
            slaReg.Register(usesPerDay, spell, abilityScore, casterLevel);

			// Assert
			Assert.IsTrue(wasCalled);
		}
		#endregion
	}
}