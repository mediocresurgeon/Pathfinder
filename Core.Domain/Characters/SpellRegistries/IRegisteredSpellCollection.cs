namespace Core.Domain.Characters.SpellRegistries
{
    public interface IRegisteredSpellCollection
    {
        void Add(IRegisteredSpell spell);

        IRegisteredSpell[] GetSpellsByLevel(byte level);
    }
}