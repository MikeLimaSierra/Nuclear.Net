using System;
using System.ComponentModel;

namespace Nuclear.Exceptions.ExceptionSuites.Base {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ExceptionSuite {

        #region methods

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Boolean Equals(Object obj) => throw new NotImplementedException("This method is currently out of order.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Int32 GetHashCode() => throw new NotImplementedException("This method is currently out of order.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override String ToString() => throw new NotImplementedException("This method is currently out of order.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() => throw new NotImplementedException("This method is currently out of order.");

        #endregion

    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
