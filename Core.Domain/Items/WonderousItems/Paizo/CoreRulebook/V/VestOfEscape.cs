using System;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.WonderousItems.Paizo.CoreRulebook
{
    /// <summary>
    /// A chest slot item which grants a +6 competence bonus to Escape Artist
    /// and a +4 competence bonus to Disable Device.
    /// </summary>
    public sealed class VestOfEscape : Item, IChestSlot
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.WonderousItems.Paizo.CoreRulebook.VestOfEscape"/> class.
        /// </summary>
        public VestOfEscape()
        {
            // Intentionally blank
        }
        #endregion

        #region Methods
        /// <summary>
        /// Vest of Escape has negligible weight.
        /// </summary>
        public override double GetWeight() => 0;


        /// <summary>
        /// Vest of Escape has caster level 4.
        /// </summary>
        /// <returns>The caster level.</returns>
        public override byte? GetCasterLevel() => 4;


        /// <summary>
        /// Vest of Escape has hardness 0.
        /// </summary>
        public override byte GetHardness() => 0;


        /// <summary>
        /// Vest of Escape has 1 hit point.
        /// </summary>
        public override ushort GetHitPoints() => 1;


        /// <summary>
        /// Vest of Escape has a market price of 5,200gp.
        /// </summary>
        public override double GetMarketPrice() => 5_200;


        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        public override INameFragment[] GetName()
        {
            return new INameFragment[] {
                new NameFragment(
                    text:       "Vest of Escape",
                    webAddress: "http://www.d20pfsrd.com/magic-items/wondrous-items/wondrous-items/r-z/vest-of-escape/"
                )
            };
        }


        /// <summary>
        /// Vest of Escape has auras of Conjuration and Transmutation.
        /// </summary>
        public override School[] GetSchools()
        {
            return new School[] { School.Conjuration, School.Transmutation };
        }


        /// <summary>
        /// Applies this item's effects to an ICharacter.
        /// </summary>
        /// <param name="character">The character to apply effects to.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            character.Skills?.DisableDevice?.CompetenceBonuses?.Add(() => 4);
            character.Skills?.EscapeArtist?.CompetenceBonuses?.Add(() => 6);
        }
        #endregion
    }
}