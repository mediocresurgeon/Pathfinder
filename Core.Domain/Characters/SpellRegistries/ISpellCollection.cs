using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
    public interface ISpellCollection
    {
        void Add(ISpell spell);

        ISpell[] GetSpellsByLevel(byte level);
    }
}