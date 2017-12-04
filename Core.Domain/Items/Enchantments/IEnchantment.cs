using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Enchantments
{
    internal interface IEnchantment : IApplicable
    {
        INameFragment Name { get; }

        byte CasterLevel { get; }

        byte SpecialAbilityBonus { get; }

        double Cost { get; }

        School[] GetSchools();
    }
}