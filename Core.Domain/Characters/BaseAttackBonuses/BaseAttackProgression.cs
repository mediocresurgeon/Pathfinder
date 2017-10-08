namespace Core.Domain.Characters.BaseAttackBonuses
{
    /// <summary>
    /// The rate at which a character's base attack bonus progresses relative to its level.
    /// </summary>
    public enum BaseAttackProgression
    {
        /// <summary>
        /// The slowest base attack rate.
        /// </summary>
        AsWizard = -1,

        /// <summary>
        /// Medium base attack rate.
        /// </summary>
        AsCleric = 0,

        /// <summary>
        /// Fastest base attack bonus rate.
        /// </summary>
        AsFighter = 1,
    }
}