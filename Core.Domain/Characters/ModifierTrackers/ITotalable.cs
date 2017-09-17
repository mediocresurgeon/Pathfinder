namespace Core.Domain.Characters.ModifierTrackers
{
    /// <summary>
    /// An object which has a total which can be calculated.
    /// </summary>
    public interface ITotalable
    {
        /// <summary>
        /// Returns the total represented by this object.
        /// </summary>
        /// <returns>The total.</returns>
        byte GetTotal();
    }
}