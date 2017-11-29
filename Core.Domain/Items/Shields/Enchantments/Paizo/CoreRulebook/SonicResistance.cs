namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    internal sealed class SonicResistance : EnergyResistance
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook.SonicResistance"/> class.
        /// </summary>
        /// <param name="protectionLevel">The level of protection afforded by this enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when given a nonstandard enum argument.</exception>
        internal SonicResistance(EnergyResistanceMagnitude protectionLevel)
            : base(element:                    "Sonic",
                   energyResistanceExpression: (character) => character?.EnergyResistances?.SonicResistance,
                   protectionLevel:            protectionLevel)
        {
            // Intentionally blank
        }
    }
}