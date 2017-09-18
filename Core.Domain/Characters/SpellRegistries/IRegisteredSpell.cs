using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
	public interface IRegisteredSpell
	{
		ISpell Spell { get; }

        byte? GetDifficultyClass();

        byte GetEffectiveCasterLevel();
	}
}