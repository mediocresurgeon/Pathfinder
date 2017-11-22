using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Enchantments
{
    internal interface IShieldEnchantment : IApplicable
    {
        INameFragment Name { get; }

        byte CasterLevel { get; }

        byte SpecialAbilityBonus { get; }

        double Cost { get; }

        School[] GetSchools();

        void Enchant(Shield shield);
    }
}