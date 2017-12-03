using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// Logic which encapulates how to associate a spell-like ability with an ICharacter.
    /// </summary>
	public interface ISpellLikeAbilityRegistrar
	{
        /// <summary>
        /// Registers a spell, transforming it into a spell-like ability.
        /// The spell-like ability's caster level is equal to the ICharacter's level.
        /// </summary>
        /// <returns>The spell-like ability.</returns>
        /// <param name="usesPerDay">
        /// The number of times per day the spell-like ability can be used.
        /// Zero indicates it can be used an unlimited number of times per day.
        /// </param>
        /// <param name="spell">The spell this spell-like ability mimics.</param>
        /// <param name="keyAbilityScore">The ability score which is associated with casting this spell-like ability.</param>
        ISpellLikeAbility Register(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore);

        /// <summary>
        /// Registers a spell, transforming it into a spell-like ability.
        /// </summary>
        /// <returns>The spell-like ability.</returns>
        /// <param name="usesPerDay">
        /// The number of times per day the spell-like ability can be used.
        /// Zero indicates it can be used an unlimited number of times per day.
        /// </param>
        /// <param name="spell">The spell this spell-like ability mimics.</param>
        /// <param name="keyAbilityScore">The ability score which is associated with casting this spell-like ability.</param>
        /// <param name="baseCasterLevel">The caster level of the spell-like ability.</param>
		ISpellLikeAbility Register(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore, Func<byte> baseCasterLevel);

        /// <summary>
        /// Returns all registered spell-like abilities.
        /// </summary>
        /// <returns>The spell like abilities.</returns>
		ISpellLikeAbility[] GetSpellLikeAbilities();

        /// <summary>
        /// Subscribes to the OnRegistered event, which is invoked whenever a new spell-like ability is registered.
        /// </summary>
        /// <param name="handler">The event handler.</param>
		void OnRegistered(OnSpellLikeAbilityRegisteredEventHandler handler);
	}
}