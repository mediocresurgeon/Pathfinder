namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// An ICharacter's spell-like abilities data.
    /// </summary>
    public interface ISpellLikeAbilitySection
    {
        /// <summary>
        /// The registrar of spell-like abilities associated with the ICharacter.
        /// </summary>
		ISpellLikeAbilityRegistrar Registrar { get; }

        /// <summary>
        /// The known spell-like abilities of the ICharacter.
        /// </summary>
		ISpellLikeAbilityCollection Known { get; }
    }
}