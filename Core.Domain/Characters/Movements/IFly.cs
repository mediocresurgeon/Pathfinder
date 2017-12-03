namespace Core.Domain.Characters.Movements
{
    /// <summary>
    /// An ICharacter's ability to move by flying.
    /// </summary>
    public interface IFly : IMovement
    {
        /// <summary>
        /// Gets or sets the ICharacter's maneuverability while flying.
        /// </summary>
        Maneuverability Maneuverability { get; set; }
    }
}