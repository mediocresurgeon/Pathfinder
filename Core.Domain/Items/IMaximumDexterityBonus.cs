namespace Core.Domain.Items
{
    /// <summary>
    /// Sometimes an item will put a cap on how much of a character's dexterity bonus can be applied to their armor class.
    /// </summary>
    public interface IMaximumDexterityBonus
    {
        /// <summary>
        /// Returns the cap on how much of a dexterity bonus can be applied to a character's armor class.
        /// </summary>
        byte GetMaximumDexterityBonus();
    }
}