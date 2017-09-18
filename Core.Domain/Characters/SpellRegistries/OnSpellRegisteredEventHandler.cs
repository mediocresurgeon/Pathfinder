using Core.Domain.Characters.SpellRegistries;

/// <summary>
/// The signature of a OnSpellRegistered event handler.
/// </summary>
internal delegate void OnSpellRegisteredEventHandler(object sender, SpellRegisteredEventArgs e);