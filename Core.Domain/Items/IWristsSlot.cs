using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's wrists slot when equipped.
    /// </summary>
    public interface IWristsSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}