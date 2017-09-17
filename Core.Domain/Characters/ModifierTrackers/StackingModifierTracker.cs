using System;
using System.Collections.Generic;
using System.Linq;


namespace Core.Domain.Characters.ModifierTrackers
{
    internal abstract class StackingModifierTracker : IModifierTracker
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.BonusTrackers.StackingModifierTracker"/> class.
        /// </summary>
        protected StackingModifierTracker()
        {
            // Intentionally blank
        }


        /// <summary>
        /// A mutable collection of modifier data which is used in calculations by this class.
        /// </summary>
        /// <value>The modifiers.</value>
        protected abstract IList<byte> Modifiers { get; }


        /// <summary>
        /// Adds a modifier.
        /// </summary>
        /// <param name="amount">The magnitude of the modifier.</param>
        public virtual void Add(byte amount)
        {
            Modifiers.Add(amount);
        }


        /// <summary>
        /// Returns the total modifier.
        /// </summary>
        /// <returns>The total.</returns>
        public virtual byte GetTotal()
        {
			if (!Modifiers.Any())
				return 0;
            return Convert.ToByte(Modifiers.Cast<int>().Sum());
        }
    }
}