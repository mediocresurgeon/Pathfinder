using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's armor slot when equipped.
    /// </summary>
    public interface IArmorSlot : IItem, IApplicable, IArmorCheckPenalty
    {
        /// <summary>
        /// Returns whether or not this armor is masterwork.
        /// </summary>
        bool IsMasterwork { get; }

        /// <summary>
        /// Returns the armor bonus to armor class an ICharacter gets when this armor is equipped.
        /// </summary>
        byte GetArmorBonus();
    }
}