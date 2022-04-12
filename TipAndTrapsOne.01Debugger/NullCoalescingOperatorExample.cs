using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipAndTrapsOne._01Debugger
{
    [TestClass]
    public class NullCoalescingOperatorExample
    {
        [TestMethod]
        public void ReferenceTypes()
        {
            var name = "sarah";
            var result = string.Empty;
            //Without using the null-coalescing operator:

            if (name == null)
            {
                result = "no name provided";
            }
            else
            {
                result = name;
            }

            //Using null-coalescing operator
            result = name ?? "no name provided";

            name = null;

            result = name ?? "no name provided";
        }

        [TestMethod]
        public void NullableTypes()
        {
            int? age = null;
            int result = age ?? 0;
        }

        [TestMethod]
        public void Chaining()
        {
            int? localDefaultAge = null;
            int globalDefaultAge = 99;

            int? age = null;

            int result = age ?? localDefaultAge ?? globalDefaultAge;
        }
    }
}
