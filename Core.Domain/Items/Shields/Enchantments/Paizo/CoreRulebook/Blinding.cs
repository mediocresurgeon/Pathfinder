using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    internal sealed class Blinding : ShieldEnchantment
    {
        #region Constructor
        internal Blinding()
            : base("Blinding", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/blinding/")
        {
            this.SpecialAbilityBonus = 1;
        }
        #endregion

        #region Properties
        public override byte CasterLevel => 7;
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
            return new School[] { School.Evocation };
        }
        #endregion
    }
}