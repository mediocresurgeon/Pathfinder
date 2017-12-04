namespace Core.Domain.Items.Materials.Paizo.CoreRulebook
{
    /// <summary>
    /// Functions for adjusting the stats of items made of Leather.
    /// </summary>
    internal static class Leather
    {
        /// <summary>
        /// Leather has hardness 5.
        /// </summary>
        public static byte Hardness { get; } = 2;


        /// <summary>
        /// Leather has 5 hit points per inch of thickness.
        /// </summary>
        public static byte HitPointsPerInch { get; } = 5;
    }
}
