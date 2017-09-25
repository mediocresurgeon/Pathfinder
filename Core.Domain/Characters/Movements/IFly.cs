namespace Core.Domain.Characters.Movements
{
    public interface IFly : IMovement
    {
        Maneuverability Maneuverability { get; set; }
    }
}