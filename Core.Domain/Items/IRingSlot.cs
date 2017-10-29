using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies one of a character's ring slots when equipped.
    /// </summary>
    public interface IRingSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}