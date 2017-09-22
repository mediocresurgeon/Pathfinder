using Core.Domain.Characters.AbilityScores;
using Core.Domain.Spells;


namespace Core.Domain.Characters.SpellRegistries
{
    public class SpellLikeAbility : CastableSpell, ISpellLikeAbility
    {
        #region Backing variables
        private readonly byte _usesPerDay;
        #endregion

        #region Constructors
        public SpellLikeAbility(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore, byte casterLevel)
            : base(spell, keyAbilityScore, casterLevel)
        {
            _usesPerDay = usesPerDay;
        }

        public SpellLikeAbility(byte usesPerDay, ISpell spell, IAbilityScore keyAbilityScore, ICharacter character)
            : base(spell, keyAbilityScore, character)
        {
            _usesPerDay = usesPerDay;
        }
        #endregion

        #region Properties
        public virtual byte UsesPerDay => _usesPerDay;
        #endregion
    }
}