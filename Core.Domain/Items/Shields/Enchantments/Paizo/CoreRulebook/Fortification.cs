using System;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    /// <summary>
    /// The level of magical force which protects vital areas of the wearer for effectively.
    /// </summary>
    public enum FortificationType
    {
        /// <summary>
        /// 25% chance to negate critical hits and sneak attacks.
        /// </summary>
        Light,

        /// <summary>
        /// 50% chance to negate critical hits and sneak attacks.
        /// </summary>
        Medium,

        /// <summary>
        /// 75% chance to negate critical hits and sneak attacks.
        /// </summary>
        Heavy,
    }


    internal sealed class Fortification : ShieldEnchantment
    {
        #region Constructor
        internal Fortification(FortificationType fortType)
            : base($"{ fortType } Fortification", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/fortification/")
        {
            switch (fortType)
            {
                case FortificationType.Light:
                    this.SpecialAbilityBonus = 1;
                    break;
                case FortificationType.Medium:
                    this.SpecialAbilityBonus = 3;
                    break;
                case FortificationType.Heavy:
                    this.SpecialAbilityBonus = 5;
                    break;
                default:
                    throw new NotImplementedException($"Unable to determine the special ability bonus for { fortType } Fortification.");
            }
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
            return new School[] { School.Abjuration };
        }
        #endregion
    }
}