using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's belt slot when equipped.
    /// </summary>
    public interface IBeltSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}