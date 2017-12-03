using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class ArrowDeflectionTests
    {
        [Test(Description = "Ensures that a fresh instance of Arrow Deflection has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var enchantment = new ArrowDeflection();

            // Assert
            Assert.AreEqual("Arrow Deflection", enchantment.Name.Text);
            Assert.AreEqual(2, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(5, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Abjuration == s));
        }
    }
}