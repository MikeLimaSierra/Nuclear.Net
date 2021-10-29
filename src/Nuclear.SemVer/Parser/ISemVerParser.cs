using System;

using Nuclear.Creation;

namespace Nuclear.SemVer.Parser {

    /// <summary>
    /// Defines a parser to create instances of <see cref="SemanticVersion"/> from a <see cref="String"/>.
    /// </summary>
    public interface ISemVerParser : ICreator<SemanticVersion, String> { }

}
