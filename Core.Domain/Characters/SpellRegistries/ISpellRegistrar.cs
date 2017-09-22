using System.Collections.Generic;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
    public interface ISpellRegistrar
    {
        ICastableSpell Register(ISpell spell, IAbilityScore keyAbilityScore);

        ICastableSpell Register(ISpell spell, IAbilityScore keyAbilityScore, byte casterLevel);

        ICastableSpell[] GetSpells();

        void OnSpellRegistered(OnSpellRegisteredEventHandler handler);
    }
}