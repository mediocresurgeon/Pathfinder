using System;


namespace Core.Domain.Items.Materials.Paizo.CoreRulebook
{
    /// <summary>
    /// Functions for adjusting the stats of items made of Adamantine.
    /// </summary>
    internal static class Adamantine
    {
        /// <summary>
        /// Adamantine has hardness 20.
        /// </summary>
        public static byte Hardness { get; } = 20;

        /// <summary>
        /// Adamantine has 40 hit points per inch of thickness.
        /// </summary>
        public static byte HitPointsPerInch { get; } = 40;


        public static string WebAddress { get; } = "http://www.d20pfsrd.com/equipment/special-materials#TOC-Adamantine";

        #region Light armor
        /// <summary>
        /// Light armor made of adamantine costs +5000gp (including the cost of masterwork).
        /// </summary>
        /// <param name="basePrice">The base price for the armor, including adjustments for size.</param>
        public static double GetLightArmorBaseMarketPrice(double basePrice)
        {
            return basePrice + 5_000;
        }


        /// <summary>
        /// Light armor made of Adamantine has DR 1/-.
        /// </summary>
        public static (Func<byte> Magnitude, string BypassedBy) GetLightArmorDamageReduction()
        {
            return (() => 1, "—");
        }
        #endregion

        #region Medium armor
        /// <summary>
        /// Medium armor made of adamantine costs +10000gp (including the cost of masterwork).
        /// </summary>
        /// <param name="basePrice">The base price for the armor, including adjustments for size.</param>
        public static double GetMediumArmorBaseMarketPrice(double basePrice)
        {
            return basePrice + 10_000;
        }


        /// <summary>
        /// Medium armor made of Adamantine has DR 1/-.
        /// </summary>
        public static (Func<byte> Magnitude, string BypassedBy) GetMediumArmorDamageReduction()
        {
            return (() => 2, "—");
        }
        #endregion

        #region Heavy armor
        /// <summary>
        /// Heavy armor made of adamantine costs +15000gp (including the cost of masterwork).
        /// </summary>
        /// <param name="basePrice">The base price for the armor, including adjustments for size.</param>
        public static double GetHeavyArmorBaseMarketPrice(double basePrice)
        {
            return basePrice + 15_000;
        }


        /// <summary>
        /// Heavy armor made of Adamantine has DR 1/-.
        /// </summary>
        public static (Func<byte> Magnitude, string BypassedBy) GetHeavyArmorDamageReduction()
        {
            return (() => 3, "—");
        }
        #endregion
    }
}