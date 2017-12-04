using System;
using System.ComponentModel;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Enchantments.Paizo.CoreRulebook
{
    /// <summary>
    /// Indicates the strength of the Slick enchantment.
    /// </summary>
    public enum SlickStrength
    {
        /// <summary>
        /// Provides a +5 competence bonus on Escape Artist checks.
        /// </summary>
        Regular  = 5,

        /// <summary>
        /// Provides a +10 competence bonus on Escape Artist checks.
        /// </summary>
        Improved = 10,

        /// <summary>
        /// Provides a +15 competence bonus on Escape Artist checks.
        /// </summary>
        Greater  = 15,
    }


    internal sealed class Slick : IArmorEnchantment
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Enchantments.Paizo.CoreRulebook.Slick"/> class.
        /// </summary>
        /// <param name="slickness">The strength of the Slick enchantment.</param>
        /// /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when an argument is a nonstandard enum.</exception>
        internal Slick(SlickStrength slickness)
        {
            switch(slickness)
            {
                case SlickStrength.Regular:
                    this.CasterLevel = 4;
                    this.Cost = 3750;
                    break;
                case SlickStrength.Improved:
                    this.CasterLevel = 10;
                    this.Cost = 15_000;
                    break;
                case SlickStrength.Greater:
                    this.CasterLevel = 15;
                    this.Cost = 33_750;
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(slickness), (int)slickness, slickness.GetType());
            }
            byte skillBonus = Convert.ToByte((int)slickness);
            this.ApplicationEffects = (c) => c.Skills?.EscapeArtist?.CompetenceBonuses?.Add(() => skillBonus);
            this.Name = new NameFragment(Slick.BuildName(slickness), Slick.BuildWebAddress(slickness));
        }


        private static string BuildName(SlickStrength slickness)
        {
            string magnitude = (SlickStrength.Regular != slickness)
                             ? $"{ slickness }"
                             : String.Empty;
            return $"{ magnitude } Slick".Trim();
        }


        private static string BuildWebAddress(SlickStrength slickness)
        {
            switch (slickness) {
                case SlickStrength.Regular:
                    return "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/slick/";
                case SlickStrength.Improved:
                    return "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/slick-improved/";
                case SlickStrength.Greater:
                    return "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/slick-greater/";
                default:
                    throw new InvalidEnumArgumentException(nameof(slickness), (int)slickness, slickness.GetType());
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
        public School[] GetSchools() => new School[] { School.Conjuration };


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