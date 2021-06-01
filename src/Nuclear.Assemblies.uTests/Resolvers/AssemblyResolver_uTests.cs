using System;

using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class AssemblyResolver_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<AssemblyResolver<IDefaultResolverData>, IAssemblyResolver<IDefaultResolverData>>();

        }

        [TestMethod]
        void DefaultInstances() {

            IDefaultResolver instance1 = null;
            IDefaultResolver instance2 = null;

            Test.IfNot.Action.ThrowsException(() => instance1 = AssemblyResolver.Default, out Exception ex);
            Test.IfNot.Action.ThrowsException(() => instance2 = AssemblyResolver.Default, out ex);

            Test.IfNot.Reference.IsEqual(instance1, instance2);

        }

        [TestMethod]
        void NugetInstances() {

            INugetResolver instance1 = null;
            INugetResolver instance2 = null;

            Test.IfNot.Action.ThrowsException(() => instance1 = AssemblyResolver.Nuget, out Exception ex);
            Test.IfNot.Action.ThrowsException(() => instance2 = AssemblyResolver.Nuget, out ex);

            Test.IfNot.Reference.IsEqual(instance1, instance2);

        }

    }
}
