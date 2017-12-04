using Core.Domain.Characters;
using Core.Domain.Items.Shields;
using Core.Domain.Spells;


namespace Core.Domain.Items.Enchantments.Paizo.CoreRulebook
{
    internal sealed class ArrowDeflection : IShieldEnchantment
    {
        #region Constructor
        internal ArrowDeflection()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        public byte CasterLevel => 5;


        public INameFragment Name { get; } = new NameFragment("Arrow Deflection", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/arrow-deflection/");


        public byte SpecialAbilityBonus => 2;


        public double Cost => 0;
        #endregion

        #region Methods
        public School[] GetSchools() => new School[] { School.Abjuration };


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