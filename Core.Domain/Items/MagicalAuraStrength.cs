namespace Core.Domain.Items
{
    /// <summary>
    /// The strength of an emanation of magical energy.
    /// </summary>
    public enum MagicalAuraStrength
    {
        /// <summary>
        /// No aura is present.
        /// </summary>
        None,

        /// <summary>
        /// A residual aura which lingers after its original source dissipates or is destroyed.
        /// </summary>
        Dim,

        /// <summary>
        /// A weak aura which indicates a functioning spell of level 3 or lower, or a magic item of caster level 5 or lower.
        /// </summary>
        Faint,

        /// <summary>
        /// An aura which indicates a functioning spell of level 4-6, or a magic item of caster level 6-11.
        /// </summary>
        Moderate,

        /// <summary>
        /// A potent aura which indicates a functioning spell of level 7-9, or a magic item of caster level 12-20.
        /// </summary>
        Strong,

        /// <summary>
        /// A godlike aura which indicates an epic-level spell, or the presence of an artifact.
        /// </summary>
        Overwhelming,
    }
}