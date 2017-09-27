using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Skills
{
    internal class Skill : ISkill
    {
        // This class is intended to be inherited.
        #region Backing variables
        private readonly ICharacter _character;
        private readonly Func<byte> _getTrainedBonus;
        private readonly string _name;
        private IAbilityScore _keyAbilityScore;
        private byte _ranks;
		#endregion


		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Skills.Skill"/> class.
		/// </summary>
		/// <param name="character">The character to whom this skill belongs.</param>
		/// <param name="keyAbilityScore">The ability score associated with this skill.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
		internal Skill(ICharacter character, IAbilityScore keyAbilityScore, string name)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            _keyAbilityScore = keyAbilityScore ?? throw new ArgumentNullException(nameof(keyAbilityScore), "Argument cannot be null.");
            _name = name ?? throw new ArgumentNullException(nameof(name), "Argument cannot be null.");

			// Gives a +3 untyped bonus if this is a class skill and is trained.
			_getTrainedBonus = () =>  // Couldn't be assigned directly to the property because of "this" references
            {
				if (this.IsClassSkill && this.Ranks > 0)
					return 3;
				return 0;
			};
            this.UntypedBonuses.Add(GetTrainedBonus);
        }
		#endregion


		#region Properties
		/// <summary>
		/// Provides a way for inheriting classes to override the logic which determines
		/// the magnitude of a trained class skill bonus
		/// and the conditions under which it is granted.
        /// This function will automatically be aggregated with untyped bonuses.
		/// </summary>
		protected virtual Func<byte> GetTrainedBonus => _getTrainedBonus;


        /// <summary>
        /// Provides a way for inheriting classes to access the ICharacter tied to this skill.
        /// </summary>
        /// <value>The character.</value>
        protected virtual ICharacter Character => _character;


        /// <summary>
        /// Gets or sets the ability score which is associated with this skill.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Thrown when assigning a null value.</exception>
        public virtual IAbilityScore KeyAbilityScore
        {
            get => _keyAbilityScore;
            set => _keyAbilityScore = value ?? throw new ArgumentNullException(nameof(value), "Cannot be null.");
        }


        /// <summary>
        /// Flags whether or not this skill can be used untrained.
        /// </summary>
        public virtual bool CanBeUsedUntrained { get; set; } = true;


        /// <summary>
        /// Flags this skill as a class skill.
        /// </summary>
        public virtual bool IsClassSkill { get; set; } = false;


        /// <summary>
        /// Gets or sets this skill's ranks.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the ranks are greater than the character's level.</exception>
        public virtual byte Ranks
        {
            get => _ranks;
            set
            {
                if (value > this.Character.Level)
                    throw new ArgumentOutOfRangeException(nameof(value), $"Ranks cannot exceed the character's level.");
                _ranks = value;
            }
        }


		/// <summary>
		/// Gets the racial bonuses associated with this skill.
		/// </summary>
		public virtual IModifierTracker RacialBonuses { get; } = new RacialBonusTracker();


		/// <summary>
		/// Gets the size bonuses associated with this skill.
		/// </summary>
		public virtual IModifierTracker SizeBonuses { get; } = new SizeBonusTracker();


		/// <summary>
		/// Gets the untyped bonuses associated with this skill.
		/// </summary>
		public virtual IModifierTracker UntypedBonuses { get; } = new UntypedBonusTracker();


		/// <summary>
		/// Gets the penalties associated with this skill.
		/// </summary>
		/// <value>The penalties tracker.</value>
		public virtual IModifierTracker Penalties { get; } = new PenaltyTracker();
        #endregion


		/// <summary>
		/// Gets the total modifier for this skill.
		/// </summary>
		public virtual sbyte? GetTotal()
        {
            if (!this.CanBeUsedUntrained && 1 > this.Ranks)
                return null;
            int runningTotal = this.Ranks;
            runningTotal += this.KeyAbilityScore.GetModifier();
            runningTotal += this.RacialBonuses.GetTotal();
            runningTotal += this.SizeBonuses.GetTotal();
            runningTotal += this.UntypedBonuses.GetTotal();
            runningTotal -= this.Penalties.GetTotal();
            return Convert.ToSByte(runningTotal);
        }


        public override string ToString()
        {
            return _name;
        }
    }
}