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
    public class RhinoHideTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of RhinoHide.")]
        public void Default()
        {
            // Arrange
            var armor = new RhinoHide();

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.AreEqual(1, armor.GetArmorCheckPenalty());
            Assert.AreEqual(9, armor.GetCasterLevel());
            Assert.AreEqual(6, armor.GetHardness());
            Assert.AreEqual(40, armor.GetHitPoints());
            Assert.AreEqual(5165, armor.GetMarketPrice());
            Assert.That(armor.GetName(),
                        Has.Exactly(1).Matches<INameFragment>(nf => "Rhino Hide" == nf.Text));
            Assert.That(armor.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Transmutation == s));
            Assert.AreEqual(6, armor.GetArmorBonus());
            Assert.AreEqual(25, armor.GetWeight());
        }


        [Test(Description = "Ensures that passing a null ICharacter argument to RhinoHide.ApplyTo() throws an exception.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            var armor = new RhinoHide();

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

            var armor = new RhinoHide();

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(armorBonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 6 == calc())),
                        "Rhino Hide should add a +6 armor bonus to a character's armor class.");
            Mock.Get(maxDexPenaltyTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 4 == calc())),
                        "Rhino Hide should inflict a +4 max dex bonus to a character's armor class.");
            Mock.Get(affectedMovement)
                .Verify(bt => bt.Add(It.Is<Func<byte>> (calc => 2 == calc())),
                        "Rhino Hide should reduce a speed from 30ft to 20ft.");
            Mock.Get(unaffectedMovement)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Rhino Hide should not penalize a movement mode which does not have a base speed.");
            Mock.Get(unaffectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Rhino Hide should not add penalties to skills where armor check penalties do not apply.");
            Mock.Get(affectedPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Rhino Hide should add a -1 penalty to skills where armor check penalties apply.");
        }
    }
}