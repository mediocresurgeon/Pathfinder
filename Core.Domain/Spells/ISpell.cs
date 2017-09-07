using System;
using System.Collections.Generic;

namespace Core.Domain.Spells
{
    /// <summary>
    /// Represents an arcane or divine spell.
    /// </summary>
    public interface ISpell
    {
        /// <summary>
        /// The name of the ISpell.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The web address of the ISpell.
        /// </summary>
        Uri Source { get; }

        /// <summary>
        /// The level of the ISpell.
        /// </summary>
        byte Level { get; }

        /// <summary>
        /// The Descriptors of the ISpell.
        /// </summary>
        IEnumerable<Descriptor> Descriptors { get; }

        /// <summary>
        /// The School of the ISpell.
        /// </summary>
        School School { get; }

        /// <summary>
        /// The Subschools of the ISpell.
        /// </summary>
        IEnumerable<Subschool> Subschools { get; }
    }
}