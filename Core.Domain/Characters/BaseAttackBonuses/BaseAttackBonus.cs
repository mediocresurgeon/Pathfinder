using System;
using System.ComponentModel;


namespace Core.Domain.Characters.BaseAttackBonuses
{
    internal sealed class BaseAttackBonus : IBaseAttackBonus
    {
        #region Backing variables
        private readonly ICharacter _character;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.BaseAttackBonuses.BaseAttackBonus"/> class.
        /// </summary>
        /// <param name="character">The character to whom this base attack bonus belongs.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal BaseAttackBonus(ICharacter character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the rate at which the base attack bonus grows by character level.
        /// </summary>
        /// <value>The base attack bonus progression.</value>
        public BaseAttackProgression Rate { get; set; } = BaseAttackProgression.AsCleric;
        #endregion

        #region Methods
        /// <summary>
        /// Returns this character's base attack bonus.
        /// </summary>
        /// <returns>The total.</returns>
        public byte GetTotal()
        {
            return Convert.ToByte(
                Math.Floor(
                    _character.Level * this.GetBabMultiplier()
                ));
        }


        /// <summary>
        /// Finds the coefficient which determines a character's base attack bonus based on the character's level.
        /// </summary>
        /// <returns>The base attack bonus multiplier.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when this method references an unsupported BaseAttackBonusProgression enum.</exception>
        private float GetBabMultiplier()
        {
            switch(this.Rate)
            {
                case BaseAttackProgression.AsWizard:  return 0.50f;
                case BaseAttackProgression.AsCleric:  return 0.75f;
                case BaseAttackProgression.AsFighter: return 1.00f;
                default:
                    throw new InvalidEnumArgumentException($"Dev error!  Unable to convert { this.Rate } into a base attack bonus progression multiplier.");
            }
        }
		#endregion
	}
}