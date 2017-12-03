using System;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.Skills;
using Core.Domain.Spells;


namespace Core.Domain.Items.WonderousItems.Paizo.CoreRulebook
{
    /// <summary>
    /// A slotless item which grants a +1 luck bonus to skills,
    /// saving throws,
    /// and ability checks (such as initiative).
    /// </summary>
    public sealed class StoneOfGoodLuck : Item, IStowable
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.WonderousItems.Paizo.CoreRulebook.StoneOfGoodLuck"/> class.
        /// </summary>
        public StoneOfGoodLuck()
            : base()
        {
            // Intentionally blank
        }
        #endregion

        #region Methods
        /// <summary>
        /// Stone of Good Luck has negligible weight.
        /// </summary>
        public override double GetWeight() => 0;


        /// <summary>
        /// Stone of Good Luck has caster level 5.
        /// </summary>
        public override byte? GetCasterLevel() => 5;


        /// <summary>
        /// Stone of Good Luck has hardness 8.
        /// </summary>
        public override byte GetHardness() => 8;


        /// <summary>
        /// Stone of Good Luck has 15 hit points.
        /// </summary>
        public override ushort GetHitPoints() => 15;


        /// <summary>
        /// Stone of Good Luck has a market price of 20,000gp.
        /// </summary>
        public override double GetMarketPrice() => 20_000;


        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        public override INameFragment[] GetName()
        {
            return new INameFragment[]
            {
                new NameFragment(
                    text:       "Stone of Good Luck",
                    webAddress: "http://www.d20pfsrd.com/magic-items/wondrous-items/wondrous-items/r-z/stone-of-good-luck-luckstone/"
                )
            };
        }


        /// <summary>
        /// Stone of Good Luck has an Evocation aura.
        /// </summary>
        public override School[] GetSchools()
        {
            return new School[] { School.Evocation };
        }


        /// <summary>
        /// Applies the effects of this item to the character.
        /// </summary>
        /// <param name="character">The character who is stowing this item.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            character.Initiative?.LuckBonuses?.Add(() => 1); // Initiative is an ability check
            #region Saving throws
            character.SavingThrows?.Fortitude?.LuckBonuses?.Add(() => 1);
            character.SavingThrows?.Reflex?.LuckBonuses?.Add(() => 1);
            character.SavingThrows?.Will?.LuckBonuses?.Add(() => 1);
            #endregion
            #region Skills
            foreach(var skill in character.Skills?.GetAllSkills() ?? Enumerable.Empty<ISkill>())
            {
                skill.LuckBonuses?.Add(() => 1);
            }
            #endregion
        }
        #endregion
    }
}