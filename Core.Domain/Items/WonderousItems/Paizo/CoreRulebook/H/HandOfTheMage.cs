using System;
using Core.Domain.Characters;
using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;


namespace Core.Domain.Items.WonderousItems.Paizo.CoreRulebook
{
    /// <summary>
    /// A mummified elf hand which hangs by a golden chain around one's neck.
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

        #region Properties
        public override double Weight => 2;


        public override byte? CasterLevel => 2;
        #endregion

        #region Methods
        public override byte GetHardness()
        {
            return 2;
        }


        public override ushort GetHitPoints()
        {
            return 5;
        }


        public override double GetMarketPrice()
        {
            return 900;
        }


        public override INameFragment[] GetName()
        {
            return new INameFragment[] {
                new NameFragment(
                    text:       "Hand of the Mage",
                    webAddress: "http://www.d20pfsrd.com/magic-items/wondrous-items/wondrous-items/h-l/hand-of-the-mage/")
            };
        }


        public override School[] GetSchools()
        {
            return new School[] { School.Transmutation };
        }


        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            character.SpellLikeAbilities?.Registrar?.Register(0, MageHand.SorcererVersion, character.AbilityScores.Charisma);
        }
        #endregion
    }
}