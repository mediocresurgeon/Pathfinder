using System;


namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    /// <summary>
    /// Contains functions which adjust the stats of a shield when the shield is made of Darkwood.
    /// </summary>
    internal static class DarkwoodShield
    {
        public static byte Hardness { get; } = 5;


        public static byte HitPointsPerInch { get; } = 10;


        public static string WebAddress { get; } = "http://www.d20pfsrd.com/equipment/special-materials#TOC-Darkwood";


        /// <summary>
        /// Making a shield from Darkwood cuts the weight of the shield in half.
        /// </summary>
        /// <returns>The weight.</returns>
        /// <param name="baseWeight">The base weight of the shield (including adjustments for size).</param>
        public static double GetWeight(double baseWeight)
        {
            return baseWeight / 2;
        }

        /// <summary>
        /// Determines the market value for a Darkwood shield.
        /// The cost is: base cost, plus masterwork cost, plus 10gp per pound.
        /// </summary>
        /// <returns>The market value.</returns>
        /// <param name="basePrice">The base cost of the item (including adjustments for size).</param>
        /// <param name="weight">The weight of the item (including adjustments for size).</param>
        public static double GetBaseMarketValue(double basePrice, double weight)
        {
            double runningTotal = basePrice;
            runningTotal += 150;             // cost of masterwork
            runningTotal += 20 * weight;     // additional material cost
            return runningTotal;
        }

        /// <summary>
        /// Making a shield from Darkwood reduces the shield's armor check penalty by two (to a minimum of zero).
        /// This does not stack with Masterwork.
        /// </summary>
        /// <returns>The armor check penalty.</returns>
        /// <param name="baseArmorCheckPenalty">The shield's base armor check penalty.</param>
        public static byte GetArmorCheckPenalty(byte baseArmorCheckPenalty)
        {
            int subtotal = baseArmorCheckPenalty - 2;
            return subtotal > 0 ? Convert.ToByte(subtotal) : (byte)0;
        }
    }
}