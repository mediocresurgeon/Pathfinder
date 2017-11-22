﻿namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
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
        public static double GetBaseMarketValue(double basePrice)
        {
            
            double runningTotal = basePrice;
            runningTotal += 150;             // cost of masterwork
            runningTotal *= 2;               // double the price
            return runningTotal;
        }
    }
}