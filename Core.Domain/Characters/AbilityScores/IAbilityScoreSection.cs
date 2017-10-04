namespace Core.Domain.Characters.AbilityScores
{
    public interface IAbilityScoreSection
    {
        IAbilityScore Strength { get; }

        IAbilityScore Dexterity { get; }

        IAbilityScore Constitution { get; }

        IAbilityScore Intelligence { get; }

        IAbilityScore Wisdom { get; }

        IAbilityScore Charisma { get; }
    }
}