using System;


namespace Core.Domain.Characters.AttackBonuses
{
    internal sealed class AttackBonusSection : IAttackBonusSection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.AttackBonuses.AttackBonusSection"/> class.
        /// </summary>
        /// <param name="character">The character to whom these attack bonuses belong.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal AttackBonusSection(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            this.BaseAttackBonus = new BaseAttackBonus(character);
        }

        public IBaseAttackBonus BaseAttackBonus { get; }

        public IUniversalAttackBonus GenericMeleeAttackBonus { get; } = new UniversalAttackBonus();

        public IUniversalAttackBonus GenericThrowingAttackBonus { get; } = new UniversalAttackBonus();

        public IUniversalAttackBonus GenericRangedAttackBonus { get; } = new UniversalAttackBonus();
    }
}