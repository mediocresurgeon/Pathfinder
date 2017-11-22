using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Items.Shields.Enchantments;
using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields
{
    internal sealed class ShieldEnchantmentAggregator : IShieldEnchantmentAggregator
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.ShieldEnchantmentAggregator"/> class.
        /// </summary>
        /// <param name="shield">The shield which "owns" the shield enchantments.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal ShieldEnchantmentAggregator(Shield shield)
        {
            this.Shield = shield ?? throw new ArgumentNullException(nameof(shield), "Argument cannot be null.");
        }
        #endregion

        #region Properties
        private Shield Shield { get; }

        private List<IShieldEnchantment> Enchantments { get; } = new List<IShieldEnchantment>();

        private ICharacter Character { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Enchants the shield with a shield enchantment.
        /// </summary>
        /// <param name="enchantment">The shield enchantment to apply to the shield.</param>
        /// <typeparam name="T">The type of shield enchantment.</typeparam>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when attempting to apply an enchantment twice,
        /// or when attempting to apply an enchantment before applying an enhancement bonus.
        /// </exception>
        public void EnchantWith<T>(T enchantment) where T : IShieldEnchantment
        {
            if (null == enchantment)
                throw new ArgumentNullException(nameof(enchantment), "Argument cannot be null.");
            if (!(enchantment is EnhancementBonus) && !this.Enchantments.Any(e => e is EnhancementBonus))
                throw new InvalidOperationException($"Non-enhancement bonus enchantments may not be applied until an enhancement bonus has been applied.");
            if (this.Enchantments.Any(e => e.GetType() == typeof(T)))
                throw new InvalidOperationException($"{ this.Shield } may not be enchanted with { typeof(T) } a second time.");
            enchantment.Enchant(this.Shield);
            this.Enchantments.Add(enchantment);

            // If the shield has already been equipped, apply the new enchantment immediately.
            if (null != this.Character)
                enchantment.ApplyTo(this.Character);
        }


        /// <summary>
        /// Gets the total market value from enchantments.
        /// </summary>
        /// <returns>The enchantment market value.</returns>
        public double GetEnchantmentMarketValue()
        {
            if (!this.Enchantments.Any())
                return 0;
            double runningTotal = this.Enchantments.Select(e => e.Cost)
                                                   .Sum();
            int totalEnhancementBonus = this.Enchantments.Select(e => (int)e.SpecialAbilityBonus)
                                                         .Sum();
            runningTotal += 1000 * Math.Pow(totalEnhancementBonus, 2); // Square the enahancement bonuses, then multiply by 1000
            return runningTotal;
        }


        /// <summary>
        /// Returns the enchantment schools.
        /// </summary>
        public School[] GetSchools()
        {
            //If there are no enchantments, return an empty array.
            if (!this.Enchantments.Any())
                return new School[0];

            //If there are enchantments other than an enhancement bonus, return their schools.
            var nonEnhancementBonusEnchantments = this.Enchantments.Where(e => !(e is EnhancementBonus));
            if (nonEnhancementBonusEnchantments.Any())
                return nonEnhancementBonusEnchantments.SelectMany(e => e.GetSchools())
                                                      .Distinct()
                                                      .ToArray();

            // Otherwise, there is only an enhancement bonus. Return its school.
            return this.Enchantments.First(e => e is EnhancementBonus).GetSchools();
        }


        public (INameFragment enhancement, INameFragment[] others) GetNames()
        {
            if (!this.Enchantments.Any())
                return (null, new INameFragment[0]);
            INameFragment enhancementName = this.Enchantments.First(e => e is EnhancementBonus)
                                                             .Name;
            INameFragment[] otherNames = this.Enchantments.Where(e => !(e is EnhancementBonus))
                                                          .Select(e => e.Name)
                                                          .OrderBy(name => name.Text)
                                                          .ToArray();
            return (enhancementName, otherNames);
        }


        /// <summary>
        /// Returns the caster level.
        /// </summary>
        public byte? GetCasterLevel()
        {
            if (!this.Enchantments.Any())
                return null;
            return this.Enchantments.Select(e => e.CasterLevel)
                                    .Max();
        }


        /// <summary>
        /// Applies all enchantments on this shield to the character.
        /// </summary>
        /// <param name="character">Character.</param>
        public void ApplyTo(ICharacter character)
        {
            this.Character = character ?? throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            foreach (var enchantment in this.Enchantments)
                enchantment.ApplyTo(this.Character);
        }
        #endregion
    }
}