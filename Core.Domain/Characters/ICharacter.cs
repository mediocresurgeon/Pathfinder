using Core.Domain.Characters.AbilityScores;


namespace Core.Domain.Characters
{
    public interface ICharacter
    {
        IAbilityScore Strength { get; }

        IAbilityScore Dexterity { get; }

        IAbilityScore Constitution { get; }

        IAbilityScore Intelligence { get; }

        IAbilityScore Wisdom { get; }

        IAbilityScore Charisma { get; }
    }
}