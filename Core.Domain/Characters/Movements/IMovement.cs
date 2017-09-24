namespace Core.Domain.Characters.Movements
{
    public interface IMovement
    {
        byte? BaseSpeed { get; set; }

        byte? GetTotal();

        void AddEnhancementBonus(byte squares);
    }
}