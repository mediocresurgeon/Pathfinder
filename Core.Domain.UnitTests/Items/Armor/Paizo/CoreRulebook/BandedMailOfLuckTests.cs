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
    public class BandedMailOfLuckTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of BandedMailOfLuck.")]
        public void Default()
        {
            // Arrange
            var armor = new BandedMailOfLuck();

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.AreEqual(5, armor.GetArmorCheckPenalty());
            Assert.AreEqual(12, armor.GetCasterLevel());
            Assert.AreEqual(16, armor.GetHardness());
            Assert.AreEqual(65, armor.GetHitPoints());
            Assert.AreEqual(18_900, armor.GetMarketPrice());
            Assert.That(armor.GetName(),
                        Has.Exactly(1).Matches<INameFragment>(nf => "Banded Mail of Luck" == nf.Text));
            Assert.That(armor.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Enchantment == s));
            Assert.AreEqual(10, armor.GetArmorBonus());
            Assert.AreEqual(35, armor.GetWeight());
        }


        [Test(Description = "Ensures that passing a null ICharacter argument to BandedMailofLuck.ApplyTo() throws an exception.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            var armor = new BandedMailOfLuck();

            // Act
            TestDelegate applyTo = () => armor.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures Banded Mail of Luck will apply an AC bonus and armor check penalties to a character.")]
        public void ApplyTo_ArmorBonusAndArmorCheckPenalty()
        {
            // Arrange
            var affectedMovement = Mock.Of<IModifierTracker>();
            var mockAffectedMovement = new Mock<IMovement>();
            mockAffectedMovement.Setup(m => m.BaseSpeed)
                                .Returns(6);
            mockAffectedMovement.Setup(m => m.Penalties)
                                .Returns(affectedMovement);

            var unaffectedMovement = Mock.Of<IModifierTracker>();
            var mockUnaffectedMovement = new Mock<IMovement>();
            mockUnaffectedMovement.Setup(m => m.BaseSpeed)
                                .Returns((byte?)null);
            mockUnaffectedMovement.Setup(m => m.Penalties)
                                .Returns(unaffectedMovement);

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
            mockCharacter.Setup(c => c.MovementModes.GetAll())
                         .Returns(new IMovement[] { mockUnaffectedMovement.Object, mockAffectedMovement.Object });
            mockCharacter.Setup(c => c.Skills.GetAllSkills())
                         .Returns(new ISkill[] { mockUnaffectedSkill.Object, mockAffectedSkill.Object });

            var armor = new BandedMailOfLuck();

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(armorBonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 10 == calc())),
                        "Banded Mail of Luck should add a +10 armor bonus to a character's armor class.");
            Mock.Get(maxDexPenaltyTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Banded Mail of Luck should inflict a +1 max dex bonus to a character's armor class.");
            Mock.Get(affectedMovement)
                .Verify(bt => bt.Add(It.Is<Func<byte>> (calc => 2 == calc())),
                        "Banded Mail of Luck should reduce a speed from 30ft to 20ft.");
            Mock.Get(unaffectedMovement)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Banded Mail of Luck should not penalize a movement mode which does not have a base speed.");
            Mock.Get(unaffectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Banded Mail of Luck should not add penalties to skills where armor check penalties do not apply.");
            Mock.Get(affectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 5 == calc())),
                        "Banded Mail of Luck should add a -5 penalty to skills where armor check penalties apply.");
        }
    }
}