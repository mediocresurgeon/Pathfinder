using System;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.Skills;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    /// <summary>
    /// +1 Heavy Steel Shield which can disintigrate once every two days.
    /// </summary>
    public sealed class AbsorbingShield : Item, IHeavyShield
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Shields.Paizo.CoreRulebook.AbsorbingShield"/> class.
        /// </summary>
        public AbsorbingShield()
            : base()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        /// <summary>
        /// Absorbing Shield is masterwork.
        /// </summary>
        public bool IsMasterwork => true;
        #endregion

        #region Methods
        /// <summary>
        /// Absorbing Shield weights 15lbs.
        /// </summary>
        /// <returns>The weight.</returns>
        public override double GetWeight() => 15;


        /// <summary>
        /// Absorbing Shield has caster level 17.
        /// </summary>
        /// <returns>The caster level.</returns>
        public override byte? GetCasterLevel() => 17;


        /// <summary>
        /// Absorbing Shield has an armor check penalty of 1.
        /// </summary>
        public byte GetArmorCheckPenalty()
        {
            return 1;
        }


        /// <summary>
        /// Absorbing Shield has hardness 12.
        /// </summary>
        public override byte GetHardness()
        {
            return 12;
        }


        /// <summary>
        /// Absorbing Shield has 30 hit points.
        /// </summary>
        public override ushort GetHitPoints()
        {
            return 30;
        }


        /// <summary>
        /// Absorbing Shield has a market price of 50,170gp.
        /// </summary>
        /// <returns>The market price.</returns>
        public override double GetMarketPrice()
        {
            return 50_170;
        }


        /// <summary>
        /// Returned the name of Absorbing Shield.
        /// </summary>
        public override INameFragment[] GetName()
        {
            return new INameFragment[] {
                new NameFragment(text:       "Absorbing Shield",
                                 webAddress: "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-shields/absorbing-shield/")
            };
        }


        /// <summary>
        /// Absorbing Shield has a Transmutation aura.
        /// </summary>
        public override School[] GetSchools()
        {
            return new School[] { School.Transmutation };
        }


        /// <summary>
        /// Absorbing Shield confers a +3 shield bonus to AC.
        /// </summary>
        public byte GetShieldBonus()
        {
            return 3;
        }


        /// <summary>
        /// Applies Absorbing Shield's effects to a character.
        /// </summary>
        /// <param name="character">The character who has equipped this shield.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument may not be null.");
            character.ArmorClass?.ShieldBonuses?.Add(() => this.GetShieldBonus());
            foreach (var skill in character.Skills?.GetAllSkills() ?? Enumerable.Empty<ISkill>())
            {
                skill.Penalties?.Add(() => skill.ArmorCheckPenaltyApplies ? this.GetArmorCheckPenalty() : (byte)0);
            }
        }
        #endregion
    }
}