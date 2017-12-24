using System;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.Skills;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Items.Armor.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Armor.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class CelestialArmorTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of Celestial Armor.")]
        public void Default()
        {
            // Arrange
            var armor = new CelestialArmor();

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.AreEqual(2, armor.GetArmorCheckPenalty());
            Assert.AreEqual(5, armor.GetCasterLevel());
            Assert.AreEqual(16, armor.GetHardness());
            Assert.AreEqual(60, armor.GetHitPoints());
            Assert.AreEqual(22_400, armor.GetMarketPrice());
            Assert.That(armor.GetName(),
                        Has.Exactly(1).Matches<INameFragment>(nf => "Celestial Armor" == nf.Text));
            Assert.That(armor.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Transmutation == s));
            Assert.AreEqual(9, armor.GetArmorBonus());
            Assert.AreEqual(20, armor.GetWeight());
        }


        [Test(Description = "Ensures that passing a null ICharacter argument to CelestialArmor.ApplyTo() throws an exception.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            var armor = new CelestialArmor();

            // Act
            TestDelegate applyTo = () => armor.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures Celestial will apply an AC bonus and armor check penalties to a character.")]
        public void ApplyTo_ArmorBonusAndArmorCheckPenalty()
        {
            // Arrange
            var spellLikeAbilities = Mock.Of<ISpellLikeAbilityCollection>();

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

            var armorBonusTracker = Mock.Of<IModifierTracker>();
            var maxDexPenaltyTracker = Mock.Of<IModifierTracker>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass.ArmorBonuses)
                         .Returns(armorBonusTracker);
            mockCharacter.Setup(c => c.ArmorClass.MaxKeyAbilityScore)
                         .Returns(maxDexPenaltyTracker);
            mockCharacter.Setup(c => c.Skills.GetAllSkills())
                         .Returns(new ISkill[] { mockUnaffectedSkill.Object, mockAffectedSkill.Object });
            mockCharacter.Setup(c => c.SpellLikeAbilities.Known)
                         .Returns(spellLikeAbilities);

            var armor = new CelestialArmor();

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(armorBonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 9 == calc())),
                        "Celestial Armor should add a +9 armor bonus to a character's armor class.");
            Mock.Get(maxDexPenaltyTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 8 == calc())),
                        "Celestial Armor should inflict a +8 max dex bonus to a character's armor class.");
            Mock.Get(unaffectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Celestial Armor should not add penalties to skills where armor check penalties do not apply.");
            Mock.Get(affectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Celestial Armor should add a -2 penalty to skills where armor check penalties apply.");
            Mock.Get(spellLikeAbilities)
                .Verify(slac => slac.Add(It.Is<ISpellLikeAbility>(sla => 1 == sla.UsesPerDay
                                                                  && 5 == sla.CasterLevel.GetTotal()
                                                                  && sla.Spell is Core.Domain.Spells.Paizo.CoreRulebook.Fly)),
                        "Celestial Armor lets its wielder use Fly once per day at caster level 5.");
        }
    }
}