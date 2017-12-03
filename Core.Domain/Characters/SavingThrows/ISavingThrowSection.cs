namespace Core.Domain.Characters.SavingThrows
{
    /// <summary>
    /// An ICharacter's saving throws.
    /// </summary>
    public interface ISavingThrowSection
    {
        /// <summary>
        /// A measurement of an ICharacter's ability to stand up to physical punishment, or attacks which sap vitality or health.
        /// </summary>
        ISavingThrow Fortitude { get; }

        /// <summary>
        /// A measurement of an ICharacter's ability to dodge area attacks and unexpected situations.
        /// </summary>
        ISavingThrow Reflex { get; }

        /// <summary>
        /// A measurement of an ICharacter's ability to resist mental influence as well as many magical effects.
        /// </summary>
        ISavingThrow Will { get; }
    }
}