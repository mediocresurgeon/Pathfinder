using Core.Domain.Items.Shields;


namespace Core.Domain.Items.Enchantments
{
    internal interface IShieldEnchantment : IEnchantment
    {
        void Enchant(Shield shield);
    }
}