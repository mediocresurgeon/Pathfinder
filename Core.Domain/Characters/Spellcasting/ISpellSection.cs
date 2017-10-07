using Core.Domain.Items;


namespace Core.Domain.Characters.Spellcasting
{
    public interface ISpellSection
    {
        ICastableSpellCollection Known { get; }

        ICastableSpellCollection Prepared { get; }

		ISpellRegistrar Registrar { get; }

		ISpellbook Spellbook { get; set; }
    }
}