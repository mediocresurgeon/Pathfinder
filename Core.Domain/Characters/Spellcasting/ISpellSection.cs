namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// An ICharacter's spell data.
    /// </summary>
    public interface ISpellSection
    {
        /// <summary>
        /// The ICharacter's spell registrar.
        /// </summary>
        ISpellRegistrar Registrar { get; }

        /// <summary>
        /// The ICharacter's spells known.
        /// </summary>
        ICastableSpellCollection Known { get; }

        /// <summary>
        /// The ICharacter's prepared spells.
        /// </summary>
        ICastableSpellCollection Prepared { get; }
    }
}