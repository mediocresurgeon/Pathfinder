using Core.Domain.Spells;


namespace Core.Domain.Items
{
    public interface IItem
    {
        INameFragment[] GetName();

        double GetMarketPrice();

        double Weight { get; }

        byte GetHardness();

        ushort GetHitPoints();

        byte? CasterLevel { get; }

        MagicalAuraStrength AuraStrength { get; }

        School[] GetSchools();

        sbyte? GetFortitude();

        sbyte? GetReflex();

        sbyte? GetWill();
    }
}