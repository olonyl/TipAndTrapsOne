extern alias APeople;
extern alias BPeople;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipAndTrapsOne._05.Tests.DemoSupportCode;
using NestedClass1 = TipAndTrapsOne._05.Tests.DemoSupportCode.Nested.Class1;

namespace TipAndTrapsOne._05.Tests
{
    [TestClass]
    public class NamespaceAliasignExample
    {
        [TestMethod]
        public void AliasingTypes()
        {
            var a = new Class1();
            var b = new NestedClass1(); //nested Class1

        }

        [TestMethod]
        public void Extern()
        {
            var a = new APeople.ConflictingNamespace.Person();
            var b = new BPeople.ConflictingNamespace.Person();
        }
    }
}
