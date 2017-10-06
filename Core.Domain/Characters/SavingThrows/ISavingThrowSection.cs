namespace Core.Domain.Characters.SavingThrows
{
    public interface ISavingThrowSection
    {
        ISavingThrow Fortitude { get; }

        ISavingThrow Reflex { get; }

        ISavingThrow Will { get; }
    }
}