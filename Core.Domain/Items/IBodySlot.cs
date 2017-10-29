using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's body slot when equipped.
    /// </summary>
    public interface IBodySlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}