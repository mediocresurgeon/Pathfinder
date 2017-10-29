using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's armor slot when equipped.
    /// </summary>
    public interface IArmorSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}