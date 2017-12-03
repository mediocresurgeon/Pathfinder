using System;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    /// <summary>
    /// A +3 heavy wooden shield which lets the user fly once per day, as the spell.
    /// </summary>
    public sealed class WingedShield : Item, IHeavyShield
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.Paizo.CoreRulebook.WingedShield"/> class.
        /// </summary>
        public WingedShield()
            : base()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        /// <summary>
        /// Winged Shield is masterwork.
        /// </summary>
        public bool IsMasterwork => true;
        #endregion

        #region Methods
        /// <summary>
        /// Winged Shield has an armor check penalty of -1.
        /// </summary>
        public byte GetArmorCheckPenalty() => 1;


        /// <summary>
        /// Winged Shield has caster level 5.
        /// </summary>
        /// <remarks>Normally, a +3 shield requires caster level 9 at minimum.</remarks>
        public override byte? GetCasterLevel() => 5;


        /// <summary>
        /// Winged Shield has hardness 11.
        /// </summary>
        public override byte GetHardness() => 11;


        /// <summary>
        /// Winged Shield has 45 hit points.
        /// </summary>
        public override ushort GetHitPoints() => 45;


        /// <summary>
        /// Winged Shield has a market price of 17,257gp.
        /// </summary>
        public override double GetMarketPrice() => 17_257;


        /// <summary>
        /// Returns the name of this shield.
        /// </summary>
        public override INameFragment[] GetName()
        {
            return new INameFragment[] {
                new NameFragment(
                    text:       "Winged Shield",
                    webAddress: "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-shields/winged-shield/"
            )};
        }


        /// <summary>
        /// Winged Shield has a Transmutation aura.
        /// </summary>
        public override School[] GetSchools() => new School[] { School.Transmutation };


        /// <summary>
        /// Winged Shield adds a +5 shield bonus to a character's AC.
        /// </summary>
        public byte GetShieldBonus() => 5;


        /// <summary>
        /// Winged Shield weighs 10lbs.
        /// </summary>
        public override double GetWeight() => 10;


        /// <summary>
        /// Applies Winged Shield's effects to an ICharacter.
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
            // Do not register the spell-like ability--we don't want feats applying to it.
            var flySpell = Spells.Paizo.CoreRulebook.Fly.WizardVersion;
            IAbilityScore shieldCastingStat = new AbilityScore { BaseScore = Convert.ToByte(10 + flySpell.Level) };
            ISpellLikeAbility flySpellLikeAbility = new SpellLikeAbility(usesPerDay:      1,
                                                                         spell:           flySpell,
                                                                         keyAbilityScore: shieldCastingStat,
                                                                         baseCasterLevel: () => this.GetCasterLevel().Value);
            character?.SpellLikeAbilities?.Known?.Add(flySpellLikeAbility);
        }
        #endregion
    }
}