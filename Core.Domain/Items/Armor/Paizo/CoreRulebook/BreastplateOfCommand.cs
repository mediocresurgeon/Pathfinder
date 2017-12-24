using System;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.Movements;
using Core.Domain.Characters.Skills;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using Core.Domain.Spells;


namespace Core.Domain.Items.Armor.Paizo.CoreRulebook
{
    /// <summary>
    /// +2 Breastplate which gives a +2 competence bonus to all charisma checks.
    /// </summary>
    public sealed class BreastplateOfCommand : Item, IBreastplate, IMediumArmor
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.BreastplateOfCommand"/> class.
        /// </summary>
        public BreastplateOfCommand()
            : base()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        /// <summary>
        /// Breastplate of Command is masterwork.
        /// </summary>
        public bool IsMasterwork => true;
        #endregion

        #region Methods
        /// <summary>
        /// Breastplate of Command has a +8 armor bonus.
        /// </summary>
        public byte GetArmorBonus() => 8;


        /// <summary>
        /// Breastplate of Command has an armor check penalty of -3.
        /// </summary>
        public byte GetArmorCheckPenalty() => 3;


        /// <summary>
        /// Breastplate of Command has a caster level of 15.
        /// </summary>
        public override byte? GetCasterLevel() => 15;


        /// <summary>
        /// Breastplate of Command has hardness 14.
        /// </summary>
        public override byte GetHardness() => Convert.ToByte(Steel.Hardness + 4);


        /// <summary>
        /// Breastplate of Command has 50 hit points.
        /// </summary>
        public override ushort GetHitPoints() => 50;


        /// <summary>
        /// Breastplate of Command has a market price of 25400gp.
        /// </summary>
        public override double GetMarketPrice() => 25_400;


        /// <summary>
        /// Breastplate of Command has a maximum dexterity bonus of 3.
        /// </summary>
        public byte GetMaximumDexterityBonus() => 3;


        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        public override INameFragment[] GetName() => new INameFragment[] {
            new NameFragment("Breastplate of Command",
                             "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-armor/breastplate-of-command/")
        };


        /// <summary>
        /// Breastplate of Command has an enchantment aura.
        /// </summary>
        public override School[] GetSchools() => new School[] { School.Enchantment };


        /// <summary>
        /// Breastplate of Command weighs 30 pounds.
        /// </summary>
        public override double GetWeight() => 30;


        /// <summary>
        /// Applies the effects of Breastplate of Command to a character.
        /// </summary>
        /// <param name="character">The chracter wearing the armor.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument may not be null.");
            character.ArmorClass?.ArmorBonuses?.Add(this.GetArmorBonus);
            character.ArmorClass?.MaxKeyAbilityScore?.Add(this.GetMaximumDexterityBonus);
            // Inititive is an ability check.
            // If initiative is keyed to Charisma, add a +2 competence bonus.
            character.Initiative?.CompetenceBonuses?.Add(() => {
                if (null != character.AbilityScores?.Charisma
                    && null != character.Initiative?.KeyAbilityScore
                    && character.AbilityScores.Charisma == character.Initiative.KeyAbilityScore)
                {
                    return 2;
                }
                return 0;
            });
            foreach (var skill in character.Skills?.GetAllSkills() ?? Enumerable.Empty<ISkill>()) {
                skill.Penalties?.Add(() => skill.ArmorCheckPenaltyApplies ? this.GetArmorCheckPenalty() : (byte)0);
                // If the skill is keyed to Charisma, add a +2 competence bonus.
                skill.CompetenceBonuses?.Add(() => {
                    if (null != character.AbilityScores?.Charisma
                        && null != skill.KeyAbilityScore
                        && character.AbilityScores.Charisma == skill.KeyAbilityScore)
                    {
                        return 2;
                    }
                    return 0;
                });
            }
            foreach (var movement in character.MovementModes?.GetAll() ?? Enumerable.Empty<IMovement>()) {
                movement.Penalties.Add(() => {
                    if (!movement.BaseSpeed.HasValue)
                        return 0;
                    var finalSpeed = Math.Floor(.75 * movement.BaseSpeed.Value);
                    return Convert.ToByte(movement.BaseSpeed.Value - finalSpeed);
                });
            }
        }
        #endregion
    }
}