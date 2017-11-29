using System;
using System.ComponentModel;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    /// <summary>
    /// Indicates how much energy resistance is bestowed.
    /// </summary>
    public enum EnergyResistanceMagnitude
    {
        /// <summary>
        /// Provides energy resistance of 10.
        /// </summary>
        Regular = 10,

        /// <summary>
        /// Provides energy resistance of 20.
        /// </summary>
        Improved = 20,

        /// <summary>
        /// Provides energy resistance of 30.
        /// </summary>
        Greater = 30,
    }


    internal abstract class EnergyResistance : ShieldEnchantment
    {
        #region Backing variables
        private readonly byte _casterLevel;
        private readonly Action<ICharacter> _applicationEffects;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook.EnergyResistance"/> class.
        /// </summary>
        /// <param name="element">The kind of element which is to be resisted.</param>
        /// <param name="protectionLevel">The level of protection afforded by this enchantment.</param>
        /// <exception cref="System.ArgumentException">Thrown when element argument is empty or whitespace.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when given a nonstandard enum argument.</exception>
        internal EnergyResistance(string                             element,
                                  Func<ICharacter, IModifierTracker> energyResistanceExpression,
                                  EnergyResistanceMagnitude          protectionLevel)
            : base(name:       EnergyResistance.BuildName(element, protectionLevel),
                   webAddress: EnergyResistance.BuildWebAddress(protectionLevel))
        {
            if (null == energyResistanceExpression)
                throw new ArgumentNullException(nameof(energyResistanceExpression), "Argument may not be null.");
            byte energyResistance = Convert.ToByte((int)protectionLevel);
            _applicationEffects = (character) => energyResistanceExpression(character).Add(() => energyResistance);
            switch (protectionLevel)
            {
                case EnergyResistanceMagnitude.Regular:
                    this.Cost = 18_000;
                    _casterLevel = 3;
                    break;
                case EnergyResistanceMagnitude.Improved:
                    this.Cost = 42_000;
                    _casterLevel = 7;
                    break;
                case EnergyResistanceMagnitude.Greater:
                    this.Cost = 66_000;
                    _casterLevel = 11;
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(protectionLevel), (int)protectionLevel, typeof(EnergyResistanceMagnitude));
            }
        }


        private static string BuildName(string element, EnergyResistanceMagnitude protectionLevel)
        {
            if (null == element)
                throw new ArgumentNullException(nameof(element), "Argument may not be null.");
            if (String.IsNullOrWhiteSpace(element))
                throw new ArgumentException("String may not be completely whitespace nor empty.", nameof(element));
            string magnitude = (EnergyResistanceMagnitude.Regular != protectionLevel)
                             ? $"{ protectionLevel } "
                             : String.Empty;
            return $"{ magnitude }{ element.Trim() } Resistance";
        }


        private static string BuildWebAddress(EnergyResistanceMagnitude protectionLevel)
        {
            switch (protectionLevel)
            {
                case EnergyResistanceMagnitude.Regular:
                    return "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/energy-resistance/";
                case EnergyResistanceMagnitude.Improved:
                    return "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/energy-resistance-improved/";
                case EnergyResistanceMagnitude.Greater:
                    return "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/energy-resistance-greater/";
                default:
                    throw new InvalidEnumArgumentException(nameof(protectionLevel), (int)protectionLevel, typeof(EnergyResistanceMagnitude));
            }
        }
        #endregion

        #region Properties
        protected virtual Action<ICharacter> ApplyEffects => _applicationEffects;

        public override byte CasterLevel => _casterLevel;
        #endregion

        #region Methods
        public override void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument may not be null.");
            this.ApplyEffects(character);
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