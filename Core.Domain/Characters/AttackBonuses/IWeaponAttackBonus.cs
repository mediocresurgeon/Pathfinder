using Core.Domain.Characters.AbilityScores;


namespace Core.Domain.Characters.AttackBonuses
{
    /// <summary>
    /// An attack bonus which is associated with a particular weapon.
    /// </summary>
    public interface IWeaponAttackBonus : IUniversalAttackBonus
    {
        /// <summary>
        /// The ICharacter's IAbilityScore which powers this IAttackBonus.
        /// </summary>
        IAbilityScore KeyAbilityScore { get; }

        /// <summary>
        /// Returns the adjustment to attack bonus by virtue of the ICharacter's size.
        /// </summary>
        sbyte GetSizeModifier();

        /// <summary>
        /// Returns the total attack bonus.
        /// </summary>
        sbyte GetTotal();
    }
}