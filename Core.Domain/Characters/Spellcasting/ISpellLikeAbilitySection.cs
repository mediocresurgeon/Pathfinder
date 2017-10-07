namespace Core.Domain.Characters.Spellcasting
{
    public interface ISpellLikeAbilitySection
    {
		ISpellLikeAbilityRegistrar Registrar { get; }

		ISpellLikeAbilityCollection Known { get; }
    }
}