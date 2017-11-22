using Core.Domain.Characters;
using Core.Domain.Items.Shields.Enchantments;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields
{
    internal interface IShieldEnchantmentAggregator : IApplicable
    {
        void EnchantWith<T>(T enchantment) where T : IShieldEnchantment;

        double GetEnchantmentMarketValue();

        School[] GetSchools();

        (INameFragment enhancement, INameFragment[] others) GetNames();

        byte? GetCasterLevel();
    }
}