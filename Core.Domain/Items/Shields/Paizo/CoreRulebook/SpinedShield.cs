using System;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.Skills;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    /// <summary>
    /// +1 Heavy Steel Shield which acts as a spiked shield.
    /// Can fire spines as ranged weapon 3/day.
    /// </summary>
    public sealed class SpinedShield : Item, IHeavyShield
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.Paizo.CoreRulebook.SpinedShield"/> class.
        /// </summary>
        public SpinedShield()
            : base()
        {
            // Intentionally blank.
        }
        #endregion

        #region Properties
        /// <summary>
        /// Spined Shield is masterwork.
        /// </summary>
        public bool IsMasterwork => true;
        #endregion

        #region Methods
        /// <summary>
        /// Spined Shield has an armor check penalty of 1.
        /// </summary>
        public byte GetArmorCheckPenalty() => 1;


        /// <summary>
        /// Spined Shield has a caster level of 6.
        /// </summary>
        public override byte? GetCasterLevel() => 6;


        /// <summary>
        /// Spined Shield has hardness 12.
        /// </summary>
        public override byte GetHardness() => 12;


        /// <summary>
        /// Spined Shield has 30 hit points.
        /// </summary>
        /// <returns>The hit points.</returns>
        public override ushort GetHitPoints() => 30;


        /// <summary>
        /// Spined Shield has a market price of 5580gp.
        /// </summary>
        /// <returns>The market price.</returns>
        public override double GetMarketPrice() => 5580;


        /// <summary>
        /// Returns the name of this shield.
        /// </summary>
        public override INameFragment[] GetName()
        {
            return new INameFragment[] {
                new NameFragment(
                    text:       "Spined Shield",
                    webAddress: "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-shields/spined-shield/"
            )};
        }


        /// <summary>
        /// Spined Shield has an Evocation aura.
        /// </summary>
        public override School[] GetSchools() => new School[] { School.Evocation };


        /// <summary>
        /// Spined Shield gives a +3 shield bonus to AC.
        /// </summary>
        public byte GetShieldBonus() => 3;


        /// <summary>
        /// Spined Shield weighs 15lbs.
        /// </summary>
        public override double GetWeight() => 15;


        /// <summary>
        /// Applies Spined Shield's effects to an ICharacter.
        /// </summary>
        /// <param name="character">The character to apply effects to.</param>
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