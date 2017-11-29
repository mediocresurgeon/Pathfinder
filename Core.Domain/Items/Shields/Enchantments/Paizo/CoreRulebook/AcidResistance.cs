namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    internal sealed class AcidResistance : EnergyResistance
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook.AcidResistance"/> class.
        /// </summary>
        /// <param name="protectionLevel">The level of protection afforded by this enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when given a nonstandard enum argument.</exception>
        internal AcidResistance(EnergyResistanceMagnitude protectionLevel)
            : base(element:                    "Acid",
                   energyResistanceExpression: (character) => character?.EnergyResistances?.AcidResistance,
                   protectionLevel:            protectionLevel)
        {
            // Intentionally blank
        }
    }
}