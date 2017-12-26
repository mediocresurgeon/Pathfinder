using System;
using System.Linq;
using Core.Domain.Characters;
using Core.Domain.Characters.Skills;
using Core.Domain.Items.Materials.Paizo.CoreRulebook;
using Core.Domain.Spells;


namespace Core.Domain.Items.Armor.Paizo.CoreRulebook
{
    /// <summary>
    /// Non-magical mithral chainmail which counts as light armor.
    /// </summary>
    public sealed class ElvenChain : Item, IChainmail, ILightArmor
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Armor.Paizo.CoreRulebook.ElvenChain"/> class.
        /// </summary>
        public ElvenChain()
            : base()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        /// <summary>
        /// Elven Chain is masterwork.
        /// </summary>
        public bool IsMasterwork => true;
        #endregion

        #region Methods
        /// <summary>
        /// Elven Chain has a +6 armor bonus,
        /// </summary>
        public byte GetArmorBonus() => 6;


        /// <summary>
        /// Elven Chain has an armor check penalty of -2.
        /// </summary>
        public byte GetArmorCheckPenalty() => 2;


        /// <summary>
        /// Elven Chain does not have a caster level.
        /// </summary>
        public override byte? GetCasterLevel() => null;


        /// <summary>
        /// Elven Chain has hardness 15.
        /// </summary>
        public override byte GetHardness() => Mithral.Hardness;


        /// <summary>
        /// Elven Chain has 30 hit points.
        /// </summary>
        public override ushort GetHitPoints() => 30;


        /// <summary>
        /// Elven Chain has a market price of 5150gp.
        /// </summary>
        public override double GetMarketPrice() => 5150;


        /// <summary>
        /// Elven Chain has a maximum dexterity bonus of +4.
        /// </summary>
        public byte GetMaximumDexterityBonus() => 4;


        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        /// <returns>The name.</returns>
        public override INameFragment[] GetName() => new INameFragment[] {
            new NameFragment("Elven Chain", "http://www.d20pfsrd.com/magic-items/magic-armor/specific-magic-armor/elven-chain/")
        };


        /// <summary>
        /// Elven Chain does not have an aura.
        /// </summary>
        public override School[] GetSchools() => new School[0];


        /// <summary>
        /// Elven Chain weighs 20 pounds.
        /// </summary>
        /// <returns>The weight.</returns>
        public override double GetWeight() => 20;


        /// <summary>
        /// Applies the effects of this armor to the character who is wearing it.
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
        }
        #endregion
    }
}