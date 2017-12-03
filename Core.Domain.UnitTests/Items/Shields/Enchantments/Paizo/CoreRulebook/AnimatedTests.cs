using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class AnimatedTests
    {
        [Test(Description = "Ensures that a fresh instance of Animated has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var enchantment = new Animated();

            // Assert
            Assert.AreEqual("Animated", enchantment.Name.Text);
            Assert.AreEqual(2, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(12, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Transmutation == s));
        }
    }
}