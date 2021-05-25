using Nuclear.Assemblies.Factories;
using Nuclear.Creation;

namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// Static ease-of-use access class for <see cref="IDefaultResolver"/> and <see cref="INugetResolver"/>.
    /// </summary>
    public static class AssemblyResolver {

        #region static properties

        /// <summary>
        /// Gets an instance of the default resolver.
        /// </summary>
        public static IDefaultResolver Default {
            get {
                Factory.Instance.Default().Create(out IDefaultResolver obj);
                return obj;
            }
        }

        /// <summary>
        /// Gets an instance of the NuGet resolver.
        /// </summary>
        public static INugetResolver Nuget {
            get {
                Factory.Instance.Nuget().Create(out INugetResolver obj);
                return obj;
            }
        }

        #endregion

    }

}
