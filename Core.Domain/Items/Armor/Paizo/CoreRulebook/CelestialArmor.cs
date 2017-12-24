using System;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Core.Domain.Characters.Spellcasting;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using Core.Domain.Spells;


namespace Core.Domain.Items.Armor.Paizo.CoreRulebook
{
    /// <summary>
    /// This +3 chainmail is super-light and allows the wearer to fly once per day.
    /// </summary>
    public sealed class CelestialArmor : Item, IChainmail, ILightArmor // Normally, chainmail is medium armor.
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.CelestialArmor"/> class.
        /// </summary>
        public CelestialArmor()
            : base()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        /// <summary>
        /// Celestial Armor is masterwork.
        /// </summary>
        public bool IsMasterwork => true;
        #endregion

        #region Methods
        /// <summary>
        /// Celestial Armor gives a +9 armor bonus.
        /// </summary>
        public byte GetArmorBonus() => 9;


        /// <summary>
        /// Celestial Armor has a +8 maximum dexterity bonus.
        /// </summary>
        public byte GetMaximumDexterityBonus() => 8;


        /// <summary>
        /// Celestial Armor has a -2 armor check penalty.
        /// </summary>
        public byte GetArmorCheckPenalty() => 2;


        /// <summary>
        /// Celestial Armor has a market price of 22,400gp.
        /// </summary>
        public override double GetMarketPrice() => 22_400;


        /// <summary>
        /// Celestial Armor has a caster level of 5.
        /// </summary>
        public override byte? GetCasterLevel() => 5;


        /// <summary>
        /// Celestial Armor has hardness 16.
        /// </summary>
        public override byte GetHardness() => Convert.ToByte(Steel.Hardness + 6);


        /// <summary>
        /// Celestial Armor has 60 hit points.
        /// </summary>
        public override ushort GetHitPoints() => 60;


        /// <summary>
        /// Celestial Armor weighs 20 pounds.
        /// </summary>
        public override double GetWeight() => 20;


        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        public override INameFragment[] GetName() => new INameFragment[] {
            new NameFragment("Celestial Armor",
                             "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-armor/celestial-armor/")
        };


        /// <summary>
        /// Celestial Armor has a transmutation aura.
        /// </summary>
        public override School[] GetSchools() => new School[] { School.Transmutation };


        /// <summary>
        /// Applies the effects of this armor to a character.
        /// </summary>
        /// <param name="character">The character who is wearing this armor.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument may not be null.");
            character.ArmorClass?.ArmorBonuses?.Add(this.GetArmorBonus);
            character.ArmorClass?.MaxKeyAbilityScore?.Add(this.GetMaximumDexterityBonus);
            foreach (var skill in character.Skills?.GetAllSkills() ?? Enumerable.Empty<ISkill>()) {
                skill.Penalties?.Add(() => skill.ArmorCheckPenaltyApplies ? this.GetArmorCheckPenalty() : (byte)0);
            }
            // Users can cast Fly once per day
            var flySpell = Core.Domain.Spells.Paizo.CoreRulebook.Fly.WizardVersion;
            var slaAbilityScore = new AbilityScore() { BaseScore = Convert.ToByte(10 + flySpell.Level) };
            var sla = new SpellLikeAbility(usesPerDay:      1,
                                           spell:           flySpell,
                                           keyAbilityScore: slaAbilityScore,
                                           baseCasterLevel: () => this.GetCasterLevel().Value);
            character.SpellLikeAbilities?.Known?.Add(sla);
        }
        #endregion
    }
}