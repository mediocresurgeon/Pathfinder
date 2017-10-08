namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// A natural armor bonus improves armor class resulting from a creature’s naturally tough hide.
	/// </summary>
	internal sealed class NaturalArmorBonusTracker : GreatestModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.NaturalArmorBonusTracker"/> class.
        /// </summary>
		internal NaturalArmorBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
	}
}