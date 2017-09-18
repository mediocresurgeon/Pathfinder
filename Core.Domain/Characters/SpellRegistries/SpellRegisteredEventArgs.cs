using System;


namespace Core.Domain.Characters.SpellRegistries
{
	/// <summary>
	/// Contains data about an OnSpellRegistered event.
	/// </summary>
	internal sealed class SpellRegisteredEventArgs : EventArgs
	{
		private readonly RegisteredSpell _spell;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegisteredEventArgs"/> class.
		/// </summary>
		/// <param name="spell">The spell which raised the event.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when spell argument is null.</exception>
		internal SpellRegisteredEventArgs(RegisteredSpell spell)
		{
			_spell = spell ?? throw new ArgumentNullException();
		}

		/// <summary>
		/// The spell which raised the event.
		/// </summary>
		public RegisteredSpell Spell => _spell;
	}
}