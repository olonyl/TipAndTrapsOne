using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipAndTrapsOne._01Debugger
{
    [TestClass]
    public class PartialTypeExample
    {
        [TestMethod]
        public void Example()
        {
            var a = new APartialType();

            a.SomeMethod();
            a.SomeOtherMethod();

        }
    }
    partial class APartialType
    {
        internal void SomeOtherMethod() { }

        partial void APartialMethod()
        {

        }
    }

    partial class APartialType
    {
        public void SomeMethod()
        {
            APartialMethod();
        }
        partial void APartialMethod();
    }

}
