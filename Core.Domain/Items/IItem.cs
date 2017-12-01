using Core.Domain.Spells;


namespace Core.Domain.Items
{
    public interface IItem
    {
        INameFragment[] GetName();

        double GetMarketPrice();

        double GetWeight();

        byte GetHardness();

        ushort GetHitPoints();

        byte? GetCasterLevel();

        MagicalAuraStrength GetAuraStrength();

        School[] GetSchools();

        sbyte? GetFortitude();

        sbyte? GetReflex();

        sbyte? GetWill();
    }
}