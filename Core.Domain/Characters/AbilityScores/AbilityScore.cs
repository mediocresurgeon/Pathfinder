using System;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.AbilityScores
{
	/// <summary>
	/// An AbilityScore scores represent a creature’s most basic attributes.
    /// The higher the total score, the more raw potential and talent the character possesses.
	/// </summary>
	internal sealed class AbilityScore : IAbilityScore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.AbilityScores.AbilityScore"/> class.
        /// </summary>
        internal AbilityScore()
        {
            // Intentionally blank
        }

        /// <summary>
        /// Gets or sets the base score.
        /// </summary>
        public byte? BaseScore { get; set; }

        /// <summary>
        /// Tracks enhancement bonuses.
        /// </summary>
        public IModifierTracker EnhancementBonuses { get; } = new EnhancementBonusTracker();


        /// <summary>
        /// Tracks inherent bonuses.
        /// </summary>
        public IModifierTracker InherentBonuses { get; } = new InherentBonusTracker();


        /// <summary>
        /// Tracks morale bonuses.
        /// </summary>
        public IModifierTracker MoraleBonuses { get; } = new MoraleBonusTracker();


        /// <summary>
        /// Tracks penalties.
        /// </summary>
        public IModifierTracker Penalties { get; } = new PenaltyTracker();


        /// <summary>
        /// Returns this AbilityScore's bonus.
        /// The bonus is always equal to the modifier, except when the modifier is negative (in this case, zero is returned).
        /// </summary>
        public byte GetBonus()
        {
            sbyte modifier = this.GetModifier();
            if (0 > modifier)
                return 0;
            return Convert.ToByte(modifier);
        }


        /// <summary>
        /// Returns this AbilityScore's modifier.
        /// If the BaseScore is null, returns zero.
        /// </summary>
        public sbyte GetModifier()
        {
            double? totalScore = this.GetTotal();
            if (!totalScore.HasValue)
                return 0;
            return Convert.ToSByte(Math.Floor((totalScore.Value - 10) / 2));
        }


        /// <summary>
        /// Returns this AbilityScore's total.
        /// </summary>
        public byte? GetTotal()
        {
            if (!this.BaseScore.HasValue)
                return null;
            int runningTotal = this.BaseScore.Value;
            runningTotal += this.EnhancementBonuses.GetTotal();
            runningTotal += this.InherentBonuses.GetTotal();
            runningTotal += this.MoraleBonuses.GetTotal();
            runningTotal -= this.Penalties.GetTotal();
            if (0 > runningTotal)
                return 0;
            return Convert.ToByte(runningTotal);
        }
    }
}