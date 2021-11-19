using System;
using System.Collections.Generic;
using System.IO;

using Nuclear.Assemblies.ResolverData;
using Nuclear.Assemblies.ResolverData.Internal;
using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Internal;
using Nuclear.Creation;

namespace Nuclear.Assemblies.Factories.Internal {

    internal class NugetResolverFactory : INugetResolverFactory {

        #region fields

        private static readonly ICreator<INugetResolver, MatchingStrategies> _resolverCreator = Factory.Instance.Creator.Create<INugetResolver, MatchingStrategies>((in1) => new NugetResolver(in1));

        private static readonly ICreator<INugetResolver, MatchingStrategies, IEnumerable<DirectoryInfo>> _resolverWithCacheCreator
            = Factory.Instance.Creator.Create<INugetResolver, MatchingStrategies, IEnumerable<DirectoryInfo>>((in1, in2) => new NugetResolver(in1, in2));

        private static readonly ICreator<INugetResolverData, FileInfo> _dataCreator = Factory.Instance.Creator.Create<INugetResolverData, FileInfo>((file) => new NugetResolverData(file));

        #endregion

        #region methods

        public void Create(out INugetResolver obj, MatchingStrategies in1) => _resolverCreator.Create(out obj, in1);

        public Boolean TryCreate(out INugetResolver obj, MatchingStrategies in1) => _resolverCreator.TryCreate(out obj, in1);

        public Boolean TryCreate(out INugetResolver obj, MatchingStrategies in1, out Exception ex) => _resolverCreator.TryCreate(out obj, in1, out ex);

        public void Create(out INugetResolver obj, MatchingStrategies in1, IEnumerable<DirectoryInfo> in2) => _resolverWithCacheCreator.Create(out obj, in1, in2);

        public Boolean TryCreate(out INugetResolver obj, MatchingStrategies in1, IEnumerable<DirectoryInfo> in2) => _resolverWithCacheCreator.TryCreate(out obj, in1, in2);

        public Boolean TryCreate(out INugetResolver obj, MatchingStrategies in1, IEnumerable<DirectoryInfo> in2, out Exception ex) => _resolverWithCacheCreator.TryCreate(out obj, in1, in2, out ex);

        public void Create(out INugetResolverData obj, FileInfo in1) => _dataCreator.Create(out obj, in1);

        public Boolean TryCreate(out INugetResolverData obj, FileInfo in1) => _dataCreator.TryCreate(out obj, in1);

        public Boolean TryCreate(out INugetResolverData obj, FileInfo in1, out Exception ex) => _dataCreator.TryCreate(out obj, in1, out ex);

        #endregion

    }

}
