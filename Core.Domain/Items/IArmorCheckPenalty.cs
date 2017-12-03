namespace Core.Domain.Items
{
    /// <summary>
    /// An item which has an armor check penalty.
    /// </summary>
    public interface IArmorCheckPenalty
    {
        /// <summary>
        /// Returns this item's armor check penalty.
        /// </summary>
        byte GetArmorCheckPenalty();
    }
}