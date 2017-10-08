namespace Core.Domain.Characters.BaseAttackBonuses
{
    public interface IBaseAttackBonus
    {
        BaseAttackProgression Rate { get; set; }

        byte GetTotal();
    }
}