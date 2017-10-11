namespace Core.Domain.Characters.AttackBonuses
{
    public interface IBaseAttackBonus
    {
        BaseAttackProgression Rate { get; set; }

        byte GetTotal();
    }
}