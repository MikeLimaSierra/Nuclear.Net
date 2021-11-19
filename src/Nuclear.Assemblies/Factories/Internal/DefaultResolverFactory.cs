using System;
using System.IO;

using Nuclear.Assemblies.ResolverData;
using Nuclear.Assemblies.ResolverData.Internal;
using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Internal;
using Nuclear.Creation;

namespace Nuclear.Assemblies.Factories.Internal {

    internal class DefaultResolverFactory : IDefaultResolverFactory {

        #region fields

        private static readonly ICreator<IDefaultResolver, MatchingStrategies, SearchOption> _resolverCreator = Factory.Instance.Creator.Create<IDefaultResolver, MatchingStrategies, SearchOption>((in1, in2) => new DefaultResolver(in1, in2));

        private static readonly ICreator<IDefaultResolverData, FileInfo> _dataCreator = Factory.Instance.Creator.Create<IDefaultResolverData, FileInfo>((in1) => new DefaultResolverData(in1));

        #endregion

        #region methods

        public void Create(out IDefaultResolver obj, MatchingStrategies in1, SearchOption in2) => _resolverCreator.Create(out obj, in1, in2);

        public Boolean TryCreate(out IDefaultResolver obj, MatchingStrategies in1, SearchOption in2) => _resolverCreator.TryCreate(out obj, in1, in2);

        public Boolean TryCreate(out IDefaultResolver obj, MatchingStrategies in1, SearchOption in2, out Exception ex) => _resolverCreator.TryCreate(out obj, in1, in2, out ex);

        public void Create(out IDefaultResolverData obj, FileInfo file) => _dataCreator.Create(out obj, file);

        public Boolean TryCreate(out IDefaultResolverData obj, FileInfo in1) => _dataCreator.TryCreate(out obj, in1);

        public Boolean TryCreate(out IDefaultResolverData obj, FileInfo in1, out Exception ex) => _dataCreator.TryCreate(out obj, in1, out ex);

        #endregion

    }

}
