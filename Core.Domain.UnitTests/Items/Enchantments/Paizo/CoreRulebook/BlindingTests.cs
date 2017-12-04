using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class BlindingTests
    {
        [Test(Description = "Ensures that a fresh instance of Arrow Deflection has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var enchantment = new Blinding();

            // Assert
            Assert.AreEqual("Blinding", enchantment.Name.Text);
            Assert.AreEqual(1, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(7, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Evocation == s));
        }
    }
}