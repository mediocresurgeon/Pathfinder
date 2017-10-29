namespace Core.Domain.Characters
{
    public interface IApplicable
    {
        void ApplyTo(ICharacter character);
    }
}