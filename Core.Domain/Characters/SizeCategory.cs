namespace Core.Domain.Characters
{
    /// <summary>
    /// An approximation for the magnitude of physical space a character occupies.
    /// </summary>
    public enum SizeCategory
    {
        /// <summary>
        /// The size of a normal human child.
        /// For bipedal creatures, usually 2ft - 4ft tall.
        /// </summary>
        Small  = -1,

        /// <summary>
        /// The size of a normal human adult.
        /// For bipedal creatures, usually 4ft - 8ft tall.
        /// </summary>
        Medium =  0,

        /// <summary>
        /// Larger than normal human adults.
        /// For bipedal creatures, usually 8ft - 16ft tall.
        /// </summary>
        Large  =  1,
    }
}