using System;

using Nuclear.Exceptions;

namespace Nuclear.SemVer.Factories {
    internal class SemVerFactory : ISemVerFactory {

        #region methods

        public void Create(out SemanticVersion obj, String in1) => obj = SemanticVersion.Parse(in1);

        public Boolean TryCreate(out SemanticVersion obj, String in1) => SemanticVersion.TryParse(in1, out obj);

        public Boolean TryCreate(out SemanticVersion obj, String in1, out Exception ex) => Try.Do(() => SemanticVersion.Parse(in1), out obj, out ex);

        #endregion

    }
}
