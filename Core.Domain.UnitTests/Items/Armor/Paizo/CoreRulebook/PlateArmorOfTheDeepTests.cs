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
    public class PlateArmorOfTheDeepTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of PlateArmorOfTheDeep.")]
        public void Default()
        {
            // Arrange
            var armor = new PlateArmorOfTheDeep();

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.AreEqual(5, armor.GetArmorCheckPenalty());
            Assert.AreEqual(11, armor.GetCasterLevel());
            Assert.AreEqual(12, armor.GetHardness());
            Assert.AreEqual(55, armor.GetHitPoints());
            Assert.AreEqual(24_650, armor.GetMarketPrice());
            Assert.That(armor.GetName(),
                        Has.Exactly(1).Matches<INameFragment>(nf => "Plate Armor of the Deep" == nf.Text));
            Assert.That(armor.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Abjuration == s));
            Assert.AreEqual(10, armor.GetArmorBonus());
            Assert.AreEqual(50, armor.GetWeight());
        }


        [Test(Description = "Ensures that passing a null ICharacter argument to PlateArmorOfTheDeep.ApplyTo() throws an exception.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            var armor = new PlateArmorOfTheDeep();

            // Act
            TestDelegate applyTo = () => armor.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures Banded Mail of Luck will apply an AC bonus and armor check penalties to a character.")]
        public void ApplyTo_ArmorBonusAndArmorCheckPenalty()
        {
            // Arrange
            var landMovementPenalties = Mock.Of<IModifierTracker>();
            var mockLandMovement = new Mock<IMovement>();
            mockLandMovement.Setup(m => m.BaseSpeed)
                            .Returns(6);
            mockLandMovement.Setup(m => m.Penalties)
                            .Returns(landMovementPenalties);
            var landMovement = mockLandMovement.Object;

            var swimMovementPenalties = Mock.Of<IModifierTracker>();
            var mockSwimMovement = new Mock<IMovement>();
            mockSwimMovement.Setup(m => m.BaseSpeed)
                            .Returns(6);
            mockSwimMovement.Setup(m => m.Penalties)
                            .Returns(swimMovementPenalties);
            var swimMovement = mockSwimMovement.Object;

            var flyMovementPenalties = Mock.Of<IModifierTracker>();
            var mockFlyMovement = new Mock<IFly>();
            mockFlyMovement.Setup(m => m.BaseSpeed)
                           .Returns((byte?)null);
            mockFlyMovement.Setup(m => m.Penalties)
                           .Returns(flyMovementPenalties);
            var flyMovement = mockFlyMovement.Object;

            var affectedSkillPenalty = Mock.Of<IModifierTracker>();
            var mockAffectedSkill = new Mock<ISkill>();
            mockAffectedSkill.Setup(s => s.ArmorCheckPenaltyApplies)
                             .Returns(true);
            mockAffectedSkill.Setup(s => s.Penalties)
                             .Returns(affectedSkillPenalty);

            var unaffectedSkillPenalty = Mock.Of<IModifierTracker>();
            var mockUnaffectedSkill = new Mock<ISkill>();
            mockUnaffectedSkill.Setup(s => s.ArmorCheckPenaltyApplies)
                               .Returns(false);
            mockUnaffectedSkill.Setup(s => s.Penalties)
                             .Returns(unaffectedSkillPenalty);

            var mockSwimSkillPenalty = Mock.Of<IModifierTracker>();
            var mockSwimSkill = new Mock<ISkill>();
            mockSwimSkill.Setup(s => s.ArmorCheckPenaltyApplies)
                         .Returns(true);
            mockSwimSkill.Setup(s => s.Penalties)
                         .Returns(mockSwimSkillPenalty);

            var armorBonusTracker = Mock.Of<IModifierTracker>();
            var maxDexPenaltyTracker = Mock.Of<IModifierTracker>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.ArmorClass.ArmorBonuses)
                         .Returns(armorBonusTracker);
            mockCharacter.Setup(c => c.ArmorClass.MaxKeyAbilityScore)
                         .Returns(maxDexPenaltyTracker);
            mockCharacter.Setup(c => c.MovementModes.Land)
                         .Returns(landMovement);
            mockCharacter.Setup(c => c.MovementModes.Fly)
                         .Returns(flyMovement);
            mockCharacter.Setup(c => c.MovementModes.Swim)
                         .Returns(swimMovement);
            mockCharacter.Setup(c => c.MovementModes.GetAll())
                         .Returns(new IMovement[] { landMovement, swimMovement, flyMovement });
            mockCharacter.Setup(c => c.Skills.Swim)
                         .Returns(mockSwimSkill.Object);
            mockCharacter.Setup(c => c.Skills.GetAllSkills())
                         .Returns(new ISkill[] { mockUnaffectedSkill.Object, mockAffectedSkill.Object, mockSwimSkill.Object });

            var armor = new PlateArmorOfTheDeep();

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(armorBonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 10 == calc())),
                        "Plate Armor of the Deep should add a +10 armor bonus to a character's armor class.");
            Mock.Get(maxDexPenaltyTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Plate Armor of the Deep should inflict a +1 max dex bonus to a character's armor class.");
            Mock.Get(landMovementPenalties)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Plate Armor of the Deep should reduce a speed from 30ft to 20ft.");
            Mock.Get(flyMovementPenalties)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Plate Armor of the Deep should not penalize a movement mode which does not have a base speed.");
            Mock.Get(swimMovementPenalties)
                .Verify(bt => bt.Add(It.IsAny<Func<byte>>()), Times.Never(),
                        "Plate Armor of the Deep should never penalize a character's swim speed.");
            Mock.Get(unaffectedSkillPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Plate Armor of the Deep should not add penalties to skills where armor check penalties do not apply.");
            Mock.Get(affectedSkillPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 5 == calc())),
                        "Plate Armor of the Deep should add a -5 penalty to skills where armor check penalties apply.");
            Mock.Get(mockSwimSkillPenalty)
                .Verify(bt => bt.Add(It.IsAny<Func<byte>>()), Times.Never(),
                        "Plate Armor of the Deep should never penalize the Swim skill, even if the Swim skill is subject to armor check penalties.");
        }
    }
}