namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    internal sealed class ColdResistance : EnergyResistance
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook.ColdResistance"/> class.
        /// </summary>
        /// <param name="protectionLevel">The level of protection afforded by this enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when given a nonstandard enum argument.</exception>
        internal ColdResistance(EnergyResistanceMagnitude protectionLevel)
            : base(element:                    "Cold",
                   energyResistanceExpression: (character) => character?.EnergyResistances?.ColdResistance,
                   protectionLevel:            protectionLevel)
        {
            // Intentionally blank
        }
    }
}