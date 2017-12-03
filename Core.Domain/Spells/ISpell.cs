namespace Core.Domain.Spells
{
    /// <summary>
    /// Represents an arcane or divine spell.
    /// </summary>
    public interface ISpell
    {
        /// <summary>
        /// The name of the ISpell.
        /// </summary>
        INameFragment GetName();

        /// <summary>
        /// The level of the ISpell.
        /// </summary>
        byte Level { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Core.Domain.Spells.ISpell"/> allows a saving throw.
        /// </summary>
        /// <value><c>true</c> if it allows a saving throw; otherwise, <c>false</c>.</value>
        bool AllowsSavingThrow { get; }

        /// <summary>
        /// The Descriptors of the ISpell.
        /// </summary>
        Descriptor[] GetDescriptors();

        /// <summary>
        /// The School of the ISpell.
        /// </summary>
        School School { get; }

        /// <summary>
        /// The Subschools of the ISpell.
        /// </summary>
        Subschool[] GetSubschools();
    }
}