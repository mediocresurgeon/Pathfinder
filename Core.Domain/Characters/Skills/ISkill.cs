﻿using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Skills
{
    public interface ISkill
    {
        IAbilityScore KeyAbilityScore { get; set; }

        bool CanBeUsedUntrained { get; set; }

        bool IsClassSkill { get; set; }

        byte Ranks { get; set; }

        IModifierTracker RacialBonuses { get; }

        IModifierTracker SizeBonuses { get; }

        IModifierTracker UntypedBonuses { get; }

        IModifierTracker Penalties { get; }

        sbyte? GetTotal();
    }
}