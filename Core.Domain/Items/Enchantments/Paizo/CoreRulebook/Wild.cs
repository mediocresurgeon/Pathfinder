using Core.Domain.Characters;
using Core.Domain.Items.Shields;
using Core.Domain.Spells;


namespace Core.Domain.Items.Enchantments.Paizo.CoreRulebook
{
    internal sealed class Wild : IArmorEnchantment, IShieldEnchantment
    {
        #region Constructor
        internal Wild()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        public byte CasterLevel => 9;

        public INameFragment Name { get; } = new NameFragment("Wild", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/wild/");

        public byte SpecialAbilityBonus => 3;

        public double Cost => 0;
        #endregion

        #region Methods
        public School[] GetSchools() => new School[] { School.Transmutation };


        public void ApplyTo(ICharacter character)
        {
            // Intentionally blank
        }


        public void Enchant(Armor.Armor armor)
        {
            // Intentionally blank
        }


        public void Enchant(Shield shield)
        {
            // Intentionally blank
        }
        #endregion
    }
}