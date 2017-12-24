using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Initiatives;
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
    public class BreastplateOfCommandTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of BreastplateOfCommand.")]
        public void Default()
        {
            // Arrange
            var armor = new BreastplateOfCommand();

            // Assert
            Assert.IsTrue(armor.IsMasterwork);
            Assert.AreEqual(3, armor.GetArmorCheckPenalty());
            Assert.AreEqual(15, armor.GetCasterLevel());
            Assert.AreEqual(14, armor.GetHardness());
            Assert.AreEqual(50, armor.GetHitPoints());
            Assert.AreEqual(25_400, armor.GetMarketPrice());
            Assert.That(armor.GetName(),
                        Has.Exactly(1).Matches<INameFragment>(nf => "Breastplate of Command" == nf.Text));
            Assert.That(armor.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Enchantment == s));
            Assert.AreEqual(8, armor.GetArmorBonus());
            Assert.AreEqual(30, armor.GetWeight());
        }


        [Test(Description = "Ensures that passing a null ICharacter argument to BreastplateOfCommand.ApplyTo() throws an exception.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            var armor = new BreastplateOfCommand();

            // Act
            TestDelegate applyTo = () => armor.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Test(Description = "Ensures Breastplate of Command will apply an AC bonus and armor check penalties to a character.")]
        public void ApplyTo_TypicalCases()
        {
            // Arrange
            var strength = Mock.Of<IAbilityScore>();
            var dexterity = Mock.Of<IAbilityScore>();
            var charisma = Mock.Of<IAbilityScore>();

            var initiativeCompetenceBonus = Mock.Of<IModifierTracker>();
            var mockInitative = new Mock<IInitiative>();
            mockInitative.Setup(i => i.KeyAbilityScore)
                         .Returns(dexterity);
            mockInitative.Setup(i => i.CompetenceBonuses)
                         .Returns(initiativeCompetenceBonus);

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

            var charismaSkillCompetenceBonus = Mock.Of<IModifierTracker>();
            var charismaSkillPenalty = Mock.Of<IModifierTracker>();
            var mockCharismaSkill = new Mock<ISkill>();
            mockCharismaSkill.Setup(s => s.ArmorCheckPenaltyApplies)
                               .Returns(false);
            mockCharismaSkill.Setup(s => s.KeyAbilityScore)
                             .Returns(charisma);
            mockCharismaSkill.Setup(s => s.CompetenceBonuses)
                             .Returns(charismaSkillCompetenceBonus);
            mockCharismaSkill.Setup(s => s.Penalties)
                             .Returns(charismaSkillPenalty);

            var strengthSkillCompetenceBonus = Mock.Of<IModifierTracker>();
            var strengthSkillPenalty = Mock.Of<IModifierTracker>();
            var mockStrengthSkill = new Mock<ISkill>();
            mockStrengthSkill.Setup(s => s.ArmorCheckPenaltyApplies)
                               .Returns(true);
            mockStrengthSkill.Setup(s => s.KeyAbilityScore)
                             .Returns(strength);
            mockStrengthSkill.Setup(s => s.CompetenceBonuses)
                             .Returns(strengthSkillCompetenceBonus);
            mockStrengthSkill.Setup(s => s.Penalties)
                             .Returns(strengthSkillPenalty);

            var armorBonusTracker = Mock.Of<IModifierTracker>();
            var maxDexPenaltyTracker = Mock.Of<IModifierTracker>();

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores.Strength)
                         .Returns(strength);
            mockCharacter.Setup(c => c.AbilityScores.Dexterity)
                         .Returns(dexterity);
            mockCharacter.Setup(c => c.AbilityScores.Charisma)
                         .Returns(charisma);
            mockCharacter.Setup(c => c.Initiative)
                         .Returns(mockInitative.Object);
            mockCharacter.Setup(c => c.ArmorClass.ArmorBonuses)
                         .Returns(armorBonusTracker);
            mockCharacter.Setup(c => c.ArmorClass.MaxKeyAbilityScore)
                         .Returns(maxDexPenaltyTracker);
            mockCharacter.Setup(c => c.MovementModes.GetAll())
                         .Returns(new IMovement[] { mockUnaffectedMovement.Object, mockAffectedMovement.Object });
            mockCharacter.Setup(c => c.Skills.GetAllSkills())
                         .Returns(new ISkill[] { mockCharismaSkill.Object, mockStrengthSkill.Object });

            var armor = new BreastplateOfCommand();

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(armorBonusTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 8 == calc())),
                        "Breastplate of Command should add a +8 armor bonus to a character's armor class.");
            Mock.Get(maxDexPenaltyTracker)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 3 == calc())),
                        "Breastplate of Command should inflict a +3 max dex bonus to a character's armor class.");
            Mock.Get(affectedMovement)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Breastplate of Command should reduce a speed from 30ft to 20ft.");
            Mock.Get(unaffectedMovement)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Breastplate of Command should not penalize a movement mode which does not have a base speed.");
            Mock.Get(charismaSkillPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Breastplate of Command should not add penalties to skills where armor check penalties do not apply.");
            Mock.Get(charismaSkillCompetenceBonus)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Breastplate of Command should add a +2 competence bonus to Charisma skills.");
            Mock.Get(strengthSkillPenalty)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 3 == calc())),
                        "Breastplate of Command should add a -3 penalty to skills where armor check penalties apply.");
            Mock.Get(strengthSkillCompetenceBonus)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Breastplate of Command should not add competence bonuses to skills which aren't Charisma skills.");
            Mock.Get(initiativeCompetenceBonus)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 0 == calc())),
                        "Breastplate of Command should not add a competence bonus to Initiative if Initiative is not keyed to Charisma.");
        }


        [Test(Description = "Ensures that Breastplate of Command bestows a bonus to initiative if a character's initative is keyed to Charisma.")]
        public void ApplyTo_InitiativeIsCharisma()
        {
            // Arrange
            var charisma = Mock.Of<IAbilityScore>();

            var initiativeCompetenceBonus = Mock.Of<IModifierTracker>();
            var mockInitative = new Mock<IInitiative>();
            mockInitative.Setup(i => i.KeyAbilityScore)
                         .Returns(charisma);
            mockInitative.Setup(i => i.CompetenceBonuses)
                         .Returns(initiativeCompetenceBonus);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores.Charisma)
                         .Returns(charisma);
            mockCharacter.Setup(c => c.Initiative)
                         .Returns(mockInitative.Object);

            var armor = new BreastplateOfCommand();

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(initiativeCompetenceBonus)
                .Verify(bt => bt.Add(It.Is<Func<byte>>(calc => 2 == calc())),
                        "Breastplate of Command should add a +2 competence bonus to Initiative when Initiative is keyed to Charisma.");
        }
    }
}