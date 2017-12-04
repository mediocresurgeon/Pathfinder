using Core.Domain.Characters;
using Core.Domain.Items.Shields;
using Core.Domain.Spells;


namespace Core.Domain.Items.Enchantments.Paizo.CoreRulebook
{
    internal sealed class ArrowCatching : IShieldEnchantment
    {
        #region Constructor
        internal ArrowCatching()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        public byte CasterLevel => 8;


        public INameFragment Name { get; } = new NameFragment("Arrow Catching", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/arrow-catching/");


        public byte SpecialAbilityBonus => 1;


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