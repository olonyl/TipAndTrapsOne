using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class DebuggerStepThrough
    {
        [TestMethod]
        public void Example()
        {
            var t = new Thing();

            t.Method1();

            var n = t.Name;

            t.Name = "Sarah";
        }
    }

    internal class Thing
    {
        private string _name;

        public Thing()
        {
        }

        public string Name
        {
            [System.Diagnostics.DebuggerStepThrough]
            get => _name;
            set { _name = value; }
        }

        [System.Diagnostics.DebuggerStepThrough]
        internal void Method1()
        {
            Method2();
        }

        void Method2()
        {

        }
    }
}
