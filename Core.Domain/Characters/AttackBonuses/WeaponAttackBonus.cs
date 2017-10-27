using System;
using Core.Domain.Characters.AbilityScores;


namespace Core.Domain.Characters.AttackBonuses
{
    internal sealed class WeaponAttackBonus : UniversalAttackBonus, IWeaponAttackBonus
    {
        #region Backing variables
        private IAbilityScore _keyAbilityScore;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.AttackBonuses.SpecificAttackBonus"/> class.
        /// </summary>
        /// <param name="character">The character to whom this attack bonus belongs.</param>
        /// <param name="keyAbilityScore">The ability score associated with this attack bonus.</param>
        /// <param name="sharedAttackBonus">The generic attack bonus which contains universal bonuses which apply to this attack bonus.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal WeaponAttackBonus(ICharacter character, IAbilityScore keyAbilityScore, IUniversalAttackBonus sharedAttackBonus)
            : base()
        {
            this.Character = character ?? throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            this.KeyAbilityScore = keyAbilityScore ?? throw new ArgumentNullException(nameof(keyAbilityScore), "Argument cannot be null");
            this.SharedAttackBonus = sharedAttackBonus ?? throw new ArgumentNullException(nameof(sharedAttackBonus), "Argument cannot be null");
            this.EnhancementBonuses.Add(
                () => this.SharedAttackBonus.EnhancementBonuses?.GetTotal() ?? 0
            );
            this.UntypedBonuses.Add(
                () => this.SharedAttackBonus.UntypedBonuses?.GetTotal() ?? 0
            );
            this.Penalties.Add(
                () => this.SharedAttackBonus.Penalties?.GetTotal() ?? 0
            );
        }
        #endregion

        #region Properties
        private ICharacter Character { get; }

        private IUniversalAttackBonus SharedAttackBonus { get; }

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
        #endregion

        #region Methods
        public sbyte GetSizeModifier()
        {
            switch(this.Character.Size)
            {
                case SizeCategory.Small:  return  1;
                case SizeCategory.Medium: return  0;
                case SizeCategory.Large:  return -1;
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