using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.CombatManeuverBonuses
{
    internal sealed class CombatManeuverBonus : ICombatManeuverBonus
    {
        #region Backing variables
        private IAbilityScore _keyAbilityScore;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.CombatManeuverBonuses.CombatManeuverBonus"/> class.
        /// </summary>
        /// <param name="character">The character to whom this Combat Maneuver Bonus belongs.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when ICharacter has a null Strength ability score.</exception>
        internal CombatManeuverBonus(ICharacter character)
        {
            this.Character = character ?? throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            this.KeyAbilityScore = character.AbilityScores?.Strength ?? throw new ArgumentException($"Argument must have a non-null { nameof(character.AbilityScores.Strength) } object.");
            this.EnhancementBonuses.Add(
                () => this.Character.AttackBonuses?.GenericMeleeAttackBonus?.EnhancementBonuses?.GetTotal() ?? 0
            );
            this.UntypedBonuses.Add(
                () => this.Character.AttackBonuses?.GenericMeleeAttackBonus?.UntypedBonuses?.GetTotal() ?? 0
            );
            this.Penalties.Add(
                () => this.Character.AttackBonuses?.GenericMeleeAttackBonus?.Penalties?.GetTotal() ?? 0
            );
        }
        #endregion

        #region Properties
        private ICharacter Character { get; }

        /// <summary>
        /// Gets or sets the key ability score.
        /// </summary>
        /// <value>The key ability score.</value>
        /// <exception cref="System.ArgumentNullException">Thrown when assignment is null.</exception>
        public IAbilityScore KeyAbilityScore
        {
            get => _keyAbilityScore;
            set
            {
                _keyAbilityScore = value ?? throw new ArgumentNullException(nameof(value), "Assignment cannot be null.");
            }
        }

        public IModifierTracker EnhancementBonuses { get; } = new EnhancementBonusTracker();

        public IModifierTracker UntypedBonuses { get; } = new UntypedBonusTracker();

        public IModifierTracker Penalties { get; } = new PenaltyTracker();
        #endregion

        #region Methods
        public sbyte GetSizeModifier()
        {
            switch (this.Character.Size)
            {
                case SizeCategory.Small:  return -1;
                case SizeCategory.Medium: return  0;
                case SizeCategory.Large:  return  1;
                default:
                    throw new NotImplementedException($"Unable to determine a size modifier for SizeCategory { this.Character.Size }.");
            }
        }

        public sbyte GetTotal()
        {
            int runningTotal = this.Character.AttackBonuses.BaseAttackBonus.GetTotal();
            runningTotal += this.KeyAbilityScore.GetModifier();
            runningTotal += this.GetSizeModifier();
            runningTotal += this.EnhancementBonuses.GetTotal();
            runningTotal += this.UntypedBonuses.GetTotal();
            runningTotal -= this.Penalties.GetTotal();
            return Convert.ToSByte(runningTotal);
        }
        #endregion
    }
}