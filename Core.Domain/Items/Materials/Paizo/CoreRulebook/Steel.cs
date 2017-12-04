namespace Core.Domain.Items.Materials.Paizo.CoreRulebook
{
    /// <summary>
    /// Functions for adjusting the stats of items made of Steel.
    /// </summary>
    internal static class Steel
    {
        /// <summary>
        /// Steel has a hardness 10.
        /// </summary>
        public static byte Hardness { get; } = 10;


        /// <summary>
        /// Steel has 30 hit points per inch of thickness.
        /// </summary>
        public static byte HitPointsPerInch { get; } = 30;
    }
}
