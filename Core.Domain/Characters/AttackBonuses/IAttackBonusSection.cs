using System;


namespace Core.Domain.Characters.AttackBonuses
{
    public interface IAttackBonusSection
    {
        IBaseAttackBonus BaseAttackBonus { get; }

        IUniversalAttackBonus GenericMeleeAttackBonus { get; }

        IUniversalAttackBonus GenericThrowingAttackBonus { get; }

        IUniversalAttackBonus GenericRangedAttackBonus { get; }
    }
}