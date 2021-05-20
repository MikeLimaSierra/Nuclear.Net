using System.IO;

using Nuclear.Exceptions;

namespace Nuclear.Assemblies.Resolvers.Data {

    internal class DefaultResolverData : IDefaultResolverData {

        #region properties

        public FileInfo File { get; }

        #endregion

        #region ctors

        internal DefaultResolverData(FileInfo file) {
            Throw.If.Object.IsNull(file, nameof(file));

            File = file;
        }

        #endregion

    }

}
