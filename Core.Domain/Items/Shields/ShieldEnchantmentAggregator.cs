using Core.Domain.Items.Aggregators;
using Core.Domain.Items.Enchantments;


namespace Core.Domain.Items.Shields
{
    internal sealed class ShieldEnchantmentAggregator : EnchantmentAggregator<IShieldEnchantment, Shield>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.ShieldEnchantmentAggregator"/> class.
        /// </summary>
        /// <param name="shield">The shield which "owns" the shield enchantments.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal ShieldEnchantmentAggregator(Shield shield)
            : base(shield, (e, s) => e.Enchant(s), 1000)
        {
            // Intentionally blank
        }
        #endregion
    }
}