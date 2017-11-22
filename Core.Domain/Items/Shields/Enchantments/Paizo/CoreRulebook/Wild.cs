using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    internal sealed class Wild : ShieldEnchantment
    {
        #region Constructor
        internal Wild()
            : base("Wild", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/wild/")
        {
            this.SpecialAbilityBonus = 3;
        }
        #endregion

        #region Properties
        public override byte CasterLevel => 9;
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
            return new School[] { School.Transmutation };
        }
        #endregion
    }
}