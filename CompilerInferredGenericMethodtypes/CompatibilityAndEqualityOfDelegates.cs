using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class CompatibilityAndEqualityOfDelegates
    {
        private delegate void ADelgateWithAnInt(int i);
        private delegate void AnotherDelgateWithAnInt(int i);

        void WriteToDebug(int percent)
        {

        }

        void WriteToDebugWithMessage(int percent)
        {

        }

        [TestMethod]
        public void CompatibilityOfDelegateTypes()
        {
            ADelgateWithAnInt a = WriteToDebug;
            AnotherDelgateWithAnInt b;

            //This will not compile
            //b = a;

            //nor this
            //b = (AnotherDelgateWithAnInt)a;

            b = new AnotherDelgateWithAnInt(a);
        }

        [TestMethod]
        public void EqualityOfDelegateInstances()
        {
            ADelgateWithAnInt a = WriteToDebug;
            ADelgateWithAnInt b = WriteToDebug;
            ADelgateWithAnInt c = WriteToDebugWithMessage;

            var instanceAEqualToB = a == b;

            var instanceAEqualToC = a == c;
        }
    }
}
