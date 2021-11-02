
using System;

using Nuclear.Creation;

namespace Nuclear.SemVer.Parser {

    /// <summary>
    /// Defines an extension to <see cref="IParser"/>.
    /// </summary>
    public static class IParserExtensions {

        /// <summary>
        /// Returns a new instance of <see cref="ICreator{SemanticVersion, String}"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="ICreator{SemanticVersion, String}"/>.</returns>
        public static ICreator<SemanticVersion, String> SemVer(this IParser _) => Factory.Instance.Creator.Create((String in1) => SemanticVersion.Parse(in1));

    }
}
