namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    public interface ITowerShield : IItem, IShieldSlot
    {
        byte MaximumDexterityBonus { get; }
    }
}