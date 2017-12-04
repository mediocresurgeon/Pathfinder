using Core.Domain.Characters;
using Core.Domain.Items.Shields;
using Core.Domain.Spells;


namespace Core.Domain.Items.Enchantments.Paizo.CoreRulebook
{
    internal sealed class Animated : IShieldEnchantment
    {
        #region Constructor
        internal Animated()
        {
            // intentionally blank
        }
        #endregion

        #region Properties
        public byte CasterLevel => 12;


        public INameFragment Name { get; } = new NameFragment("Animated", "http://www.d20pfsrd.com/Magic-items/magic-armor/magic-armor-and-shield-special-abilities/animated");


        public byte SpecialAbilityBonus => 2;


        public double Cost => 0;
        #endregion

        #region Methods
        public School[] GetSchools() => new School[] { School.Transmutation };


        public void ApplyTo(ICharacter character)
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