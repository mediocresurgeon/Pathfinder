using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.SavingThrows
{
    internal sealed class SavingThrow : ISavingThrow
    {
        #region Backing variables
        private readonly ICharacter _character;
        private IAbilityScore _keyAbilityScore;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SavingThrows.SavingThrow"/> class.
        /// </summary>
        /// <param name="character">The character to whom this saving throw belongs.</param>
        /// <param name="keyAbilityScore">The ability score which is associated with this saving throw.</param>
        /// <exception cref="System.ArgumentNullException">Throw when an argument is null.</exception>
        internal SavingThrow(ICharacter character, IAbilityScore keyAbilityScore)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            _keyAbilityScore = keyAbilityScore ?? throw new ArgumentNullException(nameof(keyAbilityScore), "Argument cannot be null.");
        }
        #endregion

        #region Properties
        public IAbilityScore KeyAbilityScore
        {
            get { return _keyAbilityScore; }
            set { _keyAbilityScore = value ?? throw new ArgumentNullException(nameof(value), "Assignment cannot be null."); }
        }

        public bool IsGood { get; set; }

        public IModifierTracker LuckBonuses { get; } = new LuckBonusTracker();

        public IModifierTracker ResistanceBonuses { get; } = new ResistanceBonusTracker();

        public IModifierTracker UntypedBonuses { get; } = new UntypedBonusTracker();

        public IModifierTracker Penalties { get; } = new PenaltyTracker();
        #endregion

        #region Methods
        public byte GetLevelBonus()
        {
            if (this.IsGood)
            {
                int levelFraction = _character.Level / 2; // rounds towards zero
                return Convert.ToByte(2 + levelFraction);
            }
            else
            {
                return Convert.ToByte(_character.Level / 3); // division rounds towards zero
            }
        }

        public sbyte GetTotal()
        {
            int runningTotal = this.GetLevelBonus();
            runningTotal += this.KeyAbilityScore.GetModifier();
            runningTotal += this.LuckBonuses.GetTotal();
            runningTotal += this.ResistanceBonuses.GetTotal();
            runningTotal += this.UntypedBonuses.GetTotal();
            runningTotal -= this.Penalties.GetTotal();
            return Convert.ToSByte(runningTotal);
        }
        #endregion
    }
}