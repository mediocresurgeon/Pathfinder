using Core.Domain.Spells;


namespace Core.Domain.Items
{
    /// <summary>
    /// An physical game item, such as an inkpen or a magical weapon.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        INameFragment[] GetName();

        /// <summary>
        /// Returns the market price of this item.
        /// </summary>
        double GetMarketPrice();

        /// <summary>
        /// Returns the caster level of this item.
        /// </summary>
        byte? GetCasterLevel();

        /// <summary>
        /// Returns this item's magical aura strength.
        /// </summary>
        MagicalAuraStrength GetAuraStrength();

        /// <summary>
        /// Returns the schools of this item's magical auras.
        /// </summary>
        School[] GetSchools();

        /// <summary>
        /// Returns this item's fortitude saving throw.
        /// </summary>
        sbyte? GetFortitude();

        /// <summary>
        /// Returns this item's reflex saving throw.
        /// </summary>
        sbyte? GetReflex();

        /// <summary>
        /// Returns this item's will saving throw.
        /// </summary>
        sbyte? GetWill();

        /// <summary>
        /// Returns the weight of this item.
        /// </summary>
        double GetWeight();

        /// <summary>
        /// Returns the hardness of this item.
        /// </summary>
        byte GetHardness();

        /// <summary>
        /// Returns the hit points of this item.
        /// </summary>
        ushort GetHitPoints();
    }
}