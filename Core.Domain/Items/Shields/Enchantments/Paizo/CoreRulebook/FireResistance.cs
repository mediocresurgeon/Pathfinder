namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    internal sealed class FireResistance : EnergyResistance
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook.FireResistance"/> class.
        /// </summary>
        /// <param name="protectionLevel">The level of protection afforded by this enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when given a nonstandard enum argument.</exception>
        internal FireResistance(EnergyResistanceMagnitude protectionLevel)
            : base(element:                    "Fire",
                   energyResistanceExpression: (character) => character?.EnergyResistances?.FireResistance,
                   protectionLevel:            protectionLevel)
        {
            // Intentionally blank
        }
    }
}