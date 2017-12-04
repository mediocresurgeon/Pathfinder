using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class GlameredTests
    {
        [Test(Description = "Ensures that a fresh instance of Glamered has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var enchantment = new Glamered();

            // Assert
            Assert.AreEqual("Glamered", enchantment.Name.Text);
            Assert.AreEqual(0, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(2700, enchantment.Cost);
            Assert.AreEqual(10, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Illusion == s));
        }
    }
}