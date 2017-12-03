using System;


namespace Core.Domain
{
    internal struct NameFragment : INameFragment, IEquatable<NameFragment>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.NameFragment"/> struct.
        /// </summary>
        /// <param name="text">The hyperlink text.</param>
        /// <param name="webAddress">The hyperlink URL. Must be a HHTP or HTTPS address.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when webAddress argument is not well-formed.</exception>
        internal NameFragment(string text, string webAddress)
        {
            this.Text = text ?? throw new ArgumentNullException(nameof(text), "Argument cannot be null.");
            if (null == webAddress) throw new ArgumentNullException(nameof(webAddress), "Argument cannot be null.");
            if (!Uri.TryCreate(webAddress, UriKind.Absolute, out Uri url)
                || (url.Scheme != "https"
                && url.Scheme != "http"))
                throw new ArgumentException($"{ nameof(webAddress) } argument is not a well-formed Url.");
            this.WebAddress = webAddress;
        }
        #endregion

        #region Properties
        public string Text { get; }

        public string WebAddress { get; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{ this.Text } ({ this.WebAddress })";
        }


        public override int GetHashCode()
        {
            return this.Text.GetHashCode() * 0x00010000 + this.WebAddress.GetHashCode();
        }


        public override bool Equals(object obj)
        {
            return obj is NameFragment && this.Equals((NameFragment)obj);
        }


        public bool Equals(NameFragment other)
        {
            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (this.Text == other.Text) && (this.WebAddress == other.WebAddress);
        }

        public static bool operator ==(NameFragment lhs, NameFragment rhs)
        {
            return lhs.Equals(rhs);
        }


        public static bool operator !=(NameFragment lhs, NameFragment rhs)
        {
            return !lhs.Equals(rhs);
        }
        #endregion
    }
}