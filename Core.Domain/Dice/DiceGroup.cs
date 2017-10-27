using System;


namespace Core.Domain.Dice
{
    // Some code adapted from
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type

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
        public ushort Quantity { get; }

        public byte Quality { get; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{ this.Quantity }d{ this.Quality}";
        }


        public override int GetHashCode()
        {
            return this.Quantity * 0x00010000 + this.Quality;
        }


        public override bool Equals(object obj)
        {
            return obj is DiceGroup && this.Equals((DiceGroup)obj);
        }


        public bool Equals(DiceGroup other)
        {
            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (this.Quality == other.Quality) && (this.Quantity == other.Quantity);
        }


        public static bool operator ==(DiceGroup lhs, DiceGroup rhs)
        {
            return lhs.Equals(rhs);
        }


        public static bool operator !=(DiceGroup lhs, DiceGroup rhs)
        {
            return !lhs.Equals(rhs);
        }


        public static DiceGroup operator +(DiceGroup lhs, DiceGroup rhs)
        {
            if (lhs.Quality != rhs.Quality)
                throw new InvalidOperationException("Unable to add DiceGroups of two different qualities.");
            ushort totalDice = Convert.ToUInt16(lhs.Quantity + rhs.Quantity);
            return new DiceGroup(totalDice, lhs.Quality);
        }


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