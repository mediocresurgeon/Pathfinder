namespace Core.Domain.Characters.ModifierTrackers
{
    internal interface IModifierTracker : ITotalable
    {
        void Add(byte amount);
    }
}