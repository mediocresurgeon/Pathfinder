using System;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.WonderousItems.Paizo.CoreRulebook
{
    /// <summary>
    /// A nondescript silk vest with numerous pockets sewn into its lining.
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

        #region Properties
        public override double GetWeight() => 0;


        public override byte? GetCasterLevel() => 4;
        #endregion

        #region Methods
        public override byte GetHardness()
        {
            return 0;
        }


        public override ushort GetHitPoints()
        {
            return 1;
        }


        public override double GetMarketPrice()
        {
            return 5_200;
        }


        public override INameFragment[] GetName()
        {
            return new INameFragment[] {
                new NameFragment(
                    text:       "Vest of Escape",
                    webAddress: "http://www.d20pfsrd.com/magic-items/wondrous-items/wondrous-items/r-z/vest-of-escape/"
                )
            };
        }


        public override School[] GetSchools()
        {
            return new School[] { School.Conjuration, School.Transmutation };
        }


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