using Core.Domain.Characters;
using Core.Domain.Characters.Feats.Paizo.CoreRulebook;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Feats.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class SpellFocusTests
    {
        [Test(Description = "Ensures the name of the feat includes the school the feat applies to.")]
        public void Name_UsesSchool()
        {
            // Arrange
            var feat = new SpellFocus(School.Enchantment);

            // Act
            var result = feat.Name;

            // Assert
            Assert.AreEqual("Spell Focus (Enchantment)", result.Text);
        }

        [Test(Description = "Ensures that applying this feat to a character calls the AddDifficultyClassBonus(1) method of all matching registered spells and spell-like abilities.")]
        public void ApplyTo_AddDifficultyClassBonus()
        {
            /* This test is a bit complex for a unit test, but bear with me.
             * Consider the following situation:
             *  Character has two spells registered: an enchantment spell and a necromany spell
             *  Character has two spell-like abilities registered: an enchantment SLA and a necromancy SLA
             *  The character learns Spell Focus: Necromancy
             * We would expect that...
             *  Enchantment spell remains unaffected
             *  Necromancy spell has DC increased by +1
             *  Enchantment SLA remains unaffected
             *  Necromancy SLA has DC increased by +1
             * Simple, right?
             * The scary wall of text is from setting up mocks.
             */

			// Arrange
			#region Mock ICastable (necromancy)
			// Set up ICastableSpell from Necromancy school
			bool necromancySpellMethodCalled = false;
            var mockNecromancySpell = new Mock<ISpell>();
            mockNecromancySpell.Setup(ns => ns.School)
                               .Returns(School.Necromancy);
            var mockCastableNecromancy = new Mock<ICastableSpell>();
            mockCastableNecromancy.Setup(c => c.Spell)
                                  .Returns(mockNecromancySpell.Object);
            mockCastableNecromancy.Setup(c => c.AddDifficultyClassBonus(It.Is<byte>(dcBonus => dcBonus == 1)))
                                  .Callback(() => necromancySpellMethodCalled = true);
            var castableNecromancy = mockCastableNecromancy.Object;
            #endregion

            #region Mock ICastable (enchantment)
            bool enchantmentSpellMethodCalled = false;
            var mockEnchantmentSpell = new Mock<ISpell>();
            mockEnchantmentSpell.Setup(ns => ns.School)
                                .Returns(School.Enchantment);
            var mockCastableEnchantment = new Mock<ICastableSpell>();
            mockCastableEnchantment.Setup(c => c.Spell)
                                  .Returns(mockEnchantmentSpell.Object);
            mockCastableEnchantment.Setup(c => c.AddDifficultyClassBonus(It.Is<byte>(dcBonus => dcBonus == 1)))
                                  .Callback(() => enchantmentSpellMethodCalled = true);
            var castableEnchantment = mockCastableEnchantment.Object;
            #endregion

            #region mock ISpellRegistrar
            var mockSpellRegistrar = new Mock<ISpellRegistrar>();
            mockSpellRegistrar.Setup(sr => sr.GetSpells())
                              .Returns(new ICastableSpell[] { castableEnchantment, castableNecromancy });
            #endregion

            #region Mock ISpellLikeAbility (necromancy)
            // Set up ICastableSpell from Necromancy school
            bool necromancySlaMethodCalled = false;
            var mockSlaNecromancy = new Mock<ISpellLikeAbility>();
            mockSlaNecromancy.Setup(c => c.Spell)
                                  .Returns(mockNecromancySpell.Object);
            mockSlaNecromancy.Setup(c => c.AddDifficultyClassBonus(It.Is<byte>(dcBonus => dcBonus == 1)))
                                  .Callback(() => necromancySlaMethodCalled = true);
            var slaNecromancy = mockSlaNecromancy.Object;
            #endregion

            #region Mock ISpellLikeAbility (enchantment)
            bool enchantmentSlaMethodCalled = false;
            var mockSlaEnchantment = new Mock<ISpellLikeAbility>();
            mockSlaEnchantment.Setup(c => c.Spell)
                                  .Returns(mockEnchantmentSpell.Object);
            mockSlaEnchantment.Setup(c => c.AddDifficultyClassBonus(It.Is<byte>(dcBonus => dcBonus == 1)))
                                  .Callback(() => enchantmentSpellMethodCalled = true);
            var slaEnchantment = mockSlaEnchantment.Object;
            #endregion

            #region mock ISpellLikeAbilityRegistrar
            var mockSlaRegistrar = new Mock<ISpellLikeAbilityRegistrar>();
            mockSlaRegistrar.Setup(sr => sr.GetSpellLikeAbilities())
                            .Returns(new ISpellLikeAbility[] { slaEnchantment, slaNecromancy });
            #endregion

            #region Mock SpellSection
            var mockSpellSection = new Mock<ISpellSection>();
            mockSpellSection.Setup(ss => ss.Registrar)
                            .Returns(mockSpellRegistrar.Object);
            #endregion

            #region mock SpellLikeAbilitySection
            var mockSlaSection = new Mock<ISpellLikeAbilitySection>();
            mockSlaSection.Setup(slaSec => slaSec.Registrar)
                          .Returns(mockSlaRegistrar.Object);
            #endregion

            #region Mock ICharacter
            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Spells)
                         .Returns(mockSpellSection.Object);
            mockCharacter.Setup(c => c.SpellLikeAbilities)
                         .Returns(mockSlaSection.Object);
            #endregion

            var spellFocus = new SpellFocus(School.Necromancy);

            // Act
            spellFocus.ApplyTo(mockCharacter.Object);

            // Assert
            Assert.IsTrue(necromancySpellMethodCalled,
                          "Spell Focus: Necromancy should increase the DC of necromancy spells.");
            Assert.IsFalse(enchantmentSpellMethodCalled,
                          "Spell Focus: Necromancy should not increase the DC of non-necromancy spells.");
            Assert.IsTrue(necromancySlaMethodCalled,
                         "Spell Focus: Necromancy should increase the DC of necromancy spell-like abilities.");
            Assert.IsFalse(enchantmentSlaMethodCalled,
                          "Spell Focus: Necromancy should not increase the DC of non-necromancy spell-like abilities.");
        }


        [Test(Description = "Ensures that applying SpellFocus to a character subscribes to Registrar events.")]
        public void ApplyTo_SubscribesTo_OnRegisteredEvents()
        {
            // Arrange
            #region mock ISpellRegistrar
            var spellRegistrarEventSubscribed = false;
			var mockSpellRegistrar = new Mock<ISpellRegistrar>();
			mockSpellRegistrar.Setup(sr => sr.GetSpells())
							  .Returns(new ICastableSpell[0]);
            mockSpellRegistrar.Setup(sr => sr.OnRegistered(It.IsNotNull<OnSpellRegisteredEventHandler>()))
                              .Callback(() => spellRegistrarEventSubscribed = true);
			#endregion

			#region mock ISpellLikeAbilityRegistrar
            var slaRegistrarEventSubscribed = false;
			var mockSlaRegistrar = new Mock<ISpellLikeAbilityRegistrar>();
			mockSlaRegistrar.Setup(sr => sr.GetSpellLikeAbilities())
							.Returns(new ISpellLikeAbility[0]);
            mockSlaRegistrar.Setup(sr => sr.OnRegistered(It.IsNotNull<OnSpellLikeAbilityRegisteredEventHandler>()))
							  .Callback(() => slaRegistrarEventSubscribed = true);
			#endregion

			#region Mock SpellSection
			var mockSpellSection = new Mock<ISpellSection>();
			mockSpellSection.Setup(ss => ss.Registrar)
							.Returns(mockSpellRegistrar.Object);
			#endregion

			#region mock SpellLikeAbilitySection
			var mockSlaSection = new Mock<ISpellLikeAbilitySection>();
			mockSlaSection.Setup(slaSec => slaSec.Registrar)
						  .Returns(mockSlaRegistrar.Object);
			#endregion

			#region Mock ICharacter
			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Spells)
						 .Returns(mockSpellSection.Object);
			mockCharacter.Setup(c => c.SpellLikeAbilities)
						 .Returns(mockSlaSection.Object);
            #endregion

            var spellFocus = new SpellFocus(School.Necromancy);

            // Act
            spellFocus.ApplyTo(mockCharacter.Object);

            // Assert
            Assert.IsTrue(spellRegistrarEventSubscribed,
                          "Spell Focus should add an event listener to Character.SpellRegistrar.OnSpellRegistered()");
			Assert.IsTrue(slaRegistrarEventSubscribed,
						  "Spell Focus should add an event listener to Character.SpellLikeAbilityRegistrar.OnSpellLikeAbilityRegistered()");
		}
    }
}