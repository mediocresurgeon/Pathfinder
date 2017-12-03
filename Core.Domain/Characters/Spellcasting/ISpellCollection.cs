using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// A collection of spells.
    /// </summary>
    public interface ISpellCollection
    {
        /// <summary>
        /// Adds a spell to this collection.
        /// </summary>
        void Add(ISpell spell);

        /// <summary>
        /// Returns all spells in this collection.
        /// </summary>
        ISpell[] GetAllSpells();
    }
}