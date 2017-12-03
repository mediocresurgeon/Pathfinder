namespace Core.Domain.Characters.Spellcasting
{
    /// <summary>
    /// A special ability which functions like a spell.
    /// </summary>
    public interface ISpellLikeAbility : ICastableSpell
    {
        /// <summary>
        /// The number of times per day this spell-like ability can be used.
        /// Zero indicates the ability can be used an unlimited number of times per day.
        /// </summary>
        byte UsesPerDay { get; }
    }
}