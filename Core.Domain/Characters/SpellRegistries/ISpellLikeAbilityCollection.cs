namespace Core.Domain.Characters.SpellRegistries
{
    public interface ISpellLikeAbilityCollection
    {
		void Add(ISpellLikeAbility spell);

		ISpellLikeAbility[] GetSpellsByLevel(byte level);
    }
}