namespace Core.Domain.Characters.SpellRegistries
{
    public interface IRegisteredSpellsCollection
    {
        void Add(IRegisteredSpell spell);

        IRegisteredSpell[] GetSpellsByLevel(byte level);
    }
}