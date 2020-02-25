using System;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class DefaultResolver_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.IsSubClass<DefaultResolver, AssemblyResolver>();
            Test.If.Type.Implements<DefaultResolver, IDefaultResolver>();
            Test.If.Type.Implements<IDefaultResolver, IAssemblyResolver>();

            IDefaultResolver instance1 = null;
            IDefaultResolver instance2 = null;

            Test.IfNot.Action.ThrowsException(() => instance1 = DefaultResolver.Instance, out Exception ex);
            Test.IfNot.Action.ThrowsException(() => instance2 = DefaultResolver.Instance, out ex);

            Test.If.Reference.IsEqual(instance1, instance2);

        }

        [TestMethod]
        void ConstructorThrows() {

            IDefaultResolver instance = DefaultResolver.Instance;

            Test.If.Action.ThrowsException(() => instance = new DefaultResolver(), out AccessViolationException ex);

            Test.If.Value.IsEqual(ex.Message, "Constructor must not be called twice.");

        }

    }
}
