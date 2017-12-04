namespace Core.Domain.Items.Enchantments
{
    internal interface IArmorEnchantment : IEnchantment
    {
        void Enchant(Armor.Armor armor);
    }
}