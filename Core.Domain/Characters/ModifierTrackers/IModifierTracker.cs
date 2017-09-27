using System;


namespace Core.Domain.Characters.ModifierTrackers
{
    public interface IModifierTracker
    {
        void Add(byte amount);

        void Add(Func<byte> calculation);

        byte GetTotal();
    }
}