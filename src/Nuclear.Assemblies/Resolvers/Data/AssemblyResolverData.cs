using System;
using System.IO;
using System.Reflection;

using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Assemblies.Resolvers.Data {

    internal abstract class AssemblyResolverData : IAssemblyResolverData {

        #region properties

        public FileInfo File { get; }

        public AssemblyName Name { get; private set; }

        public Boolean IsValid { get; }

        #endregion

        #region ctors

        internal AssemblyResolverData(FileInfo file) {
            Throw.If.Object.IsNull(file, nameof(file), $"Parameter {nameof(file).Format()} must not be null.");
            Throw.If.Value.IsFalse(AssemblyHelper.TryGetAssemblyName(file, out AssemblyName name), nameof(file), $"Could not resolve the AssemblyName of file {file.Format()}.");

            File = file;
            Name = name;

            IsValid = Init();
        }

        #endregion

        #region methods

        protected abstract Boolean Init();

        #endregion

    }
}
