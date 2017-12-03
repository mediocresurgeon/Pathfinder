using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// The skill level at which a spell can be cast.
    /// </summary>
    public interface ICasterLevel
    {
        /// <summary>
        /// Returns the untyped bonuses to caster level.
        /// </summary>
        IModifierTracker UntypedBonuses { get; }

        /// <summary>
        /// Returns the total caster level.
        /// </summary>
        byte GetTotal();
    }
}