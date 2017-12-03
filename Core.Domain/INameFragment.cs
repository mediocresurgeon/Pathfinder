namespace Core.Domain
{
    /// <summary>
    /// A subsection of a string matched with a URL.
    /// </summary>
    public interface INameFragment
    {
        /// <summary>
        /// The text to display.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// The URL associated with the text.
        /// </summary>
        string WebAddress { get; }
    }
}