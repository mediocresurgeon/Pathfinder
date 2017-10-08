﻿namespace Core.Domain.Characters.Spellcasting
{
    public interface ICastableSpellCollection
    {
        void Add(ICastableSpell spell);

        ICastableSpell[] GetAll();
    }
}