using System;
using System.ComponentModel;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    /// <summary>
    /// The magnitude of spell resistance that will be bestowed via enchantment.
    /// </summary>
    public enum SpellResistanceMagnitude
    {
        /// <summary>
        /// Spell resistance 13.
        /// </summary>
        SR13 = 13,

        /// <summary>
        /// Spell resistance 15.
        /// </summary>
        SR15 = 15,

        /// <summary>
        /// Spell resistance 17.
        /// </summary>
        SR17 = 17,

        /// <summary>
        /// Spell resistance 19.
        /// </summary>
        SR19 = 19,
    }


    internal sealed class SpellResistance : ShieldEnchantment
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook.SpellResistance"/> class.
        /// </summary>
        /// <param name="spellResistance">The amount of spell resistance to add.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when SpellResistanceMagnitude is an unexpected value.</exception>
        internal SpellResistance(SpellResistanceMagnitude spellResistance)
            : base($"Spell Resistance ({ (int)spellResistance })", "http://www.d20pfsrd.com/magic-items/magic-armor/magic-armor-and-shield-special-abilities/spell-resistance/")
        {
            switch (spellResistance)
            {
                case SpellResistanceMagnitude.SR13:
                    this.SpecialAbilityBonus = 2;
                    break;
                case SpellResistanceMagnitude.SR15:
                    this.SpecialAbilityBonus = 3;
                    break;
                case SpellResistanceMagnitude.SR17:
                    this.SpecialAbilityBonus = 4;
                    break;
                case SpellResistanceMagnitude.SR19:
                    this.SpecialAbilityBonus = 5;
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(spellResistance), (int)spellResistance, typeof(SpellResistanceMagnitude));
            }
            this.GetSpellResistance = () => Convert.ToByte(spellResistance);
        }
        #endregion

        #region Properties
        private Func<byte> GetSpellResistance { get; }

        public override byte CasterLevel => 15;
        #endregion

        #region Methods
        public override void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            character.SpellResistance?.Add(this.GetSpellResistance);
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