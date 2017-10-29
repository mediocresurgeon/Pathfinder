using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's headband slot when equipped.
    /// </summary>
    public interface IHeadbandSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}