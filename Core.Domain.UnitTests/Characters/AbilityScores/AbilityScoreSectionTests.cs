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
            Assert.IsInstanceOf<AbilityScore>(abilityScores.Strength);
            Assert.IsInstanceOf<AbilityScore>(abilityScores.Dexterity);
            Assert.IsInstanceOf<AbilityScore>(abilityScores.Constitution);
            Assert.IsInstanceOf<AbilityScore>(abilityScores.Intelligence);
            Assert.IsInstanceOf<AbilityScore>(abilityScores.Wisdom);
            Assert.IsInstanceOf<AbilityScore>(abilityScores.Charisma);
        }
    }
}