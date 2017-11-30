using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class ArrowCatchingTests
    {
        [Test(Description = "Ensures that a fresh instance of ArrowCatching has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var enchantment = new ArrowCatching();

            // Act
            Assert.AreEqual("Arrow Catching", enchantment.Name.Text);
            Assert.AreEqual(1, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(8, enchantment.CasterLevel);
            Assert.AreEqual(1, enchantment.GetSchools().Length);
            Assert.Contains(School.Abjuration, enchantment.GetSchools());
        }
    }
}