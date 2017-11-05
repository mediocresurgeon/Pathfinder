using Core.Domain.Characters;


namespace Core.Domain.Items
{
    /// <summary>
    /// An item which occupies a character's shield slot when equipped.
    /// </summary>
    public interface IShieldSlot : IItem, IApplicable, IArmorCheckPenalty
    {
        bool IsMasterwork { get; }

        byte GetShieldBonus();
    }
}