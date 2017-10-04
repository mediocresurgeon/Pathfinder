using Core.Domain.Characters.AbilityScores;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.AbilityScores
{
    [TestFixture]
    public class AbilityScoreSectionTests
    {
        [Test(Description = "Ensures sensible defaults for a default AbilityScoreSection.")]
        public void Default_Properties()
        {
            // Arrange
            AbilityScoreSection abilityScores = new AbilityScoreSection();

            // Assert
            Assert.IsInstanceOf<Strength>(abilityScores.Strength);
            Assert.IsInstanceOf<Dexterity>(abilityScores.Dexterity);
            Assert.IsInstanceOf<Constitution>(abilityScores.Constitution);
            Assert.IsInstanceOf<Intelligence>(abilityScores.Intelligence);
            Assert.IsInstanceOf<Wisdom>(abilityScores.Wisdom);
            Assert.IsInstanceOf<Charisma>(abilityScores.Charisma);
        }
    }
}