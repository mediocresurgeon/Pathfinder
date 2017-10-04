namespace Core.Domain.Characters.Movements
{
    internal sealed class MovementSection : IMovementSection
    {
        internal MovementSection()
        {
            // Intentionally blank
        }

        public IMovement Burrow { get; } = new Movement();

        public IMovement Climb { get; } = new Movement();

        public IFly Fly { get; } = new Fly();

        public IMovement Land { get; } = new Movement { BaseSpeed = 6 };

        public IMovement Swim { get; } = new Movement();
    }
}