using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's feet slot when equipped.
    /// </summary>
    public interface IFeetSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}