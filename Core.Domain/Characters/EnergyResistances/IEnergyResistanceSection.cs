using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.EnergyResistances
{
    public interface IEnergyResistanceSection
    {
        IModifierTracker AcidResistance { get; }

        IModifierTracker ColdResistance { get; }

        IModifierTracker ElectricityResistance { get; }

        IModifierTracker FireResistance { get; }

        IModifierTracker SonicResistance { get; }
    }
}