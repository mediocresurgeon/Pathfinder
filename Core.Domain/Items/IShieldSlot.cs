using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's shield slot when equipped.
    /// </summary>
    public interface IShieldSlot : IItem, IApplicable, IArmorCheckPenalty
    {
        /// <summary>
        /// Returns whether or not this shield is masterwork.
        /// </summary>
        bool IsMasterwork { get; }

        /// <summary>
        /// Returns the shield bonus to armor class an ICharacter gets when this shield is equipped.
        /// </summary>
        byte GetShieldBonus();
    }
}