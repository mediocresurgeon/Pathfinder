using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;


namespace Core.Domain.Items.WonderousItems.Paizo.CoreRulebook
{
    /// <summary>
    /// A neck item which lets the equipped character cast Mage Hand at will.
    /// </summary>
    public sealed class HandOfTheMage : Item, INeckSlot
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.WonderousItems.Paizo.CoreRulebook.H.HandOfTheMage"/> class.
        /// </summary>
        public HandOfTheMage()
        {
            // Intentionally blank
        }
        #endregion

        #region Methods
        /// <summary>
        /// Hand of the Mage weighs 2lbs.
        /// </summary>
        public override double GetWeight() => 2;


        /// <summary>
        /// Hand of the Mage has caster level 2.
        /// </summary>
        public override byte? GetCasterLevel() => 2;


        /// <summary>
        /// Hand of the Mage has hardness 2.
        /// </summary>
        public override byte GetHardness() => 2;


        /// <summary>
        /// Hand of the Mage has 5 hit points.
        /// </summary>
        public override ushort GetHitPoints() => 5;


        /// <summary>
        /// The market price of Hand of the Mage is 900gp.
        /// </summary>
        public override double GetMarketPrice() => 900;


        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        public override INameFragment[] GetName()
        {
            return new INameFragment[] {
                new NameFragment(
                    text:       "Hand of the Mage",
                    webAddress: "http://www.d20pfsrd.com/magic-items/wondrous-items/wondrous-items/h-l/hand-of-the-mage/")
            };
        }


        /// <summary>
        /// Hand of the Mage has a Transmutation aura.
        /// </summary>
        public override School[] GetSchools()
        {
            return new School[] { School.Transmutation };
        }


        /// <summary>
        /// Applies the effects of Hand of the Mage to an ICharacter.
        /// </summary>
        /// <param name="character">The character to apply effects to.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            // Do not register the spell-like ability--we don't want feats applying to it.
            var spell = MageHand.SorcererVersion;
            IAbilityScore handOfTheMageCastingStat = new AbilityScore { BaseScore = Convert.ToByte(10 + spell.Level) };
            ISpellLikeAbility mageHandSpellLikeAbility = new SpellLikeAbility(usesPerDay:      0,
                                                                              spell:           spell,
                                                                              keyAbilityScore: handOfTheMageCastingStat,
                                                                              baseCasterLevel: () => this.GetCasterLevel().Value);
            character.SpellLikeAbilities?.Known?.Add(mageHandSpellLikeAbility);
        }
        #endregion
    }
}