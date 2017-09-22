namespace Core.Domain.Characters.ModifierTrackers
{
    public interface IModifierTracker : ITotalable
    {
        void Add(byte amount);
    }
}