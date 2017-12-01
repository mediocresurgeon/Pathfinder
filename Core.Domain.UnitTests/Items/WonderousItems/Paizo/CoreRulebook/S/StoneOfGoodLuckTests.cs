using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Initiatives;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.SavingThrows;
using Core.Domain.Characters.Skills;
using Core.Domain.Items.WonderousItems.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.WonderousItems.Paizo.CoreRulebook.S
{
    [TestFixture]
    [Parallelizable]
    public class StoneOfGoodLuckTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of Stone of Good Luck.")]
        public void Default()
        {
            // Arrange
            StoneOfGoodLuck luckstone = new StoneOfGoodLuck();

            // Assert
            Assert.AreEqual(0, luckstone.GetWeight());
            Assert.AreEqual(5, luckstone.GetCasterLevel().Value);
            Assert.AreEqual(8, luckstone.GetHardness());
            Assert.AreEqual(15, luckstone.GetHitPoints());
            Assert.AreEqual(20000, luckstone.GetMarketPrice());
            Assert.AreEqual("Stone of Good Luck", luckstone.GetName()[0].Text);
            Assert.Contains(School.Evocation, luckstone.GetSchools());
        }

        #region Stow()
        [Test(Description = "Ensures that Stone of Good Luck cannot be stowed on a null character.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;
            StoneOfGoodLuck luckstone = new StoneOfGoodLuck();

            // Act
            TestDelegate stow = () => luckstone.ApplyTo(character);

            // Assert
            Assert.Throws<ArgumentNullException>(stow);
        }


        [Test(Description = "Ensures that Stone of Good Luck is applied to a character correctly when stowed.")]
        public void ApplyTo()
        {
            // Arrange
            var initiativeLuckBonus = Mock.Of<IModifierTracker>();

            var fortitudeLuckBonus = Mock.Of<IModifierTracker>();
            var reflexLuckBonus = Mock.Of<IModifierTracker>();
            var willLuckBonus = Mock.Of<IModifierTracker>();

            var skillLuckBonus1 = Mock.Of<IModifierTracker>();
            var skill1 = new Mock<ISkill>();
            skill1.Setup(s => s.LuckBonuses)
                  .Returns(skillLuckBonus1);
            
            var skillLuckBonus2 = Mock.Of<IModifierTracker>();
            var skill2 = new Mock<ISkill>();
            skill2.Setup(s => s.LuckBonuses)
                  .Returns(skillLuckBonus2);
            
            var skillLuckBonus3 = Mock.Of<IModifierTracker>();
            var skill3 = new Mock<ISkill>();
            skill3.Setup(s => s.LuckBonuses)
                  .Returns(skillLuckBonus3);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Initiative.LuckBonuses)
                         .Returns(initiativeLuckBonus);
            mockCharacter.Setup(c => c.SavingThrows.Fortitude.LuckBonuses)
                         .Returns(fortitudeLuckBonus);
            mockCharacter.Setup(c => c.SavingThrows.Reflex.LuckBonuses)
                         .Returns(reflexLuckBonus);
            mockCharacter.Setup(c => c.SavingThrows.Will.LuckBonuses)
                         .Returns(willLuckBonus);
            mockCharacter.Setup(c => c.Skills.GetAllSkills())
                         .Returns(new ISkill[] { skill1.Object, skill2.Object, skill3.Object });
            
            StoneOfGoodLuck luckstone = new StoneOfGoodLuck();

            // Act
            luckstone.ApplyTo(mockCharacter.Object);

            // Assert
            Mock.Get(initiativeLuckBonus)
                .Verify(lb => lb.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Stone of Good Luck gives a +1 luck bonus to ability checks; Initiative is an ability check.");
            Mock.Get(fortitudeLuckBonus)
                .Verify(lb => lb.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Stone of Good Luck gives a +1 luck bonus to saving throws, including Fortitude.");
            Mock.Get(reflexLuckBonus)
                .Verify(lb => lb.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Stone of Good Luck gives a +1 luck bonus to saving throws, including Reflex.");
            Mock.Get(willLuckBonus)
                .Verify(lb => lb.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Stone of Good Luck gives a +1 luck bonus to saving throws, including Will.");
            Mock.Get(skillLuckBonus1)
                .Verify(lb => lb.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Any skill returned by ISkillSection.GetAllSkills() should receive a +1 luck bonus.");
            Mock.Get(skillLuckBonus2)
                .Verify(lb => lb.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Any skill returned by ISkillSection.GetAllSkills() should receive a +1 luck bonus.");
            Mock.Get(skillLuckBonus3)
                .Verify(lb => lb.Add(It.Is<Func<byte>>(calc => 1 == calc())),
                        "Any skill returned by ISkillSection.GetAllSkills() should receive a +1 luck bonus.");
        }
        #endregion
    }
}