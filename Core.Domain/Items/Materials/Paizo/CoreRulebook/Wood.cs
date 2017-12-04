namespace Core.Domain.Items.Materials.Paizo.CoreRulebook
{
    /// <summary>
    /// Functions for adjusting the stats of items made of Wood.
    /// </summary>
    internal static class Wood
    {
        /// <summary>
        /// Wood has hardness 5.
        /// </summary>
        public static byte Hardness { get; } = 5;


        /// <summary>
        /// Wood has 10 hit points per inch of thickness.
        /// </summary>
        public static byte HitPointsPerInch { get; } = 10;
    }
}