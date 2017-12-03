namespace Core.Domain.Characters.Feats
{
    /// <summary>
    /// A specialized training which grants an ICharacter new or improved abilities.
    /// </summary>
    public abstract class Feat
    {
        #region Backing variables
        private readonly INameFragment _name;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Feats.Feat"/> class.
        /// </summary>
        /// <param name="name">The name of the feat.</param>
        /// <param name="webAddress">The URL of the feat.  Must be http or https.</param>
        /// <exception cref="System.ArgumentException">Thrown when webAddress is not a well-formed http or https url.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        protected Feat(string name, string webAddress)
        {
            _name = new NameFragment(name, webAddress);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the name of this feat.
        /// </summary>
        public virtual INameFragment Name => _name;
        #endregion

        #region Methods
        /// <summary>
        /// Controls what happens when a Character trains this feat.
        /// </summary>
        /// <remarks>
        /// Override this behavior to control what happens when a character trains this feat.
        /// </remarks>
        /// <param name="character">The character which is being trained in this feat.</param>
        public abstract void ApplyTo(ICharacter character);
        #endregion
    }
}