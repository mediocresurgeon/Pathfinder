using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Items.Enchantments;
using Core.Domain.Items.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;


namespace Core.Domain.Items.Aggregators
{
    internal abstract class EnchantmentAggregator<E, I>: IEnchantmentAggregator<E, I> where E : IEnchantment
                                                                                      where I : IItem
    {
        #region Backing variables
        private readonly I _item;
        private readonly Action<E, I> _applyEnchantmentToItem;
        private readonly double _enhancementBonusCostCoefficient;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Aggregators.EnchantmentAggregator`1"/> class.
        /// </summary>
        /// <param name="itemToEnchant">The item which is to be enchanted.</param>
        /// <param name="applyEnchantmentToItem">A function which applies the effects of an enchantment to an item.</param>
        /// <param name="enhancementBonusCostCoefficient">Enhancement bonus cost coefficient.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when enhancementBonusCostCoefficient is less than zero.</exception>
        protected EnchantmentAggregator(I itemToEnchant, Action<E, I> applyEnchantmentToItem, double enhancementBonusCostCoefficient)
        {
            if (null == itemToEnchant)
                throw new ArgumentNullException(nameof(itemToEnchant), "Argument may not be null.");
            _item = itemToEnchant;
            _applyEnchantmentToItem = applyEnchantmentToItem ?? throw new ArgumentNullException(nameof(applyEnchantmentToItem), "Argument may not be null.");
            if (0 > enhancementBonusCostCoefficient)
                throw new ArgumentOutOfRangeException(nameof(enhancementBonusCostCoefficient), enhancementBonusCostCoefficient, "Coefficient may not be less than zero.");
            _enhancementBonusCostCoefficient = enhancementBonusCostCoefficient;
        }
        #endregion

        #region Properties
        /// <summary>
        /// The item to be enchanted.
        /// </summary>
        protected I Item => _item;


        /// <summary>
        /// An action which applies the effects of an enchantment to the item it is enchanting.
        /// </summary>
        protected virtual Action<E, I> ApplyEnchantmentToItem => _applyEnchantmentToItem;


        /// <summary>
        /// The cost coefficient to use when determining the cost of special abilities bonuses.
        /// </summary>
        protected virtual double EnhancementBonusCostCoefficient => _enhancementBonusCostCoefficient;


        /// <summary>
        /// The collection of enchantments tracked by this object.
        /// </summary>
        protected virtual List<E> Enchantments { get; } = new List<E>();


        /// <summary>
        /// May be null.
        /// Set by calling EnchantmentAggregator&lt;T&gt;.ApplyTo(ICharacter).
        /// </summary>
        /// <value>The character.</value>
        protected virtual ICharacter Character { get; set; }
        #endregion

        #region Virtual methods
        /// <summary>
        /// Returns a copy of the collection of enchantments tracked by this object.
        /// </summary>
        public virtual E[] GetEnchantments()
        {
            return this.Enchantments.ToArray();
        }


        /// <summary>
        /// Returns the enchantment schools.
        /// </summary>
        public virtual School[] GetSchools()
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


        /// <summary>
        /// Returns the total market price of all enchantments.
        /// </summary>
        public virtual double GetMarketPrice()
        {
            if (!this.Enchantments.Any())
                return 0;
            double runningTotal = this.Enchantments.Select(e => e.Cost)
                                                   .Sum();
            int totalEnhancementBonus = this.Enchantments.Select(e => (int)e.SpecialAbilityBonus)
                                                         .Sum();
            runningTotal += this.EnhancementBonusCostCoefficient * Math.Pow(totalEnhancementBonus, 2); // Square the enahancement bonuses, then multiply by cost coefficient
            return runningTotal;
        }


        /// <summary>
        /// Returns the names of the enchantments.
        /// </summary>
        public virtual (INameFragment enhancement, INameFragment[] others) GetNames()
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
        /// Returns the caster level of the enchantments.
        /// </summary>
        public virtual byte? GetCasterLevel()
        {
            if (!this.Enchantments.Any())
                return null;
            return this.Enchantments.Select(e => e.CasterLevel)
                                    .Max();
        }


        /// <summary>
        /// Applies the effects of an enchantment to an item.
        /// </summary>
        public virtual void EnchantWith(E enchantment)
        {
            if (null == enchantment)
                throw new ArgumentNullException(nameof(enchantment), "Argument cannot be null.");
            if (!(enchantment is EnhancementBonus) && !this.Enchantments.Any(e => e is EnhancementBonus))
                throw new InvalidOperationException($"Non-enhancement bonus enchantments may not be applied until an enhancement bonus has been applied.");
            if (this.Enchantments.Any(e => e.GetType() == enchantment.GetType()))
                throw new InvalidOperationException($"Duplicate enchantments of type { enchantment.GetType() } are not permitted.");
            this.ApplyEnchantmentToItem(enchantment, this.Item);
            this.Enchantments.Add(enchantment);

            // If the shield has already been equipped, apply the new enchantment immediately.
            if (null != this.Character)
                enchantment.ApplyTo(this.Character);
        }


        /// <summary>
        /// Applies the effects of all of the enchantments to a character.
        /// </summary>
        /// <param name="character">The character to apply effects to.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public virtual void ApplyTo(ICharacter character)
        {
            this.Character = character ?? throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            foreach (var enchantment in this.Enchantments)
                enchantment.ApplyTo(this.Character);
        }
        #endregion
    }
}