using Core.Domain.Spells;


namespace Core.Domain.Characters.Spellcasting
{
	public interface ICastableSpell
	{
		ISpell Spell { get; }

        void AddDifficultyClassBonus(byte bonus);

        ICasterLevel CasterLevel { get; }

        byte? GetDifficultyClass();
	}
}