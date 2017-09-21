using System;


namespace Core.Domain.Characters.Feats
{
    public abstract class Feat
    {
        #region Backing variables
        private readonly string _name;
        private readonly Uri _uri;
        #endregion


        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Feats.Feat"/> class.
        /// </summary>
        /// <param name="name">The name of the feat.</param>
        /// <param name="webAddress">The URL of the feat.  Must be http or https.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when webAddress is not a well-formed http or https url.</exception>
        protected Feat(string name, string webAddress)
        {
            _name = name ?? throw new ArgumentNullException();
            if (null == webAddress)
                throw new ArgumentNullException($"{ nameof(webAddress) } argument cannot be null.");
            if (!Uri.TryCreate(webAddress, UriKind.Absolute, out _uri)
                || (_uri.Scheme != "https"
                    && _uri.Scheme != "http"))
                throw new ArgumentException($"{ nameof(webAddress) } argument is not a well-formed Url.");
        }
        #endregion


        #region Properties
        /// <summary>
        /// Returns the name of this feat.
        /// </summary>
        public virtual string Name => _name;


        /// <summary>
        /// Returns the URL of this feat.
        /// </summary>
        public virtual Uri Source => _uri;
        #endregion


        #region Methods
        /// <summary>
        /// Controls what happens when a Character trains this feat.
        /// </summary>
        /// <remarks>
        /// Override this behavior to control what happens when a character trains this feat.
        /// </remarks>
        /// <param name="character">The character which is being trained in this feat.</param>
        internal virtual void Train(Character character)
        {
            // Intentionally blank
        }
        #endregion
    }
}