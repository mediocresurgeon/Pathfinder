using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
	public interface ISpellLikeAbilityRegistrar
	{
        ISpellLikeAbility Register(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore);

		ISpellLikeAbility Register(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore, byte casterLevel);

		ISpellLikeAbility[] GetSpellLikeAbilities();

		void OnRegistered(OnSpellLikeAbilityRegisteredEventHandler handler);
	}
}