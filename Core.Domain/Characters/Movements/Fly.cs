namespace Core.Domain.Characters.Movements
{
    /// <summary>
    /// The ability to fly through the air, such as with wings or magic.
    /// </summary>
    internal sealed class Fly : Movement, IFly
    {
        public Maneuverability Maneuverability { get; set; } = Maneuverability.Average;
    }
}