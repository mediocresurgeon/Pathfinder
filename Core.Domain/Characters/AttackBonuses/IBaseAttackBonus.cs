namespace Core.Domain.Characters.AttackBonuses
{
    /// <summary>
    /// A measurement of an ICharacter's skill in battle.
    /// </summary>
    public interface IBaseAttackBonus
    {
        /// <summary>
        /// The rate at which an ICharacter's base attack progress increases relative to the ICharacter's level.
        /// </summary>
        BaseAttackProgression Rate { get; set; }

        /// <summary>
        /// The total base attack bonus.
        /// </summary>
        byte GetTotal();
    }
}