using System;
using System.ComponentModel;
using System.Linq;
using Core.Domain.Items.Aggregators;
using Core.Domain.Items.Enchantments;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Items.Shields;


namespace Core.Domain.Items.Materials.Paizo.CoreRulebook
{
    /// <summary>
    /// The color of the dragon's hide.
    /// </summary>
    public enum DragonhideColor
    {
        /// <summary>
        /// Evil dragons with acidic breath weapons.
        /// </summary>
        Black,

        /// <summary>
        /// Evil dragons with electrical breath weapons.
        /// </summary>
        Blue,

        /// <summary>
        /// Good dragons with fiery breath weapons.
        /// </summary>
        Brass,

        /// <summary>
        /// Good dragons with electrical breath weapons.
        /// </summary>
        Bronze,

        /// <summary>
        /// Good dragons with acidic breath weapons.
        /// </summary>
        Copper,

        /// <summary>
        /// Good dragons with fiery breath weapons.
        /// </summary>
        Gold,

        /// <summary>
        /// Evil dragons with acidic breath weapons.
        /// </summary>
        Green,

        /// <summary>
        /// Evil dragons with fiery breath weapons.
        /// </summary>
        Red,

        /// <summary>
        /// Good dragons with cold breath weapons.
        /// </summary>
        Silver,

        /// <summary>
        /// Evil dragons with cold breath weapons.
        /// </summary>
        White,
    }


    /// <summary>
    /// Functions for adjusting the stats of items made of Dragonhide.
    /// </summary>
    internal static class Dragonhide
    {
        /// <summary>
        /// Dragonhide has a hardness 10.
        /// </summary>
        public static byte Hardness { get; } = 10;


        /// <summary>
        /// Dragonhide has 10 hit points per inch of thickness.
        /// </summary>
        public static byte HitPointsPerInch { get; } = 10;


        /// <summary>
        /// The URL of Dragonhide.
        /// </summary>
        public static string WebAddress { get; } = "http://www.d20pfsrd.com/equipment/special-materials#TOC-Dragonhide";


        /// <summary>
        /// Determines the market value for Dragonhide armor.
        /// The cost is: base cost, plus masterwork cost, multiplied by two.
        /// </summary>
        /// <returns>The market value.</returns>
        /// <param name="basePrice">The base cost of the armor (including adjustments for size).</param>
        /// <param name="enchantments">The enchantments placed on the armor.</param>
        /// <param name="color">The color of the dragon's hide.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        public static double GetArmorBaseMarketPrice(double basePrice, IEnchantmentAggregator<IArmorEnchantment, Armor.Armor> enchantments, DragonhideColor color)
        {
            return GetBaseMarketPrice(basePrice, enchantments, color);
        }


        /// <summary>
        /// Determines the market value for a Dragonhide shield.
        /// The cost is: base cost, plus masterwork cost, multiplied by two.
        /// </summary>
        /// <returns>The market value.</returns>
        /// <param name="basePrice">The base cost of the shield (including adjustments for size).</param>
        /// <param name="enchantments">The enchantments placed on the shield.</param>
        /// <param name="color">The color of the dragon's hide.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        public static double GetShieldBaseMarketPrice(double basePrice, IEnchantmentAggregator<IShieldEnchantment, Shield> enchantments, DragonhideColor color)
        {
            return GetBaseMarketPrice(basePrice, enchantments, color);
        }


        /// <summary>
        /// Calculates the market price of an armor or shield made of dragonhide.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        private static double GetBaseMarketPrice<E, I>(double basePrice, IEnchantmentAggregator<E, I> enchantmentAggregator, DragonhideColor color) where E : IEnchantment
                                                                                                                                                    where I : IItem
        {
            if (null == enchantmentAggregator)
                throw new ArgumentNullException(nameof(enchantmentAggregator), "Argument may not be null.");
            double physicalCost = 2 * (basePrice + 150); // twice the masterwork cost

            // Dragonhide reduces the cost of energy resistance enchantments by 25%
            double energyResistanceEnchantmentDiscount = 0; // keep track of total discounts
            foreach (var enchantment in enchantmentAggregator.GetEnchantments().Where((ench) => ench is EnergyResistanceEnchantment))
            {
                switch (color)
                {
                    case DragonhideColor.Black:
                    case DragonhideColor.Copper:
                    case DragonhideColor.Green:
                        if (enchantment is AcidResistance)
                            energyResistanceEnchantmentDiscount += 0.25 * enchantment.Cost;
                        break;
                    case DragonhideColor.Silver:
                    case DragonhideColor.White:
                        if (enchantment is ColdResistance)
                            energyResistanceEnchantmentDiscount += 0.25 * enchantment.Cost;
                        break;
                    case DragonhideColor.Blue:
                    case DragonhideColor.Bronze:
                        if (enchantment is ElectricityResistance)
                            energyResistanceEnchantmentDiscount += 0.25 * enchantment.Cost;
                        break;
                    case DragonhideColor.Brass:
                    case DragonhideColor.Gold:
                    case DragonhideColor.Red:
                        if (enchantment is FireResistance)
                            energyResistanceEnchantmentDiscount += 0.25 * enchantment.Cost;
                        break;
                    default:
                        throw new InvalidEnumArgumentException(nameof(color), (int)color, color.GetType());
                }

            }
            return physicalCost - energyResistanceEnchantmentDiscount;
        }
    }
}