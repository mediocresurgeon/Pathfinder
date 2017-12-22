namespace Core.Domain.Items.Materials.Paizo.CoreRulebook
{
    /// <summary>
    /// Functions for adjusting the stats of items made of Cloth.
    /// </summary>
    internal static class Cloth
    {
        /// <summary>
        /// Cloth has a hardness 0.
        /// </summary>
        public static byte Hardness { get; } = 0;


        /// <summary>
        /// Cloth has 2 hit points per inch of thickness.
        /// </summary>
        public static byte HitPointsPerInch { get; } = 2;
    }
}
