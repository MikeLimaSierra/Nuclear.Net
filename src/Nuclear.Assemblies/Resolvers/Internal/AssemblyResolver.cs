
using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Assemblies.Resolvers.Internal {

    internal abstract class AssemblyResolver : IAssemblyResolver {

        #region properties

        public MatchingStrategies MatchingStrategy { get; }

        #endregion

        #region ctors

        internal AssemblyResolver(MatchingStrategies strategy) {
            Throw.IfNot.Enum.IsDefined<MatchingStrategies>(strategy, nameof(strategy), $"Given strategy is not defined {strategy.Format()}");
            Throw.If.Value.IsTrue(strategy == MatchingStrategies.Unknown, nameof(strategy), $"Strategy must not be {strategy.Format()}");

            MatchingStrategy = strategy;
        }

        #endregion

    }

}
