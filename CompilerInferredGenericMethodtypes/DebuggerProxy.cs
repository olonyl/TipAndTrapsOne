using CompilerInferredGenericMethodtypes.DemoSupportCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class DebuggerProxy
    {
        [TestMethod]
        public void Example()
        {
            var p = new Person("Sarah");

            p.Age = 33;

            p.FavouriteColors.Add(2, "Red");
            p.FavouriteColors.Add(1, "Orange");
            p.FavouriteColors.Add(3, "Pink");
        }
    }
}
