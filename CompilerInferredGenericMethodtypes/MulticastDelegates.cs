using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class MulticastDelegates
    {
        private delegate void ProgressChangeNotifier(int percent);

        void WriteToDebug(int percent)
        {
            Trace.WriteLine(percent);
        }

        void WriteToDebugWithMessage(int percent)
        {
            Trace.WriteLine("Progress now at: " + percent);
        }

        [TestMethod]
        public void MultiCastExample()
        {
            var progressDelegate = new ProgressChangeNotifier(WriteToDebug);
            Trace.WriteLine("Invoking delegate with a single target method assigned");
            progressDelegate(50);

            progressDelegate += WriteToDebugWithMessage;
            Trace.WriteLine("Invoking delegate with a two target method assigned");
            progressDelegate(50);

            progressDelegate -= WriteToDebug;
            Trace.WriteLine("Invoking delegate with first target method removed");
            progressDelegate(50);

            progressDelegate -= WriteToDebug;
        }

        private delegate int MathOperation(int a, int b);

        private int Add(int a, int b)
        {
            Trace.WriteLine("Add called");
            return a + b;
        }

        private int Multiply(int a, int b)
        {
            Trace.WriteLine("Multiply called");
            return a * b;
        }

        [TestMethod]
        public void MulticastReturnValues()
        {
            var mathDelegate = new MathOperation(Add);

            mathDelegate += Multiply;

            var result = mathDelegate(10, 10);
        }
    }
}
