namespace Core.Domain.Items.Shields.Paizo.CoreRulebook
{
    /// <summary>
    /// A Tower Shield.
    /// </summary>
    public interface ITowerShield : IItem, IShieldSlot
    {
        /// <summary>
        /// Returns the maximum decterity bonus granted to an ICharacter's armor class while this shield is equipped.
        /// </summary>
        byte MaximumDexterityBonus { get; }
    }
}