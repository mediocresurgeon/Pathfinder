using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    internal sealed class ArrowDeflection : ShieldEnchantment
    {
        #region Constructor
        internal ArrowDeflection()
            : base("Arrow Deflection", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/arrow-deflection/")
        {
            this.SpecialAbilityBonus = 2;
        }
        #endregion

        #region Properties
        public override byte CasterLevel => 5;
        #endregion

        #region Methods
        public override void ApplyTo(ICharacter character)
        {
            // Intentionally blank
        }

        public override void Enchant(Shield shield)
        {
            // Intentionally blank
        }

        public override School[] GetSchools()
        {
            return new School[] { School.Abjuration };
        }
        #endregion
    }
}