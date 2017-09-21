using Core.Domain.Characters;
using Core.Domain.Characters.Feats;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Feats
{
    [TestFixture]
    public class SpellFocusTests
    {
        [Test(Description = "Ensures the name of the feat includes the school the feat applies to.")]
        public void Name_UsesSchool()
        {
            // Arrange
            var feat = new SpellFocus(School.Enchantment);

            // Assert
            Assert.AreEqual("Spell Focus (Enchantment)", feat.Name);
        }


		[Test(Description = "Ensures that training this feat gives a bonus to spells which are already registered")]
		public void Training_AppliesToExistingSpells()
		{
            // Arrange
            var character = new Character(1);
            character.Charisma.BaseScore = 18;

            var mockSpell = new Mock<ISpell>();
            mockSpell.Setup(s => s.Level).Returns(1);
            mockSpell.Setup(s => s.AllowsSavingThrow).Returns(true);
            mockSpell.Setup(s => s.School).Returns(School.Necromancy);
            var registeredSpell = character.SpellRegistrar.Register(mockSpell.Object, character.Charisma);

            var feat = new SpellFocus(School.Necromancy);

            // Act
            feat.Train(character);
            var spellDC = registeredSpell.GetDifficultyClass();

			// Assert
            Assert.AreEqual(16, spellDC,
                            "10 base + 4 ability + 1 level + 1 spell focus = DC 16");
		}


		[Test(Description = "Ensures that spells regsitered after training this feat are affected.")]
		public void Training_AppliesToNewSpells()
		{
			// Arrange
			var character = new Character(1);
			character.Charisma.BaseScore = 18;
			
            var feat = new SpellFocus(School.Necromancy);
            feat.Train(character);

			var mockSpell = new Mock<ISpell>();
			mockSpell.Setup(s => s.Level).Returns(1);
			mockSpell.Setup(s => s.AllowsSavingThrow).Returns(true);
			mockSpell.Setup(s => s.School).Returns(School.Necromancy);

			// Act
            var registeredSpell = character.SpellRegistrar.Register(mockSpell.Object, character.Charisma);
			var spellDC = registeredSpell.GetDifficultyClass();

			// Assert
			Assert.AreEqual(16, spellDC,
							"10 base + 4 ability + 1 level + 1 spell focus = DC 16");
		}
    }
}