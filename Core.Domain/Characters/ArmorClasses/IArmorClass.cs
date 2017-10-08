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

        IModifierTracker SizeBonuses { get; }

        IModifierTracker DodgeBonuses { get; }

        IModifierTracker DeflectionBonuses { get; }

        IModifierTracker NaturalArmorBonuses { get; }

        IModifierTracker NaturalArmorEnhancementBonuses { get; }

        IModifierTracker UntypedBonuses { get; }

        IModifierTracker Penalties { get; }

        sbyte GetTotal();
    }
}