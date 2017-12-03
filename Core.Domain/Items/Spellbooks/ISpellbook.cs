using Core.Domain.Characters.Spellcasting;


namespace Core.Domain.Items
{
    /// <summary>
    /// A book containing the magical writings necessary to cast spells.
    /// </summary>
    public interface ISpellbook : ISpellCollection, IItem, IStowable
    {
        // Intentionally blank.  This is used to create a composite interface.
        // (C# 7 does not let you declare variables which are compositions of types.)
    }
}