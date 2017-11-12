using System;


namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    /// <summary>
    /// Contains functions which adjust the stats of a shield when the shield is made of Mithril.
    /// </summary>
    internal static class MithralShield
    {
        public static byte Hardness { get; } = 15;


        public static byte HitPointsPerInch { get; } = 30;


        public static string WebAddress { get; } = "http://www.d20pfsrd.com/equipment/special-materials/#TOC-Mithral";


        /// <summary>
        /// Making a shield from Mithral cuts the weight of the shield in half.
        /// </summary>
        /// <returns>The weight.</returns>
        /// <param name="baseWeight">The base weight of the shield (including adjustments for size).</param>
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
        public static double GetBaseMarketValue(double basePrice)
        {
            double runningTotal = basePrice;
            runningTotal += 1000;             // cost of material
            return runningTotal;
        }


        /// <summary>
        /// Making a shield from Mithral reduces the shield's armor check penalty by three (to a minimum of zero).
        /// This does not stack with Masterwork.
        /// </summary>
        /// <returns>The armor check penalty.</returns>
        /// <param name="baseArmorCheckPenalty">The shield's base armor check penalty.</param>
        public static byte GetArmorCheckPenalty(byte baseArmorCheckPenalty)
        {
            int subtotal = baseArmorCheckPenalty - 3;
            return subtotal > 0 ? Convert.ToByte(subtotal) : (byte)0;
        }
    }
}