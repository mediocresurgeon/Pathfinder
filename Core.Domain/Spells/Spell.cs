using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Core.Domain.Spells
{
    /// <summary>
    /// An arcane or divine spell.
    /// </summary>
    public abstract class Spell : ISpell
    {
        #region Backing variables
        private readonly Uri _uri;
        private readonly string _name;
        private readonly byte _level;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Spell"/> class.
        /// </summary>
        /// <param name="name">The name of the spell.</param>
        /// <param name="webAddress">The URL of the spell.</param>
        /// <param name="spellLevel">The spell's level.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when a parameter is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when url is not a valid web address.</exception>
        protected Spell(string name,
                        string webAddress,
                        byte   spellLevel)
        {
            _name = name ?? throw new ArgumentNullException($"{ nameof(name) } argument cannot be null.");
            if (null == webAddress)
                throw new ArgumentNullException($"{ nameof(webAddress) } argument cannot be null.");
            if (!Uri.TryCreate(webAddress, UriKind.Absolute, out _uri)
                || (_uri.Scheme != "https"
                    && _uri.Scheme != "http"))
                throw new ArgumentException($"{ nameof(webAddress) } argument is not a well-formed Url.");
            _level = spellLevel;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name => _name;


        /// <summary>
        /// Returns the web address of this Spell.
        /// </summary>
        /// <value>The source.</value>
        public virtual Uri Source => _uri;


        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>The level.</value>
        public virtual byte Level => _level;


        /// <summary>
        /// Gets the descriptors.
        /// </summary>
        /// <value>The descriptors.</value>
        public abstract Descriptor[] Descriptors { get; }


        /// <summary>
        /// Gets the school.
        /// </summary>
        /// <value>The school.</value>
        public abstract School School { get; }


        /// <summary>
        /// Gets the subschools.
        /// </summary>
        /// <value>The subschools.</value>
        public abstract Subschool[] Subschools { get; }


        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Core.Domain.Spells.Spell"/> allows a saving throw.
        /// </summary>
        /// <value><c>true</c> if it allows a saving throw; otherwise, <c>false</c>.</value>
        public abstract bool AllowsSavingThrow { get; }
        #endregion
    }
}