using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.EnergyResistances
{
    /// <summary>
    /// The ICharacter's energy resistances.
    /// </summary>
    public interface IEnergyResistanceSection
    {
        /// <summary>
        /// The ICharacter's resistance to acid damage.
        /// </summary>
        IModifierTracker AcidResistance { get; }

        /// <summary>
        /// The ICharacter's resistance to cold damage.
        /// </summary>
        IModifierTracker ColdResistance { get; }

        /// <summary>
        /// The ICharacter's resistance to electricity damage.
        /// </summary>
        IModifierTracker ElectricityResistance { get; }

        /// <summary>
        /// The ICharacter's resistance to fire damage.
        /// </summary>
        IModifierTracker FireResistance { get; }

        /// <summary>
        /// The ICharacter's resistance to sonic damage.
        /// </summary>
        IModifierTracker SonicResistance { get; }
    }
}