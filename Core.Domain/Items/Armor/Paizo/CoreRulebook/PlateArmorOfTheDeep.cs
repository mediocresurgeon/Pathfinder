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
    /// +1 Full Plate which does not penalize one's ability to swim.
    /// Also lets the user breathe underwater and converse with any water-breathing creature with a language.
    /// </summary>
    public sealed class PlateArmorOfTheDeep : Item, IFullPlate, IHeavyArmor
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.PlateArmorOfTheDeep"/> class.
        /// </summary>
        public PlateArmorOfTheDeep()
            : base()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        /// <summary>
        /// Plate Armor of the Deep is masterwork.
        /// </summary>
        public bool IsMasterwork => true;
        #endregion

        #region Methods
        /// <summary>
        /// Plate Armor of the Deep has a +10 armor bonus.
        /// </summary>
        public byte GetArmorBonus() => 10;


        /// <summary>
        /// Plate Armor of the Deep has a -5 armor check penalty.
        /// </summary>
        public byte GetArmorCheckPenalty() => 5;


        /// <summary>
        /// Plate Armor of the Deep has a caster level of 11.
        /// </summary>
        public override byte? GetCasterLevel() => 11;


        /// <summary>
        /// Plate Armor of the Deep has hardness 12.
        /// </summary>
        public override byte GetHardness() => Convert.ToByte(Steel.Hardness + 2);


        /// <summary>
        /// Plate Armor of the Deep has 55 hit points.
        /// </summary>
        public override ushort GetHitPoints() => 55;


        /// <summary>
        /// Plate Armor of the Deep has a market value of 24,650gp.
        /// </summary>
        public override double GetMarketPrice() => 24_650;


        /// <summary>
        /// Plate Armor of the Deep has a max dex bonus of +1.
        /// </summary>
        public byte GetMaximumDexterityBonus() => 1;


        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        public override INameFragment[] GetName() => new INameFragment[] {
            new NameFragment("Plate Armor of the Deep", "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-armor/plate-armor-of-the-deep/")
        };


        /// <summary>
        /// Plate Armor of the Deep has an abjuration aura.
        /// </summary>
        public override School[] GetSchools() => new School[] { School.Abjuration };


        /// <summary>
        /// Plate Armor of the Deep weighs 50 pounds.
        /// </summary>
        public override double GetWeight() => 50;


        /// <summary>
        /// Applies the effects of this armor to the character wearing it.
        /// </summary>
        /// <param name="character">The character who is wearing this armor.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument may not be null.");
            character.ArmorClass?.ArmorBonuses?.Add(this.GetArmorBonus);
            character.ArmorClass?.MaxKeyAbilityScore?.Add(this.GetMaximumDexterityBonus);
            foreach (var skill in character.Skills?.GetAllSkills().Where(s => s != character.Skills?.Swim) ?? Enumerable.Empty<ISkill>()) {
                skill.Penalties?.Add(() => skill.ArmorCheckPenaltyApplies ? this.GetArmorCheckPenalty() : (byte)0);
            }
            foreach (var movement in character.MovementModes?.GetAll().Where(m => character.MovementModes?.Swim != m) ?? Enumerable.Empty<IMovement>()) {
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