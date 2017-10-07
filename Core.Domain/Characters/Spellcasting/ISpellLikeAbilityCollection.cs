namespace Core.Domain.Characters.Spellcasting
{
    public interface ISpellLikeAbilityCollection
    {
		void Add(ISpellLikeAbility spell);

		ISpellLikeAbility[] GetAll();
    }
}