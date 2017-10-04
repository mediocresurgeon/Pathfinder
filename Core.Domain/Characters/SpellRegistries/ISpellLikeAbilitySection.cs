namespace Core.Domain.Characters.SpellRegistries
{
    public interface ISpellLikeAbilitySection
    {
		ISpellLikeAbilityRegistrar Registrar { get; }

		ISpellLikeAbilityCollection Known { get; }
    }
}