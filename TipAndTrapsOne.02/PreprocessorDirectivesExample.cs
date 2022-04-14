using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TipAndTrapsOne._02
{
    [TestClass]
    public class PreprocessorDirectivesExample
    {
        [TestMethod]
        public void ContitionalExample1()
        {
            string s;
#if DEBUG
            s = "debug build";
#elif RELEASE
            s = "release build";
#else
            s = "some other build";
#endif

            Trace.WriteLine(s);
        }

        [TestMethod]
        public void ConditionalExample2()
        {
            WriteToDebugLogFile("Test");
        }
        public void WriteToDebugLogFile(string message)
        {
#if DEBUG
            //... debug write code
            Trace.WriteLine(message);
#endif
        }

        [TestMethod]
        public void WarningAndErrorsExample()
        {
#warning This is a random warning!
#if DEBUG && RELEASE
            //#error Cannot be both a debug and release build at the same time!!
#endif

        }
    }
}
