using System;


namespace Core.Domain.Characters.Movements
{
    public interface IMovementSection
    {
        IMovement Burrow { get; }

        IMovement Climb { get; }

        IFly Fly { get; }

        IMovement Land { get; }

        IMovement Swim { get; }
    }
}