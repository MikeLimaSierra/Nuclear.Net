using Nuclear.Creation;

namespace Nuclear.Assemblies.Factories {

    /// <summary>
    /// Extends the functionality of <see cref="IFactory"/>.
    /// </summary>
    public static class IFactoryExtensions {

        /// <summary>
        /// Returns a new instance of type <see cref="IDefaultResolverFactory"/>.
        /// </summary>
        /// <param name="this">The extended <see cref="IFactory"/> instance.</param>
        /// <returns>A new instance of type <see cref="IDefaultResolverFactory"/>.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static IDefaultResolverFactory Default(this IFactory @this) => new DefaultResolverFactory();
#pragma warning restore IDE0060 // Remove unused parameter

        /// <summary>
        /// Returns a new instance of type <see cref="INugetResolverFactory"/>.
        /// </summary>
        /// <param name="this">The extended <see cref="IFactory"/> instance.</param>
        /// <returns>A new instance of type <see cref="INugetResolverFactory"/>.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static INugetResolverFactory Nuget(this IFactory @this) => new NugetResolverFactory();
#pragma warning restore IDE0060 // Remove unused parameter

    }

}
