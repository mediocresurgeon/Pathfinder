namespace Core.Domain.Characters.Movements
{
    /// <summary>
    /// An ICharacter's modes of movement.
    /// </summary>
    public interface IMovementSection
    {
        /// <summary>
        /// Returns the ICharacter's physical ability to burrow.
        /// </summary>
        IMovement Burrow { get; }

        /// <summary>
        /// Returns the ICharacter's physical ability to climb.
        /// </summary>
        IMovement Climb { get; }

        /// <summary>
        /// Returns the ICharacter's physical ability to fly.
        /// </summary>
        IFly Fly { get; }

        /// <summary>
        /// Returns the ICharacter's physical ability to walk and run.
        /// </summary>
        IMovement Land { get; }

        /// <summary>
        /// Returns the ICharacter's physical ability to swim.
        /// </summary>
        IMovement Swim { get; }

        /// <summary>
        /// Returns all movement modes.
        /// </summary>
        IMovement[] GetAll();
    }
}