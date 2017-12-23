using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// Logic which encapulates how to associate a spell with an ICharacter.
    /// </summary>
    public interface ISpellRegistrar
    {
        /// <summary>
        /// Registers a spell, transforming it into a castable spell.
        /// The castable spell's caster level is equal to the ICharacter's level.
        /// </summary>
        /// <returns>The ICastableSpell.</returns>
        /// <param name="spell">The spell to register.</param>
        /// <param name="keyAbilityScore">The ability score which is associated with casting the spell.</param>
        ICastableSpell Register(ISpell spell, IAbilityScore keyAbilityScore);

        /// <summary>
        /// Registers a spell, transforming it into a castable spell.
        /// </summary>
        /// <returns>The ICastableSpell.</returns>
        /// <param name="spell">The spell to register.</param>
        /// <param name="keyAbilityScore">The ability score which is associated with casting the spell.</param>
        /// <param name="baseCasterLevel">The caster level of the spell.</param>
        ICastableSpell Register(ISpell spell, IAbilityScore keyAbilityScore, Func<byte> baseCasterLevel);

        /// <summary>
        /// Returns all registered spells.
        /// </summary>
        ICastableSpell[] GetSpells();

        /// <summary>
        /// The OnRegistered event is invoked whenever a new spell is registered.
        /// </summary>
        event EventHandler<SpellRegisteredEventArgs> OnRegistered;
    }
}