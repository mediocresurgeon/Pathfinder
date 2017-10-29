using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which cannot be equiped by a character.
    /// Such items can be stowed in the character's inventory.
    /// </summary>
    public interface IStowable : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}