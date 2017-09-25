using System;

namespace Core.Domain.Characters
{
    /// <summary>
    /// An approximation for the magnitude of physical space a character occupies.
    /// </summary>
    public enum SizeCategory
    {
        Small  = -1,
        Medium =  0,
        Large  =  1,
    }
}