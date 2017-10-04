using System;


namespace Core.Domain.Characters.SpellRegistries
{
    internal sealed class SpellLikeAbilitySection : ISpellLikeAbilitySection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.SpellRegistries.SpellLikeAbilitySection"/> class.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal SpellLikeAbilitySection(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            this.Registrar = new SpellLikeAbilityRegistrar(character);
        }
        #endregion

        #region Properties
        public ISpellLikeAbilityRegistrar Registrar { get; }

        public ISpellLikeAbilityCollection Known { get; } = new SpellLikeAbilityCollection();
        #endregion
    }
}