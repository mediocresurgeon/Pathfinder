using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    internal sealed class UndeadControlling : ShieldEnchantment
    {
        #region Constructor
        internal UndeadControlling()
            : base("Undead Controlling", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/undead-controlling/")
        {
            this.Cost = 49_000;
        }
        #endregion

        #region Properties
        public override byte CasterLevel => 13;
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
            return new School[] { School.Necromancy };
        }
        #endregion
    }
}