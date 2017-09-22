namespace Core.Domain.Characters.SpellRegistries
{
    public interface ICastableSpellCollection
    {
        void Add(ICastableSpell spell);

        ICastableSpell[] GetSpellsByLevel(byte level);
    }
}