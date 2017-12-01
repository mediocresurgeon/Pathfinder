using System;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.Skills;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    /// <summary>
    /// A magical heavy steel shield made of metal, but with a flat black color that seems to absorbs light.
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
        public override double GetWeight() => 15;


        public override byte? GetCasterLevel() => 17;


        public bool IsMasterwork => true;
        #endregion

        #region Methods
        public byte GetArmorCheckPenalty()
        {
            return 1;
        }


        public override byte GetHardness()
        {
            return 12;
        }


        public override ushort GetHitPoints()
        {
            return 30;
        }


        public override double GetMarketPrice()
        {
            return 50_170;
        }


        public override INameFragment[] GetName()
        {
            return new INameFragment[] {
                new NameFragment(text:       "Absorbing Shield",
                                 webAddress: "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-shields/absorbing-shield/")
            };
        }


        public override School[] GetSchools()
        {
            return new School[] { School.Transmutation };
        }


        public byte GetShieldBonus()
        {
            return 3;
        }


        /// <summary>
        /// Applies this shield's effects to a character.
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