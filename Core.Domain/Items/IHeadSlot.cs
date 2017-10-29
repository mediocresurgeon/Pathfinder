using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's head slot when equipped.
    /// </summary>
    public interface IHeadSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}