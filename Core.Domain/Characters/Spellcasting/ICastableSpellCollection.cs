namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// A collection of ICastableSpells.
    /// </summary>
    public interface ICastableSpellCollection
    {
        /// <summary>
        /// Adds an ICastableSpell to this collection.
        /// </summary>
        void Add(ICastableSpell spell);

        /// <summary>
        /// Returns all ICastableSpells which have been added to this collection.
        /// </summary>
        ICastableSpell[] GetAllSpells();
    }
}