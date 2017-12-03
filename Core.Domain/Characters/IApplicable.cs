namespace Core.Domain.Characters
{
    /// <summary>
    /// An object which applies effects to an ICharacter.
    /// </summary>
    public interface IApplicable
    {
        /// <summary>
        /// Applies this object's effects to the ICharacter.
        /// </summary>
        /// <param name="character">The ICharacter to apply effects to.</param>
        void ApplyTo(ICharacter character);
    }
}