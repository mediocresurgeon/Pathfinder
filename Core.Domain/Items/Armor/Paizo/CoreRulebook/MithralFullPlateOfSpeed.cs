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
    /// +1 Mithral Full Plate which lets the wearer use Haste for 10 rounds/day.
    /// </summary>
    public sealed class MithralFullPlateOfSpeed : Item, IFullPlate, IHeavyArmor
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.MithralFullPlateOfSpeed"/> class.
        /// </summary>
        public MithralFullPlateOfSpeed()
            : base()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        /// <summary>
        /// Mithral Full Plate of Speed is masterwork.
        /// </summary>
        public bool IsMasterwork => true;
        #endregion

        #region Methods
        /// <summary>
        /// Mithral Full Plate of Speed has a +10 armor bonus.
        /// </summary>
        public byte GetArmorBonus() => 10;


        /// <summary>
        /// Mithral Full Plate of Speed has an armor check penalt of -3.
        /// </summary>
        public byte GetArmorCheckPenalty() => 3;


        /// <summary>
        /// Mithral Full Plate of Speed has a caster level of 5.
        /// </summary>
        public override byte? GetCasterLevel() => 5;


        /// <summary>
        /// Mithral Full Plate of Speed hardness 17.
        /// </summary>
        public override byte GetHardness() => Convert.ToByte(Mithral.Hardness + 2);


        /// <summary>
        /// Mithral Full Plate of Speed has 55 hit points.
        /// </summary>
        public override ushort GetHitPoints() => 55;


        /// <summary>
        /// Mithral Full Plate of Speed has a market price of 26,500.
        /// </summary>
        public override double GetMarketPrice() => 26_500;


        /// <summary>
        /// Mithral Full Plate of Speed has a +3 maximum dexterity bonus.
        /// </summary>
        public byte GetMaximumDexterityBonus() => 3;


        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        public override INameFragment[] GetName() => new INameFragment[] {
            new NameFragment("Mithral Full Plate of Speed", "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-armor/mithral-full-plate-of-speed/")
        };


        /// <summary>
        /// Mithral Full Plate of Speed has a transmutation aura.
        /// </summary>
        public override School[] GetSchools() => new School[] { School.Transmutation };


        /// <summary>
        /// Mithral Full Plate of Speed weighs 25 pounds.
        /// </summary>
        public override double GetWeight() => 25;


        /// <summary>
        /// Applies the effects of this armor to the character wearing it.
        /// </summary>
        /// <param name="character">The character who is wearing this armor.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument may not be null.");
            character?.ArmorClass?.ArmorBonuses?.Add(this.GetArmorBonus);
            character?.ArmorClass?.MaxKeyAbilityScore?.Add(this.GetMaximumDexterityBonus);
            foreach (var skill in character?.Skills?.GetAllSkills() ?? Enumerable.Empty<ISkill>()) {
                skill.Penalties?.Add(() => skill.ArmorCheckPenaltyApplies ? this.GetArmorCheckPenalty() : (byte)0);
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