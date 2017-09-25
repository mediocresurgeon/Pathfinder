namespace Core.Domain.Characters.Movements
{
    /// <summary>
    /// Summarizes how physically agile a character is while flying.
    /// </summary>
    public enum Maneuverability
    {
        Clumsy  = -2,
        Poor    = -1,
        Average =  0,
        Good    =  1,
        Perfect =  2,
    }
}