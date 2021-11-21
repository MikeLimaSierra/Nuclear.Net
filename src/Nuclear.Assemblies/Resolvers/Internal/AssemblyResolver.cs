
using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Assemblies.Resolvers.Internal {

    internal abstract class AssemblyResolver : IAssemblyResolver {

        #region properties

        public MatchingStrategies AssemblyMatchingStrategy { get; }

        #endregion

        #region ctors

        internal AssemblyResolver(MatchingStrategies assemblyStrategy) {
            Throw.IfNot.Enum.IsDefined<MatchingStrategies>(assemblyStrategy, nameof(assemblyStrategy), $"Given strategy is not defined {assemblyStrategy.Format()}");
            Throw.If.Value.IsTrue(assemblyStrategy == MatchingStrategies.Unknown, nameof(assemblyStrategy), $"Strategy must not be {assemblyStrategy.Format()}");

            AssemblyMatchingStrategy = assemblyStrategy;
        }

        #endregion

    }

}
