using Core.Domain.Characters;
using Core.Domain.Items.Enchantments;
using Core.Domain.Spells;


namespace Core.Domain.Items.Aggregators
{
    internal interface IEnchantmentAggregator<E, I> where E : IEnchantment
                                                    where I : IItem
    {
        void EnchantWith(E enchantment);

        E[] GetEnchantments();

        double GetMarketPrice();

        byte? GetCasterLevel();

        School[] GetSchools();

        (INameFragment enhancement, INameFragment[] others) GetNames();

        void ApplyTo(ICharacter character);
    }
}