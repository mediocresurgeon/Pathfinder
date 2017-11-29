namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    internal sealed class ElectricityResistance : EnergyResistance
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook.ElectricityResistance"/> class.
        /// </summary>
        /// <param name="protectionLevel">The level of protection afforded by this enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when given a nonstandard enum argument.</exception>
        internal ElectricityResistance(EnergyResistanceMagnitude protectionLevel)
            : base(element:                    "Electricity",
                   energyResistanceExpression: (character) => character?.EnergyResistances?.ElectricityResistance,
                   protectionLevel:            protectionLevel)
        {
            // Intentionally blank
        }
    }
}