namespace Core.Domain.Characters.AttackBonuses
{
    /// <summary>
    /// A section of an ICharacter which stores global attack bonus data.
    /// </summary>
    public interface IAttackBonusSection
    {
        /// <summary>
        /// Returns the ICharacter's base attack bonus.
        /// </summary>
        IBaseAttackBonus BaseAttackBonus { get; }

        /// <summary>
        /// Returns the ICharacter's bonuses to all melee attacks.
        /// </summary>
        IUniversalAttackBonus GenericMeleeAttackBonus { get; }

        /// <summary>
        /// Returns the ICharacter's bonuses to all thrown attacks.
        /// </summary>
        IUniversalAttackBonus GenericThrowingAttackBonus { get; }

        /// <summary>
        /// Returns the ICharacter's bonuses to all non-thrown ranged attacks.
        /// </summary>
        IUniversalAttackBonus GenericRangedAttackBonus { get; }
    }
}