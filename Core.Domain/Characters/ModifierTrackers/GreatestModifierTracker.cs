using System;
using System.Linq;
using System.Collections.Generic;


namespace Core.Domain.Characters.ModifierTrackers
{
	/// <summary>
	/// Stores the state of a modifier which aggregates by returning the maximum.
	/// </summary>
	internal abstract class GreatestModifierTracker : IModifierTracker
	{
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="T:Core.Domain.Characters.BonusTrackers.StackingModifierTracker"/> class.
		/// </summary>
		protected GreatestModifierTracker()
		{
			// Intentionally blank
		}


        /// <summary>
        /// A mutable collection of modifier data which is used in calculations by this class.
        /// </summary>
        /// <value>The modifiers.</value>
        protected virtual IList<Func<byte>> Modifiers { get; } = new List<Func<byte>>();


		/// <summary>
		/// Adds a dynamic modifier.
		/// </summary>
		/// <param name="calculation">The calculation which determines a modifier.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
		public virtual void Add(Func<byte> calculation)
        {
            if (null == calculation)
                throw new ArgumentNullException(nameof(calculation), "Cannot be null.");
            this.Modifiers.Add(calculation);
        }


		/// <summary>
		/// Returns the total modifier.
		/// </summary>
		/// <returns>The total.</returns>
		public virtual byte GetTotal()
		{
            Func<byte> seedFunction = () => 0;
            return this.Modifiers
                       .Aggregate(seedFunction, (Func<byte> calc1, Func<byte> calc2) =>
                       {
                           var result1 = calc1();
                           var result2 = calc2();
                           return () => (result1 > result2) ? result1 : result2;
                       })
                       (); // Calls the resultant function
		}
	}
}