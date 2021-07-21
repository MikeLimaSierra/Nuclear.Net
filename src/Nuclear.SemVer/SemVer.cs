using System;
using System.Collections.Generic;
using System.Text;

using Nuclear.Exceptions;

namespace Nuclear.SemVer {
    internal class SemVer : ISemVer {

        #region properties
        
        public Int32 Major { get; }
        
        public Int32 Minor { get; }
        
        public Int32 Patch { get; }
        
        public Boolean IsPreRelease { get; }
        
        public String PreRelease { get; }
        
        public Boolean HasMetaData { get; }
        
        public String MetaData { get; }

        #endregion

        #region ctors

        public SemVer(String input) {
            Throw.If.Object.IsNull(input, nameof(input));
            Throw.If.String.IsNullOrWhiteSpace(input, nameof(input));

            throw new NotImplementedException();
        }

        #endregion

        #region methods

        public override String ToString() => base.ToString();

        public override Int32 GetHashCode() => base.GetHashCode();

        public override Boolean Equals(Object obj) => base.Equals(obj);

        #endregion

        #region IEquatable

        public Boolean Equals(ISemVer other) => throw new NotImplementedException();

        #endregion

        #region IComparable

        public Int32 CompareTo(ISemVer other) => throw new NotImplementedException();

        #endregion

    }
}
