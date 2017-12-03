using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class GhostTouchTests
    {
        [Test(Description = "Ensures that a fresh instance of Ghost Touch has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var enchantment = new GhostTouch();

            // Assert
            Assert.AreEqual("Ghost Touch", enchantment.Name.Text);
            Assert.AreEqual(3, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(15, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Transmutation == s));
        }
    }
}