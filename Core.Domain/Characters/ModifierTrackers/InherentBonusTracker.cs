namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// An inherent bonus makes something inherently better at something.
	/// </summary>
	/// <remarks>
	/// This description can be improved.
	/// See http://www.d20pfsrd.com/basics-ability-scores/glossary/
	/// </remarks>
	internal sealed class InherentBonusTracker : NonStackingModifierTracker
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ModifierTrackers.InherentBonusTracker"/> class.
        /// </summary>
		internal InherentBonusTracker()
		{
			// This intentionally blank constructor
			// allows this class to be instantiated.
		}
	}
}