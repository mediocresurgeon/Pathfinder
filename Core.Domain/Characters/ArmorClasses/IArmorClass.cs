using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.ArmorClasses
{
    /// <summary>
    /// An ICharacter's measurement of defenses against physical attacks.
    /// </summary>
    public interface IArmorClass
    {
        /// <summary>
        /// Returns the ability score which modifies the armor class.
        /// (This is usually the ICharacter's Dexterity ability score.)
        /// </summary>
        IAbilityScore KeyAbilityScore { get; }

        /// <summary>
        /// Returns the maximum bonus which can be added from an ICharacter's ability score to armor class.
        /// (This is usually lowered by wearing armor or tower shields.)
        /// </summary>
        IModifierTracker MaxKeyAbilityScore { get; }

        /// <summary>
        /// Returns armor bonuses to armor class.
        /// </summary>
        IModifierTracker ArmorBonuses { get; }

        /// <summary>
        /// Returns shield bonuses to armor class.
        /// </summary>
        IModifierTracker ShieldBonuses { get; }

        /// <summary>
        /// Returns circumstance bonuses to armor class.
        /// </summary>
        IModifierTracker CircumstanceBonuses { get; }

        /// <summary>
        /// Returns dodge bonuses to armor class.
        /// </summary>
        IModifierTracker DodgeBonuses { get; }

        /// <summary>
        /// Returns deflection bonuses to armor class.
        /// </summary>
        IModifierTracker DeflectionBonuses { get; }

        /// <summary>
        /// Returns insight bonuses to armor class.
        /// </summary>
        IModifierTracker InsightBonuses { get; }

        /// <summary>
        /// Returns luck bonuses to armor class.
        /// </summary>
        IModifierTracker LuckBonuses { get; }

        /// <summary>
        /// Returns morale bonuses to armor class.
        /// </summary>
        IModifierTracker MoraleBonuses { get; }

        /// <summary>
        /// Returns natural armor bonuses to armor class.
        /// </summary>
        IModifierTracker NaturalArmorBonuses { get; }

        /// <summary>
        /// Returns enhancement bonuses to natural armor..
        /// </summary>
        IModifierTracker NaturalArmorEnhancementBonuses { get; }

        /// <summary>
        /// Returns profane bonuses to armor class.
        /// </summary>
        IModifierTracker ProfaneBonuses { get; }

        /// <summary>
        /// Returns sacred bonuses to armor class.
        /// </summary>
        IModifierTracker SacredBonuses { get; }

        /// <summary>
        /// Returns untyped bonuses to armor class.
        /// </summary>
        IModifierTracker UntypedBonuses { get; }

        /// <summary>
        /// Returns the penalties to armor class.
        /// Does not include adjustments from ICharacter size.
        /// </summary>
        /// <value>The penalties.</value>
        IModifierTracker Penalties { get; }

        /// <summary>
        /// Returns adjustments to armor class from ICharacter size.
        /// </summary>
        /// <returns>The size modifier.</returns>
        sbyte GetSizeModifier();

        /// <summary>
        /// Returns the total armor class rating.
        /// </summary>
        sbyte GetTotal();
    }
}