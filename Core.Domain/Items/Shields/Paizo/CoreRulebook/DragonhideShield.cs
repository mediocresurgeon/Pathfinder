using System.Linq;
using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;


namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    /// <summary>
    /// Contains functions which adjust the stats of a shield when the shield is made of Dragonhide.
    /// </summary>
    internal static class DragonhideShield
    {
        public static byte Hardness { get; } = 10;


        public static byte HitPointsPerInch { get; } = 10;


        public static string WebAddress { get; } = "http://www.d20pfsrd.com/equipment/special-materials#TOC-Darkwood";


        /// <summary>
        /// Determines the market value for a Dragonhide shield.
        /// The cost is: base cost, plus masterwork cost, multiplied by two.
        /// </summary>
        /// <returns>The market value.</returns>
        /// <param name="basePrice">The base cost of the item (including adjustments for size).</param>
        public static double GetBaseMarketValue(double basePrice, IShieldEnchantmentAggregator enchantments)
        {
            double physicalCost = 2 * (basePrice + 150); // twice the masterwork cost

            // Dragonhide reduces the cost of energy resistance enchantments by 25%
            double energyResistanceEnchantmentDiscount = 0; // keep track of total discounts
            foreach(var enchantment in enchantments.GetEnchantments().Where(e => e is EnergyResistance))
            {
                energyResistanceEnchantmentDiscount += 0.25 * enchantment.Cost;
            }
            return physicalCost - energyResistanceEnchantmentDiscount;
        }
    }
}