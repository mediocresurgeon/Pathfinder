using System.Collections.Generic;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
    public interface ISpellRegistrar
    {
        IRegisteredSpell Register(ISpell spell, IAbilityScore keyAbilityScore);

        IRegisteredSpell Register(ISpell spell, IAbilityScore keyAbilityScore, byte casterLevel);

        IEnumerable<IRegisteredSpell> GetRegisteredSpells();
    }
}