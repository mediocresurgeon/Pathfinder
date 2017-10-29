using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's chest slot when equipped.
    /// </summary>
    public interface IChestSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}