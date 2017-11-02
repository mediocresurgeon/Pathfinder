using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Spellcasting
{
    public interface ICasterLevel
    {
        IModifierTracker UntypedBonuses { get; }

        byte GetTotal();
    }
}