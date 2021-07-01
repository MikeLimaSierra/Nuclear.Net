using Nuclear.Creation;

namespace Nuclear.SemVer.Factories {

    /// <summary>
    /// Extends the functionality of <see cref="IFactory"/>.
    /// </summary>
    public static class IFactoryExtensions {

        /// <summary>
        /// Returns a new instance of type <see cref="ISemVerFactory"/>.
        /// </summary>
        /// <param name="this">The extended <see cref="IFactory"/> instance.</param>
        /// <returns>A new instance of type <see cref="ISemVerFactory"/>.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static ISemVerFactory SemVer(this IFactory @this) => new SemVerFactory();
#pragma warning restore IDE0060 // Remove unused parameter

    }

}
