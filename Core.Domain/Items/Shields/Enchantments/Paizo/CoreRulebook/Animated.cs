using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    internal sealed class Animated : ShieldEnchantment
    {
        #region Constructor
        internal Animated()
            : base("Animated", "http://www.d20pfsrd.com/Magic-items/magic-armor/magic-armor-and-shield-special-abilities/animated")
        {
            this.SpecialAbilityBonus = 2;
        }
        #endregion

        #region Properties
        public override byte CasterLevel => 12;
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