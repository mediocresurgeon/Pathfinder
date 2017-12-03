namespace Core.Domain.Spells
{
    /// <summary>
    /// An arcane or divine spell.
    /// </summary>
    public abstract class Spell : ISpell
    {
        #region Backing variables
        private readonly byte _level;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Spells.Spell"/> class.
        /// </summary>
        /// <param name="name">The name of the spell.</param>
        /// <param name="webAddress">The URL of the spell.</param>
        /// <param name="spellLevel">The spell's level.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when url is not a valid web address.</exception>
        protected Spell(string name,
                        string webAddress,
                        byte   spellLevel)
        {
            this.Name = new NameFragment(name, webAddress);
            _level = spellLevel;
        }
        #endregion

        private INameFragment Name { get; }

        #region Virtual members
        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>The level.</value>
        public virtual byte Level => _level;


        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual INameFragment GetName() => this.Name;
        #endregion

        #region Abstract members
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Core.Domain.Spells.Spell"/> allows a saving throw.
        /// </summary>
        /// <value><c>true</c> if allows saving throw; otherwise, <c>false</c>.</value>
        public abstract bool AllowsSavingThrow { get; }


        /// <summary>
        /// Returns this spell's school of magic.
        /// </summary>
        public abstract School School { get; }


        /// <summary>
        /// Returns this spell's descriptors.
        /// </summary>
        public abstract Descriptor[] GetDescriptors();


        /// <summary>
        /// Returns this spell's subschools.
        /// </summary>
        public abstract Subschool[] GetSubschools();
        #endregion
    }
}