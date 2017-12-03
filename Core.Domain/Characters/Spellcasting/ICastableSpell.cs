using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// An ISpell which has been associated with an ICharacter such that the ICharacter can cast it.
    /// </summary>
	public interface ICastableSpell
	{
        /// <summary>
        /// The spell.
        /// </summary>
		ISpell Spell { get; }

        /// <summary>
        /// Returns the caster level of the spell.
        /// </summary>
        ICasterLevel CasterLevel { get; }

        /// <summary>
        /// Adds a bonus to this ICastableSpell's difficulty class, making it harder to resist.
        /// </summary>
        /// <param name="bonus">Bonus.</param>
        void AddDifficultyClassBonus(byte bonus);

        /// <summary>
        /// Returns the DC of the ISpell.
        /// </summary>
        byte? GetDifficultyClass();
	}
}