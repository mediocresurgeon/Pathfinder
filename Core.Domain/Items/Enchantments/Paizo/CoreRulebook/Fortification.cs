using System.ComponentModel;
using Core.Domain.Characters;
using Core.Domain.Items.Shields;
using Core.Domain.Spells;


namespace Core.Domain.Items.Enchantments.Paizo.CoreRulebook
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


    internal sealed class Fortification : IArmorEnchantment, IShieldEnchantment
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Armor.Enchantments.Paizo.CoreRulebook.Fortification"/> class.
        /// </summary>
        /// <param name="protectionLevel">The level of protection afforded by this Fortification enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        internal Fortification(FortificationType protectionLevel)
        {
            switch (protectionLevel)
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
                    throw new InvalidEnumArgumentException(nameof(protectionLevel), (int)protectionLevel, protectionLevel.GetType());
            }
            this.Name = new NameFragment($"{ protectionLevel } Fortification", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/fortification/");
        }
        #endregion

        #region Properties
        public byte CasterLevel => 13;


        public INameFragment Name { get; }


        public byte SpecialAbilityBonus { get; }


        public double Cost => 0;
        #endregion

        #region Methods
        public School[] GetSchools() => new School[] { School.Abjuration };


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