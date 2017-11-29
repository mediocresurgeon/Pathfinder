using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.EnergyResistances
{
    internal sealed class EnergyResistanceSection : IEnergyResistanceSection
    {
        #region Constructor
        internal EnergyResistanceSection()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        public IModifierTracker AcidResistance { get; } = new EnergyResistance();

        public IModifierTracker ColdResistance { get; } = new EnergyResistance();

        public IModifierTracker ElectricityResistance { get; } = new EnergyResistance();

        public IModifierTracker FireResistance { get; } = new EnergyResistance();

        public IModifierTracker SonicResistance { get; } = new EnergyResistance();
        #endregion
    }
}