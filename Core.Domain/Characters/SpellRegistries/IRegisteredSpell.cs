using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
	public interface IRegisteredSpell
	{
		ISpell Spell { get; }

        void AddDifficultyClassBonus(byte bonus);

        byte? GetDifficultyClass();

        byte GetEffectiveCasterLevel();
	}
}