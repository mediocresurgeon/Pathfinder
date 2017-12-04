using Core.Domain.Characters;
using Core.Domain.Items.Shields;
using Core.Domain.Spells;


namespace Core.Domain.Items.Enchantments.Paizo.CoreRulebook
{
    internal sealed class UndeadControlling : IArmorEnchantment, IShieldEnchantment
    {
        #region Constructor
        internal UndeadControlling()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        public byte CasterLevel => 13;


        public INameFragment Name { get; } = new NameFragment("Undead Controlling", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/undead-controlling/");


        public byte SpecialAbilityBonus => 0;


        public double Cost => 49_000;
        #endregion

        #region Methods
        public School[] GetSchools() => new School[] { School.Necromancy };


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