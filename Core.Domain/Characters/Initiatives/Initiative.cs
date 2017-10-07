using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Initiatives
{
    internal sealed class Initiative : IInitiative
    {
        #region Backing variables
        private IAbilityScore _keyAbilityScore;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Initiatives.Initiative"/> class.
        /// </summary>
        /// <param name="keyAbilityScore">The ability score associated with initiative.</param>
        internal Initiative(IAbilityScore keyAbilityScore)
        {
            _keyAbilityScore = keyAbilityScore ?? throw new ArgumentNullException(nameof(keyAbilityScore), "Argument cannot be null.");
        }
        #endregion

        #region Properties
        public IAbilityScore KeyAbilityScore
        {
            get => _keyAbilityScore;
            set => _keyAbilityScore = value ?? throw new ArgumentNullException(nameof(value), "Assignment cannot be null.");
        }

        public IModifierTracker UntypedBonuses { get; } = new UntypedBonusTracker();

        public IModifierTracker Penalties { get; } = new PenaltyTracker();
        #endregion

        #region Methods
        public sbyte GetTotal()
        {
            int runningTotal = this.KeyAbilityScore.GetModifier();
            runningTotal += this.UntypedBonuses.GetTotal();
            runningTotal -= this.Penalties.GetTotal();
            return Convert.ToSByte(runningTotal);
        }
        #endregion
    }
}