using Core.Domain.Items.Aggregators;
using Core.Domain.Items.Enchantments;


namespace Core.Domain.Items.Armor
{
    internal sealed class ArmorEnchantmentAggregator : EnchantmentAggregator<IArmorEnchantment, Armor>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.ArmorEnchantmentAggregator"/> class.
        /// </summary>
        /// <param name="armor">The armor which owns the enchantments.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public ArmorEnchantmentAggregator(Armor armor)
            : base(armor, (e, a) => e.Enchant(a), 1000)
        {
            // Intentionally blank
        }
        #endregion
    }
}