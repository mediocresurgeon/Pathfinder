using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Movements
{
    /// <summary>
    /// A mode of movement, such as burrowing, climbing, flying, swimming, or walking.
    /// </summary>
    public interface IMovement
    {
        /// <summary>
        /// Gets or sets the base speed (in squares) for this movement type.
        /// </summary>
        byte? BaseSpeed { get; set; }

        /// <summary>
        /// Returns the enhancement bonuses to this movement speed (in squares).
        /// </summary>
        IModifierTracker EnhancementBonuses { get; }

        /// <summary>
        /// Returns the total movement speed (in squares).
        /// </summary>
        byte? GetTotal();
    }
}