using System;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.Skills;
using Core.Domain.Items.Shields.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class SpinedShieldTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of SpinedShield.")]
        public void Default()
        {
            // Arrange
            var shield = new SpinedShield();

            // Assert
            Assert.IsTrue(shield.IsMasterwork);
            Assert.AreEqual(1, shield.GetArmorCheckPenalty());
            Assert.AreEqual(6, shield.GetCasterLevel());
            Assert.AreEqual(12, shield.GetHardness());
            Assert.AreEqual(30, shield.GetHitPoints());
            Assert.AreEqual(5580, shield.GetMarketPrice());
            Assert.That(shield.GetName(),
                        Has.Exactly(1).Matches<INameFragment>(nf => "Spined Shield" == nf.Text));
            Assert.That(shield.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Evocation == s));
            Assert.AreEqual(3, shield.GetShieldBonus());
            Assert.AreEqual(15, shield.GetWeight());
        }


        [Test(Description = "Ensures that passing a null ICharacter argument to SpinedShield.ApplyTo() throws an exception.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            var shield = new SpinedShield();

            // Act
            TestDelegate applyTo = () => shield.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures Spined Shield will apply an AC bonus and armor check penalties to a character.")]
        public void ApplyTo_ArmorBonusAndArmorCheckPenalty()
        {
            // Arrange
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
            mockCharacter.Setup(c => c.ArmorClass.ShieldBonuses)
                         .Returns(shieldBonusTracker);
            mockCharacter.Setup(c => c.Skills.GetAllSkills())
                         .Returns(new ISkill[] { mockUnaffectedSkill.Object, mockAffectedSkill.Object });

            var shield = new SpinedShield();

            // Act
            shield.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(shieldBonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 3 == calc())),
                        "Spined Shield should add a +3 shield bonus to a character's armor class.");
            Mock.Get(unaffectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Spined Shield should not add penalties to skills where armor check penalties do not apply.");
            Mock.Get(affectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Spined Shield should add a -1 penalty to skills where armor check penalties apply.");
        }
    }
}