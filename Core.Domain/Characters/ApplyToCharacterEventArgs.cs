using System;


namespace Core.Domain.Characters
{
    /// <summary>
    /// EventArgs where the subject of the event is an ICharacter.
    /// </summary>
    public sealed class ApplyToCharacterEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.ApplyToCharacterEventArgs"/> class.
        /// </summary>
        /// <param name="character">The subject of the event.</param>
        public ApplyToCharacterEventArgs(ICharacter character)
        {
            this.Character = character ?? throw new ArgumentNullException(nameof(character), "Argument may not be null.");
        }

        /// <summary>
        /// The subject of the event.
        /// </summary>
        public ICharacter Character { get; }
    }
}