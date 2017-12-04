using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class FortificationTests
    {
        [Test(Description = "Ensures that a fresh instance of Light Fortification has sensible defaults.")]
        public void LightFortification_Default()
        {
            // Arrange
            var enchantment = new Fortification(FortificationType.Light);

            // Assert
            Assert.AreEqual("Light Fortification", enchantment.Name.Text);
            Assert.AreEqual(1, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(13, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Abjuration == s));
        }


        [Test(Description = "Ensures that a fresh instance of Medium Fortification has sensible defaults.")]
        public void MediumFortification_Default()
        {
            // Arrange
            var enchantment = new Fortification(FortificationType.Medium);

            // Assert
            Assert.AreEqual("Medium Fortification", enchantment.Name.Text);
            Assert.AreEqual(3, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(13, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Abjuration == s));
        }


        [Test(Description = "Ensures that a fresh instance of Heavy Fortification has sensible defaults.")]
        public void HeavyFortification_Default()
        {
            // Arrange
            var enchantment = new Fortification(FortificationType.Heavy);

            // Assert
            Assert.AreEqual("Heavy Fortification", enchantment.Name.Text);
            Assert.AreEqual(5, enchantment.SpecialAbilityBonus);
            Assert.AreEqual(13, enchantment.CasterLevel);
            Assert.That(enchantment.GetSchools(),
                        Has.Exactly(1).Matches<School>(s => School.Abjuration == s));
        }
    }
}