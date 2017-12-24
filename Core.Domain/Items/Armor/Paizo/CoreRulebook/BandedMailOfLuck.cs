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
    /// +3 Banded Mail which allows an attack roll made against the wearer to be rerolled (1/week).
    /// </summary>
    public sealed class BandedMailOfLuck : Item, IBandedMail
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.BandedMailOfLuck"/> class.
        /// </summary>
        public BandedMailOfLuck()
            : base()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        /// <summary>
        /// Banded Mail of Luck is masterwork.
        /// </summary>
        public bool IsMasterwork => true;
        #endregion

        #region Methods
        /// <summary>
        /// Banded Mail of Luck bestows a +10 armor bonus.
        /// </summary>
        public byte GetArmorBonus() => 10;


        /// <summary>
        /// Banded Mail of Luck has an armor check penalty of 5.
        /// </summary>
        public byte GetArmorCheckPenalty() => 5;


        /// <summary>
        /// Banded Mail of Luck weighs 35 pounds.
        /// </summary>
        public override double GetWeight() => 35;


        /// <summary>
        /// Banded Mail of Luck has a market price of 18900gp.
        /// </summary>
        public override double GetMarketPrice() => 18_900;


        /// <summary>
        /// Banded Mail of Luck has a caster level of 12.
        /// </summary>
        public override byte? GetCasterLevel() => 12;


        /// <summary>
        /// Banded Mail of Luck has a hardness of 16.
        /// </summary>
        public override byte GetHardness() => Convert.ToByte(Steel.Hardness + 6);


        /// <summary>
        /// Banded Mail of Luck has 65 hit points.
        /// </summary>
        public override ushort GetHitPoints() => 65;


        /// <summary>
        /// Banded Mail of Luck has a maximum dexterity bonus of 1.
        /// </summary>
        public byte GetMaximumDexterityBonus() => 1;


        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        public override INameFragment[] GetName() => new INameFragment[] {
            new NameFragment("Banded Mail of Luck",
                             "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-armor/banded-mail-of-luck/")
        };


        /// <summary>
        /// Banded Mail of Luck has an Enchantment aura.
        /// </summary>
        public override School[] GetSchools() => new School[] { School.Enchantment };


        /// <summary>
        /// Applies the effects of Banded Mail of Luck to a character.
        /// </summary>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument may not be null.");
            character.ArmorClass?.ArmorBonuses?.Add(this.GetArmorBonus);
            character.ArmorClass?.MaxKeyAbilityScore?.Add(this.GetMaximumDexterityBonus);
            foreach (var skill in character.Skills?.GetAllSkills() ?? Enumerable.Empty<ISkill>())
            {
                skill.Penalties?.Add(() => skill.ArmorCheckPenaltyApplies ? this.GetArmorCheckPenalty() : (byte)0);
            }
            foreach(var movement in character.MovementModes?.GetAll() ?? Enumerable.Empty<IMovement>())
            {
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