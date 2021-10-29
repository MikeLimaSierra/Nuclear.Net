
using Nuclear.Creation;

namespace Nuclear.SemVer.Parser {

    /// <summary>
    /// Defines an extension to <see cref="IParser"/>.
    /// </summary>
    public static class IParserExtensions {

        /// <summary>
        /// Returns a new instance of <see cref="ISemVerParser"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="ISemVerParser"/>.</returns>
        public static ISemVerParser SemVer(this IParser _) => new SemVerParser();

    }
}
