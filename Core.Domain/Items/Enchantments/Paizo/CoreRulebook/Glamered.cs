using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Enchantments.Paizo.CoreRulebook
{
    internal sealed class Glamered : IArmorEnchantment
    {
        #region Constructor
        internal Glamered()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        public INameFragment Name { get; } = new NameFragment("Glamered", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/glamered/");


        public byte CasterLevel => 10;


        public byte SpecialAbilityBonus => 0;


        public double Cost => 2700;
        #endregion

        #region Methods
        public School[] GetSchools() => new School[] { School.Illusion };


        public void ApplyTo(ICharacter character)
        {
            // Intentionally blank
        }


        public void Enchant(Armor.Armor armor)
        {
            // Intentionally blank
        }
        #endregion
    }
}