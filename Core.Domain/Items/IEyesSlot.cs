using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's eyes slot when equipped.
    /// </summary>
    public interface IEyesSlot : IItem, IApplicable
    {
        // Composite interface; intentionally blank.
    }
}