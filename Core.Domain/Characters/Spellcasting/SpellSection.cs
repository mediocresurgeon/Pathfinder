using System;
using Core.Domain.Items;


namespace Core.Domain.Characters.Spellcasting
{
    internal sealed class SpellSection : ISpellSection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegistries.SpellSection"/> class.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal SpellSection(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            this.Registrar = new SpellRegistrar(character);
        }
        #endregion

        #region Properties
        public ISpellRegistrar Registrar { get; }

        public ISpellbook Spellbook { get; set; }

        public ICastableSpellCollection Prepared { get; } = new CastableSpellCollection();

        public ICastableSpellCollection Known { get; } = new CastableSpellCollection();
        #endregion
    }
}