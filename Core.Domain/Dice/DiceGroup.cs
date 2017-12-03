using System;


namespace Core.Domain.Dice
{
    // Some code adapted from
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type

    /// <summary>
    /// Represents a group of dice, such as 4d8.
    /// </summary>
    public struct DiceGroup : IEquatable<DiceGroup>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Dice.DiceGroup"/> struct.
        /// </summary>
        /// <param name="quantity">The quantity of dice.</param>
        /// <param name="quality">The quality of dice.</param>
        internal DiceGroup(ushort quantity, byte quality)
        {
            this.Quantity = quantity;
            this.Quality = quality;
        }
        #endregion

        #region Properties
        /// <summary>
        /// The quantity of dice.
        /// </summary>
        public ushort Quantity { get; }

        /// <summary>
        /// The quality of dice.
        /// </summary>
        /// <value>The quality.</value>
        public byte Quality { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Core.Domain.Dice.DiceGroup"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Core.Domain.Dice.DiceGroup"/>.</returns>
        public override string ToString()
        {
            return $"{ this.Quantity }d{ this.Quality }";
        }


        /// <summary>
        /// Serves as a hash function for a <see cref="T:Core.Domain.Dice.DiceGroup"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return this.Quantity * 0x00010000 + this.Quality;
        }


        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:Core.Domain.Dice.DiceGroup"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:Core.Domain.Dice.DiceGroup"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="T:Core.Domain.Dice.DiceGroup"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return obj is DiceGroup && this.Equals((DiceGroup)obj);
        }


        /// <summary>
        /// Determines whether the specified <see cref="Core.Domain.Dice.DiceGroup"/> is equal to the current <see cref="T:Core.Domain.Dice.DiceGroup"/>.
        /// </summary>
        /// <param name="other">The <see cref="Core.Domain.Dice.DiceGroup"/> to compare with the current <see cref="T:Core.Domain.Dice.DiceGroup"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Core.Domain.Dice.DiceGroup"/> is equal to the current
        /// <see cref="T:Core.Domain.Dice.DiceGroup"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(DiceGroup other)
        {
            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (this.Quality == other.Quality) && (this.Quantity == other.Quantity);
        }


        /// <summary>
        /// Determines whether a specified instance of <see cref="Core.Domain.Dice.DiceGroup"/> is equal to another
        /// specified <see cref="Core.Domain.Dice.DiceGroup"/>.
        /// </summary>
        /// <param name="lhs">The first <see cref="Core.Domain.Dice.DiceGroup"/> to compare.</param>
        /// <param name="rhs">The second <see cref="Core.Domain.Dice.DiceGroup"/> to compare.</param>
        /// <returns><c>true</c> if <c>lhs</c> and <c>rhs</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(DiceGroup lhs, DiceGroup rhs)
        {
            return lhs.Equals(rhs);
        }


        /// <summary>
        /// Determines whether a specified instance of <see cref="Core.Domain.Dice.DiceGroup"/> is not equal to another
        /// specified <see cref="Core.Domain.Dice.DiceGroup"/>.
        /// </summary>
        /// <param name="lhs">The first <see cref="Core.Domain.Dice.DiceGroup"/> to compare.</param>
        /// <param name="rhs">The second <see cref="Core.Domain.Dice.DiceGroup"/> to compare.</param>
        /// <returns><c>true</c> if <c>lhs</c> and <c>rhs</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(DiceGroup lhs, DiceGroup rhs)
        {
            return !lhs.Equals(rhs);
        }


        /// <summary>
        /// Adds a <see cref="Core.Domain.Dice.DiceGroup"/> to a <see cref="Core.Domain.Dice.DiceGroup"/>, yielding a
        /// new <see cref="T:Core.Domain.Dice.DiceGroup"/>.
        /// </summary>
        /// <param name="lhs">The first <see cref="Core.Domain.Dice.DiceGroup"/> to add.</param>
        /// <param name="rhs">The second <see cref="Core.Domain.Dice.DiceGroup"/> to add.</param>
        /// <returns>The <see cref="T:Core.Domain.Dice.DiceGroup"/> that is the sum of the values of <c>lhs</c> and <c>rhs</c>.</returns>
        public static DiceGroup operator +(DiceGroup lhs, DiceGroup rhs)
        {
            if (lhs.Quality != rhs.Quality)
                throw new InvalidOperationException("Unable to add DiceGroups of two different qualities.");
            ushort totalDice = Convert.ToUInt16(lhs.Quantity + rhs.Quantity);
            return new DiceGroup(totalDice, lhs.Quality);
        }


        /// <summary>
        /// Roll this DiceGroup.
        /// </summary>
        /// <returns>The sum of the results of the dice.</returns>
        /// <param name="random">The RNG.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public ushort Roll(Random random)
        {
            if (null == random)
                throw new ArgumentNullException(nameof(random), "Argument cannot be null.");
            int maxQuality = this.Quality + 1;
            int runningTotal = 0;
            for (int i = 0; i < this.Quantity; i++)
            {
                runningTotal += random.Next(1, maxQuality);
            }
            return Convert.ToUInt16(runningTotal);
        }
        #endregion
    }
}