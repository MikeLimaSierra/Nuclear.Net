using System;
using System.IO;

using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;

namespace Nuclear.Assemblies.Factory {

    internal class DefaultResolverFactory : IDefaultResolverFactory {

        #region fields

        private static readonly ICreator<IDefaultResolver> _resolverCreator = Creation.Factory.Instance.Creator.Create<IDefaultResolver>(() => new DefaultResolver());

        private static readonly ICreator<IDefaultResolverData, FileInfo> _dataCreator = Creation.Factory.Instance.Creator.Create<IDefaultResolverData, FileInfo>((file) => new DefaultResolverData(file));

        #endregion

        #region methods

        public void Create(out IDefaultResolver obj) => _resolverCreator.Create(out obj);

        public Boolean TryCreate(out IDefaultResolver obj) => _resolverCreator.TryCreate(out obj);

        public Boolean TryCreate(out IDefaultResolver obj, out Exception ex) => _resolverCreator.TryCreate(out obj, out ex);

        public void Create(out IDefaultResolverData obj, FileInfo file) => _dataCreator.Create(out obj, file);

        public Boolean TryCreate(out IDefaultResolverData obj, FileInfo in1) => _dataCreator.TryCreate(out obj, in1);

        public Boolean TryCreate(out IDefaultResolverData obj, FileInfo in1, out Exception ex) => _dataCreator.TryCreate(out obj, in1, out ex);

        #endregion

    }

}
