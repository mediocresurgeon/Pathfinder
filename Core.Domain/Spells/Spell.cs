using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly School _school;
        private readonly Subschool[] _subschools;
        private readonly Descriptor[] _descriptors;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Spell"/> class.
		/// </summary>
		/// <param name="name">The name of the spell.</param>
		/// <param name="webAddress">The URL of the spell.</param>
		/// <param name="school">The school of the spell.</param>
		/// <param name="level">The level of this spell.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when a parameter is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when url is not a valid web address.</exception>
		protected Spell(string name,
                        string webAddress,
                        School school,
                        byte level)
            : this(name, webAddress, school, level, null, null)
        {
            // Intentionally blank
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Spell"/> class.
		/// </summary>
		/// <param name="name">The name of the spell.</param>
		/// <param name="webAddress">The URL of the spell.</param>
		/// <param name="school">The school of the spell.</param>
		/// <param name="level">The level of this spell.</param>
		/// <param name="subschools">The subschools of this spell.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when a parameter is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when url is not a valid web address.</exception>
		protected Spell(string name,
                        string webAddress,
                        School school,
                        byte level,
                        IEnumerable<Subschool> subschools)
            : this(name, webAddress, school, level, subschools, null)
        {
            // Intentionally blank
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Spell"/> class.
		/// </summary>
		/// <param name="name">The name of the spell.</param>
		/// <param name="webAddress">The URL of the spell.</param>
		/// <param name="school">The school of the spell.</param>
		/// <param name="level">The level of this spell.</param>
		/// <param name="descriptors">The descriptors of this spell.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when a parameter is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when url is not a valid web address.</exception>
		protected Spell(string name,
                        string webAddress,
                        School school,
                        byte level,
                        IEnumerable<Descriptor> descriptors)
            : this(name, webAddress, school, level, null, descriptors)
        {
            // Intentionally blank
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Spell"/> class.
		/// </summary>
		/// <param name="name">The name of the spell.</param>
		/// <param name="webAddress">The URL of the spell.</param>
		/// <param name="school">The school of the spell.</param>
		/// <param name="level">The level of this spell.</param>
		/// <param name="subschools">The subschools of this spell.</param>
		/// <param name="descriptors">The descriptors of this spell.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when a parameter is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when url is not a valid web address.</exception>
		protected Spell(string name,
                        string webAddress,
                        School school,
                        byte level,
                        IEnumerable<Subschool> subschools,
                        IEnumerable<Descriptor> descriptors)
        {
            _name = name ?? throw new ArgumentNullException($"{ nameof(name) } argument cannot be null."); ;
            if (null == webAddress)
                throw new ArgumentNullException($"{ nameof(webAddress) } argument cannot be null.");
            if (!Uri.TryCreate(webAddress, UriKind.Absolute, out _uri)
                || (_uri.Scheme != "https"
                    && _uri.Scheme != "http"))
                throw new ArgumentException($"{ nameof(webAddress) } argument is not a well-formed Url.");
            _school = school;
            _level = level;
            _subschools = (subschools ?? Enumerable.Empty<Subschool>()).ToArray();
            _descriptors = (descriptors ?? Enumerable.Empty<Descriptor>()).ToArray();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Returns the web address of this Spell.
        /// </summary>
        /// <value>The source.</value>
        public Uri Source
        {
            get { return _uri; }
        }

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>The level.</value>
        public byte Level
        {
            get { return _level; }
        }

        /// <summary>
        /// Gets the descriptors.
        /// </summary>
        /// <value>The descriptors.</value>
        public IEnumerable<Descriptor> Descriptors
        {
            get { return _descriptors.ToArray(); } // Returns a copy, not the original array.
		}

        /// <summary>
        /// Gets the school.
        /// </summary>
        /// <value>The school.</value>
        public School School
        {
            get { return _school; }
        }

        /// <summary>
        /// Gets the subschools.
        /// </summary>
        /// <value>The subschools.</value>
        public IEnumerable<Subschool> Subschools
        {
            get { return _subschools.ToArray(); } // Returns a copy, not the original array.
        }
        #endregion
    }
}