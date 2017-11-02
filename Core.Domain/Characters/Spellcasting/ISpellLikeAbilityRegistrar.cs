using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
	public interface ISpellLikeAbilityRegistrar
	{
        ISpellLikeAbility Register(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore);

		ISpellLikeAbility Register(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore, Func<byte> baseCasterLevel);

		ISpellLikeAbility[] GetSpellLikeAbilities();

		void OnRegistered(OnSpellLikeAbilityRegisteredEventHandler handler);
	}
}