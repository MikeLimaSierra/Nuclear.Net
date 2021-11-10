using System;
using System.Collections.Generic;
using System.IO;

using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;

namespace Nuclear.Assemblies.Factories {

    internal class NugetResolverFactory : INugetResolverFactory {

        #region fields

        private static readonly ICreator<INugetResolver> _resolverCreator = Factory.Instance.Creator.Create<INugetResolver>(() => new NugetResolver());

        private static readonly ICreator<INugetResolver, IEnumerable<DirectoryInfo>> _resolverWithCacheCreator
            = Factory.Instance.Creator.Create<INugetResolver, IEnumerable<DirectoryInfo>>((in1) => new NugetResolver(in1));

        private static readonly ICreator<INugetResolverData, FileInfo> _dataCreator = Factory.Instance.Creator.Create<INugetResolverData, FileInfo>((file) => new NugetResolverData(file));

        #endregion

        #region methods

        public void Create(out INugetResolver obj) => _resolverCreator.Create(out obj);

        public Boolean TryCreate(out INugetResolver obj) => _resolverCreator.TryCreate(out obj);

        public Boolean TryCreate(out INugetResolver obj, out Exception ex) => _resolverCreator.TryCreate(out obj, out ex);

        public void Create(out INugetResolver obj, IEnumerable<DirectoryInfo> in1) => _resolverWithCacheCreator.Create(out obj, in1);

        public Boolean TryCreate(out INugetResolver obj, IEnumerable<DirectoryInfo> in1) => _resolverWithCacheCreator.TryCreate(out obj, in1);

        public Boolean TryCreate(out INugetResolver obj, IEnumerable<DirectoryInfo> in1, out Exception ex) => _resolverWithCacheCreator.TryCreate(out obj, in1, out ex);

        public void Create(out INugetResolverData obj, FileInfo in1) => _dataCreator.Create(out obj, in1);

        public Boolean TryCreate(out INugetResolverData obj, FileInfo in1) => _dataCreator.TryCreate(out obj, in1);

        public Boolean TryCreate(out INugetResolverData obj, FileInfo in1, out Exception ex) => _dataCreator.TryCreate(out obj, in1, out ex);

        #endregion

    }

}
