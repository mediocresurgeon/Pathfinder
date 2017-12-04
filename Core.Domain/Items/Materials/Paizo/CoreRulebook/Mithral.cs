using System;


namespace Core.Domain.Items.Materials.Paizo.CoreRulebook
{
    /// <summary>
    /// Functions for adjusting the stats of items made of Mithral.
    /// </summary>
    internal static class Mithral
    {
        public static byte Hardness { get; } = 15;


        public static byte HitPointsPerInch { get; } = 30;


        public static string WebAddress { get; } = "http://www.d20pfsrd.com/equipment/special-materials/#TOC-Mithral";


        /// <summary>
        /// Making an item from Mithral cuts its weight in half.
        /// </summary>
        /// <returns>The weight.</returns>
        /// <param name="baseWeight">The base weight of the item (including adjustments for size).</param>
        public static double GetWeight(double baseWeight)
        {
            return baseWeight / 2;
        }


        /// <summary>
        /// Determines the market value for a Mithral shield.
        /// The cost is: base cost plus 1000gp.  Includes masterwork.
        /// </summary>
        /// <returns>The market value.</returns>
        /// <param name="basePrice">The base cost of the item (including adjustments for size).</param>
        public static double GetShieldBaseMarketValue(double basePrice)
        {
            double runningTotal = basePrice;
            runningTotal += 1000;             // cost of material, including the cost of Masterwork
            return runningTotal;
        }


        /// <summary>
        /// Making aarmor or shields from Mithral reduces its armor check penalty by three (to a minimum of zero).
        /// This does not stack with Masterwork.
        /// </summary>
        /// <returns>The armor check penalty.</returns>
        /// <param name="baseArmorCheckPenalty">The armor or shield's base armor check penalty.</param>
        public static byte GetArmorCheckPenalty(byte baseArmorCheckPenalty)
        {
            int subtotal = baseArmorCheckPenalty - 3;
            return subtotal > 0 ? Convert.ToByte(subtotal) : (byte)0;
        }
    }
}