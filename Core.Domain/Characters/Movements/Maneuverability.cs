namespace Core.Domain.Characters.Movements
{
    /// <summary>
    /// Summarizes how physically agile a character is while flying.
    /// </summary>
    public enum Maneuverability
    {
        /// <summary>
        /// Indicates a terrible level of maneuverability.
        /// </summary>
        Clumsy  = -2,

        /// <summary>
        /// Indicates a sub-par level of maneuverability.
        /// </summary>
        Poor    = -1,

        /// <summary>
        /// Indicates typical maneuverability.
        /// </summary>
        Average =  0,

        /// <summary>
        /// Indicates a high level of maneuverability.
        /// </summary>
        Good    =  1,

        /// <summary>
        /// Indicates an unparalleled level of maneuverability.
        /// </summary>
        Perfect =  2,
    }
}