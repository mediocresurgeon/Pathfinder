using System.Collections.Generic;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
    public interface ISpellRegistrar
    {
        ICastableSpell Register(ISpell spell, IAbilityScore keyAbilityScore);

        ICastableSpell Register(ISpell spell, IAbilityScore keyAbilityScore, byte casterLevel);

        ICastableSpell[] GetSpells();

        void OnRegistered(OnSpellRegisteredEventHandler handler);
    }
}