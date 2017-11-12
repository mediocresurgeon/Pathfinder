using System;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Items.Shields
{
    public sealed class ShieldHitPointAggregator
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Shields.ShieldHitPointAggregator"/> class.
        /// </summary>
        /// <param name="inchesOfThickness">The thickness of the shield, for the purposes of calculating hit points.</param>
        /// <param name="hitPointsPerInchOfThickness">The number of hit points per inch of thickness, as determine by the shield' material.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when inchesOfThickness is less than zero.</exception>
        internal ShieldHitPointAggregator(float inchesOfThickness, byte hitPointsPerInchOfThickness)
        {
            if (0 > inchesOfThickness)
                throw new ArgumentOutOfRangeException(nameof(inchesOfThickness), inchesOfThickness, "Physical objects can never have a negative thickness.");
            this.InchesOfThickness = inchesOfThickness;
            this.HitPointsPerInchOfThickness = hitPointsPerInchOfThickness;
        }
        #endregion

        #region Properties
        internal float InchesOfThickness { get; }

        internal byte HitPointsPerInchOfThickness { get; }

        internal IModifierTracker EnhancementBonuses { get; } = new EnhancementBonusTracker();
        #endregion

        #region Methods
        internal ushort GetTotal()
        {
            ushort runningTotal = Convert.ToUInt16(Math.Floor(this.InchesOfThickness * this.HitPointsPerInchOfThickness));
            runningTotal = 1 > runningTotal ? (ushort)1 : runningTotal; // Items always have at least 1 hit point
            runningTotal += this.EnhancementBonuses.GetTotal();
            return runningTotal;
        }
        #endregion
    }
}
