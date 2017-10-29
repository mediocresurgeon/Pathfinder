using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's neck slot when equipped.
    /// </summary>
    public interface INeckSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}