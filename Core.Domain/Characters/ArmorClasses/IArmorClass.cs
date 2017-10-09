using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.ArmorClasses
{
    public interface IArmorClass
    {
        IAbilityScore KeyAbilityScore { get; }

        IModifierTracker MaxKeyAbilityScore { get; }

        IModifierTracker ArmorBonuses { get; }

        IModifierTracker ShieldBonuses { get; }

        IModifierTracker CircumstanceBonuses { get; }

        IModifierTracker DodgeBonuses { get; }

        IModifierTracker DeflectionBonuses { get; }

        IModifierTracker InsightBonuses { get; }

        IModifierTracker LuckBonuses { get; }

        IModifierTracker MoraleBonuses { get; }

        IModifierTracker NaturalArmorBonuses { get; }

        IModifierTracker NaturalArmorEnhancementBonuses { get; }

        IModifierTracker ProfaneBonuses { get; }

        IModifierTracker SacredBonuses { get; }

        IModifierTracker UntypedBonuses { get; }

        IModifierTracker Penalties { get; }

        sbyte GetSizeModifier();

        sbyte GetTotal();
    }
}