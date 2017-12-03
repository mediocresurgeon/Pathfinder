using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class WildTests
    {
        [Test(Description = "Ensures that a fresh instance of Ghost Touch has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var enchantment = new Wild();

            // Assert
            Assert.AreEqual("Wild", enchantment.Name.Text);
            Assert.AreEqual(3, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(9, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Transmutation == s));
        }
    }
}