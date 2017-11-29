using Core.Domain.Characters.ModifierTrackers;

namespace Core.Domain.Characters.Movements
{
    public interface IMovement
    {
        byte? BaseSpeed { get; set; }

        IModifierTracker EnhancementBonuses { get; }

        byte? GetTotal();
    }
}