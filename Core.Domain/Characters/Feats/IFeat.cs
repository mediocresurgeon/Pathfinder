namespace Core.Domain.Characters.Feats
{
    public interface IFeat
    {
        void ApplyTo(ICharacter character);
    }
}