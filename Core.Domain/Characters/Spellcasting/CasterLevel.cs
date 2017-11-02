using System;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.Spellcasting
{
    internal sealed class CasterLevel : ICasterLevel
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Spellcasting.CasterLevel"/> class.
        /// </summary>
        /// <param name="baseCasterLevel">The base caster level.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal CasterLevel(Func<byte> baseCasterLevel)
        {
            if (null == baseCasterLevel)
                throw new ArgumentNullException(nameof(baseCasterLevel));
            this.UntypedBonuses.Add(baseCasterLevel);
        }
        #endregion

        #region Properties
        public IModifierTracker UntypedBonuses { get; } = new UntypedBonusTracker();
        #endregion

        #region Methods
        public byte GetTotal()
        {
            return this.UntypedBonuses.GetTotal();
        }
        #endregion
    }
}