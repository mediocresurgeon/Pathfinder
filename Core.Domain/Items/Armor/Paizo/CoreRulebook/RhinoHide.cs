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
    /// +2 hide armor which increases the damage dealt when charging (including monted charges).
    /// Has a reduced armor check penalty.
    /// </summary>
    public sealed class RhinoHide : Item, IHideArmor, IMediumArmor
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.RhinoHide"/> class.
        /// </summary>
        public RhinoHide()
            : base()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        /// <summary>
        /// Rhino Hide is masterwork.
        /// </summary>
        public bool IsMasterwork => true;
        #endregion

        #region Methods
        /// <summary>
        /// Rhino Hide has a +6 armor bonus.
        /// </summary>
        public byte GetArmorBonus() => 6;


        /// <summary>
        /// Rhino Hide has an armor check penalty of -1.
        /// </summary>
        public byte GetArmorCheckPenalty() => 1;


        /// <summary>
        /// Rhino Hide has a caster level of 9.
        /// </summary>
        public override byte? GetCasterLevel() => 9;


        /// <summary>
        /// Rhino Hide has hardness 6.
        /// </summary>
        public override byte GetHardness() => Convert.ToByte(Leather.Hardness + 4);


        /// <summary>
        /// Rhino Hide has 40 hit points.
        /// </summary>
        public override ushort GetHitPoints() => 40;


        /// <summary>
        /// Rhino Hide has a market price of 5,165gp.
        /// </summary>
        public override double GetMarketPrice() => 5_165;


        /// <summary>
        /// Rhino Hide has a maximum dexterity bonus of +4.
        /// </summary>
        public byte GetMaximumDexterityBonus() => 4;


        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        public override INameFragment[] GetName() => new INameFragment[] {
            new NameFragment("Rhino Hide", "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-armor/rhino-hide/")
        };


        /// <summary>
        /// Rhino Hide has a transmutation aura.
        /// </summary>
        public override School[] GetSchools() => new School[] { School.Transmutation };


        /// <summary>
        /// Rhino Hide weighs 25 pounds.
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
            character.ArmorClass?.ArmorBonuses?.Add(this.GetArmorBonus);
            character.ArmorClass?.MaxKeyAbilityScore?.Add(this.GetMaximumDexterityBonus);
            foreach (var skill in character.Skills?.GetAllSkills() ?? Enumerable.Empty<ISkill>()) {
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