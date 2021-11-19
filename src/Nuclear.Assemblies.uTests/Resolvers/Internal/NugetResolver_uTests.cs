using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.ResolverData;
using Nuclear.Assemblies.Runtimes;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Internal {
    class NugetResolver_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.IsSubClass<NugetResolver, AssemblyResolver<INugetResolverData>>();
            Test.If.Type.Implements<NugetResolver, INugetResolver>();

        }

        #region GetAssemblyCandidates

        [TestMethod]
        [TestData(nameof(GetAssemblyCandidates_Throws_Data))]
        void GetAssemblyCandidates_Throws((AssemblyName assemblyName, IEnumerable<DirectoryInfo> cacheDirs, RuntimeInfo current) input, String paramName) {

            Test.If.Action.ThrowsException(() => NugetResolver.GetAssemblyCandidates(input.assemblyName, input.cacheDirs, input.current), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, paramName);

        }

        IEnumerable<Object[]> GetAssemblyCandidates_Throws_Data() {
            return new List<Object[]>() {
                new Object[] { ((AssemblyName) null, (IEnumerable<DirectoryInfo>) null, (RuntimeInfo) null), "assemblyName" },
                new Object[] { (typeof(NugetResolver).Assembly.GetName(), (IEnumerable<DirectoryInfo>) null, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0))), "cacheDirs" },
                new Object[] { (typeof(NugetResolver).Assembly.GetName(), Enumerable.Empty<DirectoryInfo>(), (RuntimeInfo) null), "current" },
            };
        }

        #endregion

        #region TryGetPackage

        [TestMethod]
        [TestData(nameof(TryGetPackage_Throws_Data))]
        void TryGetPackage_Throws<TException>((String name, DirectoryInfo cache) input, String paramName)
            where TException : ArgumentException {

            Test.If.Action.ThrowsException(() => NugetResolver.TryGetPackage(input.name, input.cache, out _), out TException ex);

            Test.If.Value.IsEqual(ex.ParamName, paramName);

        }

        IEnumerable<Object[]> TryGetPackage_Throws_Data() {
            return new List<Object[]>() {
                new Object[] { typeof(ArgumentNullException), ((String) null, (DirectoryInfo) null), "name" },
                new Object[] { typeof(ArgumentException), ("", (DirectoryInfo) null), "name" },
                new Object[] { typeof(ArgumentException), (" ", (DirectoryInfo) null), "name" },
                new Object[] { typeof(ArgumentException), ("some.assembly", (DirectoryInfo) null), "cache" },
            };
        }

        #endregion

    }
}
