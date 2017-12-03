using System;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Spells;


namespace Core.Domain.Items.Spellbooks.Paizo.CoreRulebook
{
    /// <summary>
    /// A tome which contains the magical writings necessary
    /// for some spellcasters (such as wizards) to prepare spells.
    /// </summary>
    public class Spellbook : Item, ISpellbook
    {
		// This class isn't sealed,
		// so we need to assume
		// that something will try to inherit from it.
		#region Protected members
		/// <summary>
		/// The collection of spells contained within this Spellbook.
		/// </summary>
		protected virtual ISpellCollection Spells { get; } = new SpellCollection();


        /// <summary>
        /// The value of this spellbook when it is empty.
        /// </summary>
        protected virtual double MarketPriceWhenEmpty { get; } = 15;


        /// <summary>
        /// Determines the cost adjustment to this spellbook for including a spell.
        /// </summary>
        /// <returns>The market price adjustment for the spell.</returns>
        /// <param name="level">The level of the spell.</param>
        protected virtual double GetMarketPriceOfSpell(byte level)
        {
            // This method could be static, but
            // we want subclasses to be able to be able to
            // write their own implementations of this function.
            switch (level)
            {
                case 0:  return 5;
                default: return Math.Pow(level, 2) * 10;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Spellbook"/> class.
        /// </summary>
        public Spellbook()
        {
            // Intentionally blank
        }
        #endregion

        #region Public properties
        /// <summary>
        /// The weight of this spellbook (in pounds).
        /// </summary>
        public override double GetWeight() => 3;


        /// <summary>
        /// The caster level of this spellbook.
        /// </summary>
        public override byte? GetCasterLevel() => null;
        #endregion

        #region Public methods
        /// <summary>
        /// Scribes a spell into this spellbook.
        /// </summary>
        /// <param name="spell">The spell to scribe.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the spell is null.</exception>
        public virtual void Add(ISpell spell)
        {
            if (null == spell)
                throw new ArgumentNullException($"{ nameof(spell) } argument cannot be null.");
            this.Spells.Add(spell);
        }


        /// <summary>
        /// Returns all spells in this spellbook.
        /// </summary>
        public virtual ISpell[] GetAllSpells() => this.Spells.GetAllSpells();


        /// <summary>
        /// Calculates the market price for this spellbook.
        /// </summary>
        /// <returns>The market price (in gold pieces).</returns>
        public override double GetMarketPrice()
        {
            double runningTotal = this.MarketPriceWhenEmpty;
            foreach(var spellsByLevel in this.Spells.GetAllSpells().GroupBy(s => s.Level))
            {
                double priceOfEachSpell = this.GetMarketPriceOfSpell(spellsByLevel.First().Level);
                runningTotal += priceOfEachSpell * spellsByLevel.Count();
            }
            return runningTotal;
        }


        /// <summary>
        /// Returns the name of this spellbook.
        /// </summary>
        public override INameFragment[] GetName()
        {
            return new INameFragment[]
            {
                new NameFragment(
                    text:       "Spellbook",
                    webAddress: "http://www.d20pfsrd.com/equipment/goods-and-services/books-paper-writing-supplies/#TOC-Spellbook"
                )
            };
        }


        /// <summary>
        /// Returns the hardness of this spellbook.
        /// </summary>
        public override byte GetHardness() => 2;


        /// <summary>
        /// Returns the hit points of this spellbook.
        /// </summary>
        public override ushort GetHitPoints() => 1;


        /// <summary>
        /// Returns the magical auras belonging to this spellbook.
        /// </summary>
        public override School[] GetSchools() => new School[0];


        /// <summary>
        /// Applies any effects of this spellbook to an ICharacter.
        /// </summary>
        /// <param name="character">The character to apply effects to.</param>
        public virtual void ApplyTo(ICharacter character)
        {
            // Intentionally blank.
        }
        #endregion
    }
}