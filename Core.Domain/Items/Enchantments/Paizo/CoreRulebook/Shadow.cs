using System;
using System.ComponentModel;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Enchantments.Paizo.CoreRulebook
{
    /// <summary>
    /// Indicates the strength of the Shadow enchantment.
    /// </summary>
    public enum ShadowStrength
    {
        /// <summary>
        /// Provides a +5 competence bonus on Stealth checks.
        /// </summary>
        Regular  = 5,

        /// <summary>
        /// Provides a +10 competence bonus on Stealth checks.
        /// </summary>
        Improved = 10,

        /// <summary>
        /// Provides a +15 competence bonus on Stealth checks.
        /// </summary>
        Greater  = 15,
    }


    internal sealed class Shadow : IArmorEnchantment
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Enchantments.Paizo.CoreRulebook.Shadow"/> class.
        /// </summary>
        /// <param name="strength">The strength of the enchantment.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        internal Shadow(ShadowStrength strength)
        {
            switch(strength)
            {
                case ShadowStrength.Regular:
                    this.CasterLevel = 5;
                    this.Cost = 3750;
                    break;
                case ShadowStrength.Improved:
                    this.CasterLevel = 10;
                    this.Cost = 15_000;
                    break;
                case ShadowStrength.Greater:
                    this.CasterLevel = 15;
                    this.Cost = 33_750;
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(strength), (int)strength, strength.GetType());
            }
            byte skillBonus = Convert.ToByte((int)strength);
            this.ApplicationEffects = (c) => c.Skills?.Stealth?.CompetenceBonuses?.Add(() => skillBonus);
            this.Name = new NameFragment(Shadow.BuildName(strength), Shadow.BuildWebAddress(strength));
        }


        private static string BuildName(ShadowStrength strength)
        {
            string magnitude = (ShadowStrength.Regular != strength)
                             ? $"{ strength }"
                             : String.Empty;
            return $"{ magnitude } Shadow".Trim();
        }


        private static string BuildWebAddress(ShadowStrength strength)
        {
            switch (strength) {
                case ShadowStrength.Regular:
                    return "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/shadow/";
                case ShadowStrength.Improved:
                    return "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/shadow-improved/";
                case ShadowStrength.Greater:
                    return "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/shadow-greater/";
                default:
                    throw new InvalidEnumArgumentException(nameof(strength), (int)strength, strength.GetType());
            }
        }
        #endregion

        #region Properties
        private Action<ICharacter> ApplicationEffects { get; }


        public INameFragment Name { get; }


        public byte CasterLevel { get; }


        public byte SpecialAbilityBonus => 0;


        public double Cost { get; }
        #endregion

        #region Methods
        public School[] GetSchools() => new School[] { School.Illusion };


        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument may not be null");
            this.ApplicationEffects(character);
        }


        public void Enchant(Armor.Armor armor)
        {
            // Intentionally blank
        }
        #endregion
    }
}