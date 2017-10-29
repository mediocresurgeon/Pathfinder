using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's hands slot when equipped.
    /// </summary>
    public interface IHandsSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}