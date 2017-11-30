using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Feats.Paizo.CoreRulebook;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Feats.Paizo.CoreRulebook.S
{
    [TestFixture]
    [Parallelizable]
    public class SkillFocusTests
    {
        [Test(Description = "Ensures SKillFocus cannot be created with a null instance of ISkill.")]
        public void Constructor()
        {
            // Arrange
            ISkill skill = null;

            // Act
            TestDelegate constructor = () => new SkillFocus(skill);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


		[Test(Description = "Ensures a skill with 9 ranks gets a +3 untyped bonus.")]
		public void SkillRanks9_Bonus3()
		{
            // Arrange
            Func<byte> untypedBonusCalc = null; // we'll test this later

            var character = Mock.Of<ICharacter>();

			var mockSkill = new Mock<ISkill>();
            mockSkill.Setup(s => s.Ranks)
                     .Returns(9);
            mockSkill.Setup(s => s.UntypedBonuses.Add(It.IsAny<Func<byte>>()))
                     .Callback<Func<byte>>(f => untypedBonusCalc = f);

            SkillFocus skillFocus = new SkillFocus(mockSkill.Object);

            // Act
            skillFocus.ApplyTo(character);

            // Assert
            Assert.AreEqual(3, untypedBonusCalc(),
                           "Applying Skill Focus to a character should introduce an untyped bonus calculation to its associated skill.  If the skill has fewer than 10 ranks, the untyped bonus should be +3.");
		}


		[Test(Description = "Ensures a skill with 10 ranks gets a +6 untyped bonus.")]
		public void SkillRanks10_Bonus6()
		{
			// Arrange
			Func<byte> untypedBonusCalc = null; // we'll test this later

			var character = Mock.Of<ICharacter>();

			var mockSkill = new Mock<ISkill>();
			mockSkill.Setup(s => s.Ranks)
                     .Returns(10);
			mockSkill.Setup(s => s.UntypedBonuses.Add(It.IsAny<Func<byte>>()))
					 .Callback<Func<byte>>(f => untypedBonusCalc = f);

			SkillFocus skillFocus = new SkillFocus(mockSkill.Object);

			// Act
			skillFocus.ApplyTo(character);

			// Assert
			Assert.AreEqual(6, untypedBonusCalc(),
						   "Applying Skill Focus to a character should introduce an untyped bonus calculation to its associated skill.  If the skill has at least 10 ranks, the untyped bonus should be +6.");
		}
    }
}