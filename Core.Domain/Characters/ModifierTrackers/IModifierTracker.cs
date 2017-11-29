using System;


namespace Core.Domain.Characters.ModifierTrackers
{
    public interface IModifierTracker
    {
        void Add(Func<byte> calculation);

        byte GetTotal();
    }
}