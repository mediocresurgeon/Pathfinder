using System;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.Movements;
using Core.Domain.Characters.Skills;
using Core.Domain.Items.Armor.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Armor.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class ElvenChainTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of ElvenChain.")]
        public void Default()
        {
            // Arrange
            var armor = new ElvenChain();

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.AreEqual(2, armor.GetArmorCheckPenalty());
            Assert.IsFalse(armor.GetCasterLevel().HasValue);
            Assert.AreEqual(15, armor.GetHardness());
            Assert.AreEqual(30, armor.GetHitPoints());
            Assert.AreEqual(5150, armor.GetMarketPrice());
            Assert.That(armor.GetName(),
                        Has.Exactly(1).Matches<INameFragment>(nf => "Elven Chain" == nf.Text));
            Assert.IsEmpty(armor.GetSchools());
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(20, armor.GetWeight());
        }


        [Test(Description = "Ensures that passing a null ICharacter argument to ElvenChain.ApplyTo() throws an exception.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            var armor = new ElvenChain();

            // Act
            TestDelegate applyTo = () => armor.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures Elven Chain will apply an AC bonus and armor check penalties to a character.")]
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

            var armorBonusTracker = Mock.Of<IModifierTracker>();
            var maxDexPenaltyTracker = Mock.Of<IModifierTracker>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass.ArmorBonuses)
                         .Returns(armorBonusTracker);
            mockCharacter.Setup(c => c.ArmorClass.MaxKeyAbilityScore)
                         .Returns(maxDexPenaltyTracker);
            mockCharacter.Setup(c => c.Skills.GetAllSkills())
                         .Returns(new ISkill[] { mockUnaffectedSkill.Object, mockAffectedSkill.Object });

            var armor = new ElvenChain();

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(armorBonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 6 == calc())),
                        "Elven Chain should add a +6 armor bonus to a character's armor class.");
            Mock.Get(maxDexPenaltyTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 4 == calc())),
                        "Elven Chain should inflict a +1 max dex bonus to a character's armor class.");
            Mock.Get(unaffectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Elven Chain should not add penalties to skills where armor check penalties do not apply.");
            Mock.Get(affectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Elven Chain should add a -2 penalty to skills where armor check penalties apply.");
        }
    }
}