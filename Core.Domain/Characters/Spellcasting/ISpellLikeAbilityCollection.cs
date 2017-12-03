namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// A collection of spell-like abilities.
    /// </summary>
    public interface ISpellLikeAbilityCollection
    {
        /// <summary>
        /// Adds a spell-like ability to this collection.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="spell">Spell.</param>
		void Add(ISpellLikeAbility spell);

        /// <summary>
        /// Returns all spell-like abilities in this collection.
        /// </summary>
        /// <returns>The all spells.</returns>
		ISpellLikeAbility[] GetAllSpells();
    }
}