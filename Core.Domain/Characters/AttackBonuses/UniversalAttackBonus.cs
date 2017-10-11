using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.AttackBonuses
{
    internal class UniversalAttackBonus : IUniversalAttackBonus
    {
        // This class is intended to be inherited.

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.AttackBonuses.GenericAttackBonus"/> class.
        /// </summary>
        internal UniversalAttackBonus()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        public virtual IModifierTracker EnhancementBonuses { get; } = new EnhancementBonusTracker();

        public virtual IModifierTracker UntypedBonuses { get; } = new UntypedBonusTracker();

        public virtual IModifierTracker Penalties { get; } = new PenaltyTracker();
        #endregion
    }
}