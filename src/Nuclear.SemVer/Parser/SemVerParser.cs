using System;

using Nuclear.Exceptions;

namespace Nuclear.SemVer.Parser {
    internal class SemVerParser : ISemVerParser {

        public void Create(out SemanticVersion obj, String in1) => obj = SemanticVersion.Parse(in1);

        public Boolean TryCreate(out SemanticVersion obj, String in1) {
            obj = default;

            Try.Do(() => SemanticVersion.Parse(in1), out obj, out Exception _);

            return obj != null;
        }

        public Boolean TryCreate(out SemanticVersion obj, String in1, out Exception ex) {
            obj = default;

            Try.Do(() => SemanticVersion.Parse(in1), out obj, out ex);

            return obj != null;
        }

    }
}
