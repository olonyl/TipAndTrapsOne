using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Demos
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Example()
        {
            const string name = "Sarah";
            const int age = 42;

            WriteToDebug(name);
            WriteToDebug(age);
        }

        void WriteToDebug<T>(T obj)
        {
            Trace.WriteLine(obj);
        }

        void WriteToDebug(string obj)
        {
            Trace.WriteLine(obj);
        }
    }
}
