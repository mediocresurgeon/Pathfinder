using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's shoulders slot when equipped.
    /// </summary>
    public interface IShouldersSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}