namespace Core.Domain.Characters.SpellRegistries
{
    public interface ISpellLikeAbility : ICastableSpell
    {
        byte UsesPerDay { get; }
    }
}