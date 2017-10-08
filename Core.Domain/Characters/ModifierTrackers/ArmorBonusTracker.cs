namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// An armor bonus applies to armor class
    /// and is granted by armor or by a spell
    /// or magical effect
    /// that mimics armor.
	/// </summary>
	internal sealed class ArmorBonusTracker : GreatestModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.ArmorBonusTracker"/> class.
        /// </summary>
		internal ArmorBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
	}
}