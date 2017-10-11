using Core.Domain.Characters.AbilityScores;


namespace Core.Domain.Characters.AttackBonuses
{
    public interface IWeaponAttackBonus : IUniversalAttackBonus
    {
        IAbilityScore KeyAbilityScore { get; }

        sbyte GetSizeModifier();

        sbyte GetTotal();
    }
}