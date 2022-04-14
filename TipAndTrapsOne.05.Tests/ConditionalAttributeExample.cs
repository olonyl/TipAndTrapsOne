using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TipAndTrapsOne._05.Tests
{
    [TestClass]
    public class ConditionalAttributeExample
    {
        [TestMethod]
        public void UsingConditionalDirectives()
        {
            var logger = new FakeLogger();

#if LOG
            logger.WriteLogMessage("Message 1");
#endif

#if LOG
            logger.WriteLogMessage("Message 2");
#endif
        }

        [TestMethod]
        public void UsingConditionalAttribute()
        {
            var logger = new FakeLogger2();

            logger.WriteLogMessage("Message 1");
            logger.WriteLogMessage("Message 2");
        }
    }

    internal class FakeLogger
    {
        public void WriteLogMessage(string message)
        {
            Trace.WriteLine("DEBBUG MESSAGE: " + message);
        }
    }

    internal class FakeLogger2
    {
        [Conditional("LOG")]
        public void WriteLogMessage(string message)
        {
            Trace.WriteLine("DEBBUG MESSAGE: " + message);
        }
    }
}
