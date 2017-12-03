using System;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.Skills;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Items.Shields.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class WingedShieldTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of WingedShield.")]
        public void Default()
        {
            // Arrange
            var shield = new WingedShield();

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
            Assert.AreEqual(5, shield.GetCasterLevel());
            Assert.AreEqual(11, shield.GetHardness());
            Assert.AreEqual(45, shield.GetHitPoints());
            Assert.AreEqual(17_257, shield.GetMarketPrice());
            Assert.That(shield.GetName(),
                        Has.Exactly(1).Matches<INameFragment>(nf => "Winged Shield" == nf.Text));
            Assert.That(shield.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Transmutation == s));
            Assert.AreEqual(5, shield.GetShieldBonus());
            Assert.AreEqual(10, shield.GetWeight());
        }


        [Test(Description = "Ensures that passing a null ICharacter argument to WingedShield.ApplyTo() throws an exception.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            var shield = new WingedShield();

            // Act
            TestDelegate applyTo = () => shield.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures Winged Shield will apply an AC bonus and armor check penalties to a character, and let the character use Fly as a spell-like ability..")]
        public void ApplyTo_ArmorBonusAndArmorCheckPenalty()
        {
            // Arrange
            var slaKnown = Mock.Of<ISpellLikeAbilityCollection>();

            var unaffectedPenalty = Mock.Of<IModifierTracker>();
            var mockUnaffectedSkill = new Mock<ISkill>();
            mockUnaffectedSkill.Setup(s => s.ArmorCheckPenaltyApplies)
                               .Returns(false);
            mockUnaffectedSkill.Setup(s => s.Penalties)
                               .Returns(unaffectedPenalty);

            var affectedPenalty = Mock.Of<IModifierTracker>();
            var mockAffectedSkill = new Mock<ISkill>();
            mockAffectedSkill.Setup(s => s.ArmorCheckPenaltyApplies)
                               .Returns(true);
            mockAffectedSkill.Setup(s => s.Penalties)
                             .Returns(affectedPenalty);

            var shieldBonusTracker = Mock.Of<IModifierTracker>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.SpellLikeAbilities.Known)
                         .Returns(slaKnown);
            mockCharacter.Setup(c => c.ArmorClass.ShieldBonuses)
                         .Returns(shieldBonusTracker);
            mockCharacter.Setup(c => c.Skills.GetAllSkills())
                         .Returns(new ISkill[] { mockUnaffectedSkill.Object, mockAffectedSkill.Object });

            var shield = new WingedShield();

            // Act
            shield.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(shieldBonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 5 == calc())),
                        "Winged Shield should add a +5 shield bonus to a character's armor class.");
            Mock.Get(unaffectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Winged Shield should not add penalties to skills where armor check penalties do not apply.");
            Mock.Get(affectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Winged Shield should add a -1 penalty to skills where armor check penalties apply.");
            Mock.Get(slaKnown)
                .Verify(r => r.Add(It.Is<ISpellLikeAbility>(sla => sla.Spell is Core.Domain.Spells.Paizo.CoreRulebook.Fly
                                                            && 1 == sla.UsesPerDay
                                                            && 5 == sla.CasterLevel.GetTotal()
                                                            && 3 == sla.Spell.Level)),
                        "Winged Shield should let character use Fly (level 3) once per day as a spell-like ability at caster level 5.");
        }
    }
}