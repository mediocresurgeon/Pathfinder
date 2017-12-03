using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class UndeadControllingTests
    {
        [Test(Description = "Ensures that a fresh instance of Undead Controlling has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var enchantment = new UndeadControlling();

            // Assert
            Assert.AreEqual("Undead Controlling", enchantment.Name.Text);
            Assert.AreEqual(49_000, enchantment.Cost);
            Assert.AreEqual(13, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Necromancy == s));
        }
    }
}