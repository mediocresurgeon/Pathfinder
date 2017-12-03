using System;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    /// <summary>
    /// +2 Heavy Steel Shield which can use bite attacks 3/day.
    /// </summary>
    public sealed class LionsShield : Item, IShieldSlot
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.Paizo.CoreRulebook.LionsShield"/> class.
        /// </summary>
        public LionsShield()
            : base()
        {
            // Intentionally blank
        }
        #endregion


        /// <summary>
        /// Lion's Shield is masterwork.
        /// </summary>
        public bool IsMasterwork => true;


        /// <summary>
        /// Lion's SHield has an armor check penalty of 1.
        /// </summary>
        public byte GetArmorCheckPenalty() => 1;



        /// <summary>
        /// Lion's Shield has caster level 10.
        /// </summary>
        public override byte? GetCasterLevel() => 10;


        /// <summary>
        /// Lion's Shield has hardness 14..
        /// </summary>
        public override byte GetHardness() => 14;


        /// <summary>
        /// Lion's Shield has 40 hit point.
        /// </summary>
        public override ushort GetHitPoints() => 40;


        /// <summary>
        /// Lion's Shield has a market price of 9170gp.
        /// </summary>
        public override double GetMarketPrice() => 9170;


        /// <summary>
        /// Returns Lion's Shield's name and URL.
        /// </summary>
        public override INameFragment[] GetName()
        {
            return new INameFragment[] {
                new NameFragment(text:       "Lion's Shield",
                                 webAddress: "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-shields/lion-s-shield/")
            };
        }


        /// <summary>
        /// Lion's Shield has a Conjuration aura.
        /// </summary>
        public override School[] GetSchools()
        {
            return new School[] { School.Conjuration };
        }


        /// <summary>
        /// Lion's Shield has a shield bonus of +4.
        /// </summary>
        public byte GetShieldBonus() => 4;


        /// <summary>
        /// Lion's Shield weighs 15lbs.
        /// </summary>
        public override double GetWeight() => 15;


        /// <summary>
        /// Applies Lion's Shield's effects to a character.
        /// </summary>
        /// <param name="character">The character who has equipped Lion's Shield.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument may not be null.");
        }
    }
}