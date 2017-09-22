using System;


namespace Core.Domain.Characters.SpellRegistries
{
	/// <summary>
	/// Contains data about an OnSpellLikeAbilityRegistered event.
	/// </summary>
	public sealed class SpellLikeAbilityRegisteredEventArgs : EventArgs
	{
		private readonly ISpellLikeAbility _spellLikeAbility;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegisteredEventArgs"/> class.
		/// </summary>
		/// <param name="spellLikeAbility">The spell which raised the event.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when spell argument is null.</exception>
		internal SpellLikeAbilityRegisteredEventArgs(ISpellLikeAbility spellLikeAbility)
		{
			_spellLikeAbility = spellLikeAbility ?? throw new ArgumentNullException();
		}

		/// <summary>
		/// The spell which raised the event.
		/// </summary>
		public ISpellLikeAbility SpellLikeAbility => _spellLikeAbility;
	}
}