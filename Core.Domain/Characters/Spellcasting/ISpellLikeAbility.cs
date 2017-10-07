namespace Core.Domain.Characters.Spellcasting
{
    public interface ISpellLikeAbility : ICastableSpell
    {
        byte UsesPerDay { get; }
    }
}